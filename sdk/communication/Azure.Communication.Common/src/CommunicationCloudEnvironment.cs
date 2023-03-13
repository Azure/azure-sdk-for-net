// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Communication
{
    /// <summary> The cloud that the identifier belongs to. </summary>
    [ExcludeFromCodeCoverage]
    public readonly partial struct CommunicationCloudEnvironment : IEquatable<CommunicationCloudEnvironment>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="CommunicationCloudEnvironment"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CommunicationCloudEnvironment(string value)
            => _value = value ?? throw new ArgumentNullException(nameof(value));

        private const string PublicValue = "public";
        private const string DodValue = "dod";
        private const string GcchValue = "gcch";

        /// <summary> public. </summary>
        public static CommunicationCloudEnvironment Public { get; } = new CommunicationCloudEnvironment(PublicValue);
        /// <summary> dod. </summary>
        public static CommunicationCloudEnvironment Dod { get; } = new CommunicationCloudEnvironment(DodValue);
        /// <summary> gcch. </summary>
        public static CommunicationCloudEnvironment Gcch { get; } = new CommunicationCloudEnvironment(GcchValue);
        /// <summary> Determines if two <see cref="CommunicationCloudEnvironment"/> values are the same. </summary>
        public static bool operator ==(CommunicationCloudEnvironment left, CommunicationCloudEnvironment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CommunicationCloudEnvironment"/> values are not the same. </summary>
        public static bool operator !=(CommunicationCloudEnvironment left, CommunicationCloudEnvironment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CommunicationCloudEnvironment"/>. </summary>
        public static implicit operator CommunicationCloudEnvironment(string value) => new(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CommunicationCloudEnvironment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CommunicationCloudEnvironment other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
