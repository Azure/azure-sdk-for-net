// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Reason of why the Recognize operation succeeded.
    /// </summary>
    public readonly partial struct RecognizeSuccessReason : IEquatable<RecognizeSuccessReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RecognizeSuccessReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RecognizeSuccessReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MaxDigitsReceivedValue = "8531";
        private const string StopToneDetectedValue = "8514";
        private const string OperationCanceledValue = "8508";

        /// <summary> Action completed, max digits received. </summary>
        public static RecognizeSuccessReason MaxDigitsReceived { get; } = new RecognizeSuccessReason(MaxDigitsReceivedValue);
        /// <summary> Action completed as stop tone was detected. </summary>
        public static RecognizeSuccessReason StopToneDetected { get; } = new RecognizeSuccessReason(StopToneDetectedValue);
        /// <summary> Action falied, the operation was cancelled. </summary>
        public static RecognizeSuccessReason OperationCanceled { get; } = new RecognizeSuccessReason(OperationCanceledValue);

        /// <summary> Determines if two <see cref="RecognizeSuccessReason"/> values are the same. </summary>
        public static bool operator ==(RecognizeSuccessReason left, RecognizeSuccessReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RecognizeSuccessReason"/> values are not the same. </summary>
        public static bool operator !=(RecognizeSuccessReason left, RecognizeSuccessReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RecognizeSuccessReason"/>. </summary>
        public static implicit operator RecognizeSuccessReason(string value) => new RecognizeSuccessReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RecognizeSuccessReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RecognizeSuccessReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
