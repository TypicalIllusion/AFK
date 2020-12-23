using System;

using Exiled.API.Features;
using Exiled.API.Enums;
using Server = Exiled.Events.Handlers.Server;

namespace AFK
{
    public class AFK : Plugin<Config>
    {
        public override string Name { get; } = "AFK";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 21);
        public override string Prefix { get; } = "AFK";

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public static bool enabledInGame = true;
        private AFK() { }

        private static readonly Lazy<AFK> LazyInstance = new Lazy<AFK>(valueFactory: () => new AFK()); // instance
        public static AFK Instance => LazyInstance.Value; // instance

        private Handlers.Server server;

        public void RegisterEvents()
        {
            server = new Handlers.Server();

            Server.RespawningTeam += server.OnRespawningTeam;

        }
        public void UnregisterEvents()
        {
            Server.RespawningTeam -= server.OnRespawningTeam;

            server = null;
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }
    }
}
