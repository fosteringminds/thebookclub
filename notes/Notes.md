# Notes

Making some general notes.

## Basic architecture

The basic architecture will use many of the concepts and ideas used from [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers). In terms of the actual application the basic requirements have to be understood first as defined in the [High Level Requirements](#high-level-requirements). 

With the requirements in mind a design could be created using a microservice-like approach. We can have a service responsible for the identity of users in the system. The identity service would for the registration of new users. It would also allow for the generation of JWTs to be used across other services.

In addition to an identity service we could add a catalogue service to keep a database of all the books. Lastly we could create a subscription service to handle subscription logic. 

## High level requirements

> The business has requested the development of a new system which allows users to register online and purchase a subscription to books listed in the online catalogue. Only A registered user can purchase a subscription to any book available in the product catalogue. A user can unsubscribe to any book a user currently has in their subscription. The system should also allow 3rd party resellers to access the system or parts of the system through an Api over Http which provides the same functionality.

## Technical Requirements 

- Develop a Restful Api that contains service end-points for the problem scenario. 
- Develop a Web UI for the problem scenario

## Basic Entities 

 ### User 

- Email address
- First Name
- Last Name

### Book

- Name
- Text
- Purchase Price

## General

- Decided to go for a "simpler" JWT authentication mechanism; versus full ASP.NET Identity. ASP.NET Identity is very complex - adding many additional features not needed. 
- Also going to use SQLite for the moment.
- Will be using EF Core for migrations. Dapper for queries. Goal is to have CQRS-like architecture where queries and commands are separated.
