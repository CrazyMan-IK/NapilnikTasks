namespace Task1
{
    class Bot
    {
        public Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
