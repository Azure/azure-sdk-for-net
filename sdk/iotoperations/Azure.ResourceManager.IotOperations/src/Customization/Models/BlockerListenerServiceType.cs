// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> Kubernetes Service Types supported by Listener. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("BlockerListenerServiceType is deprecated. Please use BrokerListenerServiceType instead.")]
    public readonly partial struct BlockerListenerServiceType : IEquatable<BlockerListenerServiceType>
    {
        private readonly string _value;
        /// <summary> Cluster IP Service. </summary>
        private const string ClusterIPValue = "ClusterIp";
        /// <summary> Load Balancer Service. </summary>
        private const string LoadBalancerValue = "LoadBalancer";
        /// <summary> Node Port Service. </summary>
        private const string NodePortValue = "NodePort";

        /// <summary> Initializes a new instance of <see cref="BlockerListenerServiceType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BlockerListenerServiceType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Cluster IP Service. </summary>
        public static BlockerListenerServiceType ClusterIP { get; } = new BlockerListenerServiceType(ClusterIPValue);

        /// <summary> Load Balancer Service. </summary>
        public static BlockerListenerServiceType LoadBalancer { get; } = new BlockerListenerServiceType(LoadBalancerValue);

        /// <summary> Node Port Service. </summary>
        public static BlockerListenerServiceType NodePort { get; } = new BlockerListenerServiceType(NodePortValue);

        /// <summary> Determines if two <see cref="BlockerListenerServiceType"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(BlockerListenerServiceType left, BlockerListenerServiceType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="BlockerListenerServiceType"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(BlockerListenerServiceType left, BlockerListenerServiceType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="BlockerListenerServiceType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator BlockerListenerServiceType(string value) => new BlockerListenerServiceType(value);

        /// <summary> Converts a string to a <see cref="BlockerListenerServiceType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator BlockerListenerServiceType?(string value) => value == null ? null : new BlockerListenerServiceType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlockerListenerServiceType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(BlockerListenerServiceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
