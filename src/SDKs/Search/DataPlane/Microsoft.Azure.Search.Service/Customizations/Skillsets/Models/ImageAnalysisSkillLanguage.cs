// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of ImageAnalysisSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<ImageAnalysisSkillLanguage>))]
    public sealed class ImageAnalysisSkillLanguage : ExtensibleEnum<ImageAnalysisSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly ImageAnalysisSkillLanguage en = new ImageAnalysisSkillLanguage("en");

        /// <summary>
        /// Indicates language code "zh" (for Simplified Chinese)
        /// </summary>
        public static readonly ImageAnalysisSkillLanguage zh = new ImageAnalysisSkillLanguage("zh");

        private ImageAnalysisSkillLanguage(string formatName) : base(formatName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new ImageAnalysisSkillLanguage instance, or returns an existing instance if the given name matches that of a
        /// known synonym format.
        /// </summary>
        /// <param name="name">Name of the synonym map format.</param>
        /// <returns>A ImageAnalysisSkillLanguage instance with the given name.</returns>
        public static ImageAnalysisSkillLanguage Create(string name) => Lookup(name) ?? new ImageAnalysisSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to ImageAnalysisSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a ImageAnalysisSkillLanguage.</returns>
        public static implicit operator ImageAnalysisSkillLanguage(string name) => Create(name);
    }
}