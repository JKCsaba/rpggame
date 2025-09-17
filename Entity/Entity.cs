using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.Entity
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public int BaseHp { get; protected set; }
        public int CurrentHp { get; protected set; }
        public int BaseAtk { get; protected set; }
        public bool Alive => this.CurrentHp > 0; //this shit is called expression-bodied member and is just a get returning true if currenthp > 0

        protected Entity(string Name, int Hp, int Atk)
        {
            this.Name = Name;
            this.BaseHp = Hp;
            this.CurrentHp = Hp;
            this.BaseAtk = Atk;
        }
        public virtual void TakeDamage(int dm)
        {
            if (dm > 0)
            {
                this.CurrentHp -= dm;
            }
            if (this.CurrentHp < 0)
            {
                this.CurrentHp = 0;
            }
        }

    }
}