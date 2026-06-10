// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Grafana.Models
{
    /// <summary>
    /// The StartTLSPolicy setting of the SMTP configuration
    /// https://pkg.go.dev/github.com/go-mail/mail#StartTLSPolicy
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This struct is obsolete and will be removed in a future release", false)]
    public readonly partial struct StartTLSPolicy : IEquatable<StartTLSPolicy>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StartTLSPolicy"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StartTLSPolicy(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OpportunisticStartTLSValue = "OpportunisticStartTLS";
        private const string MandatoryStartTLSValue = "MandatoryStartTLS";
        private const string NoStartTLSValue = "NoStartTLS";

        /// <summary> OpportunisticStartTLS. </summary>
        public static StartTLSPolicy OpportunisticStartTLS { get; } = new StartTLSPolicy(OpportunisticStartTLSValue);
        /// <summary> MandatoryStartTLS. </summary>
        public static StartTLSPolicy MandatoryStartTLS { get; } = new StartTLSPolicy(MandatoryStartTLSValue);
        /// <summary> NoStartTLS. </summary>
        public static StartTLSPolicy NoStartTLS { get; } = new StartTLSPolicy(NoStartTLSValue);
        /// <summary> Determines if two <see cref="StartTLSPolicy"/> values are the same. </summary>
        public static bool operator ==(StartTLSPolicy left, StartTLSPolicy right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StartTLSPolicy"/> values are not the same. </summary>
        public static bool operator !=(StartTLSPolicy left, StartTLSPolicy right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="StartTLSPolicy"/>. </summary>
        public static implicit operator StartTLSPolicy(string value) => new StartTLSPolicy(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StartTLSPolicy other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StartTLSPolicy other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
