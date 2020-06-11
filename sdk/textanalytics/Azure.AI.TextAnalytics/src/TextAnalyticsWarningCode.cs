// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics warning code values.
    /// </summary>
    public readonly struct TextAnalyticsWarningCode : IEquatable<TextAnalyticsWarningCode>
    {
        private readonly string _value;

        /// <summary>
        /// Specifies that the warning code is long words in document.
        /// </summary>
        public static readonly string LongWordsInDocument = "LongWordsInDocument";

        /// <summary>
        /// Specifies that the warning code is a document truncated.
        /// </summary>
        public static readonly string DocumentTruncated = "DocumentTruncated";

        private TextAnalyticsWarningCode(string warningCode)
        {
            Argument.AssertNotNullOrEmpty(warningCode, nameof(warningCode));
            _value = warningCode;
        }

        /// <summary>
        /// Defines implicit conversion from string to TextAnalyticsWarningCode.
        /// </summary>
        /// <param name="warningCode">string to convert.</param>
        /// <returns>The string as an TextAnalyticsWarningCode.</returns>
        public static implicit operator TextAnalyticsWarningCode(string warningCode) => new TextAnalyticsWarningCode(warningCode);

        /// <summary>
        /// Defines explicit conversion from TextAnalyticsWarningCode to string.
        /// </summary>
        /// <param name="warningCode">TextAnalyticsWarningCode to convert.</param>
        /// <returns>The TextAnalyticsWarningCode as a string.</returns>
        public static explicit operator string(TextAnalyticsWarningCode warningCode) => warningCode._value;

        /// <summary>
        /// Compares two TextAnalyticsWarningCode values for equality.
        /// </summary>
        /// <param name="left">The first TextAnalyticsWarningCode to compare.</param>
        /// <param name="right">The second TextAnalyticsWarningCode to compare.</param>
        /// <returns>true if the TextAnalyticsWarningCode objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(TextAnalyticsWarningCode left, TextAnalyticsWarningCode right) => Equals(left, right);

        /// <summary>
        /// Compares two TextAnalyticsWarningCode values for inequality.
        /// </summary>
        /// <param name="left">The first TextAnalyticsWarningCode to compare.</param>
        /// <param name="right">The second TextAnalyticsWarningCode to compare.</param>
        /// <returns>true if the TextAnalyticsWarningCode objects are not equal; false otherwise.</returns>
        public static bool operator !=(TextAnalyticsWarningCode left, TextAnalyticsWarningCode right) => !Equals(left, right);

        /// <summary>
        /// Compares the TextAnalyticsWarningCode for equality with another TextAnalyticsWarningCode.
        /// </summary>
        /// <param name="other">The TextAnalyticsWarningCode with which to compare.</param>
        /// <returns><c>true</c> if the TextAnalyticsWarningCode objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(TextAnalyticsWarningCode other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAnalyticsWarningCode warningCode && Equals(warningCode);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the TextAnalyticsWarningCode.
        /// </summary>
        /// <returns>The TextAnalyticsWarningCode as a string.</returns>
        public override string ToString() => _value;
    }
}
