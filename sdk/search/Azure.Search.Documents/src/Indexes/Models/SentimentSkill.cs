// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Indexes.Models
{
    // Hide the versioned SentimentSkill. We unify all within a single type.
    [CodeGenModel("SentimentSkillV3")]
    internal partial class SentimentSkillV3 { }

    /// <summary> Evaluates unstructured text and for each record, provides sentiment labels (such as "negative", "neutral" and "positive")
    /// based on the highest confidence score found by the service at a sentence and document-level using the Text Analytics API. </summary>
    public partial class SentimentSkill
    {
        private readonly SkillVersion _skillVersion = SkillVersion.V1;
        private bool? _includeOpinionMining = false;
        private string _modelVersion;

        /// <summary> Initializes a new instance of <see cref="SentimentSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="skillVersion"> Service version information of the skill. Default value is <see cref="SkillVersion.V1"/>. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        public SentimentSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, SkillVersion skillVersion) : this(inputs, outputs)
        {
            _skillVersion = skillVersion;
            ODataType = skillVersion.ToString();
        }

        /// <summary> Initializes a new instance of SentimentSkill. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SentimentSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            ODataType = "#Microsoft.Skills.Text.SentimentSkill";
        }

        /// <summary> A value indicating which language code to use. Default is <see cref="SentimentSkillLanguage.En"/>. </summary>
        public SentimentSkillLanguage? DefaultLanguageCode { get; set; } = SentimentSkillLanguage.En;

        /// <summary> If set to true, the skill output will include information from Text Analytics for opinion mining,
        /// namely targets (nouns or verbs) and their associated assessment (adjective) in the text. Default is <c>false</c>. </summary>
        public bool? IncludeOpinionMining
        {
            get => _includeOpinionMining;
            set
            {
                if (_skillVersion != SkillVersion.V3)
                {
                    throw new InvalidOperationException($"{nameof(IncludeOpinionMining)} can only be used with {SkillVersion.V3}");
                }
                _includeOpinionMining = value;
            }
        }

        /// <summary> The version of the model to use when calling the Text Analytics service.
        /// It will default to the latest available when not specified.
        ///  We recommend you do not specify this value unless absolutely necessary. </summary>
        public string ModelVersion
        {
            get => _modelVersion;

            set
            {
                if (!(_skillVersion >= SkillVersion.V3))
                {
                    throw new InvalidOperationException($"{nameof(ModelVersion)} can only be used with {SkillVersion.V3} and above");
                }
                _modelVersion = value;
            }
        }
    }
}
