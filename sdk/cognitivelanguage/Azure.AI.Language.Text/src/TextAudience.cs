﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Text
{
    /// <summary> Cloud audiences available for Text. </summary>
    internal readonly partial struct TextAudience : IEquatable<TextAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes.For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public TextAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static TextAudience AzureChina { get; } = new TextAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static TextAudience AzureGovernment { get; } = new TextAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static TextAudience AzurePublicCloud { get; } = new TextAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="TextAudience"/> values are the same. </summary>
        public static bool operator ==(TextAudience left, TextAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TextAudience"/> values are not the same. </summary>
        public static bool operator !=(TextAudience left, TextAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TextAudience"/>. </summary>
        public static implicit operator TextAudience(string value) => new TextAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TextAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
