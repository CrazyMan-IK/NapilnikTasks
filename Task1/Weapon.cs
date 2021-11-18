namespace Task1
{
    class Weapon
    {
        public int Damage;
        public int Bullets;

        public void Fire(Player player)
        {
            player.Health -= Damage;
            Bullets -= 1;
        }
    }
}
