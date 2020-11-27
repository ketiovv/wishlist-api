#
# It's default config from docs.docker
# https://github.com/iayti/CleanArchitecture/blob/master/src/Apps/WebApi/Dockerfile
# Look here for interesting build
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ["/WishlistAPI/WishlistAPI.csproj", "/WishlistAPI/"]
COPY ["/WishlistAPI.Application/WishlistAPI.Application.csproj", "/WishlistAPI.Application/"]
COPY ["/WishlistAPI.Infrastructure/WishlistAPI.Infrastructure.csproj", "/WishlistAPI.Infrastructure/"]
COPY ["/WishlistAPI.Domain/WishlistAPI.Domain.csproj", "/WishlistAPI.Domain/"]
RUN dotnet restore "/WishlistAPI/WishlistAPI.csproj"
COPY . .
WORKDIR "/WishlistAPI"
RUN dotnet build "WishlistAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WishlistAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WishlistAPI.dll"]