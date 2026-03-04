// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
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

        /// <summary> Deprecated. A list of entity categories that should be extracted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated. Use EntityCategories instead.", true)]
        public IList<EntityCategory> Categories { get;  }

        /// <summary> A list of entity categories that should be extracted. </summary>
        [CodeGenMember("Categories")]
        public IList<string> EntityCategories { get; }

        /// <summary> Deprecated. Determines whether or not to include entities which are well known but don't conform to a pre-defined type. </summary>
        [Obsolete("This property is deprecated. Use EntityRecognitionSkill with SkillVersion.V3 instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IncludeTypelessEntities { get; set; }

        /// <summary> Deprecated. A value indicating which language code to use. Default is en. </summary>
        [Obsolete("This property is deprecated. Use EntityLanguageCode instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EntityRecognitionSkillLanguage? DefaultLanguageCode { get; set; }

        /// <summary> A value indicating which language code to use. Default is `en`. </summary>
        [CodeGenMember("DefaultLanguageCode")]
        public string LanguageCode { get; set; }
    }
}
