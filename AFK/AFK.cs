using System;

using Exiled.API.Features;
using Exiled.API.Enums;
namespace AFK
{
    public class AFK : Plugin<Config>
    {
        public override string Name { get; } = "AFK";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);
        public override string Prefix { get; } = "AFK";

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public static bool enabledInGame = true;


        public void RegisterEvents()
        {
            
        }
        public void UnregisterEvents()
        {
            
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
