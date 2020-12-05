using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using System.Linq;
using static AFK.AFK;

namespace AFK
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class AfkCmd : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gives a player overwatch mode to prevent afk kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);
                p.IsOverwatchEnabled = !p.IsOverwatchEnabled; // set overwatch to the player
                response = p.IsOverwatchEnabled // ? = first time doing the command. : = second time
                    ? "You have been set to overwatch mode.\nYou will not respawn."
                    : "You have been removed from overwatch mode.\nYou may now respawn.";
                return true;
            }
            if (Player.List.Count() >= Singleton.Config.Maxplayers)
            {
                response = "Too many players";
                return false;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}