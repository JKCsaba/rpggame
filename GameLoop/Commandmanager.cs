using rpggame.Entity;
using rpggame.GameLoop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop
{
    public class CommandManager
    {
        private readonly Dictionary<string, ICommand> _commands;
        private Player _player;
        private ShopManager _shopManager;

        public CommandManager()
        {
            _commands = new Dictionary<string, ICommand>
            {
                {"stats", new StatsCommand() },
                {"help", new HelpCommand() },
                {"inv", new InventoryCommand() },
                {"hunt", new HuntCommand() },
                {"clear", new ClearCommand() },
                {"eat", new EatCommand() },
                {"sell", new SellCommand() },
                {"buy", new BuyCommand() },
                {"shop", new ShopCommand() },
                {"equip", new EquipCommand() },
                {"unequip", new UnequipCommand() },
                {"save", new SaveCommand() },
                {"load", new LoadCommand() }
            };
        }
        public string ProcessCommand(Player player, ShopManager shopManager, string input)
        {
            string[] parts = input.Trim().ToLower().Split(' ');

            string commandName = parts[0];

            string[] args = parts.Skip(1).ToArray();

            if (_commands.ContainsKey(commandName))
            {
                return _commands[commandName].Execute(player, shopManager, args);
            }
            else
            {
                return "Unknown command. Type 'help' for a list of commands.";
            }
        }
    }
}