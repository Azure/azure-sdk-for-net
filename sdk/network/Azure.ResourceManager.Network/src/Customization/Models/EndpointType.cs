// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    // Retain the type used by ConnectionMonitorEndpoint.Type before its name was corrected.
    /// <summary> The endpoint type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version. Please use ConnectionMonitorEndpointType instead.")]
    public readonly partial struct EndpointType : IEquatable<EndpointType>
    {
        private readonly ConnectionMonitorEndpointType _value;

        internal EndpointType(ConnectionMonitorEndpointType value) => _value = value;

        internal ConnectionMonitorEndpointType Value => _value;

        /// <summary> Initializes a new instance of <see cref="EndpointType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EndpointType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = new ConnectionMonitorEndpointType(value);
        }

        /// <summary> AzureVM. </summary>
        public static EndpointType AzureVM { get; } = new EndpointType("AzureVM");
        /// <summary> AzureVNet. </summary>
        public static EndpointType AzureVNet { get; } = new EndpointType("AzureVNet");
        /// <summary> AzureSubnet. </summary>
        public static EndpointType AzureSubnet { get; } = new EndpointType("AzureSubnet");
        /// <summary> ExternalAddress. </summary>
        public static EndpointType ExternalAddress { get; } = new EndpointType("ExternalAddress");
        /// <summary> MMAWorkspaceMachine. </summary>
        public static EndpointType MMAWorkspaceMachine { get; } = new EndpointType("MMAWorkspaceMachine");
        /// <summary> MMAWorkspaceNetwork. </summary>
        public static EndpointType MMAWorkspaceNetwork { get; } = new EndpointType("MMAWorkspaceNetwork");
        /// <summary> AzureArcVM. </summary>
        public static EndpointType AzureArcVM { get; } = new EndpointType("AzureArcVM");
        /// <summary> AzureVMSS. </summary>
        public static EndpointType AzureVMSS { get; } = new EndpointType("AzureVMSS");
        /// <summary> AzureArcNetwork. </summary>
        public static EndpointType AzureArcNetwork { get; } = new EndpointType("AzureArcNetwork");

        /// <summary> Determines if two values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(EndpointType left, EndpointType right) => left.Equals(right);
        /// <summary> Determines if two values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(EndpointType left, EndpointType right) => !left.Equals(right);
        /// <summary> Converts a string to an endpoint type. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator EndpointType(string value) => new EndpointType(value);
        /// <summary> Converts a string to a nullable endpoint type. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator EndpointType?(string value) => value is null ? (EndpointType?)null : new EndpointType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EndpointType other && Equals(other);
        /// <inheritdoc/>
        public bool Equals(EndpointType other) => _value.Equals(other._value);
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
