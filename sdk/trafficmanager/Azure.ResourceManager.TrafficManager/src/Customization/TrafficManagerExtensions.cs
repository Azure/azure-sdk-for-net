// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    [CodeGenSuppress("GetTrafficManagerUserMetrics", typeof(SubscriptionResource))]
    public static partial class TrafficManagerExtensions
    {
        /// <summary> Gets the TrafficManagerGeographicHierarchy. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy(this TenantResource tenantResource)
        {
            return GetMockableTrafficManagerTenantResource(tenantResource).GetTrafficManagerGeographicHierarchy();
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
