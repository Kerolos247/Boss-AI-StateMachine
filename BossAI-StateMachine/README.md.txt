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
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp26.GameStates;

namespace WindowsFormsApp26
{
    internal class Boss : CreatureActions
    {
        // ====== Constants ======
        private const int DeathFallLimitY = 620;
        private const int FlyUpLimitY = 20;
        private const int LeftFlyBoundaryX = 8700;
        private const int RightFlyBoundaryX = 10000;
        private const int WalkSpeed = 3;
        private const int FlySpeed = 5;
        private const int DeathAnimFrameThreshold = 30;

        // ====== Properties ======
        public int BossHealth = 100;
        public bool IsFlyingRight = false;
        public BossState State = BossState.Idle;

        public Animation WalkLeft = new Animation();
        public Animation FlyLeft = new Animation();
        public Animation DeathAnim = new Animation();

        // ====== State Machine ======
        public void Logic_StateMachine()
        {
            if (BossHealth <= 0)
            {
                Death();
                return;
            }

            switch (State)
            {
                case BossState.DownFly:
                    FlyDown();
                    break;
                case BossState.Fly:
                    FlyBoss();
                    break;
                case BossState.WalkLeft:
                    AnimateWalkLeft();
                    break;
                default:
                    break;
            }
        }

        // ====== Death ======
        public override void Death()
        {
            State = BossState.Death;

            if (y < DeathFallLimitY)
            {
                MoveDownOnDeath();
            }
            else
            {
                AnimateDeath();
            }
        }

        void MoveDownOnDeath() => y += FlySpeed;

        void AnimateDeath()
        {
            DeathAnim.FrameCounter++;
            if (DeathAnim.FrameCounter >= DeathAnimFrameThreshold)
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
            if (y > FlyUpLimitY)
            {
                y -= FlySpeed; //---> Fly up
            }
            else if (x > LeftFlyBoundaryX && !IsFlyingRight)
            {
                x -= FlySpeed; //---> Move left
            }
            else
            {
                IsFlyingRight = true;
                x += FlySpeed; //---> Move right
                if (x >= RightFlyBoundaryX)
                    IsFlyingRight = false;
            }
        }

        // ====== Walk Left ======
        void AnimateWalkLeft()
        {
            WalkLeft.Animate(4);
            MoveLeft();
        }

        public override void MoveLeft() => x -= WalkSpeed;

        // ====== Move Basic ======
        public override void MoveBasic()
        {
            if (y < DeathFallLimitY)
            {
                y += FlySpeed; // Fly down
            }
            else
            {
                State = BossState.Fly;
            }
        }
    }
}
