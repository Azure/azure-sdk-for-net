// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly partial struct TextAnalyticsInnerErrorCode : IEquatable<TextAnalyticsInnerErrorCode>
    {
        private readonly string _value;

        /// <summary>
        /// </summary>
        public TextAnalyticsInnerErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidParameterValueValue = "invalidParameterValue";
        private const string InvalidRequestBodyFormatValue = "invalidRequestBodyFormat";
        private const string EmptyRequestValue = "emptyRequest";
        private const string MissingInputRecordsValue = "missingInputRecords";
        private const string InvalidDocumentValue = "invalidDocument";
        private const string ModelVersionIncorrectValue = "modelVersionIncorrect";
        private const string InvalidDocumentBatchValue = "invalidDocumentBatch";
        private const string UnsupportedLanguageCodeValue = "unsupportedLanguageCode";
        private const string InvalidCountryHintValue = "invalidCountryHint";

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode InvalidParameterValue { get; } = new TextAnalyticsInnerErrorCode(InvalidParameterValueValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode InvalidRequestBodyFormat { get; } = new TextAnalyticsInnerErrorCode(InvalidRequestBodyFormatValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode EmptyRequest { get; } = new TextAnalyticsInnerErrorCode(EmptyRequestValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode MissingInputRecords { get; } = new TextAnalyticsInnerErrorCode(MissingInputRecordsValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode InvalidDocument { get; } = new TextAnalyticsInnerErrorCode(InvalidDocumentValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode ModelVersionIncorrect { get; } = new TextAnalyticsInnerErrorCode(ModelVersionIncorrectValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode InvalidDocumentBatch { get; } = new TextAnalyticsInnerErrorCode(InvalidDocumentBatchValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode UnsupportedLanguageCode { get; } = new TextAnalyticsInnerErrorCode(UnsupportedLanguageCodeValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsInnerErrorCode InvalidCountryHint { get; } = new TextAnalyticsInnerErrorCode(InvalidCountryHintValue);

        /// <summary>
        /// </summary>
        public static bool operator ==(TextAnalyticsInnerErrorCode left, TextAnalyticsInnerErrorCode right) => left.Equals(right);

        /// <summary>
        /// </summary>
        public static bool operator !=(TextAnalyticsInnerErrorCode left, TextAnalyticsInnerErrorCode right) => !left.Equals(right);

        /// <summary>
        /// </summary>
        public static implicit operator TextAnalyticsInnerErrorCode(string value) => new TextAnalyticsInnerErrorCode(value);

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAnalyticsInnerErrorCode other && Equals(other);

        /// <summary>
        /// </summary>
        public bool Equals(TextAnalyticsInnerErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// </summary>
        public override string ToString() => _value;
    }
}
