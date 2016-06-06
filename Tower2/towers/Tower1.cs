﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_defense_domain.bullets;

namespace tower_defense_domain.towers
{
    public class Tower1 : AbstractTower
    {
        protected override IBullet createBullet(IEnemy enemy)
        {
            return new Bullet1(enemy, Location, 3);
        }

        protected override void SetTimerReload()
        {
            timerReload = 10;
        }

        public Tower1(Point location, int range, int atackSpeed)
            : base(location, range, atackSpeed)
        { }
    }
}
