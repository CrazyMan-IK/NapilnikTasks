using System;

namespace Task1
{
    public class Weapon
    {
        private readonly int _damage = 0;
        private readonly int _bulletsPerMagazine = 0;

        public int Bullets { get; private set; }
        public bool NeedReloading => Bullets <= 0;

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
            _bulletsPerMagazine = bulletsPerMagazine;
        }

        public bool CannotFire()
        {
            return NeedReloading;
        }

        public void Fire(IDamageable target)
        {
            if (CannotFire())
            {
                throw new InvalidOperationException();
            }

            target.TakeDamage(_damage);

            Bullets -= 1;
        }

        public void Reload()
        {
            Bullets = _bulletsPerMagazine;
        }
    }
}
