# SimpleCrudOnDocker
It's a simple crud application using .net core 5, sqlserver and docker

#### To build docker file
Go to directory that "Dockerfile" located and then use
````
docker build -t tarafdarmansour/simplecrudondocker:v1 .
````        

#### To run docker image
````
docker run -p 80:80 -p 443:443 --name simplecrudcontainer tarafdarmansour/simplecrudondocker:v1
````   

after running container you need find out your host ip to set in "appsettings.Production.json" when running on docker environment.
*DO NOT forget to open your host 1433 port for incomming traffic and enable remote connection in sql sqrver configuration*

#### To run some command on docker container
open bash commandline
````
docker exec -it <container_Id> bash
````

get linux version
````
cat /etc/os-release
````

install ifconfig
````
apt-get install net-tools
````

install telnet
````
apt-get install telnet
````

install ping
````
apt-get install iputils-ping
````
