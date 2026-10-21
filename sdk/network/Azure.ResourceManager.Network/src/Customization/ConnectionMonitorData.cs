// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("ConnectionMonitorType")]
    [CodeGenSuppress("MonitorType")]
    public partial class ConnectionMonitorData
    {
        /// <summary> List of connection monitor endpoints. </summary>
        [CodeGenMember("Endpoints")]
        [WirePath("properties.endpoints")]
        public IReadOnlyList<ConnectionMonitorEndpoint> Endpoints =>
            Properties is null ? default : new ReadOnlyCollection<ConnectionMonitorEndpoint>(Properties.Endpoints);

        /// <summary> List of connection monitor outputs. </summary>
        [CodeGenMember("Outputs")]
        [WirePath("properties.outputs")]
        public IReadOnlyList<ConnectionMonitorOutput> Outputs =>
            Properties is null ? default : new ReadOnlyCollection<ConnectionMonitorOutput>(Properties.Outputs);

        /// <summary> List of connection monitor test configurations. </summary>
        [CodeGenMember("TestConfigurations")]
        [WirePath("properties.testConfigurations")]
        public IReadOnlyList<ConnectionMonitorTestConfiguration> TestConfigurations =>
            Properties is null ? default : new ReadOnlyCollection<ConnectionMonitorTestConfiguration>(Properties.TestConfigurations);

        /// <summary> List of connection monitor test groups. </summary>
        [CodeGenMember("TestGroups")]
        [WirePath("properties.testGroups")]
        public IReadOnlyList<ConnectionMonitorTestGroup> TestGroups =>
            Properties is null ? default : new ReadOnlyCollection<ConnectionMonitorTestGroup>(Properties.TestGroups);

        /// <summary> Type of connection monitor. </summary>
        public ConnectionMonitorType? ConnectionMonitorType => Properties?.ConnectionMonitorType;
    }
}
