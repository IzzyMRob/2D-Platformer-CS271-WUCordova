# The Mitten
Inspired by the cildrens book "The Mitten", adapted and illustrated by Jan Brett.

## Play the Game
**Unity Play Link**: (https://play.unity.com/en/games/f6c58692-187d-4cfe-b49b-e9af7737964c/the-mitten)

## Game Overview
In this game you play as a bear walking through the snowy forest, searching for a warm place to rest. Along the way you must find your friend, the tiny mouse. 
Journey together and find warmth in a child's lost mitten.

Run and jump your way through the snow, but make sure you avoid the sharp rocks and deadly pits! Don't forget to find the mouse along the way, the mitten will be too cold without them! 

### Controls
- Keyboard & Mouse
  - Use the "A" & "D" or left & right arrow keys to move side to side.
  - Use the space bar to jump.

### How to Play
Start somewhere in the frozen forest, make your way through the level to reach the warm mitten! Explore every path you see to find your friend along the way, after all, comfort is always better shared.

There is no timer or scoring system, just focus on playing through the puzzle and having fun! This game is designed to be a cozy adaptation of a beloved book from my childhood, not an intense platformer.

## Base Game Implementation

### Completion Status

Base:

- [x] Levels
- [x] Sprites
- [x] Prefabs
- [x] Colliders
- [x] Ridigbodies
- [X] Triggers
- [X] UI Text
- [X] Sprite Movement
- [X] Particle Systems
- [X] GameObject Movement
- [X] Game Release

Advanced Features:

- [ ] Audio (2)
- [X] Animations (2)
- [ ] Menu (2)

Creativity & Innovation:

- [X] Original Art (2)
- [X] Compelling Narrative (2)????

Polish & Presentation:

- [X] Game Trailer (3)
- [ ] Cross-Platform Build (2)


### Known Bugs
- When jumping sometimes the bear gets stuck on the edges of tiles, this doesnt let them get up (ie. it's not a cheat) but it looks bad.
- 

### Limitations
- There is a very small amount of levels, the implimentation would have to be changed to easily add more.
- There isn't a custom background, I would like to add one but the ones I created were too distracting from the playable area.

## Extensions Implemented

### 1. Audio (2 points)
**Implementation**: I found sound assets in the Unity Store and imported them, the music just got added to the scene on a loop and the jump landing is called in the same place as the landing particle effect.
**Game Impact**: Adds immersion and feedback to the player jumps, a more upbeat feling as well.
**Technical Details**: Imported the files and added them to audio sources, one called in code and one constantly looping.
**Known Issues**: N/A

### 2. Animations (2 points)
**Implementation**: I created custom animations for each action that could happen, eg. idle, walking, jumping up, and falling. ThenI used a script to set which animation was active based on how the player was currently moving. Meaning no movement was idle, moving left or right was walking, a positive velocity was jumping, and negative was falling.

**Game Impact**: It makes the bear a lot more interactive, and provides lots of feedback to player input.

**Technical Details**: Int lengthened the Player script and I had to check for more values, but it wasn't super difficult once I understood how to activate animations.

**Known Issues**: N/A

### 3. Menu (2 points)
**Implementation**: A menu pops up when the player reaches the mitten with the mouse prompting them to restart the level. If clicked it starts the scene from the beginning.

**Game Impact**: Provides a concrete end to the game when it is won, and lets the player re-play if they want.

**Technical Details**: I set the UI active when the player reaches the mitten and is carrying the mouse, and the button call function is just restarting the scene.

**Known Issues**: N/A

### 4. Original Art (2 points)

**Grading Request**: I would like to request that the score for creating original art be changed from 2 points to 3 points, so that it is the same amount as creating a game trailer. I personally spent a lot more time and effort creating the assets than the video, especially with all the custom animations and multiple tiles each needing individual sprites. I believe that creating your own assets is a worthwhile endevour to increase the player immersion and your own connection to your game. I also think that 3 points is more in line with the other standards for this assignment. Thank you for your consideration.

**Implementation**: I created custom sprites in the PixelStudio software and imported them into Unity. The bear was always just a simple 2D sprite with slight variations, the animations just switch between different ones. All of the environment is in a Tilesheet. Everything is created as 32x32px, imported as 512x512px for clarity.

**Game Impact**: Made it easy to create the level once I had the tag interactions set in the Player script. Meant everything lined up in a grid, fitting the pixel art theme.

**Technical Details**: The ground, obstacles, and instructions are all imported into a tilesheet. Then each different type of tile (ground, damaging obstacles, instant death obstacles, and instructions) was put on a different tilesheet layer with a tag corresponding to how to interact with it.

**Known Issues**: The corner tiles have a sharp edge of the collider, so the bear can get stuck on it even with friction set all the way to 0. Not game-breaking or a way to cheat, but it doesn't look good.

### 5. Compelling Narrative (2 points) ??
**Implementation**: I based the game theme on a kids book I really loved when I was younger, *The Mitten* by Jan Brett. I think it is an adorable story, and the art from it was always super comforting so I tried to imitate that with the fat bear and soft mitten sprites.

**Game Impact**: Gave it a overarching story and motivates why you need to collect the mouse before winning.

**Technical Details**: Drove how I defined the win condition (carrying the mouse and reaching the mitten).

**Known Issues**: N/A

### 6. Game Trailer (3 points)
**Implementation**: I recorded myself playing a level and edited it together in Capcut. It was supposed to be a little silly, given that the game isn't super dramatic and I only had access to limited video editing skills and free assets.

**Game Impact**: Gives players a quick intro to the game before they play it in case the description isn't enough or they want to see it.

**Technical Details**: Screen recorded a video and edited it in Capcut.

**Known Issues**: N/A

### 7. Cross-Platform Implementation (2 points)
**Implementation**: 

**Game Impact**: 

**Technical Details**: 

**Known Issues**: N/A

## Credits
- Created with Unity 6
- Visual Assets:
  - All visuals made by me using the software "Pixel Studio"
- Sound Assets:
  - Background Music: domi.wav on the Unity Asset Store
  - Jump Land Sound: KING BALTHAZAR on the Unity Asset Store
- Implimentation Help:
  - 2D Platformer tutorial from "Unity Unlocked" (https://www.youtube.com/@UnityUnlocked)
- Inspiration:
  - *The Mitten* by Jan Brett
- Video Editing:
  - Software + Confetti Effect done in Capcut

## Reflection
**Total Points Claimed**: Base 80% + Extentions 14 points

**Challenges**: 
- Getting my custom assets to import in the correct size and mesh well together took a lot of troubleshooting to get perfect.
- Moving from the first scene to the second within the game was confusing at first.

**Learning Outcomes**:
- I learned a lot about how to impliment interactions and UI elements in Unity C# scripts. I feel a lot more confident now on future projects!
- I am super confortable making tilesheets now, I really hope I can keep making my own assets for more projects!!

## Development Notes
I used the legacy input manager rather than the newer input system. I found that when I ran into errors with the input system there were way less resources online to help solve them. 
The input manager isn't perfect, but I was able to solve any issues I ran into with it much faster.
