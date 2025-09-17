using rpggame.Entity;
using rpggame.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    public class EatCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, string[] args)
        {
            if (args.Length == 0)
            {
                return "Please specify the item's number you want to eat.";
            }
            int sl = player.IsAValidSlot(args[0]);
            if (sl == -1) return "Invalid itemslot";
            return player.Eat(sl);
        }
    }
}
