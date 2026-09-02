// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ProviderHub.Models
{
    public partial class ProviderFrontloadPayloadProperties
    {
        // Workaround: customizing the backward-compat constructor (below) prevents the generator from
        // emitting the correct public constructor, so we add it here manually.
        // See: https://github.com/Azure/azure-sdk-for-net/issues/57016
        /// <summary> Initializes a new instance of <see cref="ProviderFrontloadPayloadProperties"/>. </summary>
        public ProviderFrontloadPayloadProperties(
            string operationType,
            string providerNamespace,
            string frontloadLocation,
            string copyFromLocation,
            AvailableCheckInManifestEnvironment environmentType,
            ServiceFeatureFlagAction serviceFeatureFlag,
            IEnumerable<string> includeResourceTypes,
            IEnumerable<string> excludeResourceTypes,
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
                overrideManifestLevelFields: null,
                overrideEndpointLevelFields,
                ignoreFields?.ToList(),
                additionalBinaryDataProperties: null)
        {
        }

        // Backward-compat: restores the legacy public constructor overload that includes ManifestLevelPropertyBag.
        // The generated constructor shape changed during migration, so this ApiCompat signature must stay in custom code.
        /// <summary> Backward-compat constructor with ManifestLevelPropertyBag parameter. </summary>
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
