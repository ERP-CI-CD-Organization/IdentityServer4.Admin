using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;
using IdentityServer4.Admin.Entities;
using IdentityServer4.Admin.Infrastructure;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GrantTypes = IdentityServer4.Models.GrantTypes;

namespace IdentityServer4.Admin
{
    internal class SeedData
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly AdminDbContext _dbContext;
        private readonly bool _isDev;

        public SeedData(ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _dbContext = (AdminDbContext) serviceProvider.GetRequiredService<IDbContext>();
            _isDev = serviceProvider.GetRequiredService<IHostEnvironment>().IsDevelopment();
        }

        public void EnsureData()
        {
            if (!_dbContext.Branches.Any())
            {
                AddBranches();//先填充branch数据，因为user依赖branch
            }

            if (!_dbContext.Roles.Any())
            {
                AddRoles();//角色表没有角色 则添加角色
            }

            if (!_dbContext.Users.Any())
            {
                _logger.LogInformation("Seeding database...");

                //var role = new Role
                //{
                //    Id = Guid.NewGuid(),
                //    Name = AdminConstants.AdminName,
                //    Description = "超级管理员"
                //};
                //var identityResult = _serviceProvider.GetRequiredService<RoleManager<Role>>().CreateAsync(role).Result;

                //if (!identityResult.Succeeded)
                //{
                //    throw new IdentityServer4AdminException("Create super admin role failed");
                //}

               
                var userMgr = _serviceProvider.GetRequiredService<UserManager<User>>();
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "Administrator",
                    Email = "admin@ids4admin.com",
                    EmailConfirmed = true,
                    CreationTime = DateTime.Now
                };
                
                var password = _serviceProvider.GetRequiredService<IConfiguration>()["ADMIN_PASSWORD"];
                if (string.IsNullOrWhiteSpace(password))
                {
                    password = "1qazZAQ!";
                }

                var res = userMgr.CreateAsync(user, password).Result;
                if (!res.Succeeded)
                {
                    throw new IdentityServer4AdminException("Create super admin user failed");
                }
               
                
                //重复添加同样的角色，会报错 添加角色的时候用的是NormalizedName，但是验证和授权的时候是Name
                var addUserToRoles = userMgr.AddToRolesAsync(user, new List<string>(){ AdminConstants.AdminName ,"ERP"}).Result;
                
                if (!addUserToRoles.Succeeded)
                {
                    throw new IdentityServer4AdminException("Add super admin user to role failed");
                }



                Commit();

                _logger.LogInformation("Done seeding database");
            }
            //else
            //{
            //    if (_isDev)
            //    {
            //        var userMgr = _serviceProvider.GetRequiredService<UserManager<User>>();
            //        var admin = userMgr.FindByNameAsync(AdminConstants.AdminName).Result;
            //        if (admin != null)
            //        {
            //            userMgr.DeleteAsync(admin).GetAwaiter().GetResult();
            //        }

            //        var user = new User
            //        {
            //            Id = Guid.NewGuid(),
            //            UserName = AdminConstants.AdminName,
            //            Email = "admin@ids4admin.com",
            //            EmailConfirmed = true,
            //            CreationTime = DateTime.Now
            //        };

            //        var password = _serviceProvider.GetRequiredService<IConfiguration>()["ADMIN_PASSWORD"];
            //        if (string.IsNullOrWhiteSpace(password))
            //        {
            //            password = "1qazZAQ!";
            //        }

            //        var identityResult = userMgr.CreateAsync(user, password).Result;
            //        if (!identityResult.Succeeded)
            //        {
            //            throw new IdentityServer4AdminException("Create super admin user failed");
            //        }

            //        identityResult = userMgr.AddToRoleAsync(user, AdminConstants.AdminName).Result;
            //        if (!identityResult.Succeeded)
            //        {
            //            throw new IdentityServer4AdminException("Add super admin user to role failed");
            //        }

            //        Commit();
            //    }

            //    _logger.LogInformation("Ignore seed database...");
            //}

            var userMgr2 = _serviceProvider.GetRequiredService<UserManager<User>>();
            var testUserCount = 15;
            if (_dbContext.Users.Count() < testUserCount)
            {
                for (int i = 0; i < testUserCount; ++i)
                {
                    var user = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "testuser" + i,
                        Email = "testuser" + i + "@ids4admin.com",
                        EmailConfirmed = true,
                        CreationTime = DateTime.Now
                    };

                    var password = _serviceProvider.GetRequiredService<IConfiguration>()["ADMIN_PASSWORD"];
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        password = "1qazZAQ!";
                    }

