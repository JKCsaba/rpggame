using rpggame.Entity;
using rpggame.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop
{
    public class ShopManager
    {
        ItemFactory _itemFactory = new();
        public List<Item> Stock { get; } = new();
        Random _random = new();

        public ShopManager(){}
        public string ListItems()
        {
            string answer = $"Shop's stock:\n";
            if (this.Stock.Count == 0) return answer += "Empty";
            for (int i = 0; i < Stock.Count; i++)
            {
                answer += ($"{i+1}.: {Stock[i].Name}\t\tStrength:{Stock[i].Points}\tValue:{Stock[i].Points * 2} Golds\n");
            }
            return answer;
        }
        public int IsAValidSlot(string input)
        {
            int slot;
            bool number = int.TryParse(input, out slot);
            if (!number) return -1;
            else if (slot - 1 >= this.Stock.Count || slot < 1) return -1;
            return slot;
        }
        public void AddItem(Item item)
        {
            Stock.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Stock.Remove(item);
        }
        public void Flush()
        {
            Stock.Clear();
        }
        public string Fill(int level)
        {
            this.Flush();
            for (int i = 0; i < 10; i++)
            {
                Item item = _itemFactory.CreateRandTypeItem(_random.Next(0,3) * 3 + level * _random.Next(1,5));
                this.AddItem(item);
            }
            if (Stock.Count > 0) return "The shop has been refilled with new merchandise.";
            return "Couldn't refill the shop";
        }
    }
}