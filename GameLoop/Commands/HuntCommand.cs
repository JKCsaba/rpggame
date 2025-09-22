using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rpggame.GameLoop;

namespace rpggame.GameLoop.Commands
{
    public class HuntCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, SaveLoadManager saveLoadManager, string[] args)
        {
            EnemyFactory _enemyFactory = new();
            Enemy _enemy = _enemyFactory.CreateRandEnemy(player);

            Combat _combat = new(player, _enemy);

            (string answer, bool lvlup) = _combat.Fight();
            if (lvlup) { shopManager.Fill(player.CurrentLevel()); answer += " The shop's stock has been refreshed."; }
            return answer;

        }
    }
}
