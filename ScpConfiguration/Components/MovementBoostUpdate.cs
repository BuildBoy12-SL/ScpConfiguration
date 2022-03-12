// -----------------------------------------------------------------------
// <copyright file="MovementBoostUpdate.cs" company="Build">
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
    public class MovementBoostUpdate : MonoBehaviour
    {
        private Player player;
        private MovementBoost movementBoost;

        private void OnHurting(HurtingEventArgs ev)
        {
            if (player == ev.Target && ev.Handler.Type == DamageType.Scp207)
                ev.IsAllowed = false;
        }

        private void Awake()
        {
            player = Player.Get(gameObject);
            movementBoost = player.ReferenceHub.playerEffectsController.GetEffect<MovementBoost>();
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
        }

        private void FixedUpdate()
        {
            if (!movementBoost.IsEnabled && Plugin.Instance.Config.MovementBoostAmounts.TryGetValue(player.Role, out byte intensity))
            {
                movementBoost.Intensity = --intensity;
                player.EnableEffect(movementBoost);
            }
        }

        private void OnDestroy()
        {
            player.DisableEffect<MovementBoost>();
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
        }
    }
}