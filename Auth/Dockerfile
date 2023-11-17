FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /src
COPY ["Auth/*.csproj", "Auth/"]
RUN dotnet restore "Auth/*.csproj" --use-current-runtime
COPY . .
WORKDIR "/src/Auth"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false --use-current-runtime --self-contained false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoStudent.Auth.dll"]
