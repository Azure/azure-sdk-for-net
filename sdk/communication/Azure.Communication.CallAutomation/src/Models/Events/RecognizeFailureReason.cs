// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Failure Reason for incoming webhook events.
    /// </summary>
    public readonly partial struct RecognizeFailureReason : IEquatable<RecognizeFailureReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RecognizeFailureReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RecognizeFailureReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InitialSilenceTimeoutValue = "8510";
        private const string InterDigitTimeoutValue = "8532";
        private const string PlayPromptFailedValue = "8511";
        private const string UspecifiedErrorValue = "9999";

        /// <summary> Action failed, initial silence timeout reached. </summary>
        public static RecognizeFailureReason InitialSilenceTimeout { get; } = new RecognizeFailureReason(InitialSilenceTimeoutValue);
        /// <summary> Action failed, inter-digit silence timeout reached. </summary>
        public static RecognizeFailureReason InterDigitTimeout { get; } = new RecognizeFailureReason(InterDigitTimeoutValue);
        /// <summary> Action failed, encountered failure while trying to play the prompt. </summary>
        public static RecognizeFailureReason PlayPromptFailed { get; } = new RecognizeFailureReason(PlayPromptFailedValue);
        /// <summary> Unknown internal server error. </summary>
        public static RecognizeFailureReason UspecifiedError { get; } = new RecognizeFailureReason(UspecifiedErrorValue);
        /// <summary> Determines if two <see cref="RecognizeFailureReason"/> values are the same. </summary>
        public static bool operator ==(RecognizeFailureReason left, RecognizeFailureReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RecognizeFailureReason"/> values are not the same. </summary>
        public static bool operator !=(RecognizeFailureReason left, RecognizeFailureReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RecognizeFailureReason"/>. </summary>
        public static implicit operator RecognizeFailureReason(string value) => new RecognizeFailureReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RecognizeFailureReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RecognizeFailureReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
