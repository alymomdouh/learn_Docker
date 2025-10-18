# learn_Docker
all content and links and details i used to learn docker


1- [introduction-to-docker-ebook](https://github.com/bobbyiliev/introduction-to-docker-ebook?tab=readme-ov-file)

2- [Docker سلسلة تعلم](https://www.youtube.com/playlist?list=PLX1bW_GeBRhDkTf_jbdvBbkHs2LCWVeXZ)

2.1 Docker New Pricing Model

2.2 Docker Architecture | Part 2 | Docker شرح

<img width="1132" height="607" alt="image" src="https://github.com/user-attachments/assets/5e1a220f-1ae2-4a62-8727-7c3eec25e06f" />
<img width="1108" height="150" alt="image" src="https://github.com/user-attachments/assets/995b5566-414b-44a6-830c-2bb4a2d68501" />
 
2.3  Docker Installation | Part 3 | Docker شرح
>> docker -v

2.4 Docker Settings | Part 4 | Docker شرح

[ documentation Url](https://docs.docker.com/?uuid=F0ECF433-8FBC-496A-AAF7-FFC2482C5DFB)

[ docker hub](https://hub.docker.com/)

2.5 Basic Commands in Docker | Part 6 | Docker شرح

----   a mean all 
----  ls mean list 
> docker run hello-world

>docker ps -al

>docker container ls -a

>docker pull fedora:rawhide

> docker rm id

2.6 Basic Commands in Docker | Part 6 | Docker شرح

>docker pull redis:alpine3.22

>docker pull redis

>>docker inspect redis

>>docker logs containId

2.7 Basic Commands in Docker | Part 7 | Docker شرح

>docker container run --detach --publish 80:80 nginx

>docker container stop nginx

>docker container start nginx

>docker help run

>docker exec -it nginx bash

##>service nginx -v

2.8 Navigating Files and Directories in Bash | Part 8 | Docker شرح

#> ls 
#> cd etc
#> cd ..
#> cd /
#> mkdir alyfolder 
#> touch default.html 
#> cp default.html foldername
#> rm default.html 

2.9 Docker Tags, Image Layers and Dockerfiles | Part 9 | Docker شرح
<img width="1232" height="596" alt="image" src="https://github.com/user-attachments/assets/16437c83-8656-4636-bf05-9b480cf4875f" />

2.10 10. Create New Tags and Push to Docker Hub  Part 10  Docker شرح
> docker history redis

2.11   not working 


2.12 12. Dockerize ASP.NET Core Application  Part 12  Docker شرح


>cd
>mkdir dockerize
>cd dockerize
>dotnet new mvc --name dockertestProject --output dockerwebsiteTest
>touch dockerFile
>touch .dockerignore
>docker build --tag dockertestapp .
>docker images ls
>docker run -d -p 8080:80 --name htapp taganem
>in url write localhost:8080
> dotnet build  // rebuild app
>docker build --tag dockertestTagapp .     // rebuild docker
> docker run -d -p 8080:80 --name htapp taganem
>docker container ls
> docker container rm -f htapp  /// -f  === force 
>