                    userMgr2.CreateAsync(user, password).GetAwaiter().GetResult();
                }
            }

            AddIdentityResources();
            AddApiResources();
            AddClients();

            Commit();
        }

        private void Commit()
        {
            _dbContext.SaveChanges();
        }

        private void AddApiResources()
        {
            if (!_dbContext.ApiResources.Any())
            {
                _logger.LogInformation("ApiResources being populated");
                foreach (var resource in GetApiResources().ToList())
                {
                    _dbContext.ApiResources.Add(resource.ToEntity());
                }
            }
            else
            {
                _logger.LogInformation("ApiResources already populated");
            }
        }

        private void AddIdentityResources()
        {
            if (!_dbContext.IdentityResources.Any())
            {
                _logger.LogInformation("IdentityResources being populated");

                foreach (var resource in GetIdentityResources().ToList())
                {
                    var entity = resource.ToEntity();
                    _dbContext.IdentityResources.Add(entity);
                }
            }
            else
            {
                _logger.LogInformation("IdentityResources already populated");
            }

            Commit();
        }

        private void AddClients()
        {
            if (!_dbContext.Clients.Any())
            {
                _logger.LogInformation("Clients being populated");
                foreach (var client in GetClients().ToList())
                {
                    _dbContext.Clients.Add(client.ToEntity());
                }
            }
            else
            {
                _logger.LogInformation("Clients already populated");
            }
        }

        private void AddBranches()
        {
            if (!_dbContext.Branches.Any())
            {
                _logger.LogInformation("branches数据正在填充");
                foreach (var branch in GetBranches())
                {
                 _dbContext.Branches.Add(branch);

                }
            }
            else
            {
                _logger.LogInformation("branch数据已经被填充");
            }

            Commit();
        }

        private IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API"),
                new ApiResource("western-research-api", "western-research-api"),
                new ApiResource("ERP-API","ERP的API")
                {
                    ApiSecrets = {new Secret(){Type = IdentityServerConstants.SecretTypes.SharedSecret,Value = "ERP-API secret".Sha256()}},
                    //Scopes = {new Scope()
                    //{
                    //    Description = "Full access ERP-API",
                    //    DisplayName = "ERP-API Full Access",
                    //    Name = "ERP-API",
                    //    Emphasize = false,
                    //    Required = false,
                    //    ShowInDiscoveryDocument = false,
                    //    UserClaims = {"role","openid","branchId"}
                    //}}
                    
                },
            };
        }

        // scopes define the resources in your system
        private IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResource("role", "Your roles", new[] {"role"})
            };
        }

        private IEnumerable<Branch> GetBranches()
        {
            return  new List<Branch>()
            {
                new Branch()
                {
                     Id = 1000,
                     Name = "微软亚太研究中心"
                },
                new Branch()
                {
                    Id = 0,
                    Name = "系统初始化"
                },
            };
        }

        private void AddRoles()
        {
            foreach (var singleRole in BaseRoleList.RoleList)
            {
                var res = _serviceProvider.GetRequiredService<RoleManager<Role>>().CreateAsync(singleRole);

                if (!res.Result.Succeeded)
                {
                    throw new Exception($"{singleRole.Name}角色创建失败");
                }
            }
        }

        // clients want to access resources (aka scopes)
        private IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {"api1"}
                },
                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api1"}
                },
                // OpenID Connect hybrid flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = {"http://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:5002/signout-callback-oidc"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },

                    AllowOfflineAccess = true
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = {"http://localhost:5003/callback.html"},
                    PostLogoutRedirectUris = {"http://localhost:5003/index.html"},
                    AllowedCorsOrigins = {"http://localhost:5003"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                },
                // for dev
                new Client
                {
                    ClientId = "ERP-Angular-WebApp",
                    ClientName = "ERP前端",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris = { "http://localhost:4200/signin-oidc", "http://localhost:4200/redirect-silentrenew"},
                    PostLogoutRedirectUris = {"http://localhost:4200/home"},
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 60 * 5,
                    RequireConsent = false,
                    AllowRememberConsent = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "role",
                        "ERP-API",
                        "branchId"
                    }
                },
                // for staging
                new Client
                {
                    ClientId = "ERP-webapp",
                    ClientName = "ERP-webapp",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris = { "http://www.erp.com:30080/signin-oidc", "http://www.erp.com:30080/redirect-silentrenew"},
                    PostLogoutRedirectUris = {"http://www.erp.com:30080/home"},
                    AllowedCorsOrigins = {"http://www.erp.com:30080"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 60 * 5,
                    RequireConsent = false,
                    AllowRememberConsent = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "role",
                        "ERP-API",
                        "branchId"
                    }
                },
                new Client
                {
                    ClientId = "western-research",
                    ClientName = "western-research",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = {"http://localhost:6568"},
                    RedirectUris = {"http://localhost:6568/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:6568/signout-callback-oidc"},
                    RequireConsent = true,
                    AllowOfflineAccess = false,
                    AccessTokenLifetime = 3600 * 24 * 7,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "role",
                        "western-research-api"
                    }
                }
            };
        }

    }
}