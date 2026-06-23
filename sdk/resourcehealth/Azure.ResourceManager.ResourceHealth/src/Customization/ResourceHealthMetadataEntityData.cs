// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    // This is required because the generated property is IList<T>, while GA exposed IReadOnlyList<T>,
    // and @@alternateType cannot change the collection interface type.
    public partial class ResourceHealthMetadataEntityData
    {
        /// <summary> The list of keys on which this entity depends on. </summary>
        public IReadOnlyList<string> DependsOn
        {
            get
            {
                return Properties?.DependsOn as IReadOnlyList<string>;
            }
        }

        /// <summary> The list of scenarios applicable to this metadata entity. </summary>
        public IReadOnlyList<MetadataEntityScenario> ApplicableScenarios
        {
            get
            {
                return Properties?.ApplicableScenarios as IReadOnlyList<MetadataEntityScenario>;
            }
        }

        /// <summary> The list of supported values. </summary>
        public IReadOnlyList<MetadataSupportedValueDetail> SupportedValues
        {
            get
            {
                return Properties?.SupportedValues as IReadOnlyList<MetadataSupportedValueDetail>;
            }
        }
    }
}
