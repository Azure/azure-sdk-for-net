// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> Cloud audiences available for FormRecognizer.DocumentAnalysis. </summary>
    public readonly partial struct DocumentAnalysisAudience : IEquatable<DocumentAnalysisAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For FormRecognizer.DocumentAnalysis, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://docs.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="value"/> is empty. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public DocumentAnalysisAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static DocumentAnalysisAudience AzureChina { get; } = new DocumentAnalysisAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static DocumentAnalysisAudience AzureGovernment { get; } = new DocumentAnalysisAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static DocumentAnalysisAudience AzurePublicCloud { get; } = new DocumentAnalysisAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="DocumentAnalysisAudience"/> values are the same. </summary>
        public static bool operator ==(DocumentAnalysisAudience left, DocumentAnalysisAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentAnalysisAudience"/> values are not the same. </summary>
        public static bool operator !=(DocumentAnalysisAudience left, DocumentAnalysisAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentAnalysisAudience"/>. </summary>
        public static implicit operator DocumentAnalysisAudience(string value) => new DocumentAnalysisAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentAnalysisAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentAnalysisAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
