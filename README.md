Work split draft:

Nolan:
    Main character animations
        - mungo.cs

    Main character movement and interaction
        - mungo.cs 

    (Note: There were several issues surrounding the jumping mechanics, after a good chunk of time talking to team members, we couldn't figure out how to properly implement the jump so that the character's y-position would change beyond the animaion. Therefore, we put a cube in for the demo.)

    (Due to unexpected errors that could not be resolved, a large portion of work I did had to be scrapped. This includes non-enemy NPC and interactions, more puzzles with a simon game, etc)

    Implemented npc models into game

Kelsey:
    Created inventory UI and logic: 
    - Inventory.cs
    - Item.cs 
    - ItemAssets.cs
    - UI_Inventory.cs + animation
    - modified Mungo.cs
    
    Created math adding game UI and Logic:
    - MathGame.cs + animation
    - modified Mungo.cs
    
    Created fruit in the game
    - 3D models with materials and drawings for inventory (Apple_2, Avacado_2, Eggs, PurpleFood, Strawberry)
    - worked on fruitscript
    - modified Mungo.cs

    Created Start Scene UI
    - StartCanvas.cs

    Worked on End Scene UI
    - ScoreToScene.cs

    Created scene for when you lose
    - LostCanvas.cs

    Added Sounds
    - GameManager.cs: win, lose, fruit appears, collect fruit, add to inventory, wrong math answer

    Modified a few lines in other various scripts - and managed related game objects in the scene.

Drew:
    Built out inner castle area of map (four towers and everything inside castle walls)
    
    - EvilNpc.cs (made while referencing source 3)
    - FruitScript.cs
    - fruit1GamePlate1.cs
    - fruit1GamePlate2.cs
    - fruit1GamePlate3.cs
    - fruit1GamePlate4.cs
    - finalBossPlate.cs
    - KillZone.cs
    - GameManager
    - MainCamera.cs
    - All scripts related to MovingPlatforms, MovingPlatformPaths (made while referencing source 1)
    - Basic movement in Mungo.cs (made while referencing source 2 for jumping mechanics)
    - ScoreToScene.cs
    
    Map terrain / structures
    Collectible items on the map
    NPC functionality (AI? Interact with main character?)

Links to resources used in project:
- 1. MovingPlatformPath.cs, MovingPlatforms: https://www.youtube.com/watch?v=ly9mK0TGJJo
- 2. Improved Jumping mechanics: https://www.youtube.com/watch?v=ynh7b-AUSPE
- 3. Basic AI referenced in creating EvilNpc.cs: https://www.youtube.com/watch?v=UvDqnbjEEak
- 4. Implementing CineMachine camera: https://www.youtube.com/watch?v=jiyOZbKRfaY
- 5. Pausing game: https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
- 6. Inventory tutorial adapted for mungo game: https://www.youtube.com/watch?v=2WnAOV7nHW0



Unity Assets:
- CastlePack
- Cobblestone
- HandPainted Lava Textures
- JungleTemple
- SpaceSkies Free
- RPG Monster Duo PBR Polyart

Model and Animations were taken from mixamo.com


