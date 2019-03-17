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
    /// Defines the format of ImageAnalysisSkill supported language codes.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<ImageAnalysisSkillLanguage>))]
    public struct ImageAnalysisSkillLanguage : IEquatable<ImageAnalysisSkillLanguage>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates language code "en" (for English)
        /// </summary>
        public static readonly ImageAnalysisSkillLanguage En = new ImageAnalysisSkillLanguage("en");

        /// <summary>
        /// Indicates language code "zh" (for Simplified Chinese)
        /// </summary>
        public static readonly ImageAnalysisSkillLanguage Zh = new ImageAnalysisSkillLanguage("zh");

        private ImageAnalysisSkillLanguage(string language)
        {
            Throw.IfArgumentNull(language, nameof(language));
            _value = language;
        }

        /// <summary>
        /// Defines implicit conversion from string to ImageAnalysisSkillLanguage.
        /// </summary>
        /// <param name="language">string to convert.</param>
        /// <returns>The string as a ImageAnalysisSkillLanguage.</returns>
        public static implicit operator ImageAnalysisSkillLanguage(string language) => new ImageAnalysisSkillLanguage(language);

        /// <summary>
        /// Defines explicit conversion from ImageAnalysisSkillLanguage to string.
        /// </summary>
        /// <param name="language">ImageAnalysisSkillLanguage to convert.</param>
        /// <returns>The ImageAnalysisSkillLanguage as a string.</returns>
        public static explicit operator string(ImageAnalysisSkillLanguage language) => language.ToString();

        /// <summary>
        /// Compares two ImageAnalysisSkillLanguage values for equality.
        /// </summary>
        /// <param name="lhs">The first ImageAnalysisSkillLanguage to compare.</param>
        /// <param name="rhs">The second ImageAnalysisSkillLanguage to compare.</param>
        /// <returns>true if the ImageAnalysisSkillLanguage objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(ImageAnalysisSkillLanguage lhs, ImageAnalysisSkillLanguage rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two ImageAnalysisSkillLanguage values for inequality.
        /// </summary>
        /// <param name="lhs">The first ImageAnalysisSkillLanguage to compare.</param>
        /// <param name="rhs">The second ImageAnalysisSkillLanguage to compare.</param>
        /// <returns>true if the ImageAnalysisSkillLanguage objects are not equal; false otherwise.</returns>
        public static bool operator !=(ImageAnalysisSkillLanguage lhs, ImageAnalysisSkillLanguage rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the ImageAnalysisSkillLanguage for equality with another ImageAnalysisSkillLanguage.
        /// </summary>
        /// <param name="other">The ImageAnalysisSkillLanguage with which to compare.</param>
        /// <returns><c>true</c> if the ImageAnalysisSkillLanguage objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(ImageAnalysisSkillLanguage other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is ImageAnalysisSkillLanguage ? Equals((ImageAnalysisSkillLanguage)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the ImageAnalysisSkillLanguage.
        /// </summary>
        /// <returns>The ImageAnalysisSkillLanguage as a string.</returns>
        public override string ToString() => _value;
    }
}