// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenSuppress("ApplicableScenarios")]
    [CodeGenSuppress("SupportedValues")]
    [CodeGenSuppress("DependsOn")]
    public partial class ResourceHealthMetadataEntityData
    {
        /// <summary> The list of scenarios applicable to this metadata entity. </summary>
        // This shim is required because the generated property is IList<T>, while GA 1.0.0 exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<MetadataEntityScenario> ApplicableScenarios => Properties?.ApplicableScenarios as IReadOnlyList<MetadataEntityScenario>;

        /// <summary> The list of supported values. </summary>
        // Same IReadOnlyList<T> compatibility shim as ApplicableScenarios for the generated IList<T> property.
        public IReadOnlyList<MetadataSupportedValueDetail> SupportedValues => Properties?.SupportedValues as IReadOnlyList<MetadataSupportedValueDetail>;

        /// <summary> The list of keys on which this entity depends on. </summary>
        // Same IReadOnlyList<T> compatibility shim as ApplicableScenarios for the generated IList<T> property.
        public IReadOnlyList<string> DependsOn => Properties?.DependsOn as IReadOnlyList<string>;
    }
}
