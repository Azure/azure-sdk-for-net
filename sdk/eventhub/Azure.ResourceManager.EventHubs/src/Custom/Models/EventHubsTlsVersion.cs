// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly: CodeGenSuppressType("EventHubsTlsVersion")]
namespace Azure.ResourceManager.EventHubs.Models
{
    /// <summary> The minimum TLS version for the cluster to support, e.g. &apos;1.2&apos;. </summary>
    public readonly partial struct EventHubsTlsVersion : IEquatable<EventHubsTlsVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EventHubsTlsVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EventHubsTlsVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
#pragma warning disable CA1707
        private const string Tls1_0Value = "1.0";
        private const string Tls1_1Value = "1.1";
        private const string Tls1_2Value = "1.2";

        /// <summary> 1.0. </summary>
        public static EventHubsTlsVersion Tls1_0 { get; } = new EventHubsTlsVersion(Tls1_0Value);
        /// <summary> 1.1. </summary>
        public static EventHubsTlsVersion Tls1_1 { get; } = new EventHubsTlsVersion(Tls1_1Value);
        /// <summary> 1.2. </summary>
        public static EventHubsTlsVersion Tls1_2 { get; } = new EventHubsTlsVersion(Tls1_2Value);
#pragma warning restore CA1707
        /// <summary> Determines if two <see cref="EventHubsTlsVersion"/> values are the same. </summary>
        public static bool operator ==(EventHubsTlsVersion left, EventHubsTlsVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EventHubsTlsVersion"/> values are not the same. </summary>
        public static bool operator !=(EventHubsTlsVersion left, EventHubsTlsVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EventHubsTlsVersion"/>. </summary>
        public static implicit operator EventHubsTlsVersion(string value) => new EventHubsTlsVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EventHubsTlsVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EventHubsTlsVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
