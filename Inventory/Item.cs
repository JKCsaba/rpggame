using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.Inventory
{
    public abstract class Item
    {
        public Guid Id { get; }
        public string Name { get; }
        public TypeEnum Type { get; }
        public int Points { get; }
        protected Item(string Name, TypeEnum Type, int Points)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Type = Type;
            this.Points = Points;
        }
    }
    public class Food : Item
    {
        public Food(string Name, int Points) : base(Name, TypeEnum.Food, Points){}
    }

    public class Weapon : Item
    {
        public Weapon(string Name, int Points) : base(Name, TypeEnum.Weapon, Points) { }
    }

    public class Armor : Item
    {
        public Armor(string Name, int Points) : base(Name, TypeEnum.Armor, Points) { }
    }
}