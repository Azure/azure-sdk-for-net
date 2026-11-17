// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class EffectiveConnectivityConfiguration
    {
        // Shared input/output property bags generate IList; the released effective view is read-only.
        /// <summary> Groups affected by this connectivity configuration. </summary>
        [CodeGenMember("AppliesToGroups")]
        [WirePath("properties.appliesToGroups")]
        public IReadOnlyList<ConnectivityGroupItem> AppliesToGroups
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectivityGroupItem>(properties.AppliesToGroups);
            }
        }

        /// <summary> Hubs associated with this connectivity configuration. </summary>
        [CodeGenMember("Hubs")]
        [WirePath("properties.hubs")]
        public IReadOnlyList<ConnectivityHub> Hubs
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectivityHub>(properties.Hubs);
            }
        }
    }
}
