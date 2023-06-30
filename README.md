# deep_dive

## idea:
The player is a litte stone monster who has to find its ways through different caves. By that it has to be careful not to hit the spiders and the trapwalls. Furthermore it can collect fancy looking items and when it is dark a light to carry with.

## how to play:

-  the first level is a tutorial, where one can see all different objects which are in the game
- one has to press the space bar and one arrow for horizontal or vertical movement or the space bar and two arrows for diagonal movement
- one can only stop the player once after each collision with a wall (by pressing the space bar)
- The player has to avoid enemies and trapwalls, if the player collides with them the player dies and gets teleported to the start of the level.
- The more items the player collects, the better. At the end of the last level the amount of collected items will be shown.
- When the player collides with a green portal they get teleported to its connected portal.
- When the player collides with a brown scene changer object at the end of a level, they get teleported to the next level.
- Level 3 is dark and the player has to collect a light item in order to find their way around the level. When the player collides with the light item that is at the start of the level, the player automatically collects the light item and lights up their surroundings.
- When the player collides with the win object (black sphere with blue grid) at the end of level 4, the win screen shows and says how many items the player has collected in total. When you click the restart button of the win screen, the tutorial starts again.

## functionaities:

- enemies that are either static or move between two points, and kill the player on collision
- trapwalls that kill the player
- the player gets teleported back to the start of the level when they die
- items that can be collected, which are counted during the game. Some of them are hidden.
- teleportation via portals
- scene/level changing on collision with gameobject
- light item that lightens up its environment and can be collected by the player so that the player lightens up their environment

## issues we faced:
- finding good assets in the asset store
- in general the coding and using of the unity engine was challenging, especially tricky was:
  - using empty ojects as parents, whithout changing the position of the child objects
  - using the light object in level 3
  - figure out which objects needed scripts and which variables needed to be public



