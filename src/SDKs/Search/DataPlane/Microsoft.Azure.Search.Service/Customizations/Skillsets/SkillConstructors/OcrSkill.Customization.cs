// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    // Note: The addition of the optional field Skill.Name changed auto generated constructors
    // such that they were no longer be binary backwards compatiable. This additional constructor
    // is to preserve backwards compatability such that this new field is not considered a breaking change.
    // This customization can be removed in the next major version bump (10.0.0)
    public partial class OcrSkill
    {
        /// <summary>
        /// Initializes a new instance of the OcrSkill class.
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
        /// <param name="textExtractionAlgorithm">A value indicating which
        /// algorithm to use for extracting text. Default is printed. Possible
        /// values include: 'printed', 'handwritten'</param>
        /// <param name="defaultLanguageCode">A value indicating which language
        /// code to use. Default is en. Possible values include: 'zh-Hans',
        /// 'zh-Hant', 'cs', 'da', 'nl', 'en', 'fi', 'fr', 'de', 'el', 'hu',
        /// 'it', 'ja', 'ko', 'nb', 'pl', 'pt', 'ru', 'es', 'sv', 'tr', 'ar',
        /// 'ro', 'sr-Cyrl', 'sr-Latn', 'sk'</param>
        /// <param name="shouldDetectOrientation">A value indicating to turn
        /// orientation detection on or not. Default is false.</param>
        public OcrSkill(IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string description = default(string), string context = default(string), TextExtractionAlgorithm? textExtractionAlgorithm = default(TextExtractionAlgorithm?), OcrSkillLanguage? defaultLanguageCode = default(OcrSkillLanguage?), bool? shouldDetectOrientation = default(bool?))
            : base(inputs, outputs, description, context)
        {
            TextExtractionAlgorithm = textExtractionAlgorithm;
            DefaultLanguageCode = defaultLanguageCode;
            ShouldDetectOrientation = shouldDetectOrientation;
            CustomInit();
        }
    }
}
