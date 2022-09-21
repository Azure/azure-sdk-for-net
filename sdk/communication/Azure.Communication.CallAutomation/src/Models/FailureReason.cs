// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Failure Reason for incoming webhook events.
    /// </summary>
    public readonly partial struct FailureReason : IEquatable<FailureReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FailureReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FailureReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InitialSilenceTimeoutValue = "8510";
        private const string InterDigitTimeoutValue = "8532";
        private const string PlayPromptFailedValue = "8511";
        private const string UspecifiedErrorValue = "9999";

        /// <summary> Action failed, initial silence timeout reached. </summary>
        public static FailureReason InitialSilenceTimeout { get; } = new FailureReason(InitialSilenceTimeoutValue);
        /// <summary> Action failed, inter-digit silence timeout reached. </summary>
        public static FailureReason InterDigitTimeout { get; } = new FailureReason(InterDigitTimeoutValue);
        /// <summary> Action failed, encountered failure while trying to play the prompt. </summary>
        public static FailureReason PlayPromptFailed { get; } = new FailureReason(PlayPromptFailedValue);
        /// <summary> Unknown internal server error. </summary>
        public static FailureReason UspecifiedError { get; } = new FailureReason(UspecifiedErrorValue);
        /// <summary> Determines if two <see cref="FailureReason"/> values are the same. </summary>
        public static bool operator ==(FailureReason left, FailureReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FailureReason"/> values are not the same. </summary>
        public static bool operator !=(FailureReason left, FailureReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FailureReason"/>. </summary>
        public static implicit operator FailureReason(string value) => new FailureReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FailureReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FailureReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
