# Hair Salon

#### C# Application that uses a Database, 5-10-2019

#### By Megan Schulte

## Description

This web applicaton will allow the user to enter employees and their clients into a database that will keep track of them. It will also allow the user to retrieve, edit and delete this information from the database. The targeted user is the owner/manager of a fictional hair salon.

## Setup/Installation Requirements

* Make a clone from GitHub at: https://github.com/meganschultepdx/fp-word-counter.git
* Open in Atom or similar text editor to view code
* This application relies on a database to store user inputted information. To re-create database in MySql you can enter the following in the command line:
    -"mysql -uroot -proot" to access MySql
    -CREATE DATABASE megan_schulte;
    -USE megan_schulte;
    -CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
    -CREATE TABLE clients (id serial PRIMARY KEY, clientName VARCHAR(255));
* There is also a copy of the previously created database saved with this project, to import it into MySql go to https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/exporting-mysql-databases-in-phpmyadmin and scroll down to the section labelled "Importing a Previously-Exported Database". Once prompted you can find the database in the project folder under the name:  megan_schulte.sql  
* Then to view the application with database on local server type the following in the command line:
    -"mysql -uroot -proot" to access MySql (if not still in mysql)
    -dotnet restore
    -dotnet build
    -dotnet run
* If run successful (which it should be) you can go to "localhost:5000" in your Chrome browser to view the application test out saving entries to the database.
 
## Specs

|Objectives|example input|example output|
|-|-|-|
|Return 0 if user's word does not appear in sentence.| "rad","I went to the bookstore." | 0 |
|Return 1 if user sentence is single word that matches user's word.|"rad", "rad."|1|
|Return 1 if user's word appears once in sentence longer than one word.|"rad", "I wen't to a rad bookstore."| 1 |
|Return total number of times user's word appears in user sentence if more than once.|"rad", "I went to a rad bookstore full of rad books."| 2 |


## Known Bugs

No known bugs

## Support and contact details

Create a pull request on GitHub.

## Technologies Used

I used C# to build this webpage.

### License

GPL, keep information free.

Copyright (c) 2019 Megan Schulte
