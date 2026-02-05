# Snowball Wars ❄️

![Language](https://img.shields.io/badge/Language-C%23-blue) ![Platform](https://img.shields.io/badge/Platform-.NET%20Console-purple) ![License](https://img.shields.io/badge/License-MIT-green)

**Snowball Wars** is a physics-based, turn-based strategy game developed in C#. Two teams (Blue and Red) battle to destroy each other's snowmen using projectile motion physics, facing dynamic challenges like wind and obstacles.

## 🎮 About the Game

This project is built upon the principles of projectile motion. Going beyond standard requirements, it introduces **environmental factors** and **penalty mechanics** to add strategic depth to the gameplay.

### ✨ Key Features (Custom Additions)

This game includes:

* **💨 Dynamic Wind System:** A random wind factor (ranging from -2 to +2) changes every round. This affects the horizontal velocity of the snowball, forcing players to adjust their aim constantly.
* **🧱 Random Walls:** Obstacle walls of varying heights and positions are generated in the middle of the field. These block direct shots and require players to shoot over them.
* **⛄ Growing Snowman Mechanic:** If a team **misses** their shot completely (hitting nothing), one of their snowmen grows larger (making it an easier target for the opponent). This serves as a penalty for poor aim.
* **🎯 Friendly Fire & Bonuses:**
    * **Friendly Fire:** Hitting your own snowman destroys it and passes the turn.
    * **Sniper Bonus:** Hitting the opponent's "Thrower" grants you an extra turn immediately.
* **🌈 Colored Tracers:** The snowball leaves a trail that changes color (Red -> Blue -> Green) based on the distance traveled, allowing players to visualize the trajectory better.

## 🕹️ How to Play

The game is played in turns between the **Blue** and **Red** teams. Each team starts with 2 Snowmen placed randomly on their side of the field.

1.  **Objective:** The first team to destroy both of the opponent's snowmen wins the game.
2.  **Input:** On your turn, enter two values:
    * **Velocity:** A power value between `5.0` and `25.0`.
    * **Angle:** A trajectory angle between `-85.0` and `85.0`.
3.  **Physics:** The game simulates the shot based on your inputs, gravity (`-1`), and the current wind speed.

### ⌨️ Controls & Inputs

| Input | Range | Description |
| :--- | :--- | :--- |
| **Velocity** | `5.0` - `25.0` | The firing speed of the snowball. |
| **Angle** | `-85.0` - `85.0` | The angle of the shot. Positive values aim up, negative values aim down. |

## 🧮 Technical Details

The game calculates the projectile's position in real-time using the following physics formulas:

**Horizontal Position ($x$):**
$$x = x_0 + (v \cdot \cos(\theta) + \text{wind}) \cdot t$$

**Vertical Position ($y$):**
$$y = y_0 + (v \cdot \sin(\theta) \cdot t) - \frac{1}{2} g t^2$$

*The game loop runs with a time step of 0.1 seconds to ensure accurate collision detection with walls and snowmen.*

## 🚀 Installation

To run this project on your local machine:

1.  Clone this repository.
2.  Open the `Snowball-Game.sln` file in **Visual Studio**.
3.  Build and Run the project (Press **F5**).
4.  Allow the console window to resize automatically for the best experience.
