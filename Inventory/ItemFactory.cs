using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.Inventory
{
    public class ItemFactory
    {
        private static Random _random = new();

        public Item CreateRandItem(TypeEnum type, int points)
        {
            switch (type)
            {
                case TypeEnum.Food:
                    Array foodNames = Enum.GetValues(typeof(FoodEnum));
                    string foodName = foodNames.GetValue(_random.Next(foodNames.Length)).ToString();
                    return new Food(foodName, points);
                case TypeEnum.Weapon:
                    Array weaponNames = Enum.GetValues(typeof(WeaponEnum));
                    string weaponName = weaponNames.GetValue(_random.Next(weaponNames.Length)).ToString();
                    return new Weapon(weaponName, points);
                case TypeEnum.Armor:
                    Array armorNames = Enum.GetValues(typeof(ArmorEnum));
                    string armorName = armorNames.GetValue(_random.Next(armorNames.Length)).ToString()+" armor";
                    return new Armor(armorName, points);
                default:
                    throw new Exception("Invalid Item type.");
            }
        }
        public Item CreateRandTypeItem(int points)
        {
            int item = _random.Next(3);

            switch (item)
            {
                case 0:
                    return this.CreateRandItem(TypeEnum.Food, points);
                case 1:
                    return this.CreateRandItem(TypeEnum.Weapon, points);
                case 2:
                    return this.CreateRandItem(TypeEnum.Armor, points);
                default:
                    throw new Exception("Invalid Item type.");
            }
        }
    }
}