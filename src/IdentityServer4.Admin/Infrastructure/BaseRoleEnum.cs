using System;
using System.Collections.Generic;
using IdentityServer4.Admin.Entities;

namespace IdentityServer4.Admin.Infrastructure
{
    public static class BaseRoleList
    {
        public static readonly List<Role> RoleList = new List<Role>
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "超级管理员",
                NormalizedName = "Administrator",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户",
                NormalizedName = "ERP",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户",
                NormalizedName = "Mall",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的Branch管理员",
                NormalizedName = "系统管理员",
                BranchId = 0
            },

            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的出纳",
                NormalizedName = "出纳",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的会计",
                NormalizedName = "会计",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的应收会计",
                NormalizedName = "应收会计",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的应付会计",
                NormalizedName = "应付会计",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的财务经理",
                NormalizedName = "财务经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的采购员",
                NormalizedName = "采购员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的采购经理",
                NormalizedName = "采购经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的销售员",
                NormalizedName = "销售员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的直发下单员",
                NormalizedName = "直发下单员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的配货员",
                NormalizedName = "配货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的收货员",
                NormalizedName = "收货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的出库员",
                NormalizedName = "出库员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的仓库经理",
                NormalizedName = "仓库经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的分单员",
                NormalizedName = "分单员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的仓管员",
                NormalizedName = "仓管员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的直发归档员",
                NormalizedName = "直发归档员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的订单审核员",
                NormalizedName = "订单审核员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的分销对账收款员",
                NormalizedName = "分销对账收款员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的分销管理员",
                NormalizedName = "分销管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的分销对账付款员",
                NormalizedName = "分销对账付款员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的接口管理员",
                NormalizedName = "接口管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的成本管理员",
                NormalizedName = "成本管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的草稿单管理员",
                NormalizedName = "草稿单管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的库存管理员",
                NormalizedName = "库存管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的客服",
                NormalizedName = "客服",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的客服经理",
                NormalizedName = "客服经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的客服经理",
                NormalizedName = "客服经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的商城管理员",
                NormalizedName = "商城管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的商品管理员",
                NormalizedName = "商品管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的新增商品员",
                NormalizedName = "新增商品员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的商务",
                NormalizedName = "商务",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的售后专员",
                NormalizedName = "售后专员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的送货员",
                NormalizedName = "送货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的物流经理",
                NormalizedName = "物流经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的销售经理",
                NormalizedName = "销售经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的销售总监",
                NormalizedName = "销售总监",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的产品运营",
                NormalizedName = "产品运营",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的账期管理员",
                NormalizedName = "账期管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的总经理",
                NormalizedName = "总经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERP用户的总经理助理",
                NormalizedName = "总经理助理",
                BranchId = 0
            },

            //商城
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户的普通用户",
                NormalizedName = "总经理助理",
                BranchId = 0
            },

            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户的系统管理员",
                NormalizedName = "系统管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户的采购管理员",
                NormalizedName = "采购管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户的部门管理员",
                NormalizedName = "部门管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "商城用户的财务管理员",
                NormalizedName = "财务管理员",
                BranchId = 0
            },
            
        };
    }
}