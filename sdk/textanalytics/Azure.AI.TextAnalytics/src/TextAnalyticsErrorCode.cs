// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics error code values.
    /// </summary>
    public readonly struct TextAnalyticsErrorCode : IEquatable<TextAnalyticsErrorCode>
    {
        private readonly string _value;

        /// <summary>
        /// Specifies that the error code is an invalid request.
        /// </summary>
        public static readonly string InvalidRequest = "InvalidRequest";

        /// <summary>
        /// Specifies that the error code is an invalid argument.
        /// </summary>
        public static readonly string InvalidArgument = "InvalidArgument";

        /// <summary>
        /// Specifies that the error code is an internal server error.
        /// </summary>
        public static readonly string InternalServerError = "InternalServerError";

        /// <summary>
        /// Specifies that the error code is service unavailable.
        /// </summary>
        public static readonly string ServiceUnavailable = "ServiceUnavailable";

        /// <summary>
        /// Specifies that the error code is an invalid parameter value.
        /// </summary>
        public static readonly string InvalidParameterValue = "InvalidParameterValue";

        /// <summary>
        /// Specifies that the error code is an invalid request body format.
        /// </summary>
        public static readonly string InvalidRequestBodyFormat = "InvalidRequestBodyFormat";

        /// <summary>
        /// Specifies that the error code is an empty request.
        /// </summary>
        public static readonly string EmptyRequest = "EmptyRequest";

        /// <summary>
        /// Specifies that the error code is a missing input records.
        /// </summary>
        public static readonly string MissingInputRecords = "MissingInputRecords";

        /// <summary>
        /// Specifies that the error code is an invalid document.
        /// </summary>
        public static readonly string InvalidDocument = "InvalidDocument";

        /// <summary>
        /// Specifies that the error code is model version incorrect.
        /// </summary>
        public static readonly string ModelVersionIncorrect = "ModelVersionIncorrect";

        /// <summary>
        /// Specifies that the error code is an invalid document batch.
        /// </summary>
        public static readonly string InvalidDocumentBatch = "InvalidDocumentBatch";

        /// <summary>
        /// Specifies that the error code is an unsupported language code.
        /// </summary>
        public static readonly string UnsupportedLanguageCode = "UnsupportedLanguageCode";

        /// <summary>
        /// Specifies that the error code is an invalid country hint.
        /// </summary>
        public static readonly string InvalidCountryHint = "InvalidCountryHint";

        private TextAnalyticsErrorCode(string errorCode)
        {
            Argument.AssertNotNullOrEmpty(errorCode, nameof(errorCode));
            _value = errorCode;
        }

        /// <summary>
        /// Defines implicit conversion from string to TextAnalyticsErrorCode.
        /// </summary>
        /// <param name="errorCode">string to convert.</param>
        /// <returns>The string as an TextAnalyticsErrorCode.</returns>
        public static implicit operator TextAnalyticsErrorCode(string errorCode) => new TextAnalyticsErrorCode(errorCode);

        /// <summary>
        /// Defines explicit conversion from TextAnalyticsErrorCode to string.
        /// </summary>
        /// <param name="errorCode">TextAnalyticsErrorCode to convert.</param>
        /// <returns>The TextAnalyticsErrorCode as a string.</returns>
        public static explicit operator string(TextAnalyticsErrorCode errorCode) => errorCode._value;

        /// <summary>
        /// Compares two TextAnalyticsErrorCode values for equality.
        /// </summary>
        /// <param name="left">The first TextAnalyticsErrorCode to compare.</param>
        /// <param name="right">The second TextAnalyticsErrorCode to compare.</param>
        /// <returns>true if the TextAnalyticsErrorCode objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(TextAnalyticsErrorCode left, TextAnalyticsErrorCode right) => Equals(left, right);

        /// <summary>
        /// Compares two TextAnalyticsErrorCode values for inequality.
        /// </summary>
        /// <param name="left">The first TextAnalyticsErrorCode to compare.</param>
        /// <param name="right">The second TextAnalyticsErrorCode to compare.</param>
        /// <returns>true if the TextAnalyticsErrorCode objects are not equal; false otherwise.</returns>
        public static bool operator !=(TextAnalyticsErrorCode left, TextAnalyticsErrorCode right) => !Equals(left, right);

        /// <summary>
        /// Compares the TextAnalyticsErrorCode for equality with another TextAnalyticsErrorCode.
        /// </summary>
        /// <param name="other">The TextAnalyticsErrorCode with which to compare.</param>
        /// <returns><c>true</c> if the TextAnalyticsErrorCode objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(TextAnalyticsErrorCode other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAnalyticsErrorCode errorCode && Equals(errorCode);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the TextAnalyticsErrorCode.
        /// </summary>
        /// <returns>The TextAnalyticsErrorCode as a string.</returns>
        public override string ToString() => _value;
    }
}
