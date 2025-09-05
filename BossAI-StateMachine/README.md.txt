# 🎮 Boss AI State Machine  

This repository showcases the **AI State Machine** implementation for a custom Boss Fight in my 2D game built with **C# Windows Forms**.  
Instead of sharing the entire project (thousands of lines of code), here I highlight the most important part:  
the **artificial intelligence system** that drives the boss’s behavior.  

## 🚀 Features of the Boss AI
- **Finite State Machine (FSM)** to control boss behavior (Idle, Walk, Fly, Attack, Death). 
-Idle → WalkLeft → Fly → DownFly → WalkLeft → Death.
- Smooth **state transitions** with animations.  
- Dynamic **player interaction** (boss reacts based on hero’s position).  
- **Screen shake effect** for dramatic impact.  
- Easy-to-extend architecture for adding new behaviors.  

## 🎥 Demo Video  
[Watch the boss fight on LinkedIn](https://www.linkedin.com/posts/kerolos-adel-190948375_gamedevelopment-csharp-backenddeveloper-activity-7351989946074701824-Umsv?utm_source=share&utm_medium=member_desktop&rcm=ACoAAFzdtvwBqq9LIvH0ErzLfci3qroeYaCnOjY)

## 💻 Source Code  
The AI logic is available in [`src/BossAI.cs`](src/BossAI.cs).  

## ℹ️ Notes  
- This is a **highlighted part** of a full custom game project (graphics, animations, controls, sounds, etc.).  
- The focus here is on the **AI and State Machine design**, which makes the boss fight challenging and engaging.  
- The full game includes more mechanics such as bullets, traps, elevators, collectibles, and a final boss battle.  

---

⭐ If you find this project interesting, feel free to explore, learn, and connect with me!  


