// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    public partial class EntityRecognitionSkill
    {
        /// <summary>
        /// Initializes a new instance of the EntityRecognitionSkill class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the
        /// source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in an
        /// Azure Search index, or a value that can be consumed as an input by
        /// another skill.</param>
        /// <param name="description">The description of the skill which
        /// describes the inputs, outputs, and usage of the skill.</param>
        /// <param name="context">Represents the level at which operations take
        /// place, such as the document root or document content (for example,
        /// /document or /document/content). The default is /document.</param>
        /// <param name="categories">A list of entity categories that should be
        /// extracted.</param>
        /// <param name="defaultLanguageCode">A value indicating which language
        /// code to use. Default is en. Possible values include: 'de', 'en',
        /// 'es', 'fr', 'it'</param>
        /// <param name="includeTypelessEntities">Determines whether or not to
        /// include entities which are well known but don't conform to a
        /// pre-defined type. If this configuration is not set (default), set
        /// to null or set to false, entities which don't conform to one of the
        /// pre-defined types will not be surfaced.</param>
        /// <param name="minimumPrecision">A value between 0 and 1 that be used
        /// to only include entities whose confidence score is greater than the
        /// value specified. If not set (default), or if explicitly set to
        /// null, all entities will be included.</param>
        public EntityRecognitionSkill(IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string description = default(string), string context = default(string), IList<EntityCategory> categories = default(IList<EntityCategory>), EntityRecognitionSkillLanguage? defaultLanguageCode = default(EntityRecognitionSkillLanguage?), bool? includeTypelessEntities = default(bool?), double? minimumPrecision = default(double?))
            : base(inputs, outputs, description, context)
        {
            Categories = categories;
            DefaultLanguageCode = defaultLanguageCode;
            IncludeTypelessEntities = includeTypelessEntities;
            MinimumPrecision = minimumPrecision;
            CustomInit();
        }
    }
}
