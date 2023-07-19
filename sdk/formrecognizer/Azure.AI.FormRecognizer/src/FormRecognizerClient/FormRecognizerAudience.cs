// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    /// <summary> Cloud audiences available for FormRecognizer. </summary>
    public readonly partial struct FormRecognizerAudience : IEquatable<FormRecognizerAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For FormRecognizer, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://docs.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="value"/> is empty. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public FormRecognizerAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://cognitiveservices.azure.cn";
        private const string AzureGovernmentValue = "https://cognitiveservices.azure.us";
        private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";

        /// <summary> Azure China. </summary>
        public static FormRecognizerAudience AzureChina { get; } = new FormRecognizerAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static FormRecognizerAudience AzureGovernment { get; } = new FormRecognizerAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static FormRecognizerAudience AzurePublicCloud { get; } = new FormRecognizerAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="FormRecognizerAudience"/> values are the same. </summary>
        public static bool operator ==(FormRecognizerAudience left, FormRecognizerAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FormRecognizerAudience"/> values are not the same. </summary>
        public static bool operator !=(FormRecognizerAudience left, FormRecognizerAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FormRecognizerAudience"/>. </summary>
        public static implicit operator FormRecognizerAudience(string value) => new FormRecognizerAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FormRecognizerAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FormRecognizerAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
