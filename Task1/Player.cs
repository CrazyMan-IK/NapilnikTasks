using System;

namespace Task1
{
    public class Player : IDamageable
    {
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public Player(int maxHealth)
        {
            Health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}
