using System;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;

namespace AFK
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class BAFK : ICommand
    {
        public string Command { get; } = "afk";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "adds overwatch mode";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);

                response = "Overwatch mode added";
                p.IsOverwatchEnabled = false;
                return true;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}