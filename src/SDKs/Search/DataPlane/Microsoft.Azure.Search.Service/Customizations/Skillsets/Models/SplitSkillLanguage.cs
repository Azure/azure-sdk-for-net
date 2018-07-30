// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of SplitSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SplitSkillLanguage>))]
    public sealed class SplitSkillLanguage : ExtensibleEnum<SplitSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly SplitSkillLanguage Da = new SplitSkillLanguage("da");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly SplitSkillLanguage De = new SplitSkillLanguage("de");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly SplitSkillLanguage En = new SplitSkillLanguage("en");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly SplitSkillLanguage Es = new SplitSkillLanguage("es");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly SplitSkillLanguage Fi = new SplitSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly SplitSkillLanguage Fr = new SplitSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly SplitSkillLanguage It = new SplitSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly SplitSkillLanguage Ko = new SplitSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "pt" (for Portuguese)
        /// </summary>
        public static readonly SplitSkillLanguage Pt = new SplitSkillLanguage("pt");

        private SplitSkillLanguage(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new SplitSkillLanguage instance, or returns an existing instance.
        /// </summary>
        /// <param name="name">Supported language code.</param>
        /// <returns>A SplitSkillLanguage instance with the given name.</returns>
        public static SplitSkillLanguage Create(string name) => Lookup(name) ?? new SplitSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to SplitSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a SplitSkillLanguage.</returns>
        public static implicit operator SplitSkillLanguage(string name) => Create(name);
    }
}

