* GIT COMMANDS: https://www.earthdatascience.org/workshops/intro-version-control-git/basic-git-commands/


* DOCKER SQL IMAGE https://hub.docker.com/_/microsoft-mssql-server

    docker pull mcr.microsoft.com/mssql/server:2017-latest
    docker run -e 'ACCEPT_EULA=Y' -e 'QWEasd123!' -p 1434:1433 -d mcr.microsoft.com/mssql/server:2017-latest

* NUGET: Microsoft.Aspnetcore.app (db, security, logging etc)



* DB Scaffold

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=vs

Scaffold-DbContext 'Data Source=localhost, 1434;Initial Catalog=eProdaja; user=sa; Password=QWEasd123!' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Database


* EF CORE

https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0


* Automapper
https://code-maze.com/automapper-net-core/


ML.NET
https://github.com/dotnet/machinelearning-samples