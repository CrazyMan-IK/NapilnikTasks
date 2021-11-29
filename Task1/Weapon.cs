using System;

namespace Task1
{
    public class Weapon
    {
        private readonly int _damage = 0;

        public int Bullets { get; private set; }

        public Weapon(int damage, int bulletsPerMagazine)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }
            if (bulletsPerMagazine < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bulletsPerMagazine));
            }

            _damage = damage;

            Bullets = bulletsPerMagazine;
        }

        public bool CannotFire()
        {
            return Bullets <= 0;
        }

        public void Fire(IDamageable target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (CannotFire())
            {
                throw new InvalidOperationException();
            }

            target.TakeDamage(_damage);

            Bullets -= 1;
        }
    }
}
