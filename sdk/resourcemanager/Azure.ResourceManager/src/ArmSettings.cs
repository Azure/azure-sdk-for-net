// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Represents settings used to configure an <see cref="ArmClient"/>.
    /// </summary>
    public sealed class ArmSettings : ClientSettings
    {
        /// <summary>
        /// Gets or sets the default subscription ID.
        /// </summary>
        public string DefaultSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ArmClientOptions"/>.
        /// </summary>
        public ArmClientOptions Options { get; set; }

        /// <inheritdoc/>
        protected override void BindCore(IConfigurationSection section)
        {
            DefaultSubscriptionId = section["DefaultSubscriptionId"];
            // for schema should we have a layer for ClientOptions section.GetSection("ClientOptions")
            Options = new ArmClientOptions(section.GetSection("Options"));
        }
    }
}
