🕹 Boss State Machine Class

  This class represents the Boss AI and State Machine in my game. It is responsible for decision making, behavior logic, and managing the boss’s actions, while rendering/drawing is handled by other classes (e.g., GameController or Renderer).

🔹 Overview

The Boss class extends CreatureActions and implements:

AI Logic: Determines the boss behavior based on health and current state.

State Machine: Handles the transitions and animations for different states:

- WalkLeft

- Fly

- DownFly

- Death

The class ensures that the boss behaves realistically in the game world, moves according to boundaries, and triggers proper animations.

🔹 Key Features

Health & Death:

- Tracks boss health (BossHealth)

- When health ≤ 0, triggers Death() state with falling animation and death frames

Flying Behavior:

- Moves up/down and left/right between defined boundaries

- Patrol logic with IsFlyingRight flag to switch directions

- Smooth flying animation via FlyLeft.Animate()

Walking Behavior:

- Moves left with walking animation via WalkLeft.Animate()

- State Machine Logic:

- Logic_StateMachine() method checks boss health and current state, then triggers the appropriate behavior method (WalkLeft, FlyBoss, FlyDown, Death)

Animations:

- Separate Animation objects for walking, flying, and death

- Handles frame updates and frame counters to create smooth animation sequences

Reusable Movement Methods:

- MoveLeft(), MoveBasic(), FlyOrPatrol() for modular movement logic

🔹 How It Works:

- The Logic_StateMachine() is called each game update cycle.

- Depending on the boss’s state and health, the class executes one of the movement or animation methods.

Each behavior method manages:

- Position (x, y) updates

- Direction and boundary checks

- Animation frame updates

- This allows the boss to walk, fly, patrol, or die smoothly, while keeping AI logic decoupled from rendering.

🔹 Technologies & Concepts Used

- C# and OOP principles

- State Machine pattern for managing boss actions

- Animation handling with frame counters

- Separation of Concerns: AI and logic separate from rendering

- Modular movement methods for reusable code
