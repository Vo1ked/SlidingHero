# Sliding Hero

Genre: 3D Runner

Core Gameplay:
- Player character slides down from the hill on the snowboard
- User controls the snowboard movement direction using touchscreen or gyroscope (if available)
- Character encounters different obstacles on the hill (trees, stones etc.) If character collide with one of them - game ends.
- There are different pickups on the way:
- Likes 👍 - this increases score of the race
- Boosters - affect gameplay in positive or negative way (increase speed, affect score multiplier etc.)
- Goal of the race is to reach finish line (ribbon) collecting as much Likes as possible
- There are two game modes
- Finite races (three tracks, two of them procedurally generated) (see project description)
- Infinite mode (unlimited track, procedurally generated)

Targeted Platforms:
- Android

Monetization:
- Freeware
- OR DLC for additional boosters (more variable gameplay)
- OR DLC for additional level (highway to hell :D)

Project scope
- Time scale: 2 months
- Team:
    - Alexander Khomchenko
    - Alexandra Nechyporenko
    - Vladimir Sannikov

Project Description

The game starts with a short comics about main character’s dream - winning a snowboarding competition. This comics is shown only once when the game runs the first time. Then player needs to register either locally or via Play games. The game has four modes: bronze league cup, silver league cup, golden league cup and endless sliding. First three has finite mountain roads. Bronze league cup mode’s obstacles are predefined, but silver and golden’s are randomized with different frequency, as golden mode is more difficult than silver mode. When a player starts a game first time, only one mode is available - bronze league cup. Then player is shown a tutorial. After the first game the endless sliding mode is available. Player needs to avoid different obstacles and to collect likes and boosters by controlling character via touchscreen or gyroscope. Game ends if character collides with an obstacle. In bronze league cup mode, as well as in silver and golden, the goal is to reach an end of a road, collecting as many likes as possible. There are finish line and appropriately coloured goblet in the end of each road. After collecting the bronze cup the silver league cup mode will be available, and after collecting the silver cup - golden league cup mode. The endless sliding mode is a road with randomized obstacles. The goal in this mode is to survive as long as player can. In the end of each game player’s score is shown.

Assets Needed:
- Obstacles
    - Pines
    - Flags
    - Boosters
    - Rocks
    - Likes
    - Goblet
    - Ribbon
- UI Elements
    - Menu background
    - Menu button
    - Comics pages
    - Tutorial
    - Modes icons (three goblets and a snowboarder)
- Player character
- Textures
    - Background
    - Road
- Music
    - Applause
    - Crash sound
    - Bell sound (for like pick)
    - For powerup pick
    - Comic’s theme
    - Main menu’s theme
    - Playing’s theme

Menu Structure
- Three goblet icons for three different leagues
- Infinite mode button, unlocks after first ride
- Statistics, shows player score compared to other players (requires Google Play integration)
- Settings
    - Music enabled checkbox
    - Music volume slider
    - Sound effects enabled checkbox
    - Sound effects volume slider
    - Use Gyro checkbox (greyed out if unavailable)
    - Force feedback checkbox (greyed out if unavailable)
    - Language (won’t be implemented in MVP)
- About
    - Game title on top
    - Information about developers
    - Legal text
    - Replay tutorial button
- Exit game

Development plan:
- Project setup
- Collect and include assets
- Create demo scene with chunk of environment
- Add player to demo scene
- Implement basic player controls in the scene (keep abstract so it’s portable)
- Implement boundaries
- Create scene chunk and save it as prefab
- Create obstacle prefabs
- Implement obstacle logic (collisions / very basic)
- Draft bronze cup scene
- Implement object destroyers (invisible object behind camera that destroys every other object it touches)
- Implement likes on basic level (prefab, text on UI, remove obj. on pick, increase score)
- Create good scene chunk (preferably a few with some visual difference)
- \<TO BE DISCUSSED FURTHER>
