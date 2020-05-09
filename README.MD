Для запуска в докере прописать в appsettings.json строку подключения:
"Server=db-server;Database=News;User=sa;Password=Superadmin1234;"

при запуске приложения напрямую:
"Server=<ВАША_БД>;Database=News;Trusted_Connection=True;MultipleActiveResultSets=true"

Все таблицы создадутся автоматически

Для запуска в Docker выполнить в корне
docker-compose build
docker-compose up
доступ к Api в Docker через Swawgger:
  https://localhost:7000/swagger/index.html

доступ доступ к Api при запуске в IDE:
  https://localhost:5001/swagger/index.html
  
  
Стабильно работает запуск из IDE + запуск клиента через ng serve -o
