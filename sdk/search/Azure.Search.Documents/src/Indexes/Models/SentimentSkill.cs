// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Evaluates unstructured text and for each record, provides sentiment labels (such as "negative", "neutral" and "positive")
    /// based on the highest confidence score found by the service at a sentence and document-level using the Text Analytics API. </summary>
    [CodeGenType("SentimentSkillV3")]

    public partial class SentimentSkill
    {
        /// <summary> Initializes a new instance of <see cref="SentimentSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="skillVersion"> Service version information of the skill. Default value is <see cref="SkillVersion.V3"/>. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        public SentimentSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, SkillVersion skillVersion) : this(inputs, outputs)
        {
            OdataType = skillVersion.ToString();
        }
    }
}
