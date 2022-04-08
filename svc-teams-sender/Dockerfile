 FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 WORKDIR /app
 EXPOSE 80

 FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 WORKDIR /src
 COPY ["svc-teams-sender.csproj", ""]
 RUN dotnet restore "./svc-teams-sender.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "svc-teams-sender.csproj" -c Release -o /app/build

 FROM build AS publish
 RUN dotnet publish "svc-teams-sender.csproj" -c Release -o /app/publish

 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "svc-teams-sender.dll"]