
# dotnet-core-rest-api


### Executar via container docker

```sh
$ dotnet restore
$ dotnet publish -c Release -o out
$ docker build -t docker-rest-api .
$ docker run -p 5001:5000 -it --rm docker-rest-api
```

### Url teste
http://localhost:5001/rest-api/customer

### Verbos

CREATE, GET, GET/ID, PUT, DELETE