This project is a scalable microservice-based application designed for managing perishable goods and expiry tracking, particularly relevant to retail and inventory-heavy environments.

The system is built using .NET microservices architecture and follows modern distributed system design principles.

 Architecture & Technologies
 Core Architecture:
Microservices-based architecture
CQRS (Command Query Responsibility Segregation)
Event-driven communication (RabbitMQ)
API Gateway using Ocelot
 Technologies Used:
ASP.NET Core Web API
MediatR (CQRS implementation)
RabbitMQ (event bus)
Entity Framework Core
SQL Server
Ocelot API Gateway
Microservices Included
Product Service → Manages product inventory and expiry dates
Order Service → Handles purchase and stock updates
Notification Service → Sends alerts for expiring products
API Gateway → Routes and aggregates requests
System Flow (Simplified)
A product is created in the Product Service
When expiry is near, an event is published via RabbitMQ
The Notification Service consumes the event
Users receive alerts (email/SMS-ready design)
 My Contributions

I was responsible for designing and implementing key parts of the system:

Architecture Design
Designed the microservice boundaries
Implemented CQRS pattern with MediatR
Structured services for independent scalability
Backend Development
Built REST APIs for multiple services
Implemented repository pattern + unit of work
Handled data consistency across services
 Event-Driven Integration
Integrated RabbitMQ for asynchronous messaging
Designed event contracts and handlers
Ensured loose coupling between services
 API Gateway
Configured Ocelot for routing and load balancing
Centralized authentication-ready structure
