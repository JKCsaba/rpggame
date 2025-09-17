using rpggame.Entity;
using rpggame.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    public class EquipCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, string[] args)
        {
            if (args.Length == 0)
            {
                return "Please specify the number of the item you want to equip.";
            }
            int sl = player.IsAValidSlot(args[0]);
            if (sl == -1) return "Invalid itemslot";
            Item item = player.Inventory[sl - 1];
            switch (item.Type)
            {
                case TypeEnum.Food:
                    return $"You cant equip a food bruh.";
                case TypeEnum.Armor:
                    int oldh = player.MaxHp();
                    player.EquipArmor((Armor)item);
                    return $"Equipped {player.EquippedArmorName()} Total Hp changed from {oldh} to {player.MaxHp()}";
                case TypeEnum.Weapon:
                    int olda = player.FinalAtk();
                    player.EquipWeapon((Weapon)item);
                    return $"Equipped {player.EquippedWeaponName()} Atk changed from {olda} to {player.FinalAtk()}";
            }
            return "SZOPD KI A GECIM NEM CSINÁLTAM MEG MÉG EZT BAZEG";
        }
    }
}