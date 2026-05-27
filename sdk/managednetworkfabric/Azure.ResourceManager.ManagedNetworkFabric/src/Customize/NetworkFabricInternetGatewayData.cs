// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the TypeSpec migration. The generated model no longer includes
    // the old constructor and cannot attach the shipped Obsolete attribute to IPv4Address. The generated
    // TypePropertiesType is nullable because the service marks it optional, but the shipped SDK exposed a
    // non-nullable property. Removing this file would break callers that use the old InternetGatewayType
    // constructor, the IPV4Address alias, or the non-nullable TypePropertiesType property.
    [CodeGenSuppress("IPv4Address")]
    [CodeGenSuppress("TypePropertiesType")]
    public partial class NetworkFabricInternetGatewayData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="typePropertiesType"> Type of Gateway. </param>
        /// <param name="networkFabricControllerId"> Resource ID of the network fabric controller. </param>
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricInternetGatewayData(AzureLocation location, InternetGatewayType typePropertiesType, ResourceIdentifier networkFabricControllerId) : this(location, networkFabricControllerId)
        {
            TypePropertiesType = typePropertiesType;
        }

        /// <summary> IPv4 Address of Internet Gateway. </summary>
        [Obsolete("IPv4Address is deprecated, use IPV4Address instead")]
        public IPAddress IPv4Address => Properties?.IPv4Address;

        /// <summary> IPv4 Address of Internet Gateway. </summary>
        public string IPV4Address => Properties?.IPv4Address?.ToString();

        /// <summary> Gateway Type of the resource. </summary>
        public InternetGatewayType TypePropertiesType
        {
            get => Properties?.TypePropertiesType ?? default;
            set
            {
                if (Properties is null)
                {
                    Properties = new InternetGatewayProperties();
                }

                Properties.TypePropertiesType = value;
            }
        }
    }
}
