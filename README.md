# GitHub Dashboard powered by Blazor

This is a demo application built with Blazor. For now it is using the server side hosting model. Its main purpose is to talk to the GitHub Api, 
get some valueable information and display it in the browser. An ultimate goal is to continue to grow this application trying to not write a single line of Javascript.


## Run the app

1. Clone this repository
2. Register an [OAuth App](https://developer.github.com/apps/building-oauth-apps/creating-an-oauth-app/) on Github. Make note of the **clientId** and **clientSecret**
3. in ```appsettings.json``` paste the values for your clientId and clientSecret in the appropriate properties
4. Rebuild the application
5. Run the application 

## Key architectural concepts

Architecting Blazor applications is still a black box. The role of communities is to try thing out, communicate and debate to work out the best architectural patterns. 

This application tries to apply Angular architectural concepts from the Angular Style Guide to Blazor. Note following principles:
1. Each feature goes into its own folder. All code related to that feature should be placed there. This tries to emulate the "one module per feature" guideline in Angular
2. Services re-used throughout the entire Blazor application should be placed in the **Core**. 
3. Re-usable components (usually components without routing, but not always) should be placed in the **Shared** folder. 
4. The markup and C# code should be separated into different files

## Contribute
If you want to get your hands on Blazor, this is a good opportunity to do so. You'll find issues in this repo so you can work on them. Also get in touch if you need further assistance. 

Each time you want to code make sure to create a new branch and commit all your code to that branch. When you think you're ready, just submit a pull request and we'll have a look at it. 

## Disclaimer
If you want to use this app for demos, presentations or whatever else, you are free to do so.Upda
