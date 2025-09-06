// =======================================
// Boss Class
// ---------------------------------------
// This class is responsible only for:
// 1. AI logic (decision making and behavior)
// 2. State Machine for each action (Walk, Fly, DownFly, Death)
// Note: Rendering (drawing) is handled by another class, e.g., GameController/Renderer
// =======================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static WindowsFormsApp26.GameStates;

namespace WindowsFormsApp26
{
    internal class Boss : CreatureActions
    {
        public int Volume_blood_boss = 100;
        public bool RightFly = false;

        public BossState State = BossState.Idle;

        public Animation WalkLeft = new Animation();
        public Animation FlyLeft = new Animation();
        public Animation DeathAnim = new Animation();

        // ====== State Machine ======
        public void Logic_StateMachine(Graphics g, int Xscroll)
        {
            if (Volume_blood_boss <= 0)
            {
                Death();
                return;
            }
            switch (State)
            {
                case BossState.DownFly:
                    FlyDown(); break;
                case BossState.Fly:
                    FlyBoss(); break;
                case BossState.WalkLeft:
                    AnimateWalkLeft(); break;
                default:
                 break;
            }
        }

        // ====== Death ======
        public override void Death()
        {
            State = BossState.Death;
            if (y < 620)
            {
                MoveDownOnDeath();
            }
            else
            {
                AnimateDeath();
            }
        }

        void MoveDownOnDeath() => y += 5;

        void AnimateDeath()
        {
            DeathAnim.FrameCounter++;
            if (DeathAnim.FrameCounter >= 30)
            {
                if (DeathAnim.CurrentFrame < DeathAnim.Frames.Count - 1)
                    DeathAnim.CurrentFrame++;
                DeathAnim.FrameCounter = 0;
            }
        }

        // ====== Fly Down ======
        public override void FlyDown()
        {
            MoveBasic();
        }
        // ====== Fly ======
        public override void Fly()
        {
            FlyOrPatrol();
        }

        public void FlyBoss()
        {
            FlyLeft.Animate(4);
            Fly();
        }

        public override void FlyOrPatrol()
        {
            if (y > 20)
                y -= 5; //--->Fly up
            else if (x > 8700 && !RightFly)
                x -= 5; //--->Move Left
            else
            {
                RightFly = true;
                x += 5; // --->Move Right
                if (x >= 10000)
                    RightFly = false;
            }
        }

        // ====== Walk Left ======
        void AnimateWalkLeft()
        {
            WalkLeft.Animate(4);
            MoveLeft();
           
        }

        public override void MoveLeft() => x -= 3;
        // ====== Move Basic ======
        public override void MoveBasic()
        { 
            if(y<670)
            {
                y += 5;// Fly down--->الطيران للاسفل
            }
            else
            {
                State = GameStates.BossState.Fly;
            }
        }
    }
}

