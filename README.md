# MemeIT
 _Responsive meme uploading app created in Angular and .Net Core_

## Implemented tasks
### -Frontend
- Task 1 ✅ 
    - Login and Register dialogs ✅ 
    - Conditional display for Login and Register buttons ❌
    - Fixed navbar ✅ 
- Task 2 ✅ 
    - Welcome page ✅ 
    - Design compliant ✅ 
    - Auto-scroll to Upload a meme page ✅ 
- Task 3 ✅ 
    - Login and Register dialogs working ✅ 
- Task 4 ✅ 
    - Upload form created ✅ 
    - Drag and Drop Image and Upload image field with validation ❌  (used textarea to simulate)
- Task 5 ✅ 
    - Footer with redirect link on corresponding buttons ✅ 
- Task 6 ✅ 
    - Responsive design on any resolution ✅ 

### -Backend
- Task 1 ✅ 
    - DbSchema for Users ✅ 
    - DbSchema for Memes ✅ 
- Task 2 ✅ 
    - CRUD for Memes ✅ 
- Task 3 ✅ 
    - Login and Register using Bcrypt and JWToken ✅ 
- Task 4 ✅ 
    - Input validation ✅ 
- Task 5 ✅ 
    - Protected Endpoints ✅ 
- BONUS ✅ 
    - File Upload ✅ 

## Run the app
### -Frontend
##### - Prerequisites
- node.js (^14.20 | ^16.13 | ^18.10)
- npm

##### - Commands
Run at the root of the frontend project to locally host
```sh
npm install
ng serve
```
### -Backend
##### - Prerequisites
- Sql Server (running localhost database)
- Visual Studio 2022 (needed for .Net 6 support)
- ASP.Net and web development Workload (installation dialog will pop when project solution is opened in Visual Studio; workload can also be installed from Visual Studio Installer)

##### - Commands
Open project .sln file. The project solution will be opened in VS.
In Visual Studio -> Tools -> NuGet Package Manager -> Package Manager Console (to open Package Manager Console)
To run database migrations, in Package Manager Console, run:
```sh
Update-Database
```
After migration succeed project can be started from VS and it can be tested using the Swagger interface.

## Challenges 
Responsive UI - solved using fxFlex library  
Secure Authentication - solved using Bcrypt for hashing and JWToken  
Node, npm and Angular versions conflicts - used nvm to control node and npm versions  
Error handling with suggestive messages for Api - created custom exceptions and used services to emit these exception; this way the controller is responsible for catching these specific exception and an custom message can be returned for every exception

## Layout Overview
### Desktop
![](memeit.gif)

### Mobile
![](memeitmobile.gif)