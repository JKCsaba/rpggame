using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rpggame.Inventory;

namespace rpggame.Entity
{
    public class Player : Entity
    {
        public int Gold { get; private set; }
        public int Xp { get; private set; }
        public int Wins { get; private set; }
        public List<Item> Inventory { get; } = new();
        private Weapon? _weaponslot = null;
        private Armor? _armorslot = null;

        public Player(string Name="Player", int Hp=100, int Atk=10) : base(Name,Hp,Atk)
        {
            Gold = 0;
            Xp = 0;
            Wins = 0;
        }

        public int CurrentLevel()
        {
            return (int)Math.Sqrt(Xp / 50.0) + 1;
        }
        public void AddXp(int xp)
        {
            this.Xp += xp;
        }
        public int XpRequiredForNextLevel()
        {
            return (int)(50.0 * Math.Pow(this.CurrentLevel(), 2));
        }
        public int XpRemainingToNextLevel()
        {
            int required = XpRequiredForNextLevel();
            int remaining = required - this.Xp;
            return remaining > 0 ? remaining : 0;
        }
        public int MaxHp()
        {
            if (_armorslot == null) return this.BaseHp;
            int mhp = this.BaseHp + _armorslot.Points;
            return mhp;
        }
        public void AddGold(int gold)
        {
            this.Gold += gold;
        }
        public void AddWin()
        {
            this.Wins++;
        }
        public void RemoveGold(int gold)
        {
            this.Gold -= gold;
        }
        #region inventory
        public string ListInventory()
        {
            string answer = $"{this.Name}'s Inventory:\n";
            if (this.Inventory.Count == 0)
            {
                answer += "Empty";
            }
            else
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    answer += ($"{i + 1}.: {Inventory[i].Name}\t\tStrength:{Inventory[i].Points}\tValue:{Inventory[i].Points * 2} Golds\n");
                }
            }
            return answer;
        }
        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }
        public int IsAValidSlot(string input)
        {
            int slot;
            bool number = int.TryParse(input, out slot);
            if (!number) return -1;
            else if (slot - 1 >= this.Inventory.Count || slot < 1) return -1;
            return slot;
        }
        //I return the itemslot itself if its valid, and i return -1 if its invalid. I just call this before calling sell or equip.
        #endregion
        public string Eat(int slot)
        {
            slot = slot - 1;
            if (this.Inventory[slot] is not Food) return $"You can't eat a(n) {this.Inventory[slot].Name}, bruh";

            int oldhp = this.CurrentHp;
            string answer = $"You've eaten a(n) { this.Inventory[slot].Name}";
            this.CurrentHp += Inventory[slot].Points;
            if (this.CurrentHp > this.MaxHp()) CurrentHp = this.MaxHp();
            int newhp = this.CurrentHp;
            int restored = newhp - oldhp;
            answer += $" and restored {restored} Hp. Your current hp is {this.CurrentHp}/{this.MaxHp()}.";
            this.RemoveItem(Inventory[slot]);
            return answer;
        }
        public int FinalAtk()
        {
            if (_weaponslot == null) return BaseAtk;
            int finalatk = BaseAtk + _weaponslot.Points;
            return finalatk;
        }
        public void EquipArmor(Armor armor)
        {
            if (this.EquippedArmor() != null)
            {
                this.AddItem(this.EquippedArmor());
            }
            this._armorslot = armor;
            this.RemoveItem(armor);
        }
        public string EquippedArmorName()
        {
            if (_armorslot == null) return "Nothing";
            return (_armorslot.Name) + " Strength: " + (_armorslot.Points);
        }
        public Item? EquippedArmor()
        {
            if (_armorslot == null) return null;
            return _armorslot;
        }
        public void UnequipArmor()
        {
            Item item = this.EquippedArmor();
            this._armorslot = null;
            if (item != null) this.AddItem(item);
            if (this.CurrentHp > this.MaxHp()) this.CurrentHp = this.MaxHp();
        }
        public void EquipWeapon(Weapon weapon)
        {
            if (this.EquippedWeapon() != null)
            {
                this.AddItem(this.EquippedWeapon());
            }
            this._weaponslot = weapon;
            this.RemoveItem(weapon);
        }
        public string EquippedWeaponName()
        {
            if (_weaponslot == null) return "Nothing";
            return (_weaponslot.Name) + " Strength: " + (_weaponslot.Points);
        }
        public Item? EquippedWeapon()
        {
            if (_weaponslot == null) return null;
            return _weaponslot;
        }
        public void UnequipWeapon()
        {
            Item item = this.EquippedWeapon();
            this._weaponslot = null;
            if (item != null) this.AddItem(item);
        }
        public string Stats()
        {
            string stats = ($"Your stats:\nName: {this.Name}\nCurrent Level: {this.CurrentLevel()} (You need {this.XpRemainingToNextLevel()} Xp for the next level)\nHp: {this.CurrentHp}/{this.MaxHp()}\t Attack: {this.FinalAtk()}\nCurrent Armor: {this.EquippedArmorName()}\nCurrent Weapon: {this.EquippedWeaponName()}\nGold:{this.Gold}\tEnemies defeated:{this.Wins}");
            return stats;
        }
    }
}