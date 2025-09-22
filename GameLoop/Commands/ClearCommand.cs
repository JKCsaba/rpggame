using rpggame.Entity;

namespace rpggame.GameLoop.Commands
{
    public class ClearCommand : ICommand
    {
        public string Execute(Player player, ShopManager shopManager, SaveLoadManager saveLoadManager, string[] args)
        {
            Console.Clear();

            return "";
        }
    }
}