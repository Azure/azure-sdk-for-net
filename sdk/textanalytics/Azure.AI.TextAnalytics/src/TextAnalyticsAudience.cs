// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Cloud audiences available for TextAnalytics. </summary>
    public readonly partial struct TextAnalyticsAudience : IEquatable<TextAnalyticsAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes.For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://docs.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public TextAnalyticsAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static TextAnalyticsAudience AzureChina { get; } = new TextAnalyticsAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static TextAnalyticsAudience AzureGovernment { get; } = new TextAnalyticsAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static TextAnalyticsAudience AzurePublicCloud { get; } = new TextAnalyticsAudience(AzurePublicCloudValue);

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
