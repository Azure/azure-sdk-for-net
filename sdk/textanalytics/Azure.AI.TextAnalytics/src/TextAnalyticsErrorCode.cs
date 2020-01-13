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

        // Top-level codes
        private const string InvalidRequestValue = "invalidRequest";
        private const string InvalidArgumentValue = "invalidArgument";
        private const string InternalServerErrorValue = "internalServerError";
        private const string ServiceUnavailableValue = "serviceUnavailable";

        // Codes for inner errors
        // TODO: reflect difference in docs
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
        public static TextAnalyticsErrorCode InvalidParameterValue { get; } = new TextAnalyticsErrorCode(InvalidParameterValueValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidRequestBodyFormat { get; } = new TextAnalyticsErrorCode(InvalidRequestBodyFormatValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode EmptyRequest { get; } = new TextAnalyticsErrorCode(EmptyRequestValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode MissingInputRecords { get; } = new TextAnalyticsErrorCode(MissingInputRecordsValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidDocument { get; } = new TextAnalyticsErrorCode(InvalidDocumentValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode ModelVersionIncorrect { get; } = new TextAnalyticsErrorCode(ModelVersionIncorrectValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidDocumentBatch { get; } = new TextAnalyticsErrorCode(InvalidDocumentBatchValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode UnsupportedLanguageCode { get; } = new TextAnalyticsErrorCode(UnsupportedLanguageCodeValue);

        /// <summary>
        /// </summary>
        public static TextAnalyticsErrorCode InvalidCountryHint { get; } = new TextAnalyticsErrorCode(InvalidCountryHintValue);

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
