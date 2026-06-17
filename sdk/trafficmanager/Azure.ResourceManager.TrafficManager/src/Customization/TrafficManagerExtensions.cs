// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrafficManager.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    [CodeGenSuppress("GetTrafficManagerUserMetric", typeof(SubscriptionResource))]
    public static partial class TrafficManagerExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="TrafficManagerEndpointResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableTrafficManagerArmClient.GetTrafficManagerEndpointResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TrafficManagerEndpointResource"/> object. </returns>
        public static TrafficManagerEndpointResource GetTrafficManagerEndpointResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableTrafficManagerArmClient(client).GetTrafficManagerEndpointResource(id);
        }

        /// <summary> Gets the TrafficManagerUserMetricsResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <returns> An object representing a <see cref="TrafficManagerUserMetricsResource"/>. </returns>
        public static TrafficManagerUserMetricsResource GetTrafficManagerUserMetrics(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableTrafficManagerSubscriptionResource(subscriptionResource).GetTrafficManagerUserMetrics();
        }
    }
}
