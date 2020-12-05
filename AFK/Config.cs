using System.ComponentModel;

using Exiled.API.Interfaces;

namespace AFK
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How many players until the command doesnt work?")]
        public int Maxplayers { get; set; } = 10;

        [Description("What is the message given to a player when they are added to afk players?")]
        public string AddedToAFK { get; set; } = "You have been added to afk players.\nYou will not respawn.";

        [Description("What is the message given to a player when they are removed from afk players?")]
        public string RemovedFromAFK { get; set; } = "You have been removed from afk players.\nYou may now respawn.";
    }
}