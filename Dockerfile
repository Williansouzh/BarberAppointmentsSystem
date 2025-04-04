# 1. Imagem base para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 2. Copiar arquivos do projeto
COPY ["BarberFlow.API/BarberFlow.API.csproj", "BarberFlow.API/"]
COPY ["BarberFlow.Application/BarberFlow.Application.csproj", "BarberFlow.Application/"]
COPY ["BarberFlow.Domain/BarberFlow.Domain.csproj", "BarberFlow.Domain/"]
COPY ["BarberFlow.Infra.Data/BarberFlow.Infra.Data.csproj", "BarberFlow.Infra.Data/"]
# 3. Restaurar dependências
RUN dotnet restore "BarberFlow.API/BarberFlow.API.csproj"

# 4. Copiar todos os arquivos e compilar
COPY . .
WORKDIR "/app/BarberFlow.API"
RUN dotnet publish -c Release -o /out

# 5. Imagem final para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# 6. Expor porta e rodar a aplicação
EXPOSE 8080
CMD ["dotnet", "BarberFlow.API.dll"]
