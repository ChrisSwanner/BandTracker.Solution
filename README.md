
# Band Tracker

#### .NET MVC app that allows the user to track their favorite bands and the venues they have played at.

#### _By Chris Swanner_

## Description
_This is a resubmission of the week 3 C# independent project focusing on one to many relationships._

#### _Band Tracker_
* Allows the user to add a new band
* Allows the user to view all bands and all venues
* Allows the user to see the details for each band individually
* Allows the user to select a band, and see what venues they have played at

### Specifications
* User can add a new band
  * sample input: band name "AC/DC"
  * sample output: new band with the name "AC/DC" is created
* User can add a new venue to the list of venues and select and assign a band to the venue
  * sample input: Create new venue with name "Moda Center" and band "AC/DC"
  * sample output: The band AC/DC is now shows they have played at the Moda Center

  ## Setup/Installation Requirements

  * _Clone this GitHub repository_

  ```
  git clone https://github.com/ChrisSwanner/BandTracker.Solution
  ```

  * _Install the .NET Framework and MAMP_

    .NET Core 1.1 SDK (Software Development Kit)

    .NET runtime.

    MAMP

  *    _Import the data into the database_

  Type the following into the mySql command line:
  ```
  CREATE DATABASE bandTracker;
  USE bandTracker;
  CREATE TABLE bands ( id serial PRIMARY KEY, name VARCHAR(255), description VARCHAR(255);
  CREATE TABLE venues ( id serial PRIMARY KEY, name VARCHAR(255), address VARCHAR(255), bandId INT, PRIMARY KEY (`id`));
  ```

  * _Start mySql server from mamp._

  * _Run the program_
    1. In the command line, cd into the project folder.
    2. In the command line, type dotnet restore. Enter.  It make take a few minutes to complete this process.
    3. In the command line, type dotnet build. Enter. Any errror messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
    4. In the command line, type dotnet run. Enter.

  * _View program on web browser at port localhost:5000/_

  * _Follow the prompts._

## Technologies Used

* HTML
* Bootstrap
* C#
* MAMP
* .Net Core 1.1
* Razor
* MySQL

### License

*MIT License*

Copyright (c) 2018 **_Chris Swanner_**
