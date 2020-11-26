using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;

namespace AFK
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class BAFK : ICommand
    {
        public string Command { get; } = "afk";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "Gives a player overwatch mode to prevent afk kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);
                if (!p.CheckPermission("afk"))
                {
                    response = "you should have access to this, dm me. TypicalIllusion#5726";
                    return false;
                }

                response = "Overwatch mode added";
                p.IsOverwatchEnabled = true;
                return true;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}