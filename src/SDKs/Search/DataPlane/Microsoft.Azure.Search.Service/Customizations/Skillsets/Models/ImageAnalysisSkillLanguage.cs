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
        public static readonly ImageAnalysisSkillLanguage En = new ImageAnalysisSkillLanguage("en");

        /// <summary>
        /// Indicates language code "zh" (for Simplified Chinese)
        /// </summary>
        public static readonly ImageAnalysisSkillLanguage Zh = new ImageAnalysisSkillLanguage("zh");

        private ImageAnalysisSkillLanguage(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new ImageAnalysisSkillLanguage instance, or returns an existing instance.
        /// </summary>
        /// <param name="name">Supported language code.</param>
        /// <returns>An ImageAnalysisSkillLanguage instance with the given name.</returns>
        public static ImageAnalysisSkillLanguage Create(string name) => Lookup(name) ?? new ImageAnalysisSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to ImageAnalysisSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a ImageAnalysisSkillLanguage.</returns>
        public static implicit operator ImageAnalysisSkillLanguage(string name) => Create(name);
    }
}