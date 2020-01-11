// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly partial struct TextAnalyticsErrorCode : IEquatable<TextAnalyticsErrorCode>
    {
        private readonly string _value;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public TextAnalyticsErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidRequestValue = "invalidRequest";
        private const string InvalidArgumentValue = "invalidArgument";
        private const string InternalServerErrorValue = "internalServerError";
        private const string ServiceUnavailableValue = "serviceUnavailable";

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidRequest { get; } = new TextAnalyticsErrorCode(InvalidRequestValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidArgument { get; } = new TextAnalyticsErrorCode(InvalidArgumentValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InternalServerError { get; } = new TextAnalyticsErrorCode(InternalServerErrorValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode ServiceUnavailable { get; } = new TextAnalyticsErrorCode(ServiceUnavailableValue);

        /// <summary>
        /// </summary>
        public static bool operator ==(TextAnalyticsErrorCode left, TextAnalyticsErrorCode right) => left.Equals(right);

        /// <summary>
        /// </summary>
        public static bool operator !=(TextAnalyticsErrorCode left, TextAnalyticsErrorCode right) => !left.Equals(right);

        /// <summary>
        /// </summary>
        public static implicit operator TextAnalyticsErrorCode(string value) => new TextAnalyticsErrorCode(value);

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAnalyticsErrorCode other && Equals(other);

        /// <summary>
        /// </summary>
        public bool Equals(TextAnalyticsErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// </summary>
        public override string ToString() => _value;
    }
}
