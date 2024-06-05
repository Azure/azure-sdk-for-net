// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Monitor.Query
{
    /// <summary> Cloud audiences available for <see cref="MetricsClient"/>. </summary>
    public readonly partial struct MetricsClientAudience : IEquatable<MetricsClientAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsClientAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes. This value corresponds to a URL that identifies the Azure cloud where the resource is located.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Use one of the constant members over creating a custom value, unless you have special needs for doing so.</remarks>
        public MetricsClientAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://metrics.monitor.azure.cn";
        private const string AzureGovernmentValue = "https://metrics.monitor.azure.us";
        private const string AzurePublicCloudValue = "https://metrics.monitor.azure.com";

        /// <summary> Azure China. </summary>
        public static MetricsClientAudience AzureChina { get; } = new MetricsClientAudience(AzureChinaValue);

        /// <summary> Azure US Government. </summary>
        public static MetricsClientAudience AzureGovernment { get; } = new MetricsClientAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static MetricsClientAudience AzurePublicCloud { get; } = new MetricsClientAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="MetricsClientAudience"/> values are the same. </summary>
        public static bool operator ==(MetricsClientAudience left, MetricsClientAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MetricsClientAudience"/> values are not the same. </summary>
        public static bool operator !=(MetricsClientAudience left, MetricsClientAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MetricsClientAudience"/>. </summary>
        public static implicit operator MetricsClientAudience(string value) => new MetricsClientAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MetricsClientAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MetricsClientAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
