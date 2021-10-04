// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Cloud audiences available for <see cref="MetricsQueryClient"/>.
    /// </summary>
    public readonly partial struct MetricsQueryClientAudience : IEquatable<MetricsQueryClientAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsQueryClientAudience"/> with a given value.
        /// </summary>
        public MetricsQueryClientAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureResourceManagerChinaValue = "https://management.chinacloudapi.cn";
        private const string AzureResourceManagerGermanyValue = "https://management.microsoftazure.de";
        private const string AzureResourceManagerGovernmentValue = "https://management.usgovcloudapi.net";
        private const string AzureResourceManagerPublicCloudValue = "https://management.azure.com";

        /// <summary> Azure China. </summary>
        public static MetricsQueryClientAudience AzureResourceManagerChina { get; } = new(AzureResourceManagerChinaValue);
        /// <summary> Azure Germany. </summary>
        public static MetricsQueryClientAudience AzureResourceManagerGermany { get; } = new(AzureResourceManagerGermanyValue);
        /// <summary> Azure Government. </summary>
        public static MetricsQueryClientAudience AzureResourceManagerGovernment { get; } = new(AzureResourceManagerGovernmentValue);
        /// <summary> Azure Public Cloud. </summary>
        public static MetricsQueryClientAudience AzureResourceManagerPublicCloud { get; } = new(AzureResourceManagerPublicCloudValue);

        /// <summary> Determines if two <see cref="MetricsQueryClientAudience"/> values are the same. </summary>
        public static bool operator ==(MetricsQueryClientAudience left, MetricsQueryClientAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MetricsQueryClientAudience"/> values are not the same. </summary>
        public static bool operator !=(MetricsQueryClientAudience left, MetricsQueryClientAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MetricsQueryClientAudience"/>. </summary>
        public static implicit operator MetricsQueryClientAudience(string value) => new(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MetricsQueryClientAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MetricsQueryClientAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}