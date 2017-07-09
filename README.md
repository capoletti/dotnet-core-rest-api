dotnet-core-rest-api


#executar container docker

dotnet restore
dotnet publish -c Release -o out
docker build -t docker-rest-api .
docker run -p 5001:5000 -it --rm docker-rest-api


#url test
http://localhost:5001/rest-api/customer

# VERBS: CREATE, GET, GET/ID, PUT, DELETE