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
    /// Defines the format of SentimentSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SentimentSkillLanguage>))]
    public struct SentimentSkillLanguage : IEquatable<SentimentSkillLanguage>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly SentimentSkillLanguage Da = new SentimentSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly SentimentSkillLanguage Nl = new SentimentSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly SentimentSkillLanguage En = new SentimentSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly SentimentSkillLanguage Fi = new SentimentSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly SentimentSkillLanguage Fr = new SentimentSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly SentimentSkillLanguage De = new SentimentSkillLanguage("de");

        /// <summary>
        /// Indicates language code "el" (for Greek)
        /// </summary>
        public static readonly SentimentSkillLanguage El = new SentimentSkillLanguage("el");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly SentimentSkillLanguage It = new SentimentSkillLanguage("it");

        /// <summary>
        /// Indicates language code "no" (for Norwegian)
        /// </summary>
        public static readonly SentimentSkillLanguage No = new SentimentSkillLanguage("no");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly SentimentSkillLanguage Pl = new SentimentSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt-PT" (for Portuguese)
        /// </summary>
        public static readonly SentimentSkillLanguage PtPt = new SentimentSkillLanguage("pt-PT");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly SentimentSkillLanguage Ru = new SentimentSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly SentimentSkillLanguage Es = new SentimentSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly SentimentSkillLanguage Sv = new SentimentSkillLanguage("sv");

        /// <summary>
        /// Indicates language code "tr" (for Turkish)
        /// </summary>
        public static readonly SentimentSkillLanguage Tr = new SentimentSkillLanguage("tr");

        private SentimentSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to SentimentSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a SentimentSkillLanguage.</returns>
        public static implicit operator SentimentSkillLanguage(string language) => new SentimentSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from SentimentSkillLanguage to string.
        /// </summary>
        /// <param name="language">SentimentSkillLanguage to convert.</param>
        /// <returns>The SentimentSkillLanguage as a string.</returns>
        public static explicit operator string(SentimentSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two SentimentSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first SentimentSkillLanguage to compare.</param>
        /// <param name="rhs">The second SentimentSkillLanguage to compare.</param>
        /// <returns>true if the SentimentSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(SentimentSkillLanguage lhs, SentimentSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two SentimentSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first SentimentSkillLanguage to compare.</param>
        /// <param name="rhs">The second SentimentSkillLanguage to compare.</param>
        /// <returns>true if the SentimentSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(SentimentSkillLanguage lhs, SentimentSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the SentimentSkillLanguage for equality with another SentimentSkillLanguage.
        /// </summary>
        /// <param name="other">The SentimentSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the SentimentSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(SentimentSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is SentimentSkillLanguage ? Equals((SentimentSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the SentimentSkillLanguage.
        /// </summary>
        /// <returns>The SentimentSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}
