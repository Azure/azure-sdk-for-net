// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    /// <summary>Cloud audiences available for Question Answering Authoring.</summary>
    public readonly partial struct QuestionAnsweringAuthoringAudience : IEquatable<QuestionAnsweringAuthoringAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringAuthoringAudience"/> object.
        /// </summary>
        /// <param name="value">
        /// The Azure Active Directory audience to use when forming authorization scopes.
        /// For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public QuestionAnsweringAuthoringAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary>Azure China.</summary>
        public static QuestionAnsweringAuthoringAudience AzureChina { get; } = new QuestionAnsweringAuthoringAudience(AzureChinaValue);

        /// <summary>Azure Government.</summary>
        public static QuestionAnsweringAuthoringAudience AzureGovernment { get; } = new QuestionAnsweringAuthoringAudience(AzureGovernmentValue);

        /// <summary>Azure Public Cloud.</summary>
        public static QuestionAnsweringAuthoringAudience AzurePublicCloud { get; } = new QuestionAnsweringAuthoringAudience(AzurePublicCloudValue);

        /// <summary>Determines if two <see cref="QuestionAnsweringAuthoringAudience"/> values are the same.</summary>
        public static bool operator ==(QuestionAnsweringAuthoringAudience left, QuestionAnsweringAuthoringAudience right) => left.Equals(right);

        /// <summary>Determines if two <see cref="QuestionAnsweringAuthoringAudience"/> values are not the same.</summary>
        public static bool operator !=(QuestionAnsweringAuthoringAudience left, QuestionAnsweringAuthoringAudience right) => !left.Equals(right);

        /// <summary>Converts a string to a <see cref="QuestionAnsweringAuthoringAudience"/>.</summary>
        public static implicit operator QuestionAnsweringAuthoringAudience(string value) => new QuestionAnsweringAuthoringAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QuestionAnsweringAuthoringAudience other && Equals(other);

        /// <inheritdoc />
        public bool Equals(QuestionAnsweringAuthoringAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
