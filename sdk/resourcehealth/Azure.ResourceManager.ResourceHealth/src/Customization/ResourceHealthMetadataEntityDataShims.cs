// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: restore IReadOnlyList<T> return types for collection properties.
// GA 1.0.0 exposed these as IReadOnlyList<T>. The TypeSpec generator uses IList<T> in the
// Properties bag. @@alternateType cannot change collection interface types, so CodeGenSuppress
// + manual shims are required.

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
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // The generated property delegates to Properties.ApplicableScenarios which is IList<T>.
        public IReadOnlyList<MetadataEntityScenario> ApplicableScenarios => Properties?.ApplicableScenarios as IReadOnlyList<MetadataEntityScenario>;

        /// <summary> The list of supported values. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // Same pattern as ApplicableScenarios.
        public IReadOnlyList<MetadataSupportedValueDetail> SupportedValues => Properties?.SupportedValues as IReadOnlyList<MetadataSupportedValueDetail>;

        /// <summary> The list of keys on which this entity depends on. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // Same pattern as ApplicableScenarios.
        public IReadOnlyList<string> DependsOn => Properties?.DependsOn as IReadOnlyList<string>;
    }
}
