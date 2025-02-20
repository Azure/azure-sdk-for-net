// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Cloud audiences available for ACR. </summary>
    public readonly partial struct ContainerRegistryAudience : IEquatable<ContainerRegistryAudience>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="ContainerRegistryAudience"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContainerRegistryAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureResourceManagerChinaValue = "https://management.chinacloudapi.cn";
        private const string AzureResourceManagerGermanyValue = "https://management.microsoftazure.de";
        private const string AzureResourceManagerGovernmentValue = "https://management.usgovcloudapi.net";
        private const string AzureResourceManagerPublicCloudValue = "https://management.azure.com";

        /// <summary> Azure China. </summary>
        public static ContainerRegistryAudience AzureResourceManagerChina { get; } = new ContainerRegistryAudience(AzureResourceManagerChinaValue);

        /// <summary> Azure Germany. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAudience AzureResourceManagerGermany { get; } = new ContainerRegistryAudience(AzureResourceManagerGermanyValue);

        /// <summary> Azure Government. </summary>
        public static ContainerRegistryAudience AzureResourceManagerGovernment { get; } = new ContainerRegistryAudience(AzureResourceManagerGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static ContainerRegistryAudience AzureResourceManagerPublicCloud { get; } = new ContainerRegistryAudience(AzureResourceManagerPublicCloudValue);

        /// <summary> Determines if two <see cref="ContainerRegistryAudience"/> values are the same. </summary>
        public static bool operator ==(ContainerRegistryAudience left, ContainerRegistryAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ContainerRegistryAudience"/> values are not the same. </summary>
        public static bool operator !=(ContainerRegistryAudience left, ContainerRegistryAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ContainerRegistryAudience"/>. </summary>
        public static implicit operator ContainerRegistryAudience(string value) => new ContainerRegistryAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContainerRegistryAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerRegistryAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
