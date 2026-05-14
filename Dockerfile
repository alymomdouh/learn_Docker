## first stage build sdk  
# get .net version for my project 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source   # set working directory
 # copy all files with last extension .csproj into sustentation .
COPY *.csproj .  
# to run all dependents  tryDockerMvc.csproj
RUN dotnet restore 
# copy and publish application files 
# copy from any source to any destenation 
COPY . .   
# c == build configuration  release or debug 
# o is output folder 
RUN dotnet publish -c release  -o /app

## second stage run sdk 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY --from=build /app . 

##ENV ASPNETCORE_URLS=https://+:80

# start endpoint take command and dll file to run 
ENTRYPOINT ["dotnet","testdockerfive.dll"]
## TO RUN THIS CODE MAKE IN package manager console 
#========> docker build --tag testdockerfiveimage .
#=> docker image list 
# d == detach    p==publish  name=containerName
#              detach  publish 8080    containerName        tagname  
 #========>docker run -d -p 32775:8080 --name testdockerfivecontainer  testdockerfiveimage

 ###   if we update our project and need to update file 
 #step1 build project 
 #step2 rebuild same image tag 
 #========> docker build --tag testdockerfiveimage .
 #step3 remove last container and make container to contain new change
 #========> docker container rm -f testdockerfivecontainer
 #step4 create new conatiner with same name 
 #========>docker run -d -p 32775:8080 --name testdockerfivecontainer  testdockerfiveimage