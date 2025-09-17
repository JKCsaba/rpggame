using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    internal class HelpCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, string[] args)
        {
            return "List of all available commands:\n\nstats:\t\tDisplay your stats\ninv:\t\tDisplay your inventory\nhunt:\t\tHunt in the forest\neat {ID}:\t\tEat a food item from your inventory by its ID\nequip {ID}:\t\tEquip a weapon or armor by its ID\nunequip {armor/weapon}:\tUnequip your weapon or armor\nshop:\t\tList all items being sold in the market\nsell {ID}:\t\tSell an item of yours by its ID\nbuy {ID}:\t\tBuy an item from the market by its ID\nsave {slotnr}:\t\tSave your game to a save slot\nload {slotnr}:\t\tLoad a save from a save slot.\nhelp:\t\tList all available commands\nclear:\t\tClear Console";
        }
    }   
}