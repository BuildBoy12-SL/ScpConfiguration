// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpConfiguration
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Interfaces;
    using UnityEngine;

    /// <inheritdoc />
    public class Config : IConfig
    {
        private Dictionary<RoleType, byte> scp207Amounts = new Dictionary<RoleType, byte>
        {
            { RoleType.Scp93953, 1 },
            { RoleType.Scp93989, 1 },
        };

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the amount of damage a Scp939 damage deals.
        /// </summary>
        public float Scp939Damage { get; set; } = 60f;

        /// <summary>
        /// Gets or sets a collection of roles with corresponding Scp207 amounts.
        /// </summary>
        public Dictionary<RoleType, byte> Scp207Amounts
        {
            get => scp207Amounts;
            set
            {
                foreach (KeyValuePair<RoleType, byte> kvp in value.ToList())
                    value[kvp.Key] = (byte)Mathf.Clamp(value[kvp.Key], 1, 4);

                scp207Amounts = value;
            }
        }
    }
}