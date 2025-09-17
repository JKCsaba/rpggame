using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    internal class ShopCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, string[] args)
        {
            string answer = shopManager.ListItems();
            answer += $"\nYou have {player.CurrentGold()} Golds.";
            return answer;
        }
        
    }
}
