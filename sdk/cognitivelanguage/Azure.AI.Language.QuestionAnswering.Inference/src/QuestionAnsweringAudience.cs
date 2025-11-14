// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary> Cloud audiences available for QuestionAnswering. </summary>
    public readonly partial struct QuestionAnsweringAudience : IEquatable<QuestionAnsweringAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes.For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://docs.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public QuestionAnsweringAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static QuestionAnsweringAudience AzureChina { get; } = new QuestionAnsweringAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static QuestionAnsweringAudience AzureGovernment { get; } = new QuestionAnsweringAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static QuestionAnsweringAudience AzurePublicCloud { get; } = new QuestionAnsweringAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="QuestionAnsweringAudience"/> values are the same. </summary>
        public static bool operator ==(QuestionAnsweringAudience left, QuestionAnsweringAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QuestionAnsweringAudience"/> values are not the same. </summary>
        public static bool operator !=(QuestionAnsweringAudience left, QuestionAnsweringAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="QuestionAnsweringAudience"/>. </summary>
        public static implicit operator QuestionAnsweringAudience(string value) => new QuestionAnsweringAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QuestionAnsweringAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QuestionAnsweringAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
