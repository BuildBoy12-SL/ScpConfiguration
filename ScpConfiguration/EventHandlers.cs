// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpConfiguration
{
    using Exiled.Events.EventArgs;
    using ScpConfiguration.Components;
    using UnityEngine;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingRole(ChangingRoleEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.GameObject.TryGetComponent(out MovementBoostUpdate scp207Update))
                Object.Destroy(scp207Update);

            if (plugin.Config.MovementBoostAmounts.ContainsKey(ev.NewRole))
                ev.Player.GameObject.AddComponent<MovementBoostUpdate>();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnHurting(HurtingEventArgs)"/>
        public void OnHurting(HurtingEventArgs ev)
        {
            AdjustScp939Damage(ev);
        }

        private void AdjustScp939Damage(HurtingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Attacker.Role.Type.Is939())
                ev.Amount = plugin.Config.Scp939Damage;
        }
    }
}