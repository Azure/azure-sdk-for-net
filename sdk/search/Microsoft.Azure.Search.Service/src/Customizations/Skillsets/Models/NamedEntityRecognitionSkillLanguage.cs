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
    /// Defines the format of NamedEntityRecognitionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<NamedEntityRecognitionSkillLanguage>))]
    [Obsolete("Use EntityRecognitionSkillLanguage instead.")]
    public struct NamedEntityRecognitionSkillLanguage : IEquatable<NamedEntityRecognitionSkillLanguage>
    {
        private readonly string _value;

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

        private NamedEntityRecognitionSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to NamedEntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a NamedEntityRecognitionSkillLanguage.</returns>
        public static implicit operator NamedEntityRecognitionSkillLanguage(string language) =>
            new NamedEntityRecognitionSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from NamedEntityRecognitionSkillLanguage to string.
        /// </summary>
        /// <param name="language">NamedEntityRecognitionSkillLanguage to convert.</param>
        /// <returns>The NamedEntityRecognitionSkillLanguage as a string.</returns>
        public static explicit operator string(NamedEntityRecognitionSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two NamedEntityRecognitionSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first NamedEntityRecognitionSkillLanguage to compare.</param>
        /// <param name="rhs">The second NamedEntityRecognitionSkillLanguage to compare.</param>
        /// <returns>true if the NamedEntityRecognitionSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(NamedEntityRecognitionSkillLanguage lhs, NamedEntityRecognitionSkillLanguage rhs) =>
            Equals(lhs, rhs);

        /// <summary>
        /// Compares two NamedEntityRecognitionSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first NamedEntityRecognitionSkillLanguage to compare.</param>
        /// <param name="rhs">The second NamedEntityRecognitionSkillLanguage to compare.</param>
        /// <returns>true if the NamedEntityRecognitionSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(NamedEntityRecognitionSkillLanguage lhs, NamedEntityRecognitionSkillLanguage rhs) =>
            !Equals(lhs, rhs);

        /// <summary>
        /// Compares the NamedEntityRecognitionSkillLanguage for equality with another NamedEntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="other">The NamedEntityRecognitionSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the NamedEntityRecognitionSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(NamedEntityRecognitionSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) =>
            obj is NamedEntityRecognitionSkillLanguage ? Equals((NamedEntityRecognitionSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the NamedEntityRecognitionSkillLanguage.
        /// </summary>
        /// <returns>The NamedEntityRecognitionSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}
