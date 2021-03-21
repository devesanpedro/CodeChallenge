# Code Challenge

This project is a coding challenge exercise and developed using Blazor Server Technology and .NetCore.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

  - [Visual Studio 2019](https://visualstudio.com/download) or higher
  - [.Net core SDK](https://www.microsoft.com/net/download/windows) 2.0.3 or higher
  - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) developer ore express edition

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/devesanpedro/CodeChallenge.git
   ```
2. Open package manager console and set default project: <b>CodeChallenge.API</b>
   ```sh
   Run command:
   PM> Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.4
   ```
2. Set default project: <b>CodeChallenge.Persistence</b>
   ```sh
   Run command:
   PM> Update-Database //Create initial database
   ```
3. Setup start up projects
   ```sh
   Open Solution Property Pages
   Set Multiple startup projects (CodeChallenge.API and CodeChallenge.Web) 
  ![name-of-you-image](https://github.com/devesanpedro/CodeChallenge/blob/master/startup-projects.PNG?raw=true)
  
## Screenshots

![name-of-you-image](https://github.com/devesanpedro/CodeChallenge/blob/master/application-screenshot.PNG?raw=true)

![name-of-you-image](https://github.com/devesanpedro/CodeChallenge/blob/master/api-service-screenshot.PNG?raw=true)

## Authors
* **Elmer San Pedro** - *Coding Exercise* - [CodeChallenge](https://github.com/devesanpedro/CodeChallenge)
   ```
   
   
