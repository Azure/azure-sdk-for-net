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
    /// Defines the format of SplitSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SplitSkillLanguage>))]
    public struct SplitSkillLanguage : IEquatable<SplitSkillLanguage>
    {
        private readonly string _value;

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

        private SplitSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to SplitSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a SplitSkillLanguage.</returns>
        public static implicit operator SplitSkillLanguage(string language) => new SplitSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from SplitSkillLanguage to string.
        /// </summary>
        /// <param name="language">SplitSkillLanguage to convert.</param>
        /// <returns>The SplitSkillLanguage as a string.</returns>
        public static explicit operator string(SplitSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two SplitSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first SplitSkillLanguage to compare.</param>
        /// <param name="rhs">The second SplitSkillLanguage to compare.</param>
        /// <returns>true if the SplitSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(SplitSkillLanguage lhs, SplitSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two SplitSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first SplitSkillLanguage to compare.</param>
        /// <param name="rhs">The second SplitSkillLanguage to compare.</param>
        /// <returns>true if the SplitSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(SplitSkillLanguage lhs, SplitSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the SplitSkillLanguage for equality with another SplitSkillLanguage.
        /// </summary>
        /// <param name="other">The SplitSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the SplitSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(SplitSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is SplitSkillLanguage ? Equals((SplitSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the SplitSkillLanguage.
        /// </summary>
        /// <returns>The SplitSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}

