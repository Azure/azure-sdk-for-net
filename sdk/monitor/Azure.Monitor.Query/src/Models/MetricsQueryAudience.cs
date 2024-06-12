// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Monitor.Query
{
    /// <summary> Cloud audiences available for Query. </summary>
    public readonly partial struct MetricsQueryAudience : IEquatable<MetricsQueryAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsQueryAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes. For the language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/en-us/azure/azure-government/documentation-government-manage-oms" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Use one of the constant members over creating a custom value, unless you have special needs for doing so.</remarks>
        public MetricsQueryAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://management.chinacloudapi.cn";
        private const string AzureGovernmentValue = "https://management.usgovcloudapi.net";
        private const string AzurePublicCloudValue = "https://management.azure.com";

        /// <summary> Azure China. </summary>
        public static MetricsQueryAudience AzureChina { get; } = new MetricsQueryAudience(AzureChinaValue);

        /// <summary> Azure US Government. </summary>
        public static MetricsQueryAudience AzureGovernment { get; } = new MetricsQueryAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static MetricsQueryAudience AzurePublicCloud { get; } = new MetricsQueryAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="MetricsQueryAudience"/> values are the same. </summary>
        public static bool operator ==(MetricsQueryAudience left, MetricsQueryAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MetricsQueryAudience"/> values are not the same. </summary>
        public static bool operator !=(MetricsQueryAudience left, MetricsQueryAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MetricsQueryAudience"/>. </summary>
        public static implicit operator MetricsQueryAudience(string value) => new MetricsQueryAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MetricsQueryAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MetricsQueryAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
