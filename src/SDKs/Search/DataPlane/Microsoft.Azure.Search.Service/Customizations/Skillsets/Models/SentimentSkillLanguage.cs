// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of SentimentSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SentimentSkillLanguage>))]
    public sealed class SentimentSkillLanguage : ExtensibleEnum<SentimentSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly SentimentSkillLanguage da = new SentimentSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly SentimentSkillLanguage nl = new SentimentSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly SentimentSkillLanguage en = new SentimentSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly SentimentSkillLanguage fi = new SentimentSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly SentimentSkillLanguage fr = new SentimentSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly SentimentSkillLanguage de = new SentimentSkillLanguage("de");

        /// <summary>
        /// Indicates language code "el" (for Greek)
        /// </summary>
        public static readonly SentimentSkillLanguage el = new SentimentSkillLanguage("el");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly SentimentSkillLanguage it = new SentimentSkillLanguage("it");

        /// <summary>
        /// Indicates language code "no" (for Norwegian)
        /// </summary>
        public static readonly SentimentSkillLanguage no = new SentimentSkillLanguage("no");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly SentimentSkillLanguage pl = new SentimentSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt-PT" (for Portuguese)
        /// </summary>
        public static readonly SentimentSkillLanguage pt_PT = new SentimentSkillLanguage("pt-PT");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly SentimentSkillLanguage ru = new SentimentSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly SentimentSkillLanguage es = new SentimentSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly SentimentSkillLanguage sv = new SentimentSkillLanguage("sv");

        /// <summary>
        /// Indicates language code "tr" (for Turkish)
        /// </summary>
        public static readonly SentimentSkillLanguage tr = new SentimentSkillLanguage("tr");

        private SentimentSkillLanguage(string formatName) : base(formatName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new SentimentSkillLanguage instance, or returns an existing instance if the given name matches that of a
        /// known synonym format.
        /// </summary>
        /// <param name="name">Name of the synonym map format.</param>
        /// <returns>A SentimentSkillLanguage instance with the given name.</returns>
        public static SentimentSkillLanguage Create(string name) => Lookup(name) ?? new SentimentSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to SentimentSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a SentimentSkillLanguage.</returns>
        public static implicit operator SentimentSkillLanguage(string name) => Create(name);
    }
}
