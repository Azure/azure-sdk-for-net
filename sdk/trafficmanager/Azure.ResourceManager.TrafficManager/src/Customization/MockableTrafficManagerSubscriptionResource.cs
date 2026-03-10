// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager.Mocking
{
    [CodeGenSuppress("GetTrafficManagerUserMetrics")]
    public partial class MockableTrafficManagerSubscriptionResource
    {
        /// <summary> Gets the TrafficManagerUserMetricsResource. </summary>
        /// <returns> An object representing a <see cref="TrafficManagerUserMetricsResource"/>. </returns>
        public virtual TrafficManagerUserMetricsResource GetTrafficManagerUserMetrics()
        {
            return GetCachedClient(client => new TrafficManagerUserMetricsResource(client, TrafficManagerUserMetricsResource.CreateResourceIdentifier(Id.SubscriptionId)));
        }
    }
}
