// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class ConnectionMonitorData
    {
        // 1.15.0 generated IReadOnlyList<T> properties; the native flattened properties expose IList<T>.
        // Preserve the released interface with read-only views of the deserializer's backing lists.

        /// <summary> List of connection monitor endpoints. </summary>
        [CodeGenMember("Endpoints")]
        [WirePath("properties.endpoints")]
        public IReadOnlyList<ConnectionMonitorEndpoint> Endpoints
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectionMonitorEndpoint>(properties.Endpoints);
            }
        }

        /// <summary> List of connection monitor outputs. </summary>
        [CodeGenMember("Outputs")]
        [WirePath("properties.outputs")]
        public IReadOnlyList<ConnectionMonitorOutput> Outputs
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectionMonitorOutput>(properties.Outputs);
            }
        }

        /// <summary> List of connection monitor test configurations. </summary>
        [CodeGenMember("TestConfigurations")]
        [WirePath("properties.testConfigurations")]
        public IReadOnlyList<ConnectionMonitorTestConfiguration> TestConfigurations
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectionMonitorTestConfiguration>(properties.TestConfigurations);
            }
        }

        /// <summary> List of connection monitor test groups. </summary>
        [CodeGenMember("TestGroups")]
        [WirePath("properties.testGroups")]
        public IReadOnlyList<ConnectionMonitorTestGroup> TestGroups
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<ConnectionMonitorTestGroup>(properties.TestGroups);
            }
        }
    }
}
