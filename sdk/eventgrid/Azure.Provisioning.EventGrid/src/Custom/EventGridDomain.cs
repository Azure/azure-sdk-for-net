// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// EventGridDomain.
/// </summary>
public partial class EventGridDomain
{
    /// <summary>
    /// The Sku name of the resource. The possible values are: Basic or Premium.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<EventGridSku> SkuName
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }

#nullable disable

    /// <summary> Gets the private endpoint connections. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections =>
        Properties is null ? default : Properties.PrivateEndpointConnections;

#nullable enable

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
