# RabbitBasic
.Net c# Core RabbitBasic

To run generic instance of rabbitmq without the definitions use:
```
docker run --rm -it --hostname ultra2 -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```
To view the web console navigate to: http://localhost:15672/

Use username: guest password: guest
