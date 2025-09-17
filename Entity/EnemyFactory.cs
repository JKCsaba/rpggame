using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.Entity
{
    public class EnemyFactory
    {
        private static Random _random = new();

        public Enemy CreateRandEnemy(Player _player)
        {
            int level = _player.CurrentLevel();

            Array names = Enum.GetValues(typeof(EnemyNames));
            string name = names.GetValue(_random.Next(names.Length)).ToString();

            int enemyhp = _random.Next(15) + (level * 4);
            int enemyatk = _random.Next(15) + (level * 4);

            int xpdrop = _random.Next(10) + (level * 3);
            int golddrop = _random.Next(15) + (level * 2);
            int pointdrop = _random.Next(1,20) + level * 2;

            Enemy _enemy = new(name, enemyhp, enemyatk, xpdrop, golddrop, pointdrop);
            return _enemy;

        }
    }
}