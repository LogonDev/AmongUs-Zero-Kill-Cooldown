using Impostor.Api.Events;
using Impostor.Api.Events.Player;
using Microsoft.Extensions.Logging;

namespace Impostor.Plugins.Example.Handlers
{
    /// <summary>
    ///     A class that listens for two events.
    ///     It may be more but this is just an example.
    ///
    ///     Make sure your class implements <see cref="IEventListener"/>.
    /// </summary>
    public class GameEventListener : IEventListener
    {
        private readonly ILogger<ZeroKillCooldownPlugin> _logger;

        public GameEventListener(ILogger<ZeroKillCooldownPlugin> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Called when the game starts
        /// </summary>
        /// <param name="e">
        ///     The event you want to listen for.
        /// </param>
        [EventListener]
        public void OnGameStarted(IGameStartedEvent e)
        {
            //Instant kill cooldown in among us
            e.Game.Options.KillCooldown = 0.01f;
            e.Game.SyncSettingsAsync();
        }
    }
}