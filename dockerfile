# .NET Core Build
FROM microsoft/dotnet:latest AS dotnetcore-build
WORKDIR /source

# Copy Projects Files
COPY source/Application/Applications/Solution.Application.Applications.csproj ./Application/Applications/
COPY source/CrossCutting/IoC/Solution.CrossCutting.IoC.csproj ./CrossCutting/IoC/
COPY source/CrossCutting/Resources/Solution.CrossCutting.Resources.csproj ./CrossCutting/Resources/
COPY source/Core/AspNetCore/Solution.Core.AspNetCore.csproj ./Core/AspNetCore/
COPY source/Core/Databases/Solution.Core.Databases.csproj ./Core/Databases/
COPY source/Core/EntityFrameworkCore/Solution.Core.EntityFrameworkCore.csproj ./Core/EntityFrameworkCore/
COPY source/Core/Extensions/Solution.Core.Extensions.csproj ./Core/Extensions/
COPY source/Core/Logging/Solution.Core.Logging.csproj ./Core/Logging/
COPY source/Core/Mapping/Solution.Core.Mapping.csproj ./Core/Mapping/
COPY source/Core/MongoDB/Solution.Core.MongoDB.csproj ./Core/MongoDB/
COPY source/Core/Objects/Solution.Core.Objects.csproj ./Core/Objects/
COPY source/Core/Security/Solution.Core.Security.csproj ./Core/Security/
COPY source/Core/Validation/Solution.Core.Validation.csproj ./Core/Validation/
COPY source/Domain/Domains/Solution.Domain.Domains.csproj ./Domain/Domains/
COPY source/Infrastructure/Database/Solution.Infrastructure.Database.csproj ./Infrastructure/Database/
COPY source/Model/Entities/Solution.Model.Entities.csproj ./Model/Entities/
COPY source/Model/Enums/Solution.Model.Enums.csproj ./Model/Enums/
COPY source/Model/Models/Solution.Model.Models.csproj ./Model/Models/
COPY source/Model/Validators/Solution.Model.Validators.csproj ./Model/Validators/
COPY source/Web/App/Solution.Web.App.csproj ./Web/App/

# ASP.NET Core Restore
RUN dotnet restore ./Web/App/Solution.Web.App.csproj

# Copy All Files
COPY source .

# ASP.NET Core Build
RUN dotnet build ./Web/App/Solution.Web.App.csproj -c Release -o /app

# ASP.NET Core Publish
FROM dotnetcore-build AS dotnetcore-publish
RUN dotnet publish ./Web/App/Solution.Web.App.csproj -c Release -o /app

# Angular
FROM node:alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/Web/App/Frontend/package.json .
RUN npm run restore
COPY source/Web/App/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM microsoft/dotnet:2.1.5-aspnetcore-runtime AS aspnetcore-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM aspnetcore-runtime AS aspnetcore-angular
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=dotnetcore-publish /app .
COPY --from=angular-build /frontend/dist ./Frontend/dist
ENTRYPOINT ["dotnet", "Solution.Web.App.dll"]
