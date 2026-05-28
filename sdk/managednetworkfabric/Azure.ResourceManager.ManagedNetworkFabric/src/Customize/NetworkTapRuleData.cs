// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the TypeSpec migration. The generated constructor requires
    // configurationType because the service property is required. This file preserves the shipped
    // obsolete location-only constructor and flattened properties.
    public partial class NetworkTapRuleData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapRuleData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkTapRuleData(AzureLocation location) : base(location)
        {
            Properties = new NetworkTapRuleProperties();
        }

        /// <summary> Input method to configure Network Tap Rule. </summary>
        [CodeGenMember("ConfigurationType")]
        public NetworkFabricConfigurationType? ConfigurationType
        {
            get => Properties is null ? default : Properties.ConfigurationType;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRuleProperties();
                }

                Properties.ConfigurationType = value.GetValueOrDefault();
            }
        }

        /// <summary> The ARM resource Id of the NetworkTap. </summary>
        [CodeGenMember("NetworkTapId")]
        public ResourceIdentifier NetworkTapId => Properties?.NetworkTapId is null ? default : new ResourceIdentifier(Properties.NetworkTapId);

        /// <summary> Polling interval in seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use PollingIntervalInSecond instead.")]
        public PollingIntervalInSecond? PollingIntervalInSeconds
        {
            get => PollingIntervalInSecond;
            set => PollingIntervalInSecond = value;
        }
    }
}
