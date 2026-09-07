// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class EventGridDomain
{
    /// <summary> Gets the private endpoint connections. </summary>
    // The generated API exposes deployable EventGridEventGridDomainPrivateEndpointConnection
    // resources. Preserve the released inline EventGridPrivateEndpointConnectionData collection.
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections =>
        Properties is null ? default : Properties.PrivateEndpointConnections;

    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-02-15". </summary>
        public static readonly string V2025_02_15 = "2025-02-15";
        /// <summary> API version "2022-06-15". </summary>
        public static readonly string V2022_06_15 = "2022-06-15";
        /// <summary> API version "2021-12-01". </summary>
        public static readonly string V2021_12_01 = "2021-12-01";
        /// <summary> API version "2020-06-01". </summary>
        public static readonly string V2020_06_01 = "2020-06-01";
        /// <summary> API version "2019-06-01". </summary>
        public static readonly string V2019_06_01 = "2019-06-01";
    }
}
