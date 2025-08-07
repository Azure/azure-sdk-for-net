// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Indexes.Models
{
    // Hide the versioned EntityRecognitionSkill. We unify all within a single type.
    [CodeGenModel("EntityRecognitionSkillV3")]
    internal partial class EntityRecognitionSkillV3 { }

    /// <summary>
    /// Extracts entities of different types from text using the Text Analytics API.
    /// </summary>
    public partial class EntityRecognitionSkill
    {
        private readonly SkillVersion _skillVersion = SkillVersion.V1;
        private bool? _includeTypelessEntities;
        private string _modelVersion;

        /// <summary> Initializes a new instance of <see cref="EntityRecognitionSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="skillVersion">Service version information of the skill. Default value is <see cref="SkillVersion.V1"/>. </param>
        public EntityRecognitionSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, SkillVersion skillVersion) : this(inputs, outputs)
        {
            _skillVersion = skillVersion;
            ODataType = skillVersion.ToString();
        }

        /// <summary> Initializes a new instance of EntityRecognitionSkill. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EntityRecognitionSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            Categories = new ChangeTrackingList<EntityCategory>();
            ODataType = "#Microsoft.Skills.Text.EntityRecognitionSkill";
        }

        /// <summary> A list of entity categories that should be extracted. </summary>
        public IList<EntityCategory> Categories { get; }

        /// <summary> Determines whether or not to include entities which are well known but don't conform to a predefined type.
        /// If this configuration is not set (default), set to null or set to false,
        /// entities which don't conform to one of the predefined types will not be surfaced. </summary>
        public bool? IncludeTypelessEntities
        {
            get => _includeTypelessEntities;

            set
            {
                if (_skillVersion != SkillVersion.V1)
                {
                    throw new InvalidOperationException($"{nameof(IncludeTypelessEntities)} can only be used with {SkillVersion.V1}");
                }
                _includeTypelessEntities = value;
            }
        }

        /// <summary> The version of the model to use when calling the Text Analytics service.
        /// It will default to the latest available when not specified.
        /// We recommend you do not specify this value unless absolutely necessary. </summary>
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
