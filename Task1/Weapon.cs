using System;

namespace Task1
{
    public class Weapon
    {
        private readonly int _damage = 0;
        private readonly int _bulletsPerMagazine = 0;

        public int CurrentBulletsCount { get; private set; }
        public bool NeedReloading => CurrentBulletsCount <= 0;

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

            CurrentBulletsCount = bulletsPerMagazine;
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

            CurrentBulletsCount -= 1;
        }

        public void Reload()
        {
            CurrentBulletsCount = _bulletsPerMagazine;
        }
    }
}
