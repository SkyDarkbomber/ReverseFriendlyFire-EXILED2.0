using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using System;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace ReverseFriendlyFire_EXILED
{
    public class ReverseFriendlyFire : Plugin<Config>
    {      
        private static readonly Lazy<ReverseFriendlyFire> LazyInstance = new Lazy<ReverseFriendlyFire>(valueFactory: () => new ReverseFriendlyFire());
        public static ReverseFriendlyFire Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.High;

        private Handlers.Player player;

        private ReverseFriendlyFire()
        {

        }

        public override void OnEnabled()
        {
            RegisterEvents();            
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            

            Player.Hurting += player.OnFriendlyFire;
            Player.Hurting += player.OnFriendlyFireActivate;


        }

        public void UnregisterEvents()
        {
            player = new Handlers.Player();
            

            Player.Hurting -= player.OnFriendlyFire;
            Player.Hurting -= player.OnFriendlyFireActivate;

        }
    }



        


}
