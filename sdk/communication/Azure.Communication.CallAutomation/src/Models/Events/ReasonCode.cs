// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Reason Codes for incoming webhook events.
    /// </summary>
    public readonly partial struct ReasonCode : IEquatable<ReasonCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ReasonCode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ReasonCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RecognizeInitialSilenceTimedOutValue = "8510";
        private const string RecognizeInterDigitTimedOutValue = "8532";
        private const string RecognizeDtmfOptionMatchedValue = "8533";
        private const string RecognizePlayPromptFailedValue = "8511";

        private const string RecognizeMaxDigitsReceivedValue = "8531";
        private const string RecognizeIncorrectToneDetectedValue = "8534";
        private const string RecognizeStopToneDetectedValue = "8514";
        private const string RecognizeSpeechOptionMatchedValue = "8545";
        private const string RecognizeSpeechOptionNotMatchedValue = "8547";
        private const string RecognizeSpeechNotRecognizedValue = "8563";
        private const string RecognizeSpeechServiceConnectionErrorValue = "8564";

        private const string PlayDownloadFailedValue = "8536";
        private const string PlayInvalidFileFormatValue = "8535";
        private const string PlayCognitiveServicesPlayErrorValue = "8565";

        private const string CompletedSuccessfullyValue = "0";
        private const string UnspecifiedErrorValue = "9999";

        /// <summary> Action failed, initial silence timeout reached. </summary>
        public static ReasonCode RecognizeInitialSilenceTimedOut { get; } = new ReasonCode(RecognizeInitialSilenceTimedOutValue);
        /// <summary> Action failed, inter-digit silence timeout reached. </summary>
        public static ReasonCode RecognizeInterDigitTimedOut { get; } = new ReasonCode(RecognizeInterDigitTimedOutValue);
        /// <summary> Action failed, encountered failure while trying to play the prompt. </summary>
        public static ReasonCode RecognizePlayPromptFailed { get; } = new ReasonCode(RecognizePlayPromptFailedValue);

        /// <summary> Action completed, max digits received. </summary>
        public static ReasonCode RecognizeMaxDigitsReceived { get; } = new ReasonCode(RecognizeMaxDigitsReceivedValue);
        /// <summary> Action completed as stop tone was detected. </summary>
        public static ReasonCode RecognizeStopToneDetected { get; } = new ReasonCode(RecognizeStopToneDetectedValue);

        /// <summary> Action failed, play source not working. </summary>
        public static ReasonCode RecognizeDtmfOptionMatched { get; } = new ReasonCode(RecognizeDtmfOptionMatchedValue);
        /// <summary> Speech option matched. </summary>
        public static ReasonCode RecognizeSpeechOptionMatched { get; } = new ReasonCode(RecognizeSpeechOptionMatchedValue);
        /// <summary> Speech option not matched. </summary>
        public static ReasonCode RecognizeSpeechOptionNotMatched { get; } = new ReasonCode(RecognizeSpeechOptionNotMatchedValue);
        /// <summary> Recognize with Choice that incorrect tone detected. </summary>
        public static ReasonCode RecognizeIncorrectToneDetected { get; } = new ReasonCode(RecognizeIncorrectToneDetectedValue);
        /// <summary> Speech not recognized. </summary>
        public static ReasonCode RecognizeSpeechNotRecognized { get; } = new ReasonCode(RecognizeSpeechNotRecognizedValue);
        /// <summary> Speech service connection error. </summary>
        public static ReasonCode RecognizeSpeechServiceConnectionError { get; } = new ReasonCode(RecognizeSpeechServiceConnectionErrorValue);
        /// <summary> Action failed, file could not be downloaded. </summary>
        public static ReasonCode PlayDownloadFailed { get; } = new ReasonCode(PlayDownloadFailedValue);
        /// <summary> Action failed, file could not be downloaded. </summary>
        public static ReasonCode PlayInvalidFileFormat { get; } = new ReasonCode(PlayInvalidFileFormatValue);
        /// <summary> Action failed, cognitive service error. </summary>
        public static ReasonCode PlayCognitiveServicesPlayError { get; } = new ReasonCode(PlayCognitiveServicesPlayErrorValue);
        /// <summary> Action completed successfully. </summary>
        public static ReasonCode CompletedSuccessfully { get; } = new ReasonCode (CompletedSuccessfullyValue);
        /// <summary> Unknown internal server error. </summary>
        public static ReasonCode UnspecifiedError { get; } = new ReasonCode(UnspecifiedErrorValue);

        /// <summary> Determines if two <see cref="ReasonCode"/> values are the same. </summary>
        public static bool operator ==(ReasonCode left, ReasonCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ReasonCode"/> values are not the same. </summary>
        public static bool operator !=(ReasonCode left, ReasonCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ReasonCode"/>. </summary>
        public static implicit operator ReasonCode(string value) => new ReasonCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ReasonCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ReasonCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
