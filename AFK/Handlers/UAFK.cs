namespace AFK
{
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using RemoteAdmin;
    using System;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class UAFK : ICommand
    {
        public string Command => "unafk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "removes overwatch";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);
                if (!p.CheckPermission("afk"))
                {
                    response = "message the server owner to give you the permission 'afk'";
                    return false;
                }

                p.IsOverwatchEnabled = !p.IsOverwatchEnabled;
                response = p.IsOverwatchEnabled
                    ? "You have been set to overwatch mode.\nYou will not respawn."
                    : "You have been removed from overwatch mode.\nYou may now respawn.";
                return true;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}