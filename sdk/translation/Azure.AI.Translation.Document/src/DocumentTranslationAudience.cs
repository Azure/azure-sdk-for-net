// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary> Cloud audiences available for the Azure Document Translation Service. </summary>
    public readonly partial struct DocumentTranslationAudience : IEquatable<DocumentTranslationAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For the Azure Document Translation Service, this value corresponds
        /// to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://docs.microsoft.com/azure/cognitive-services/translator/sovereign-clouds?tabs=us" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="value"/> is empty. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public DocumentTranslationAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static DocumentTranslationAudience AzureChina { get; } = new DocumentTranslationAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static DocumentTranslationAudience AzureGovernment { get; } = new DocumentTranslationAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static DocumentTranslationAudience AzurePublicCloud { get; } = new DocumentTranslationAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="DocumentTranslationAudience"/> values are the same. </summary>
        public static bool operator ==(DocumentTranslationAudience left, DocumentTranslationAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentTranslationAudience"/> values are not the same. </summary>
        public static bool operator !=(DocumentTranslationAudience left, DocumentTranslationAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentTranslationAudience"/>. </summary>
        public static implicit operator DocumentTranslationAudience(string value) => new DocumentTranslationAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentTranslationAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentTranslationAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
