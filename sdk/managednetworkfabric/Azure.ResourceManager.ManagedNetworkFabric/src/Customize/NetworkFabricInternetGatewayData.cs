// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // 1. The service has duplicate gateway type properties: type and internetGatewayType.
    // 2. We suppress the less descriptive generated Type property and keep InternetGatewayType as the current property.
    // 3. Without this customization, the SDK would expose both Type and InternetGatewayType for the same service value.
    [CodeGenSuppress("Type")]
    public partial class NetworkFabricInternetGatewayData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="typePropertiesType"> Type of Gateway. </param>
        /// <param name="networkFabricControllerId"> Resource ID of the network fabric controller. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricInternetGatewayData(AzureLocation location, InternetGatewayType typePropertiesType, ResourceIdentifier networkFabricControllerId)
        {
            throw new NotSupportedException("This constructor is obsolete and will be removed in a future version.");
        }

        /// <summary> IPv4 Address of Internet Gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv4Address is deprecated, use IPV4Address instead")]
        public IPAddress IPv4Address
        {
            get => throw new NotSupportedException("IPv4Address is deprecated, use IPV4Address instead.");
        }

        // 1. The new API version replaced the shipped TypePropertiesType property with InternetGatewayType.
        // 2. We keep the obsolete TypePropertiesType property and redirect it to InternetGatewayType.
        // 3. Without this custom code, the shipped TypePropertiesType API surface would be removed.
        /// <summary> Gateway Type of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use InternetGatewayType instead.")]
        public InternetGatewayType TypePropertiesType
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use InternetGatewayType instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use InternetGatewayType instead.");
        }
    }
}
