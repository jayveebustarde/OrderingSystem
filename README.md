# OrderingSystem
This project is a simple ordering system based on a specific set of requirements.

## Setup
**Nuget**
Restore nuget packages on the solution before build.

**Database**
This solution uses EF code-first approach. In order to setup the database connection make sure that the localdb configured on the web.config is accessible on your local machine.

After that, run the following on Ordering.DataContext package manager console:
>PM> update-database

## Technologies Used
**Frontend**
angularjs, bootstrap css

**Backend**
EF6, Autofac

## Limitations
**Security**
Unfortunately, proper authentication and authorization were not applied to this project. The login functionality on depends on a simple get method for user. 
