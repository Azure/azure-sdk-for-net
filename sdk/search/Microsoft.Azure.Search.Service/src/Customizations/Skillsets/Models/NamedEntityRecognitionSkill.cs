// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Text analytics named entity recognition. This skill is deprecated in favor of <see cref="EntityRecognitionSkill"/>
    /// <see
    /// href="https://docs.microsoft.com/azure/search/cognitive-search-skill-named-entity-recognition"
    /// />
    /// </summary>
    [Newtonsoft.Json.JsonObject("#Microsoft.Skills.Text.NamedEntityRecognitionSkill")]
    [Obsolete("Use EntityRecognitionSkill instead.")]
    public partial class NamedEntityRecognitionSkill : Skill
    {
        /// <summary>
        /// Initializes a new instance of the NamedEntityRecognitionSkill
        /// class.
        /// </summary>
        public NamedEntityRecognitionSkill()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NamedEntityRecognitionSkill
        /// class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the
        /// source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in a
        /// search index, or a value that can be consumed as an input by
        /// another skill.</param>
        /// <param name="description">The description of the skill which
        /// describes the inputs, outputs, and usage of the skill.</param>
        /// <param name="context">Represents the level at which operations take
        /// place, such as the document root or document content (for example,
        /// /document or /document/content).</param>
        /// <param name="categories">A list of named entity categories.</param>
        /// <param name="defaultLanguageCode">A value indicating which language
        /// code to use. Default is en.</param>
        /// <param name="minimumPrecision">A value between 0 and 1 to indicate
        /// the confidence of the results.</param>
        public NamedEntityRecognitionSkill(IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string description = default(string), string context = default(string), IList<NamedEntityCategory> categories = default(IList<NamedEntityCategory>), NamedEntityRecognitionSkillLanguage defaultLanguageCode = default(NamedEntityRecognitionSkillLanguage), double? minimumPrecision = default(double?))
            : base(inputs, outputs, description, context)
        {
            Categories = categories;
            DefaultLanguageCode = defaultLanguageCode;
            MinimumPrecision = minimumPrecision;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a list of named entity categories.
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public IList<NamedEntityCategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which language code to use. Default
        /// is en.
        /// </summary>
        [JsonProperty(PropertyName = "defaultLanguageCode")]
        public NamedEntityRecognitionSkillLanguage DefaultLanguageCode { get; set; }

        /// <summary>
        /// Gets or sets a value between 0 and 1 to indicate the confidence of
        /// the results.
        /// </summary>
        [JsonProperty(PropertyName = "minimumPrecision")]
        public double? MinimumPrecision { get; set; }
    }
}
