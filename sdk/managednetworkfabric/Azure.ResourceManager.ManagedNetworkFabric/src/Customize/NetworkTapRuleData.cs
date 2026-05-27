// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the TypeSpec migration. The generated constructor now requires
    // configurationType because the service property is required. Removing this suppression would add a
    // new public constructor, and removing the custom members would drop shipped flattened properties.
    [CodeGenSuppress("NetworkTapRuleData", typeof(AzureLocation), typeof(NetworkFabricConfigurationType))]
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
        [CodeGenMember("PollingIntervalInSeconds")]
        public PollingIntervalInSecond? PollingIntervalInSeconds
        {
            get => Properties?.PollingIntervalInSeconds is null ? default : new PollingIntervalInSecond(Properties.PollingIntervalInSeconds.Value);
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRuleProperties();
                }

                Properties.PollingIntervalInSeconds = value.HasValue ? int.Parse(value.Value.ToString(), CultureInfo.InvariantCulture) : default(int?);
            }
        }
    }
}
