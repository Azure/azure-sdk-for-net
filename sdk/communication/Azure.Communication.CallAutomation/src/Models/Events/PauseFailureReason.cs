// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Pause failure reason.
    /// </summary>
    public readonly partial struct PauseFailureReason : IEquatable<PauseFailureReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PauseFailureReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PauseFailureReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DownloadFailedValue = "8536";
        private const string OperationCancelledValue = "8508";
        private const string InvalidFileFormatValue = "8535";
        private const string UspecifiedErrorValue = "9999";

        /// <summary> Action failed, file could not be downloaded. </summary>
        public static PauseFailureReason DownloadFailed { get; } = new PauseFailureReason(DownloadFailedValue);
        /// <summary> Action falied, the operation was cancelled. </summary>
        public static PauseFailureReason OperationCancelled { get; } = new PauseFailureReason(OperationCancelledValue);
        /// <summary> Action failed, file could not be downloaded. </summary>
        public static PauseFailureReason InvalidFileFormat { get; } = new PauseFailureReason(InvalidFileFormatValue);
        /// <summary> Unknown internal server error. </summary>
        public static PauseFailureReason UspecifiedError { get; } = new PauseFailureReason(UspecifiedErrorValue);
        /// <summary> Determines if two <see cref="PauseFailureReason"/> values are the same. </summary>
        public static bool operator ==(PauseFailureReason left, PauseFailureReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PauseFailureReason"/> values are not the same. </summary>
        public static bool operator !=(PauseFailureReason left, PauseFailureReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PauseFailureReason"/>. </summary>
        public static implicit operator PauseFailureReason(string value) => new PauseFailureReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PauseFailureReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PauseFailureReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
