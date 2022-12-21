Work split draft:

Nolan:
    Main character animations
    Main character movement and interaction
    NPC animations? 

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


Left to do until Minimum Viable Product:
- Set current fruits to Kelsey's new fruits
- Game win screen
- Game over screen? (It currently just goes back to start screen which should be fine)
- Create exit to the game in the world (Like a portal that you jump in and ends the game and counts your score)
- Character skins/animations

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


