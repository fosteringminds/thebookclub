# Notes

[[_TOC_]]

Making some general notes.

## Basic architecture

The basic architecture will use many of the concepts and ideas used from [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers). In terms of the actual application the basic requirements have to be understood first. 

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

