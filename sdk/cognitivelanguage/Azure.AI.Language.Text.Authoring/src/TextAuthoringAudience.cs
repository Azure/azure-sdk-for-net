// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Text.Authoring
{
    /// <summary> Cloud audiences available for Text Authoring. </summary>
    internal readonly partial struct TextAuthoringAudience : IEquatable<TextAuthoringAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAuthoringAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For the Text Authoring service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public TextAuthoringAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static TextAuthoringAudience AzureChina { get; } = new TextAuthoringAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static TextAuthoringAudience AzureGovernment { get; } = new TextAuthoringAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static TextAuthoringAudience AzurePublicCloud { get; } = new TextAuthoringAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="TextAuthoringAudience"/> values are the same. </summary>
        public static bool operator ==(TextAuthoringAudience left, TextAuthoringAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TextAuthoringAudience"/> values are not the same. </summary>
        public static bool operator !=(TextAuthoringAudience left, TextAuthoringAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TextAuthoringAudience"/>. </summary>
        public static implicit operator TextAuthoringAudience(string value) => new TextAuthoringAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextAuthoringAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TextAuthoringAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
