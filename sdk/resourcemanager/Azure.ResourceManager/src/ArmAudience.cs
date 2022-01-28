// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager
{
    /// <summary>
    /// ArmAudience represents the audience of Azure Cloud.
    /// </summary>
    public readonly struct ArmAudience : IEquatable<ArmAudience>
    {
        // name after the `name` property of returned audience from https://management.azure.com/metadata/endpoints?api-version=2019-11-01
        /// <summary> Azure Public Cloud. </summary>
        public static readonly ArmAudience AzureCloud = new ArmAudience("https://management.azure.com/");

        /// <summary> Azure China Cloud. </summary>
        public static readonly ArmAudience AzureChinaCloud = new ArmAudience("https://management.chinacloudapi.cn");

        /// <summary> Azure US Government. </summary>
        public static readonly ArmAudience AzureUSGovernment = new ArmAudience("https://management.usgovcloudapi.net");

        /// <summary> Azure German Cloud. </summary>
        public static readonly ArmAudience AzureGermanCloud = new ArmAudience("https://management.microsoftazure.de");

        /// <summary>
        /// Default scope of this audience.
        /// </summary>
        public string DefaultScope => GetScope(".default");

        private readonly string _value;

        /// <summary>
        /// Construct an <see cref="ArmAudience"/> using the given value.
        /// </summary>
        /// <param name="value"></param>
        public ArmAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private string GetScope(string permission)
        {
            return $"{_value}/{permission}";
        }

        /// <summary> Determines if two <see cref="ArmAudience"/> values are the same. </summary>
        public static bool operator ==(ArmAudience left, ArmAudience right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ArmAudience"/> values are not the same. </summary>
        public static bool operator !=(ArmAudience left, ArmAudience right) => !left.Equals(right);

        /// <summary> Converts a string to an <see cref="ArmAudience"/>. </summary>
        public static implicit operator ArmAudience(string value) => new ArmAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ArmAudience other && Equals(other);

        /// <inheritdoc />
        public bool Equals(ArmAudience other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
