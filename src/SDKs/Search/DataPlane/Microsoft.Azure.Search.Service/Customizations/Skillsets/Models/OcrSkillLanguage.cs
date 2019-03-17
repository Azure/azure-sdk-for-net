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
    /// Defines the format of OcrSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<OcrSkillLanguage>))]
    public struct OcrSkillLanguage : IEquatable<OcrSkillLanguage>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates language code "zh-Hans" (for Chinese Simplified)
        /// </summary>
        public static readonly OcrSkillLanguage ZhHans = new OcrSkillLanguage("zh-Hans");

        /// <summary>
        /// Indicates language code "zh-Hant" (for Chinese Traditional)
        /// </summary>
        public static readonly OcrSkillLanguage ZhHant = new OcrSkillLanguage("zh-Hant");

        /// <summary>
        /// Indicates language code "cs" (for Czech)
        /// </summary>
        public static readonly OcrSkillLanguage Cs = new OcrSkillLanguage("cs");

        /// <summary>
        /// Indicates language code "da" (for Danish)
        /// </summary>
        public static readonly OcrSkillLanguage Da = new OcrSkillLanguage("da");

        /// <summary>
        /// Indicates language code "nl" (for Dutch)
        /// </summary>
        public static readonly OcrSkillLanguage Nl = new OcrSkillLanguage("nl");

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly OcrSkillLanguage En = new OcrSkillLanguage("en");

        /// <summary>
        /// Indicates language code "fi" (for Finnish)
        /// </summary>
        public static readonly OcrSkillLanguage Fi = new OcrSkillLanguage("fi");

        /// <summary>
        /// Indicates language code "fr" (for French)
        /// </summary>
        public static readonly OcrSkillLanguage Fr = new OcrSkillLanguage("fr");

        /// <summary>
        /// Indicates language code "de" (for German)
        /// </summary>
        public static readonly OcrSkillLanguage De = new OcrSkillLanguage("de");

        /// <summary>
        /// Indicates language code "el" (for Greek)
        /// </summary>
        public static readonly OcrSkillLanguage El = new OcrSkillLanguage("el");

        /// <summary>
        /// Indicates language code "hu" (for Hungarian)
        /// </summary>
        public static readonly OcrSkillLanguage Hu = new OcrSkillLanguage("hu");

        /// <summary>
        /// Indicates language code "it" (for Italian)
        /// </summary>
        public static readonly OcrSkillLanguage It = new OcrSkillLanguage("it");

        /// <summary>
        /// Indicates language code "ja" (for Japanese)
        /// </summary>
        public static readonly OcrSkillLanguage Ja = new OcrSkillLanguage("ja");

        /// <summary>
        /// Indicates language code "ko" (for Korean)
        /// </summary>
        public static readonly OcrSkillLanguage Ko = new OcrSkillLanguage("ko");

        /// <summary>
        /// Indicates language code "nb" (for Norwegian)
        /// </summary>
        public static readonly OcrSkillLanguage No = new OcrSkillLanguage("nb");

        /// <summary>
        /// Indicates language code "pl" (for Polish)
        /// </summary>
        public static readonly OcrSkillLanguage Pl = new OcrSkillLanguage("pl");

        /// <summary>
        /// Indicates language code "pt" (for Portuguese)
        /// </summary>
        public static readonly OcrSkillLanguage Pt = new OcrSkillLanguage("pt");

        /// <summary>
        /// Indicates language code "ru" (for Russian)
        /// </summary>
        public static readonly OcrSkillLanguage Ru = new OcrSkillLanguage("ru");

        /// <summary>
        /// Indicates language code "es" (for Spanish)
        /// </summary>
        public static readonly OcrSkillLanguage Es = new OcrSkillLanguage("es");

        /// <summary>
        /// Indicates language code "sv" (for Swedish)
        /// </summary>
        public static readonly OcrSkillLanguage Sv = new OcrSkillLanguage("sv");

        /// <summary>
        /// Indicates language code "tr" (for Turkish)
        /// </summary>
        public static readonly OcrSkillLanguage Tr = new OcrSkillLanguage("tr");

        /// <summary>
        /// Indicates language code "ar" (for Arabic)
        /// </summary>
        public static readonly OcrSkillLanguage Ar = new OcrSkillLanguage("ar");

        /// <summary>
        /// Indicates language code "ro" (for Romanian)
        /// </summary>
        public static readonly OcrSkillLanguage Ro = new OcrSkillLanguage("ro");

        /// <summary>
        /// Indicates language code "sr-Cyrl" (for Serbian Cyrillic)
        /// </summary>
        public static readonly OcrSkillLanguage SrCyrl = new OcrSkillLanguage("sr-Cyrl");

        /// <summary>
        /// Indicates language code "sr-Latn" (for Serbian Latin)
        /// </summary>
        public static readonly OcrSkillLanguage SrLatn = new OcrSkillLanguage("sr-Latn");

        /// <summary>
        /// Indicates language code "sk" (for Slovak)
        /// </summary>
        public static readonly OcrSkillLanguage Sk = new OcrSkillLanguage("sk");

        private OcrSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to OcrSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a OcrSkillLanguage.</returns>
        public static implicit operator OcrSkillLanguage(string language) => new OcrSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from OcrSkillLanguage to string.
        /// </summary>
        /// <param name="language">OcrSkillLanguage to convert.</param>
        /// <returns>The OcrSkillLanguage as a string.</returns>
        public static explicit operator string(OcrSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two OcrSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first OcrSkillLanguage to compare.</param>
        /// <param name="rhs">The second OcrSkillLanguage to compare.</param>
        /// <returns>true if the OcrSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(OcrSkillLanguage lhs, OcrSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two OcrSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first OcrSkillLanguage to compare.</param>
        /// <param name="rhs">The second OcrSkillLanguage to compare.</param>
        /// <returns>true if the OcrSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(OcrSkillLanguage lhs, OcrSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the OcrSkillLanguage for equality with another OcrSkillLanguage.
        /// </summary>
        /// <param name="other">The OcrSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the OcrSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(OcrSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is OcrSkillLanguage ? Equals((OcrSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the OcrSkillLanguage.
        /// </summary>
        /// <returns>The OcrSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}

