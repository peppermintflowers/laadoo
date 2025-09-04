_Laadoo_ is a 2 player competitive **(1v1)** game developed in **Unity** as a final project for my Game Design class.
It’s designed to be played with custom spatula-shaped controllers (built using **Arduino Leonardo** and MPU6050 accelerometers), but it also supports keyboard controls.

Players compete as Team Pink vs Team Green across 4 rounds to make and serve laadoos (round desserts).

## Repository Structure  
├── Scripts/                    # Unity C# scripts for game logic  
├── spatula_controllers.ino # Arduino code for custom spatula controllers  
└── README.md                   # This file  


## Gameplay Summary

Objective: Score points by making laadoos and serving them to the kid. Player with the most points wins.

4 rounds, each with 3 stages: Make → Tug → Serve.  
   

1. **Make Stage** _(yellow backdrop)_ – Flick the spatula toward the opponent to add ingredients. Collect red dots by moving the spatula(every 2 = 1 laadoo).  
2. **Tug Stage** _(red backdrop)_ – Move spatula left/right to pull the kid toward your side.  
3. **Serve Stage** _(blue backdrop)_ – Flick the spatula forward to serve the kid (if in front). Stun opponents by flicking toward them.  

## Controls
### Keyboard

#### Pink Team (Player 1):
W – Move forward / launch  
A – Move left  
S – Move down  
D – Move right  

#### Green Team (Player 2):
I – Move forward / launch  
J – Move left  
K – Move down  
L – Move right  

### Custom Spatula Controllers

Built using Arduino Leonardo + MPU6050 accelerometers.
Flick gestures replace keyboard inputs.

## Technologies Used

**Game Engine:** Unity  
**Programming Language:** C#  
**Hardware:** Arduino Leonardo, MPU6050 Accelerometers  
**Custom Controllers:** Bespoke spatula-shaped cardboard controllers with MPU6050 mounted on them  




