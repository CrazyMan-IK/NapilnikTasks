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
            _weapon.Fire(player);
        }
    }
}
