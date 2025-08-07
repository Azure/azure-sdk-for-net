// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <summary> Cloud audiences available for Conversations Authoring. </summary>
    internal readonly partial struct ConversationsAuthoringAudience : IEquatable<ConversationsAuthoringAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationsAuthoringAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For the Conversations Authoring service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public ConversationsAuthoringAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static ConversationsAuthoringAudience AzureChina { get; } = new ConversationsAuthoringAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static ConversationsAuthoringAudience AzureGovernment { get; } = new ConversationsAuthoringAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static ConversationsAuthoringAudience AzurePublicCloud { get; } = new ConversationsAuthoringAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="ConversationsAuthoringAudience"/> values are the same. </summary>
        public static bool operator ==(ConversationsAuthoringAudience left, ConversationsAuthoringAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConversationsAuthoringAudience"/> values are not the same. </summary>
        public static bool operator !=(ConversationsAuthoringAudience left, ConversationsAuthoringAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConversationsAuthoringAudience"/>. </summary>
        public static implicit operator ConversationsAuthoringAudience(string value) => new ConversationsAuthoringAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConversationsAuthoringAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConversationsAuthoringAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
