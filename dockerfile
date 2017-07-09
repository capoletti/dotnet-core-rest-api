FROM microsoft/aspnetcore
LABEL name "docker-rest-api"

WORKDIR /app
COPY out .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "rest-api.dll"]