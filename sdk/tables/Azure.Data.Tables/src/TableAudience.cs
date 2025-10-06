// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.Tables
{
    /// <summary> Cloud audiences available for Azure Tables. </summary>
    public readonly struct TableAudience : IEquatable<TableAudience>
    {
        private readonly string _value;

        private const string AzureChinaValue = "AzureChina";
        private const string AzureGovernmentValue = "AzureGov";
        private const string AzurePublicCloudValue = "AzurePublic";

        private const string AzureStorageChinaValue = "https://storage.azure.cn";
        private const string AzureStorageGovernmentValue = "https://storage.azure.us";
        private const string AzureStoragePublicCloudValue = "https://storage.azure.com";
        private const string AzureCosmosChinaValue = "https://cosmos.azure.cn";
        private const string AzureCosmosGovernmentValue = "https://cosmos.azure.us";
        private const string AzureCosmosPublicCloudValue = "https://cosmos.azure.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="TableAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes.
        /// For the Azure Tables service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public TableAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        /// <summary> The authorization audience used to authenticate with the Azure China cloud. </summary>
        public static TableAudience AzureChina { get; } = new TableAudience(AzureChinaValue);

        /// <summary> The authorization audience used to authenticate with the Azure Government cloud. </summary>
        public static TableAudience AzureGovernment { get; } = new TableAudience(AzureGovernmentValue);

        /// <summary> The authorization audience used to authenticate with the Azure Public cloud. </summary>
        public static TableAudience AzurePublicCloud { get; } = new TableAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="TableAudience"/> values are the same. </summary>
        public static bool operator ==(TableAudience left, TableAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TableAudience"/> values are not the same. </summary>
        public static bool operator !=(TableAudience left, TableAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TableAudience"/>. </summary>
        public static implicit operator TableAudience(string value) => new TableAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TableAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TableAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        internal string GetDefaultScope(bool isCosmosEndpoint)
        {
            var audience = _value switch
            {
                AzureChinaValue when isCosmosEndpoint => AzureCosmosChinaValue,
                AzureGovernmentValue when isCosmosEndpoint => AzureCosmosGovernmentValue,
                AzurePublicCloudValue when isCosmosEndpoint => AzureCosmosPublicCloudValue,
                AzureChinaValue => AzureStorageChinaValue,
                AzureGovernmentValue => AzureStorageGovernmentValue,
                AzurePublicCloudValue => AzureStoragePublicCloudValue,
                _ => _value
            };

            if (audience.EndsWith($"/{TableConstants.DefaultScope}", StringComparison.InvariantCultureIgnoreCase))
            {
                return audience;
            }

            return audience.EndsWith("/", StringComparison.InvariantCultureIgnoreCase)
                ? $"{audience}{TableConstants.DefaultScope}"
                : $"{audience}/{TableConstants.DefaultScope}";
        }
    }
}
