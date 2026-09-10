// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // GA exposed these collection properties as IReadOnlyList<T> while the generated flattened properties are
    // IList<T>, and no client.tsp decorator can change the collection interface. Re-expose them as
    // IReadOnlyList<T> to preserve the GA surface; the generator omits its IList<T> versions because these
    // custom members already define the names.
    public partial class ResourceHealthMetadataEntityData
    {
        /// <summary> The list of keys on which this entity depends on. </summary>
        public IReadOnlyList<string> DependsOn => Properties?.DependsOn as IReadOnlyList<string>;

        /// <summary> The list of scenarios applicable to this metadata entity. </summary>
        public IReadOnlyList<MetadataEntityScenario> ApplicableScenarios => Properties?.ApplicableScenarios as IReadOnlyList<MetadataEntityScenario>;

        /// <summary> The list of supported values. </summary>
        public IReadOnlyList<MetadataSupportedValueDetail> SupportedValues => Properties?.SupportedValues as IReadOnlyList<MetadataSupportedValueDetail>;
    }
}
