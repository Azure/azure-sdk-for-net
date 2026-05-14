// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version removed the InternetGatewayType from the constructor and changed IPv4Address
    // property type. These shims preserve the v1.1.2 constructor and property signatures.
    public partial class NetworkFabricInternetGatewayData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="typePropertiesType"> Type of Gateway. </param>
        /// <param name="networkFabricControllerId"> Resource ID of the network fabric controller. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricInternetGatewayData(AzureLocation location, InternetGatewayType typePropertiesType, ResourceIdentifier networkFabricControllerId) : base(location)
        {
            TypePropertiesType = typePropertiesType;
            NetworkFabricControllerId = networkFabricControllerId;
        }

        /// <summary> IPv4 Address of Internet Gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv4Address is deprecated, use IPV4Address instead")]
        public IPAddress IPv4Address { get; }
    }
}
