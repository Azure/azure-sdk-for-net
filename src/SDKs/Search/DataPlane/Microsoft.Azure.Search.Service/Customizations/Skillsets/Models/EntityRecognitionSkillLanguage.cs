// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of EntityRecognitionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<EntityRecognitionSkillLanguage>))]
    public sealed class EntityRecognitionSkillLanguage : ExtensibleEnum<EntityRecognitionSkillLanguage>
    {
        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly EntityRecognitionSkillLanguage De = new EntityRecognitionSkillLanguage("de");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly EntityRecognitionSkillLanguage En = new EntityRecognitionSkillLanguage("en");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly EntityRecognitionSkillLanguage Es = new EntityRecognitionSkillLanguage("es");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly EntityRecognitionSkillLanguage Fr = new EntityRecognitionSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly EntityRecognitionSkillLanguage It = new EntityRecognitionSkillLanguage("it");

        private EntityRecognitionSkillLanguage(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new EntityRecognitionSkillLanguage instance, or returns an existing instance.
        /// </summary>
        /// <param name="name">Supported language code.</param>
        /// <returns>A EntityRecognitionSkillLanguage instance with the given name.</returns>
        public static EntityRecognitionSkillLanguage Create(string name) => Lookup(name) ?? new EntityRecognitionSkillLanguage(name);

        /// <summary>
        /// Defines implicit conversion from string to EntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a EntityRecognitionSkillLanguage.</returns>
        public static implicit operator EntityRecognitionSkillLanguage(string name) => Create(name);
    }
}
