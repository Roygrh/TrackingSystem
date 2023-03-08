Hello, the application is developed in .net core 7, it is already configured to run but first you have to create a database in the local instance, the sql code is in the "docker-query.sql" file. I have also prepared a dockerfile so it can be done with a container instance.

You have to go to the location of the project, where the dockerfile is, and execute the following commands:

/****************************************************/

docker build -t tracking-image .

docker run -d --name tracking-container --ip 192.168.1.100 tracking-image

/****************************************************/

You have to make sure that the IP you are choosing is free.

As mentioned, you can do it with a local instance of sql server or using docker, in the appsetting file of the project there will be the connectionstring, one for the local one if it is used or another for the docker and you want to use it.