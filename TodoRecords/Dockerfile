
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR app

COPY .csproj .
RUN dotnet restore


COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.comdotnetaspnet8.0 AS runtime
WORKDIR app
COPY --from=build appout .


EXPOSE 80


ENTRYPOINT [dotnet, TodoRecords.dll]
