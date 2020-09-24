FROM node:lts-alpine3.9 AS node
WORKDIR /app
COPY . ./
# workaround 'cd' command
WORKDIR /app/src/IdentityServer4.Admin
RUN npm i yarn
RUN yarn install
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY --from=node /app .

# dotnet commands to build, test, and publish
RUN dotnet restore
# RUN dotnet test dotnetcore-tests/dotnetcore-tests.csproj -c Release --logger "trx;LogFileName=testresults.trx"
RUN dotnet publish -c Release -o out

# Second stage - Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV IdentityServerDB=mssqldb;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=IdentityServer;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
WORKDIR /app
COPY --from=build-env /app/out .
RUN mv /etc/apt/sources.list /etc/apt/sources.list.bak && \
    echo "deb http://mirrors.aliyun.com/debian/ jessie main non-free contrib" >/etc/apt/sources.list && \
    echo "deb-src http://mirrors.aliyun.com/debian/ jessie main non-free contrib" >>/etc/apt/sources.list  
# RUN apt-get update && apt-get install -y libfontconfig1 && apt-get install -y fontconfig
RUN apt-get update && apt-get install -y libfontconfig1
ENTRYPOINT ["dotnet", "IdentityServer4.Admin.dll"]