// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthMetadataEntityData
    {
        /// <summary> The list of keys on which this entity depends on. </summary>
        [CodeGenMember("DependsOn")]
        public IReadOnlyList<string> DependsOn
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<string>)Properties.DependsOn;
            }
        }

        /// <summary> The list of scenarios applicable to this metadata entity. </summary>
        [CodeGenMember("ApplicableScenarios")]
        public IReadOnlyList<MetadataEntityScenario> ApplicableScenarios
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<MetadataEntityScenario>)Properties.ApplicableScenarios;
            }
        }

        /// <summary> The list of supported values. </summary>
        [CodeGenMember("SupportedValues")]
        public IReadOnlyList<MetadataSupportedValueDetail> SupportedValues
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<MetadataSupportedValueDetail>)Properties.SupportedValues;
            }
        }
    }
}
