// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ProviderHub.Models
{
    public partial class ResourceTypeEndpointBase
    {
        // Workaround: customizing the backward-compat constructor (below) prevents the generator from
        // emitting the correct public constructor, so we add it here manually.
        // See: https://github.com/Azure/azure-sdk-for-net/issues/57016
        /// <summary> Initializes a new instance of <see cref="ResourceTypeEndpointBase"/>. </summary>
        public ResourceTypeEndpointBase(
            bool enabled,
            IEnumerable<string> apiVersions,
            Uri endpointUri,
            IEnumerable<string> locations,
            IEnumerable<string> requiredFeatures,
            FeaturesPolicy? requiredFeaturesPolicy,
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
                requiredFeaturesPolicy is null ? default : new ProviderFeaturesRule(requiredFeaturesPolicy.Value),
                timeout,
                endpointType,
                dstsConfiguration,
                skuLink,
                apiVersion,
                zones?.ToList(),
                additionalBinaryDataProperties: null)
        {
        }

        // Backward-compat: restores the legacy public constructor overload that takes ProviderFeaturesRule.
        // The generated constructor shape changed during migration, so this ApiCompat signature must stay in custom code.
        /// <summary> Backward-compat constructor with ProviderFeaturesRule parameter. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        // Backward-compat: the mgmt generator's flatten/lift-to-nullable overhaul changed this getter
        // from FeaturesPolicy? to FeaturesPolicy. Restore the nullable return type for ApiCompat.
        /// <summary> The required feature policy. </summary>
        public FeaturesPolicy? RequiredFeaturesPolicy => FeaturesRule?.RequiredFeaturesPolicy;
    }
}
