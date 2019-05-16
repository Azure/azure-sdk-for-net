// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    public partial class KeyPhraseExtractionSkill
    {
        /// <summary>
        /// Initializes a new instance of the KeyPhraseExtractionSkill class.
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
        /// <param name="defaultLanguageCode">A value indicating which language
        /// code to use. Default is en. Possible values include: 'da', 'nl',
        /// 'en', 'fi', 'fr', 'de', 'it', 'ja', 'ko', 'no', 'pl', 'pt-PT',
        /// 'pt-BR', 'ru', 'es', 'sv'</param>
        /// <param name="maxKeyPhraseCount">A number indicating how many key
        /// phrases to return. If absent, all identified key phrases will be
        /// returned.</param>
        public KeyPhraseExtractionSkill(IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string description = default(string), string context = default(string), KeyPhraseExtractionSkillLanguage? defaultLanguageCode = default(KeyPhraseExtractionSkillLanguage?), int? maxKeyPhraseCount = default(int?))
            : base(inputs, outputs, description, context)
        {
            DefaultLanguageCode = defaultLanguageCode;
            MaxKeyPhraseCount = maxKeyPhraseCount;
            CustomInit();
        }
    }
}
