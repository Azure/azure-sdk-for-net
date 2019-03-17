// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of KeyPhraseExtractionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<KeyPhraseExtractionSkillLanguage>))]
    public struct KeyPhraseExtractionSkillLanguage : IEquatable<KeyPhraseExtractionSkillLanguage>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Da = new KeyPhraseExtractionSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Nl = new KeyPhraseExtractionSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage En = new KeyPhraseExtractionSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Fi = new KeyPhraseExtractionSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Fr = new KeyPhraseExtractionSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage De = new KeyPhraseExtractionSkillLanguage("de");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage It = new KeyPhraseExtractionSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ja" (for Japanese)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Ja = new KeyPhraseExtractionSkillLanguage("ja");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Ko = new KeyPhraseExtractionSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "no" (for Norwegian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage No = new KeyPhraseExtractionSkillLanguage("no");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Pl = new KeyPhraseExtractionSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt-PT" (for Portuguese (Portugal))
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage PtPt = new KeyPhraseExtractionSkillLanguage("pt-PT");

        /// <summary>
        /// Indicates language code "pt-BR" (for Portuguese (Brazil))
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage PtBr = new KeyPhraseExtractionSkillLanguage("pt-BR");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Ru = new KeyPhraseExtractionSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Es = new KeyPhraseExtractionSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly KeyPhraseExtractionSkillLanguage Sv = new KeyPhraseExtractionSkillLanguage("sv");

        private KeyPhraseExtractionSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to KeyPhraseExtractionSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a KeyPhraseExtractionSkillLanguage.</returns>
        public static implicit operator KeyPhraseExtractionSkillLanguage(string language) => new KeyPhraseExtractionSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from KeyPhraseExtractionSkillLanguage to string.
        /// </summary>
        /// <param name="language">KeyPhraseExtractionSkillLanguage to convert.</param>
        /// <returns>The KeyPhraseExtractionSkillLanguage as a string.</returns>
        public static explicit operator string(KeyPhraseExtractionSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two KeyPhraseExtractionSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first KeyPhraseExtractionSkillLanguage to compare.</param>
        /// <param name="rhs">The second KeyPhraseExtractionSkillLanguage to compare.</param>
        /// <returns>true if the KeyPhraseExtractionSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(KeyPhraseExtractionSkillLanguage lhs, KeyPhraseExtractionSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two KeyPhraseExtractionSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first KeyPhraseExtractionSkillLanguage to compare.</param>
        /// <param name="rhs">The second KeyPhraseExtractionSkillLanguage to compare.</param>
        /// <returns>true if the KeyPhraseExtractionSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(KeyPhraseExtractionSkillLanguage lhs, KeyPhraseExtractionSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the KeyPhraseExtractionSkillLanguage for equality with another KeyPhraseExtractionSkillLanguage.
        /// </summary>
        /// <param name="other">The KeyPhraseExtractionSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the KeyPhraseExtractionSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(KeyPhraseExtractionSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is KeyPhraseExtractionSkillLanguage ? Equals((KeyPhraseExtractionSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the KeyPhraseExtractionSkillLanguage.
        /// </summary>
        /// <returns>The KeyPhraseExtractionSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}
