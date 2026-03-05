// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.ResourceManager
{
    /// <summary>
    /// Represents the settings used to configure an <see cref="ArmClient"/> that can be loaded from an <see cref="IConfigurationSection"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public class ArmClientSettings : ClientSettings
    {
        /// <summary>
        /// Gets or sets the default Azure subscription ID.
        /// </summary>
        public string? DefaultSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ArmClientOptions"/> used to configure the <see cref="ArmClient"/>.
        /// </summary>
        public ArmClientOptions? Options { get; set; }

        /// <inheritdoc/>
        protected override void BindCore(IConfigurationSection section)
        {
            if (section is null || !section.Exists())
            {
                return;
            }

            if (section[nameof(DefaultSubscriptionId)] is string defaultSubscriptionId)
            {
                DefaultSubscriptionId = defaultSubscriptionId;
            }

            IConfigurationSection optionsSection = section.GetSection(nameof(Options));
            if (optionsSection.Exists())
            {
                Options = new ArmClientOptions(optionsSection);
            }
        }
    }
}
