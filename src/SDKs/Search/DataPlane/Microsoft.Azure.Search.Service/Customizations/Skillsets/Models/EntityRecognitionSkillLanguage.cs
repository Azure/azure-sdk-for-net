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
    /// Defines the format of EntityRecognitionSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<EntityRecognitionSkillLanguage>))]
    public struct EntityRecognitionSkillLanguage : IEquatable<EntityRecognitionSkillLanguage>
    {
        private readonly string _value;

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

        private EntityRecognitionSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to EntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as a EntityRecognitionSkillLanguage.</returns>
        public static implicit operator EntityRecognitionSkillLanguage(string value) => new EntityRecognitionSkillLanguage(value);

        /// <summary>
        /// Defines explicit conversion from EntityRecognitionSkillLanguage to string.
        /// </summary>
        /// <param name="language">EntityRecognitionSkillLanguage to convert.</param>
        /// <returns>The EntityRecognitionSkillLanguage as a string.</returns>
        public static explicit operator string(EntityRecognitionSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two EntityRecognitionSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first EntityRecognitionSkillLanguage to compare.</param>
        /// <param name="rhs">The second EntityRecognitionSkillLanguage to compare.</param>
        /// <returns>true if the EntityRecognitionSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(EntityRecognitionSkillLanguage lhs, EntityRecognitionSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two EntityRecognitionSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first EntityRecognitionSkillLanguage to compare.</param>
        /// <param name="rhs">The second EntityRecognitionSkillLanguage to compare.</param>
        /// <returns>true if the EntityRecognitionSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(EntityRecognitionSkillLanguage lhs, EntityRecognitionSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the EntityRecognitionSkillLanguage for equality with another EntityRecognitionSkillLanguage.
        /// </summary>
        /// <param name="other">The EntityRecognitionSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the EntityRecognitionSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(EntityRecognitionSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is EntityRecognitionSkillLanguage ? Equals((EntityRecognitionSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the EntityRecognitionSkillLanguage.
        /// </summary>
        /// <returns>The EntityRecognitionSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}
