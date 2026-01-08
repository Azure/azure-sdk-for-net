// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.ResourceManager
{
    /// <summary>
    /// .
    /// </summary>
    public class ArmSettings : ClientSettings
    {
        /// <summary>
        /// .
        /// </summary>
        public string DefaultSubscriptionId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public new ArmClientOptions Options { get; set; }

        /// <inheritdoc/>
        protected override void BindCore(IConfigurationSection section)
        {
            DefaultSubscriptionId = section["DefaultSubscriptionId"];
            // for schema should we have a layer for ClientOptions section.GetSection("ClientOptions")
            Options = new ArmClientOptions(section.GetSection("Options"));
        }
    }
}
