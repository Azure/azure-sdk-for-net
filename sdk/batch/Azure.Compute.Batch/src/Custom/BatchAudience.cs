// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Compute.Batch
{
    /// <summary> Microsoft Entra audiences available for Azure Batch. </summary>
    public readonly struct BatchAudience : IEquatable<BatchAudience>
    {
        private const string AzurePublicCloudValue = "https://batch.core.windows.net/";
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BatchAudience"/>. </summary>
        /// <param name="value"> The Microsoft Entra resource URI, including its trailing slash when required by the service. This value does not include the <c>/.default</c> scope suffix. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="value"/> is empty. </exception>
        public BatchAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        /// <summary> Gets the audience for Azure Public Cloud. This is also the default value of <see cref="BatchAudience"/>. </summary>
        public static BatchAudience AzurePublicCloud { get; } = new BatchAudience(AzurePublicCloudValue);

        /// <summary> Gets the audience for Azure Government. </summary>
        public static BatchAudience AzureGovernment { get; } = new BatchAudience("https://batch.core.usgovcloudapi.net/");

        /// <summary> Gets the audience for Azure China. </summary>
        public static BatchAudience AzureChina { get; } = new BatchAudience("https://batch.chinacloudapi.cn/");

        /// <summary> Determines whether two audiences are equal. </summary>
        public static bool operator ==(BatchAudience left, BatchAudience right) => left.Equals(right);

        /// <summary> Determines whether two audiences are different. </summary>
        public static bool operator !=(BatchAudience left, BatchAudience right) => !left.Equals(right);

        /// <summary> Converts a resource URI to an audience. </summary>
        public static implicit operator BatchAudience(string value) => new BatchAudience(value);

        /// <inheritdoc/>
        public bool Equals(BatchAudience other) => string.Equals(ToString(), other.ToString(), StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BatchAudience other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(ToString());

        /// <inheritdoc/>
        public override string ToString() => _value ?? AzurePublicCloudValue;
    }
}
