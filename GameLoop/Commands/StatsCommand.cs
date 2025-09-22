using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    public class StatsCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, SaveLoadManager saveLoadManager, string[] args)
        {
            return player.Stats();
        }
    }
}