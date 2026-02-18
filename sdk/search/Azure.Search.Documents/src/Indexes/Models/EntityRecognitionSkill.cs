// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// Extracts entities of different types from text using the Text Analytics API.
    /// </summary>
    [CodeGenType("EntityRecognitionSkillV3")]
    public partial class EntityRecognitionSkill
    {
        /// <summary> Initializes a new instance of <see cref="EntityRecognitionSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="skillVersion">Service version information of the skill. Default value is <see cref="SkillVersion.V3"/>. </param>
        public EntityRecognitionSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, SkillVersion skillVersion) : this(inputs, outputs)
        {
            OdataType = skillVersion.ToString();
        }

        // Work around for generator still generating deprecated type
        /// <summary> A list of entity categories that should be extracted. </summary>
        [CodeGenMember("Categories")]
        public IList<string> Categories { get; }
    }
}
