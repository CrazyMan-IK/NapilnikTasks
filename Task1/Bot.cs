using System;

namespace Task1
{
    public class Bot
    {
        private readonly Weapon _weapon = null;

        public Bot(Weapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void OnSeePlayer(Player player)
        {
            if (_weapon.CannotFire())
            {
                if (_weapon.NeedReloading)
                {
                    _weapon.Reload();
                }
            }
            _weapon.Fire(player);
        }
    }
}
