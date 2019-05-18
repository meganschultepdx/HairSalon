# Hair Salon

#### C# Application that uses a Database, 5-17-2019

#### By Megan Schulte

## Description

This web applicaton will allow the the owner/employee to enter new stylists, their specialties and their clients into a database that will keep track of them. It will also allow the owner/employee to retrieve, edit and delete this information from the database. It is also built so that a potential client can view the specialties offered by the salon and specifically see which stylist provides the service; as well as an about page for the salon. I need to move things around a bit so that the customer cannot add to/edit the specialties.

## Setup/Installation Requirements

* Make a clone from GitHub at: https://github.com/meganschultepdx/fp-word-counter.git
* Open in Atom or similar text editor to view code
* This application relies on a database to store user inputted information. To re-create database in MySql you can enter the following in the command line:
    -"mysql -uroot -proot" to access MySql
    -CREATE DATABASE megan_schulte;
    -USE megan_schulte;
    -CREATE TABLE stylists (id serial PRIMARY KEY, stylist_name VARCHAR(255));
    -CREATE TABLE clients (id serial PRIMARY KEY, client_name VARCHAR(255));
    -CREATE TABLE specialties (id serial PRIMARY KEY, stylist_id INT, specialty_id INT);
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
|User is able to save stylist name to stylist table in DB and DB assigns id to entry.| "Gary Busey" |in table:  id=0; name= Gary Busey|
|User is able to view list of all stylists saved in DB.|navigate to "see all stylists" page|-Gary Busey|
|user is able to click on specific stylist name and then add associated client that will save to client table in DB.|  click on"Steve Buscemi" | form that allows client name to be entered |
|user is able to view list of all clients associated with that stylist.|navigate to view all clients|-Steve Buscemi|
|user is able to click on specific client name and edit or delete the name.|click on "Steve Buscemi"|view "edit" and "delete" options|
|user is able to make a change to the clients name in the edit field and it will update in the client table of DB.|enter "Steve Martin" in the edit field|"Steve Martin" will now be in client list instead
|user is able to delete client|click delete button|"Steve Buscemi" is no longer in client list|
|user is able to make a change to the stylists name in the edit field and it will update in the stylists table of DB.|enter "Steve Martin" in the edit field|"Steve Martin" will now be in stylist list instead|
|user is able to delete stylist|click delete button|"Steve Buscemi" is no longer in stylist list|
|owner/stylist is able to enter specialty and it will add to specialties table of DB| enter "fade" in the edit field|"fade" will now be in specialties list instead and in the specialties DB|
|owner/stylist is able to click on a specialty and assign a stylist from a drop down list to that specialty| click on fade, then choose "Jonathan Van Ness" in list| Jonathan's id will now be added to the stylist_skills JOIN table next to fade id, and Jonathan's name will appear in a list in Fade's details page.|
|owner/stylist is able to click on a stylist and assign a specialty from a drop down list to that stylist| click on Jonathan Van Ness, then choose "fade" from list| fade's id will now be added to the stylist_skills JOIN table next to Jonathan's id, and fade will appear in a list on Jonathan's details page.|



## Known Bugs

No known bugs

## Support and contact details

Create a pull request on GitHub.

## Technologies Used

I used C# and MySql to build this webpage and Database.

### License

GPL, keep information free.

Copyright (c) 2019 Megan Schulte
