using Game4Freak.AdvancedZones;
using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQKureSistemi
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            UnturnedPlayerEvents.OnPlayerRevive += UnturnedPlayerEvents_OnPlayerRevive;
            AdvancedZones.onZoneLeave += AdvancedZones_onZoneLeave;
        }

        private void AdvancedZones_onZoneLeave(Rocket.Unturned.Player.UnturnedPlayer player, Zone zone, UnityEngine.Vector3 lastPos)
        {
            if(zone.name == "Kure")
            {
                if (!player.HasPermission("sydefq.kure"))
                {
                    player.Player.teleportToLocation(Configuration.Instance.kureSpawn, 1f);
                }
            }
        }

        private void UnturnedPlayerEvents_OnPlayerRevive(Rocket.Unturned.Player.UnturnedPlayer player, UnityEngine.Vector3 position, byte angle)
        {
            if (!player.HasPermission("sydefq.kure"))
            {
                player.Player.teleportToLocation(Configuration.Instance.kureSpawn, 1f);
            }
        }

        private void Events_OnPlayerConnected(Rocket.Unturned.Player.UnturnedPlayer player)
        {
            if (!player.HasPermission("sydefq.kure"))
            {
                player.Player.teleportToLocation(Configuration.Instance.kureSpawn, 1f);
            }
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            UnturnedPlayerEvents.OnPlayerRevive -= UnturnedPlayerEvents_OnPlayerRevive;
            AdvancedZones.onZoneLeave -= AdvancedZones_onZoneLeave;
        }

        [RocketCommand("kureayarla", "", "", AllowedCaller.Player)]
        [RocketCommandPermission("sydefq.admin")]
        public void SetGlobe(IRocketPlayer caller)
        {
            var player = caller as UnturnedPlayer;
            Configuration.Instance.kureSpawn = player.Position;
            Configuration.Save();
        }
    }
}
