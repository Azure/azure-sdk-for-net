// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Failure Reason for incoming webhook events.
    /// </summary>
    public readonly partial struct ReasonCodeName : IEquatable<ReasonCodeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ReasonCodeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ReasonCodeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RecognizeInitialSilenceTimeoutValue = "8510";
        private const string RecognizeInterDigitTimeoutValue = "8532";
        private const string RecognizePlayPromptFailedValue = "8511";

        private const string RecognizeMaxDigitsReceivedValue = "8531";
        private const string RecognizeStopToneDetectedValue = "8514";

        private const string PlayDownloadFailedValue = "8536";
        private const string PlayOperationCancelledValue = "8508";
        private const string PlayInvalidFileFormatValue = "8535";

        private const string CompletedSuccessfullyValue = "0";
        private const string OperationCanceledValue = "8508";
        private const string UspecifiedErrorValue = "9999";

        /// <summary> Action failed, initial silence timeout reached. </summary>
        public static ReasonCodeName RecognizeInitialSilenceTimeout { get; } = new ReasonCodeName(RecognizeInitialSilenceTimeoutValue);
        /// <summary> Action failed, inter-digit silence timeout reached. </summary>
        public static ReasonCodeName RecognizeInterDigitTimeout { get; } = new ReasonCodeName(RecognizeInterDigitTimeoutValue);
        /// <summary> Action failed, encountered failure while trying to play the prompt. </summary>
        public static ReasonCodeName RecognizePlayPromptFailed { get; } = new ReasonCodeName(RecognizePlayPromptFailedValue);

        /// <summary> Action completed, max digits received. </summary>
        public static ReasonCodeName RecognizeMaxDigitsReceived { get; } = new ReasonCodeName(RecognizeMaxDigitsReceivedValue);
        /// <summary> Action completed as stop tone was detected. </summary>
        public static ReasonCodeName RecognizeStopToneDetected { get; } = new ReasonCodeName(RecognizeStopToneDetectedValue);

        /// <summary> Action failed, file could not be downloaded. </summary>
        public static ReasonCodeName PlayDownloadFailed { get; } = new ReasonCodeName(PlayDownloadFailedValue);
        /// <summary> Action falied, the operation was cancelled. </summary>
        public static ReasonCodeName PlayOperationCancelled { get; } = new ReasonCodeName(PlayOperationCancelledValue);
        /// <summary> Action failed, file could not be downloaded. </summary>
        public static ReasonCodeName PlayInvalidFileFormat { get; } = new ReasonCodeName(PlayInvalidFileFormatValue);

        /// <summary> Action completed successfully. </summary>
        public static ReasonCodeName CompletedSuccessfully { get; } = new ReasonCodeName (CompletedSuccessfullyValue);
        /// <summary> Unknown internal server error. </summary>
        public static ReasonCodeName UspecifiedError { get; } = new ReasonCodeName(UspecifiedErrorValue);
        /// <summary> Action falied, the operation was cancelled. </summary>
        public static ReasonCodeName OperationCanceled { get; } = new ReasonCodeName(OperationCanceledValue);

        /// <summary> Determines if two <see cref="ReasonCodeName"/> values are the same. </summary>
        public static bool operator ==(ReasonCodeName left, ReasonCodeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ReasonCodeName"/> values are not the same. </summary>
        public static bool operator !=(ReasonCodeName left, ReasonCodeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ReasonCodeName"/>. </summary>
        public static implicit operator ReasonCodeName(string value) => new ReasonCodeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ReasonCodeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ReasonCodeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
