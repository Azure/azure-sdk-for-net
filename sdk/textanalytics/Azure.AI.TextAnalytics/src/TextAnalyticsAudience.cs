// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Cloud audiences available for ACR. </summary>
    public readonly partial struct TextAnalyticsAudience : IEquatable<TextAnalyticsAudience>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="TextAnalyticsAudience"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TextAnalyticsAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureResourceManagerChinaValue = "https://cognitiveservices.azure.cn/.default";
        private const string AzureResourceManagerGovernmentValue = "https://cognitiveservices.azure.us/.default";
        private const string AzureResourceManagerPublicCloudValue = "https://cognitiveservices.azure.com/.default";

        /// <summary> Azure China. </summary>
        public static TextAnalyticsAudience AzureResourceManagerChina { get; } = new TextAnalyticsAudience(AzureResourceManagerChinaValue);

        /// <summary> Azure Government. </summary>
        public static TextAnalyticsAudience AzureResourceManagerGovernment { get; } = new TextAnalyticsAudience(AzureResourceManagerGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static TextAnalyticsAudience AzureResourceManagerPublicCloud { get; } = new TextAnalyticsAudience(AzureResourceManagerPublicCloudValue);

        /// <summary> Determines if two <see cref="TextAnalyticsAudience"/> values are the same. </summary>
        public static bool operator ==(TextAnalyticsAudience left, TextAnalyticsAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TextAnalyticsAudience"/> values are not the same. </summary>
        public static bool operator !=(TextAnalyticsAudience left, TextAnalyticsAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TextAnalyticsAudience"/>. </summary>
        public static implicit operator TextAnalyticsAudience(string value) => new TextAnalyticsAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAnalyticsAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TextAnalyticsAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
