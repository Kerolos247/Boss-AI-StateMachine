using System.Collections.Generic;
using System.Drawing;
enum BossState
{
    Idle,
    WalkLeft,
    Fly,
    DownFly,
    Death
}
class BigBoss
{
    public int x, y;
    public int ifram_walk_left, ifram_fly_left, ifram_death;
    public List<Bitmap> walk_left, fly_left, death;

    public BossState State { get; set; } = BossState.Idle;

    // Helpers
    private int slow = 0;
    private int slow_fly = 0;
    private int cv = 0, e = 0;
    private int count_vib = 0;

    public void Update(ref int Xscroll, Hero hero, ref bool lose_boss, ref int Volume_blood_boss, ref int finish)
    {
        switch (State)
        {
            case BossState.WalkLeft:
                WalkLeft(ref Xscroll);
                break;

            case BossState.Fly:
                Fly(ref Xscroll);
                break;

            case BossState.DownFly:
                DownFly(ref Xscroll, hero, ref Volume_blood_boss);
                break;

            case BossState.Death:
                DeathState(ref Xscroll, ref lose_boss, ref finish);
                break;

            case BossState.Idle:
            default:
               
                break;
        }
    }

    public void Draw(Graphics g, int Xscroll)
    {
        Bitmap img = null;
        switch (State)
        {
            case BossState.WalkLeft:
                img = walk_left[ifram_walk_left];
                break;

            case BossState.Fly:
                img = fly_left[ifram_fly_left];
                break;

            case BossState.DownFly:
                img = fly_left[ifram_fly_left];
                break;

            case BossState.Death:
                img = death[ifram_death];
                break;

            case BossState.Idle:
                img = walk_left[0]; // idle frame
                break;
        }

        if (img != null)
            g.DrawImage(img, x - Xscroll, y);
    }

    private void WalkLeft(ref int Xscroll)
    {
        x -= 3;
        slow++;
        if (slow == 4)
        {
            slow = 0;
            ifram_walk_left = (ifram_walk_left + 1) % walk_left.Count;
        }
    }

    private void Fly(ref int Xscroll)
    {
        slow_fly++;
        if (y > 20) y -= 5;
        else if (x > 8700) x -= 5;
        else x += 5;

        if (slow_fly == 4)
        {
            ifram_fly_left = (ifram_fly_left + 1) % fly_left.Count;
            slow_fly = 0;
        }
    }

    private void DownFly(ref int Xscroll, Hero hero, ref int Volume_blood_boss)
    {
        if (y < 620) y += 5;
        else
        {
            int heroXe = hero.hero_ideal[0].x;
            int heroYe = hero.hero_ideal[0].y;
            int margin = 10;

            if (heroXe >= (x - 400 - Xscroll) - margin && heroYe == 647)
            {
                Volume_blood_boss -= 5;
            }

            count_vib++;
            if (count_vib == 30)
            {
                count_vib = 0;
                State = BossState.WalkLeft; 
            }

            ShakeScreen(ref Xscroll);
        }
    }

    private void DeathState(ref int Xscroll, ref bool lose_boss, ref int finish)
    {
        lose_boss = true;

        if (y < 620) y += 5;
        else if (finish != 1)
        {
            count_vib++;
            if (count_vib == 30)
            {
                finish = 1;
                count_vib = 0;
            }
            ShakeScreen(ref Xscroll);
        }
        else
        {
            e++;
            if (e == 30)
            {
                if (ifram_death < death.Count - 1)
                    ifram_death++;
                e = 0;
            }
        }
    }

    private void ShakeScreen(ref int Xscroll)
    {
        // اهتزاز الشاشة
        if (cv % 2 == 0) Xscroll += 30;
        else Xscroll -= 30;

        cv++;
        if (cv == 5) cv = 0;
    }
}
