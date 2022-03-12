// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpConfiguration
{
    using System.Collections.Generic;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the amount of damage a Scp939 damage deals.
        /// </summary>
        public float Scp939Damage { get; set; } = 60f;

        /// <summary>
        /// Gets or sets a collection of roles with corresponding movement boost amounts.
        /// </summary>
        public Dictionary<RoleType, byte> MovementBoostAmounts { get; set; } = new Dictionary<RoleType, byte>
        {
            { RoleType.Scp93953, 1 },
            { RoleType.Scp93989, 1 },
        };
    }
}