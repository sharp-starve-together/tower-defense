﻿using System;
using System.Drawing;
using Tower2;

namespace tower_defense_domain.bullets
{
    public abstract class AbstractBullet : IBullet
    {
        private readonly IEnemy target;
        public Point Location { get; set; }
        public int Damage { get; set; }
        private int speed = 50;

        public string NameImage { get { return "Bullet.png"; } set { } }

        public AbstractBullet(IEnemy target, Point location, int damage)
        {
            this.target = target;
            Location = location;
            Damage = damage;
        }

        public State Move()
        {
            var vector = new Point(target.Location.X - Location.X, target.Location.Y - Location.Y);
            var angle = Math.Atan2(vector.Y, vector.X);
            Location = new Point
            {
                X = Location.X + (int)Math.Round(speed * Math.Cos(angle)),
                Y = Location.Y + (int)Math.Round(speed * Math.Sin(angle))
            };
            if (NearEnemy(angle))
            {
                DealDamage();
                return State.die;
            }
            return State.go;
        }

        private bool NearEnemy(double angle)
        {
            return Math.Abs(Location.X - target.Location.X) <=speed/2 && Math.Abs(Location.Y - target.Location.Y) <= speed/2;
        }

        public void DealDamage()
        {
            target.TakeDamage(Damage);
        }
    }
}
