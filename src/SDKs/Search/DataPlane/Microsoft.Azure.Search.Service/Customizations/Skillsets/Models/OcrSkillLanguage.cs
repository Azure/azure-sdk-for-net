// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of OcrSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<OcrSkillLanguage>))]
    public sealed class OcrSkillLanguage : ExtensibleEnum<OcrSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "zh-Hans" (for Chinese Traditional)
        /// </summary>
        public static readonly OcrSkillLanguage zh_Hans = new OcrSkillLanguage("zh-Hans");

        /// <summary>
        /// Indicates language code "zh-Hant" (for Chinese Traditional)
        /// </summary>
        public static readonly OcrSkillLanguage zh_Hant = new OcrSkillLanguage("zh-Hant");

        /// <summary>
        /// Indicates language code "cs" (for Czech)
        /// </summary>
        public static readonly OcrSkillLanguage cs = new OcrSkillLanguage("cs");

        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly OcrSkillLanguage da = new OcrSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly OcrSkillLanguage nl = new OcrSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly OcrSkillLanguage en = new OcrSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly OcrSkillLanguage fi = new OcrSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly OcrSkillLanguage fr = new OcrSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly OcrSkillLanguage de = new OcrSkillLanguage("de");

        /// <summary>
        /// Indicates language code "el" (for Greek)
        /// </summary>
        public static readonly OcrSkillLanguage el = new OcrSkillLanguage("el");

        /// <summary>
        /// Indicates language code "hu" (for Hungarian)
        /// </summary>
        public static readonly OcrSkillLanguage hu = new OcrSkillLanguage("hu");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly OcrSkillLanguage it = new OcrSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ja" (for Japanese)
        /// </summary>
        public static readonly OcrSkillLanguage ja = new OcrSkillLanguage("ja");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly OcrSkillLanguage ko = new OcrSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "nb" (for Norwegian)
        /// </summary>
        public static readonly OcrSkillLanguage no = new OcrSkillLanguage("nb");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly OcrSkillLanguage pl = new OcrSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt" (for Portuguese)
        /// </summary>
        public static readonly OcrSkillLanguage pt = new OcrSkillLanguage("pt");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly OcrSkillLanguage ru = new OcrSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly OcrSkillLanguage es = new OcrSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly OcrSkillLanguage sv = new OcrSkillLanguage("sv");

        /// <summary>
        /// Indicates language code "tr" (for Turkish)
        /// </summary>
        public static readonly OcrSkillLanguage tr = new OcrSkillLanguage("tr");

        /// <summary>
        /// Indicates language code "ar" (for Arabic)
        /// </summary>
        public static readonly OcrSkillLanguage ar = new OcrSkillLanguage("ar");

        /// <summary>
        /// Indicates language code "ro" (for Romanian)
        /// </summary>
        public static readonly OcrSkillLanguage ro = new OcrSkillLanguage("ro");

        /// <summary>
        /// Indicates language code "sr-Cyrl" (for SerbianCyrillic)
        /// </summary>
        public static readonly OcrSkillLanguage sr_Cyrl = new OcrSkillLanguage("sr-Cyrl");

        /// <summary>
        /// Indicates language code "sr-Latn" (for SerbianLatin)
        /// </summary>
        public static readonly OcrSkillLanguage sr_Latn = new OcrSkillLanguage("sr-Latn");

        /// <summary>
        /// Indicates language code "sk" (for Slovak)
        /// </summary>
        public static readonly OcrSkillLanguage sk = new OcrSkillLanguage("sk");

        private OcrSkillLanguage(string formatName) : base(formatName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new OcrSkillLanguage instance, or returns an existing instance if the given name matches that of a
        /// known synonym format.
        /// </summary>
        /// <param name="name">Name of the synonym map format.</param>
        /// <returns>A OcrSkillLanguage instance with the given name.</returns>
        public static OcrSkillLanguage Create(string name) => Lookup(name) ?? new OcrSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to OcrSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a OcrSkillLanguage.</returns>
        public static implicit operator OcrSkillLanguage(string name) => Create(name);
    }
}

