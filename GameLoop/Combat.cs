using rpggame.Entity;
using rpggame.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop
{
    public class Combat
    {
        Player _player;
        Enemy _enemy;
        Random _random = new();
        ItemFactory _itemFactory = new();

        public Combat(Player _player, Enemy _enemy)
        {
            this._player = _player;
            this._enemy = _enemy;
        }

        public (string result, bool lvlup) Fight()
        {
            bool lvlup = false;

            int inflicted = 0;
            int taken = 0;
            int drop = _random.Next(5);

            while (_player.Alive && _enemy.Alive)
            {
                int p = _player.FinalAtk();
                _enemy.TakeDamage(p);
                inflicted += p;

                if (_enemy.Alive)
                {
                    int e = _enemy.BaseAtk;
                    _player.TakeDamage(e);
                    taken += e;
                }
            }
            if (_player.Alive)
            {
                int oldlv = _player.CurrentLevel();
                _player.AddXp(_enemy.XpDrop);
                _player.AddWin();
                string result = $"You've ecnountered a(n) {_enemy.Name} and defeated it.\nYou inflicted {inflicted} damage and have taken {taken} damage.\nRemaining Hp:{_player.CurrentHp}\n\nYou have recieved {_enemy.XpDrop} Xp.";
                if (drop >= 3)
                {
                    _player.AddGold(_enemy.GoldDrop);
                    result += $"\nYou found {_enemy.GoldDrop} Gold.";
                }
                if (drop == 4)
                {
                    Item newitem = _itemFactory.CreateRandTypeItem(_enemy.PointDrop);
                    _player.AddItem(newitem);
                    result += $"\nYou found a(n) {newitem.Name} with a strength of {newitem.Points}.";
                }
                if (_player.CurrentLevel() > oldlv) { result += $"\n\nYou have reached level {_player.CurrentLevel()}. You've recieved {_player.CurrentLevel()} extra Golds."; lvlup = true; }
                _player.AddGold(_player.CurrentLevel());
                return (result,lvlup);
            }
            else return ($"You have been defeated by a(n) {_enemy.Name}\nYou inflicted {inflicted} damage and have taken {taken} damage", false);
        }
    }
}