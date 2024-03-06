This is my second submission for the Telecetera Software Challenge - Paint Calculator Built with Visual Studio Code, using C#, ASP.NET, Blazor, and .NET 8

Instructions to run:

- With .NET SDK, .NET 8, Git, and Visual Studio/VSCode Installed 
(May need to use "dotnet add package Xunit" / "dotnet add package Bunit" in the test directory to run the tests)
1. in Visual Studio: do "git clone https://github.com/bennny2/Paint-Calculator-2"
2. navigate to the root directory in Visual Studio
3. use "dotnet run"
4. follow the instructions in the terminal, or open your local host to view the web app

Assumptions:

Assuming the user uses a consistent unit (eg. Metres) when inputting data
Assuming the room is a cuboid shape
Assuming the room has no windows or doors
Assuming the floor won't be painted
Assuming all walls are flat

Improvements to be made (given more time or people):

Could factor in paint coverage capacity
Could have functionality for different units and converting between
Could add functionality for other shapes of rooms (could be done by asking for amoount of walls and each of their measurements)
Could use a visual aid to dynamically show the room
Could be hosted rather than needing to be cloned through github