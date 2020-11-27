#
# It's default config from docs.docker
# https://github.com/iayti/CleanArchitecture/blob/master/src/Apps/WebApi/Dockerfile
# Look here for interesting build
#
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WishlistAPI.dll"]