// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: restores the legacy public constructor overload that includes ManifestLevelPropertyBag.
    // The generated constructor shape changed during migration, so this ApiCompat signature must stay in custom code.
    public partial class ProviderFrontloadPayloadProperties
    {
        /// <summary> Backward-compat constructor with ManifestLevelPropertyBag parameter. </summary>
        public ProviderFrontloadPayloadProperties(
            string operationType,
            string providerNamespace,
            string frontloadLocation,
            string copyFromLocation,
            AvailableCheckInManifestEnvironment environmentType,
            ServiceFeatureFlagAction serviceFeatureFlag,
            IEnumerable<string> includeResourceTypes,
            IEnumerable<string> excludeResourceTypes,
            ManifestLevelPropertyBag overrideManifestLevelFields,
            ResourceTypeEndpointBase overrideEndpointLevelFields,
            IEnumerable<string> ignoreFields)
            : this(
                operationType,
                providerNamespace,
                frontloadLocation,
                copyFromLocation,
                environmentType,
                serviceFeatureFlag,
                includeResourceTypes?.ToList(),
                excludeResourceTypes?.ToList(),
                overrideManifestLevelFields,
                overrideEndpointLevelFields,
                ignoreFields?.ToList(),
                additionalBinaryDataProperties: null)
        {
        }
    }
}
