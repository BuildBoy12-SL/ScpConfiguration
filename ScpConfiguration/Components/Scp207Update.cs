// -----------------------------------------------------------------------
// <copyright file="Scp207Update.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpConfiguration.Components
{
    using CustomPlayerEffects;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using UnityEngine;

    /// <inheritdoc />
    public class Scp207Update : MonoBehaviour
    {
        private Player player;
        private Scp207 scp207;

        private void OnHurting(HurtingEventArgs ev)
        {
            if (player == ev.Target && ev.Handler.Type == DamageType.Scp207)
                ev.IsAllowed = false;
        }

        private void Awake()
        {
            player = Player.Get(gameObject);
            scp207 = player.ReferenceHub.playerEffectsController.GetEffect<Scp207>();
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
        }

        private void FixedUpdate()
        {
            if (!scp207.IsEnabled && Plugin.Instance.Config.Scp207Amounts.TryGetValue(player.Role, out byte intensity))
            {
                scp207.Intensity = --intensity;
                player.EnableEffect(scp207);
            }
        }

        private void OnDestroy()
        {
            player.DisableEffect<Scp207>();
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
        }
    }
}