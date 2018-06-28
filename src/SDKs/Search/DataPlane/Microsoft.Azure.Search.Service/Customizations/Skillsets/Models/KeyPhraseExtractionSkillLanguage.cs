// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of KeyPhraseExtractionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<KeyPhraseExtractionSkillLanguage>))]
    public sealed class KeyPhraseExtractionSkillLanguage : ExtensibleEnum<KeyPhraseExtractionSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage da = new KeyPhraseExtractionSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage nl = new KeyPhraseExtractionSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage en = new KeyPhraseExtractionSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage fi = new KeyPhraseExtractionSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage fr = new KeyPhraseExtractionSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage de = new KeyPhraseExtractionSkillLanguage("de");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage it = new KeyPhraseExtractionSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ja" (for Japanese)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage ja = new KeyPhraseExtractionSkillLanguage("ja");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage ko = new KeyPhraseExtractionSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "no" (for Norwegian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage no = new KeyPhraseExtractionSkillLanguage("no");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage pl = new KeyPhraseExtractionSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt-PT" (for Portuguese (Portugal))
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage pt_PT = new KeyPhraseExtractionSkillLanguage("pt-PT");

        /// <summary>
        /// Indicates language code "pt-BR" (for Portuguese (Brazil))
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage pt_BR = new KeyPhraseExtractionSkillLanguage("pt-BR");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage ru = new KeyPhraseExtractionSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage es = new KeyPhraseExtractionSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage sv = new KeyPhraseExtractionSkillLanguage("sv");

        private KeyPhraseExtractionSkillLanguage(string formatName) : base(formatName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new KeyPhraseExtractionSkillLanguage instance, or returns an existing instance if the given name matches that of a
        /// known synonym format.
        /// </summary>
        /// <param name="name">Name of the synonym map format.</param>
        /// <returns>A KeyPhraseExtractionSkillLanguage instance with the given name.</returns>
        public static KeyPhraseExtractionSkillLanguage Create(string name) => Lookup(name) ?? new KeyPhraseExtractionSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to KeyPhraseExtractionSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a KeyPhraseExtractionSkillLanguage.</returns>
        public static implicit operator KeyPhraseExtractionSkillLanguage(string name) => Create(name);
    }
}
