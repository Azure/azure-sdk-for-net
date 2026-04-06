// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.ProviderHub.Models
{
    public partial class ResourceTypeEndpointBase
    {
        /// <summary> Backward-compat constructor with ProviderFeaturesRule parameter. </summary>
        public ResourceTypeEndpointBase(
            bool enabled,
            IEnumerable<string> apiVersions,
            Uri endpointUri,
            IEnumerable<string> locations,
            IEnumerable<string> requiredFeatures,
            ProviderFeaturesRule featuresRule,
            TimeSpan timeout,
            ProviderEndpointType endpointType,
            ProviderDstsConfiguration dstsConfiguration,
            string skuLink,
            string apiVersion,
            IEnumerable<string> zones)
            : this(
                enabled,
                apiVersions?.ToList(),
                endpointUri,
                locations?.ToList(),
                requiredFeatures?.ToList(),
                featuresRule,
                timeout,
                endpointType,
                dstsConfiguration,
                skuLink,
                apiVersion,
                zones?.ToList(),
                additionalBinaryDataProperties: null)
        {
        }
    }
}
