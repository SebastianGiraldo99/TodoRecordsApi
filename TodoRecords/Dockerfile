
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR app

COPY TodoRecords.csproj ./
RUN dotnet restore


COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR app
COPY --from=build appout .


EXPOSE 80


ENTRYPOINT [dotnet, TodoRecords.dll]
