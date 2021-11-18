using System;
using Xunit;
using Task1;

namespace NapilnikTasks
{
    public class Task1Test
    {
        private readonly Player _player = null;
        private readonly Weapon _weapon = null;
        private readonly Bot _bot = null;

        public Task1Test()
        {
            _player = new Player(100);
            _weapon = new Weapon(10, 5);
            _bot = new Bot(_weapon);
        }

        [Fact]
        public void CheckWeaponShooting()
        {
            _weapon.Fire(_player);

            Assert.Equal(90, _player.Health);
            Assert.Equal(4, _weapon.CurrentBulletsCount);
        }

        [Fact]
        public void CheckWeaponFireMethodException()
        {
            for (int i = 0; i < 5; i++)
            {
                _weapon.Fire(_player);
            }

            Assert.Throws<InvalidOperationException>(() => _weapon.Fire(_player));
        }

        [Fact]
        public void CheckBotOnSeePlayerHandler()
        {
            _bot.OnSeePlayer(_player);

            Assert.Equal(90, _player.Health);
            Assert.Equal(4, _weapon.CurrentBulletsCount);
        }

        [Fact]
        public void CommonTest()
        {
            while (_player.IsAlive)
            {
                _bot.OnSeePlayer(_player);
            }

            Assert.Equal(0, _player.Health);
            Assert.Equal(0, _weapon.CurrentBulletsCount);
        }
    }
}
