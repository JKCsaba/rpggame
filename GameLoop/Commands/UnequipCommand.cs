using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop.Commands
{
    public class UnequipCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, string[] args)
        {
            if (args.Length == 0)
            {
                return "Please specify whether you want to unequip your armor or your weapon.";
            }
            if (args[0].ToLower() == "armor")
            {
                if (player.EquippedArmor == null) return "Your armorslot is already empty!";
                else
                {
                    player.UnequipArmor();
                    return "Armor unequipped.";
                }
            }
            else if (args[0].ToLower() == "weapon")
            {
                if (player.EquippedWeapon == null) return "Your weaponslot is already empty!";
                else
                {
                    player.UnequipWeapon();
                    return "Weapon unequipped.";
                }
            }
            else return "Invalid slotname (Use armor/weapon)";
        }
    }
}