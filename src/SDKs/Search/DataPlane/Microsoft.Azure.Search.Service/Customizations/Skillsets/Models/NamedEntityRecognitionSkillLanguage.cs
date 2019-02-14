// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;
    using System;

    /// <summary>
    /// Defines the format of NamedEntityRecognitionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<NamedEntityRecognitionSkillLanguage>))]
    [Obsolete("Use EntityRecognitionSkillLanguage instead")]
    public sealed class NamedEntityRecognitionSkillLanguage : ExtensibleEnum<NamedEntityRecognitionSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "ar" (for Arabic)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Ar = new NamedEntityRecognitionSkillLanguage("ar");

        /// <summary>
        /// Indicates language code "cs" (for Czech)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Cs = new NamedEntityRecognitionSkillLanguage("cs");

        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Da = new NamedEntityRecognitionSkillLanguage("da");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage De = new NamedEntityRecognitionSkillLanguage("de");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage En = new NamedEntityRecognitionSkillLanguage("en");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Es = new NamedEntityRecognitionSkillLanguage("es");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Fi = new NamedEntityRecognitionSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Fr = new NamedEntityRecognitionSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "he" (for Hebrew)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage He = new NamedEntityRecognitionSkillLanguage("he");

        /// <summary>
        /// Indicates language code "hu" (for Hungarian)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Hu = new NamedEntityRecognitionSkillLanguage("hu");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage It = new NamedEntityRecognitionSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Ko = new NamedEntityRecognitionSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "pt-br" (for Portuguese (Brazil))
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage PtBr = new NamedEntityRecognitionSkillLanguage("pt-br");

        /// <summary>
        /// Indicates language code "pt" (for Portuguese)
        /// </summary>
        public static readonly NamedEntityRecognitionSkillLanguage Pt = new NamedEntityRecognitionSkillLanguage("pt");

        private NamedEntityRecognitionSkillLanguage(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new NamedEntityRecognitionSkillLanguage instance, or returns an existing instance.
        /// </summary>
        /// <param name="name">Supported language code.</param>
        /// <returns>A NamedEntityRecognitionSkillLanguage instance with the given name.</returns>
        public static NamedEntityRecognitionSkillLanguage Create(string name) => Lookup(name) ?? new NamedEntityRecognitionSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to NamedEntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a NamedEntityRecognitionSkillLanguage.</returns>
        public static implicit operator NamedEntityRecognitionSkillLanguage(string name) => Create(name);
    }
}
