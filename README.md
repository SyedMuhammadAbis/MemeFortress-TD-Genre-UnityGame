# 🎮 Meme Fortress

A fun and entertaining **2D Tower Defense game** built in Unity that combines classic tower defense mechanics with player-controlled combat and hilarious meme sound effects! Defend your fortress against waves of enemies while strategically placing towers and taking matters into your own hands with direct combat.

![Unity](https://img.shields.io/badge/Unity-2021.3.0f1-black?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)

---

## 📖 About This Project

This project was created as a **learning experience** to explore Unity game development, focusing on:
- Tower defense game mechanics
- 2D physics and collision detection
- UI/UX design and management
- Audio system integration
- Game state management and wave systems
- Object-oriented programming patterns in Unity

The game features a unique twist with **meme sound effects** that make every action entertaining - from shooting enemies with "Pew!" sounds to Squidward's walking sound effects when moving around!

---

## 🎯 Game Overview

### What is this game?

**Meme Fortress** is a strategic defense game where you must:
1. **Place towers** on designated plots to automatically attack enemies
2. **Upgrade your towers** to increase damage, range, and fire rate
3. **Control a player character** that can move around and shoot enemies directly
4. **Defend your home/base** from increasingly difficult waves of enemies
5. **Manage your economy** - earn currency from defeating enemies and spend wisely on towers and upgrades

### Gameplay Features

- 🏗️ **Tower Placement System**: Click on plots to place different types of towers
- 🔄 **Tower Upgrades**: Upgrade existing towers to boost their effectiveness
- 🎯 **Multiple Tower Types**: 
  - Basic Turret - Standard defense
  - Sniper - Long-range, high damage
  - Icy Turret - Slows down enemies
- 👾 **Wave-Based Enemies**: Increasingly difficult waves with scaling difficulty
- 🎮 **Player Combat**: Move with WASD and shoot enemies with left-click
- 💰 **Economy System**: Earn and spend currency strategically
- 🏠 **Base Defense**: Protect your home from enemy attacks
- 🎵 **Meme Sound Effects**: Fun audio throughout the gameplay experience

---

## 🛠️ How I Made This

### Development Process

This project was built step-by-step, learning Unity game development fundamentals:

#### 1. **Core Systems Setup**
   - Created singleton managers (`BuildManager`, `LevelManager`, `UiManager`) for centralized game state management
   - Implemented the currency system with spending/earning mechanics
   - Set up the wave spawning system with dynamic difficulty scaling

#### 2. **Tower Defense Mechanics**
   - Built a tower placement system using `Plot.cs` that handles click interactions
   - Created `Turret.cs` with enemy detection using `Physics2D.CircleCastAll` for targeting
   - Implemented automatic shooting with configurable fire rates
   - Added tower upgrade system with exponential scaling formulas:
     - Cost: `upgradeCost * level^0.8`
     - Fire Rate: `bulletPerSecond * level^0.5`
     - Range: `targettingRange * level^0.4`
   - Added visual range indicators using `LineRenderer` for better gameplay feedback

#### 3. **Enemy System**
   - Created pathfinding system using waypoints (`EnemyMovement.cs`)
   - Implemented wave spawner with UnityEvents for enemy tracking
   - Added enemy health system with currency rewards on death
   - Integrated speed modification system for ice turret effects

#### 4. **Player System**
   - Built player movement with `Rigidbody2D` physics
   - Created shooting system with continuous fire mechanics
   - Added UI collision detection to prevent shooting through UI elements
   - Integrated movement sound effects with walking/sprinting differentiation

#### 5. **Audio Integration**
   - Created `SoundManager.cs` for centralized audio management
   - Integrated meme sound effects throughout gameplay:
     - Shooting sounds ("Pew!", "Will Smith That's Hot" clip)
     - Walking sounds (Squidward walking sound)
     - Various meme audio clips for different game events
   - Added AudioSource components to bullets and turret projectiles

#### 6. **UI System**
   - Built comprehensive UI manager with wave counter, enemy tracker, and health display
   - Created pause menu system
   - Implemented game over screen
   - Added upgrade UI with error messages (including "Ghareebo" for not enough currency!)

#### 7. **Polish & Optimization**
   - Added visual feedback (hover effects, range indicators)
   - Implemented collision detection and layer management
   - Created multiple scenes for different game modes
   - Added animations for player and enemies

### Technical Architecture

The project follows several design patterns:

- **Singleton Pattern**: Used for managers (BuildManager, LevelManager, UiManager) to ensure single instances
- **Component-Based Design**: Modular scripts for different game systems
- **Event-Driven Architecture**: UnityEvents for enemy destruction tracking
- **Object Pooling** (potential optimization): Could be added for bullets and enemies

### Key Code Structures

```
Assets/
├── Scripts/
│   ├── BuildManager.cs          # Tower selection and building
│   ├── LevelManager.cs          # Game economy and path management
│   ├── UiManager.cs             # UI updates and game state
│   ├── SoundManager.cs          # Audio management
│   ├── Enemy/
│   │   ├── EnemySpawner.cs      # Wave system
│   │   ├── EnemyMovement.cs     # Pathfinding
│   │   └── EnemyHealth.cs       # Health and rewards
│   ├── Turret/
│   │   ├── Turret.cs            # Core turret logic
│   │   └── TurretBullet.cs      # Projectile behavior
│   ├── Player/
│   │   ├── PlayerMovement.cs    # WASD movement
│   │   └── Shooting.cs          # Player combat
│   └── Plot.cs                  # Tower placement
├── Sounds/                      # Meme sound effects
├── Prefabs/                     # Game objects
└── Scenes/                      # Game levels
```

---

## 🎵 Meme Sound Effects

One of the fun aspects of this game is the integration of meme sound effects:

- **"Pew.mp3"** - Classic shooting sound
- **"Squidward walking sound"** - Player movement audio
- **"Tomato squash.mp3"** - Enemy death/impact sounds
- **"Will Smith That's Hot"** - YouTube Rewind 2018 meme clip
- **"Aha Tamatar Bade Mazedaar"** - Hindi meme song
- **Plushie sounds** - Various game event sounds

These sounds add personality and humor to the gameplay experience!

---

## 🚀 Getting Started

### Prerequisites

- **Unity Hub** installed
- **Unity 2021.3.0f1** or compatible version
- Basic knowledge of C# (optional, for code exploration)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/meme-fortress.git
   cd meme-fortress
   ```

2. Open the project in Unity:
   - Launch Unity Hub
   - Click "Add" and select the project folder
   - Unity will import all assets (this may take a few minutes)

3. Open the main scene:
   - Navigate to `Assets/Scenes/1-TowerDefense.unity`
   - Or start from `Assets/Scenes/0-MainMenu.unity` for the full experience

4. Press Play to start the game!

### Controls

- **W/A/S/D** - Move player character
- **Left Shift** - Sprint (enables sprint sound)
- **Left Click** - Shoot (hold for continuous fire)
- **Mouse Click on Plot** - Place tower
- **Mouse Click on Tower** - Open upgrade menu
- **ESC** - Pause menu

---

## 🎮 Game Mechanics

### Tower Placement
- Click on green plots to place towers
- Each tower costs currency
- Towers automatically target and shoot enemies in range

### Tower Upgrades
- Click on existing towers to upgrade them
- Upgrades increase:
  - Damage output
  - Attack range
  - Fire rate
- Upgrade costs scale with tower level

### Enemy Waves
- Enemies spawn in waves with increasing difficulty
- Each wave has a countdown timer
- More enemies spawn per wave as you progress
- Defeating enemies rewards currency

### Economy
- Start with 100 currency
- Earn currency by defeating enemies
- Spend currency on:
  - New towers
  - Tower upgrades

### Base Defense
- Your home/base has limited health
- Enemies deal damage when they reach the base
- Game ends when base health reaches 0

---

## 🛠️ Technologies & Tools Used

- **Unity 2021.3.0f1** - Game engine
- **C#** - Programming language
- **Universal Render Pipeline (URP)** - Rendering pipeline
- **TextMesh Pro** - Advanced text rendering
- **Unity Physics 2D** - Collision detection and physics
- **Unity Audio System** - Sound management
- **Cinemachine** - Camera system (included in project)

### Unity Packages Used
- Unity 2D Feature Set
- TextMesh Pro
- Universal Render Pipeline
- Cinemachine
- Visual Scripting (optional)

---

## 📁 Project Structure

```
TowerDefenceGame/
├── Assets/
│   ├── Scripts/              # All C# game scripts
│   ├── Sounds/               # Meme sound effects
│   ├── Prefabs/              # Reusable game objects
│   ├── Scenes/               # Game levels
│   ├── Sprites/              # Game art assets
│   └── Animations/           # Character animations
├── Packages/                 # Unity package dependencies
├── ProjectSettings/          # Unity project configuration
└── README.md                 # This file
```

---

## 🎓 What I Learned

This project was an excellent learning experience in:

- **Unity Game Development**: Understanding the Unity engine, scene management, and component system
- **C# Programming**: Object-oriented programming, events, delegates, and Unity-specific APIs
- **Game Design**: Balancing gameplay mechanics, difficulty scaling, and player experience
- **Physics & Collision**: 2D physics, raycasting, and collision detection
- **UI/UX Design**: Creating intuitive interfaces and player feedback systems
- **Audio Integration**: Managing sound effects and creating an immersive audio experience
- **State Management**: Implementing singleton patterns and centralized game state

---

## 🔮 Future Enhancements

Potential improvements and features:

- [ ] More tower types and abilities
- [ ] Boss enemies with special mechanics
- [ ] Save/load system for progress
- [ ] Multiple difficulty modes
- [ ] Achievement system
- [ ] More meme sound effects integration
- [ ] Particle effects for impacts
- [ ] Screen shake and visual feedback
- [ ] Tutorial system for new players
- [ ] Sound volume controls
- [ ] Object pooling for performance optimization

---

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

## 🙏 Acknowledgments

- **Unity Technologies** for the amazing game engine
- **Tiny Swords** asset pack creators for the sprite resources
- All the meme creators whose sounds make this game entertaining!
- The Unity community for tutorials and resources

---

## 📧 Contact

Feel free to reach out if you have questions, suggestions, or want to collaborate!

---

**Enjoy Meme Fortress and have fun defending your fortress! 🎮✨**

*Made with ❤️ and lots of "Pew!" sounds*

