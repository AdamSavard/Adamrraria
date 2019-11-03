Refactoring and modifying Terraria from decompiled source code
========

### Using https://github.com/NoviaDroid/TerrariaRefractoring_1.3.2.1 as my starting point. I will be making many changes to the game to suit my needs.

### Changelog
* I changed some strings, mostly for fun.
* The number of item stacks that can be dropped on the ground increased from 400 to 1000. There is now a variable for this number.
* The items that have been dropped across the world are now saved in the world file so they will still exist after leaving and returning.
* The path was changed for world/player files since they are a different file format now.
* The player file now includes a GUID to have a unique ID.
* The world now stores the ID number of the last player. If the next player to enter the world is the same one, it will spawn that player where they were. The goal here is to have exiting the game and returning later being functionally similar to pausing.
* New menu option allows existing players to be edited to change their appearance or difficulty.
