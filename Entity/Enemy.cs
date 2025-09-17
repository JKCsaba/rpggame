using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.Entity
{
    public class Enemy : Entity
    {
        public int XpDrop { get; private set; }
        public int GoldDrop { get; private set; }
        public int PointDrop { get; private set; }
        public Enemy(string Name, int Hp,int Atk, int xpdrop, int golddrop, int pointdrop) : base(Name,Hp,Atk)
        {
            XpDrop = xpdrop;
            GoldDrop = golddrop;
            PointDrop = pointdrop;
        }

    }
}