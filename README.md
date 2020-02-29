# Cold Storage Warehouse Information System

Console app developed in C# .NET core using Factory Method design pattern. 
The goal is to simulate input of relevant data and to calculate monthly balance, 
writing and saving it all to .txt files, with using of Entity Framework for LINQ to Entities to query the data.

Note: Database needs to be in the default SQL instance folder on operating system partition in users/user folder. 
Every change that is made in the entity model needs to be done with 
Add-Migration(for more information https://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx) command 
in the package manager console, so there won't be exception error during the launch. 

E.G. C:/Users/Dex
