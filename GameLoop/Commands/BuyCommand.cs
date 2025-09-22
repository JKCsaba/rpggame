using rpggame.Entity;
using rpggame.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    public class BuyCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, SaveLoadManager saveLoadManager, string[] args)
        {
            if (args.Length == 0)
            {
                return "Please specify the item's number you want to eat.";
            }
            int sl = shopManager.IsAValidSlot(args[0]);
            if (sl == -1) return "Invalid itemslot";
            Item item = shopManager.Stock[sl - 1];
            if (player.Gold < (item.Points*2)) return $"You don't have enough money to buy this {item.Name}!(costs:{item.Points*2}, You have:{player.Gold})";
            player.AddItem(item);
            player.RemoveGold((item.Points * 2));
            string answer = $"You've bought a(n) {item.Name} for {item.Points * 2} Gold(s). (You have {player.Gold} Golds remaining)";
            shopManager.RemoveItem(item);
            return answer;
        }
    }
}
