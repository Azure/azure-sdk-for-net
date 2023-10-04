// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary> Cloud audiences available for Ingestion. </summary>
    public readonly partial struct IngestionAudience : IEquatable<IngestionAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For the language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Use one of the constant members over creating a custom value, unless you have special needs for doing so.</remarks>
        public IngestionAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://monitor.azure.cn//.default";
        private const string AzureGovernmentValue = "https://monitor.azure.us//.default";
        private const string AzurePublicCloudValue = "https://monitor.azure.com//.default";

        /// <summary> Azure China. </summary>
        public static IngestionAudience AzureChina { get; } = new IngestionAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static IngestionAudience AzureGovernment { get; } = new IngestionAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static IngestionAudience AzurePublicCloud { get; } = new IngestionAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="IngestionAudience"/> values are the same. </summary>
        public static bool operator ==(IngestionAudience left, IngestionAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IngestionAudience"/> values are not the same. </summary>
        public static bool operator !=(IngestionAudience left, IngestionAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IngestionAudience"/>. </summary>
        public static implicit operator IngestionAudience(string value) => new IngestionAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IngestionAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IngestionAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
