Поднять базу в докере: `docker-compose up -d`  
Поднять pgAdmin в докере: `docker pull dpage/pgadmin4`  
Создать миграции: `dotnet ef migrations add init -s .\JupiNode-Server\ -p .\JupiNode.DataAccess\`  
Выполнить миграцию: `dotnet ef database update -s .\JupiNode-Server\ -p .\JupiNode.DataAccess\`  
