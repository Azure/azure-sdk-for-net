// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Reason Codes for incoming webhook events.
    /// </summary>
    public readonly partial struct MediaEventReasonCode : IEquatable<MediaEventReasonCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MediaEventReasonCode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MediaEventReasonCode(string value)
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
        private const string PlaySourceTextOrSsmlEmptyValue = "8582";
        private const string CognitiveServicesErrorValue = "8565";

        private const string CompletedSuccessfullyValue = "0";
        private const string UnspecifiedErrorValue = "9999";

        /// <summary> Action failed, initial silence timeout reached. </summary>
        public static MediaEventReasonCode RecognizeInitialSilenceTimedOut { get; } = new MediaEventReasonCode(RecognizeInitialSilenceTimedOutValue);
        /// <summary> Action failed, inter-digit silence timeout reached. </summary>
        public static MediaEventReasonCode RecognizeInterDigitTimedOut { get; } = new MediaEventReasonCode(RecognizeInterDigitTimedOutValue);
        /// <summary> Action failed, encountered failure while trying to play the prompt. </summary>
        public static MediaEventReasonCode RecognizePlayPromptFailed { get; } = new MediaEventReasonCode(RecognizePlayPromptFailedValue);

        /// <summary> Action completed, max digits received. </summary>
        public static MediaEventReasonCode RecognizeMaxDigitsReceived { get; } = new MediaEventReasonCode(RecognizeMaxDigitsReceivedValue);
        /// <summary> Action completed as stop tone was detected. </summary>
        public static MediaEventReasonCode RecognizeStopToneDetected { get; } = new MediaEventReasonCode(RecognizeStopToneDetectedValue);

        /// <summary> Action failed, play source not working. </summary>
        public static MediaEventReasonCode RecognizeDtmfOptionMatched { get; } = new MediaEventReasonCode(RecognizeDtmfOptionMatchedValue);
        /// <summary> Speech option matched. </summary>
        public static MediaEventReasonCode RecognizeSpeechOptionMatched { get; } = new MediaEventReasonCode(RecognizeSpeechOptionMatchedValue);
        /// <summary> Speech option  not matched. </summary>
        public static MediaEventReasonCode RecognizeSpeechOptionNotMatched { get; } = new MediaEventReasonCode(RecognizeSpeechOptionNotMatchedValue);
        /// <summary> Recognize with Choice that incorrect tone detected. </summary>
        public static MediaEventReasonCode RecognizeIncorrectToneDetected { get; } = new MediaEventReasonCode(RecognizeIncorrectToneDetectedValue);

        /// <summary> Speech not recognized. </summary>
        public static MediaEventReasonCode RecognizeSpeechNotRecognized { get; } = new MediaEventReasonCode(RecognizeSpeechNotRecognizedValue);
        /// <summary> Speech service connection error. </summary>
        public static MediaEventReasonCode RecognizeSpeechServiceConnectionError { get; } = new MediaEventReasonCode(RecognizeSpeechServiceConnectionErrorValue);

        /// <summary> Action failed, file could not be downloaded. </summary>
        public static MediaEventReasonCode PlayDownloadFailed { get; } = new MediaEventReasonCode(PlayDownloadFailedValue);
        /// <summary> Action failed, invalid file format. </summary>
        public static MediaEventReasonCode PlayInvalidFileFormat { get; } = new MediaEventReasonCode(PlayInvalidFileFormatValue);
        /// <summary> Action failed, play source text or ssml empty. </summary>
        public static MediaEventReasonCode PlaySourceTextOrSsmlEmpty { get; } = new MediaEventReasonCode(PlaySourceTextOrSsmlEmptyValue);
        /// <summary> Action failed, cognitive service error. </summary>
        public static MediaEventReasonCode CognitiveServicesError { get; } = new MediaEventReasonCode(CognitiveServicesErrorValue);

        /// <summary> Action completed successfully. </summary>
        public static MediaEventReasonCode CompletedSuccessfully { get; } = new MediaEventReasonCode(CompletedSuccessfullyValue);
        /// <summary> Unknown internal server error. </summary>
        public static MediaEventReasonCode UnspecifiedError { get; } = new MediaEventReasonCode(UnspecifiedErrorValue);

        /// <summary> Determines if two <see cref="MediaEventReasonCode"/> values are the same. </summary>
        public static bool operator ==(MediaEventReasonCode left, MediaEventReasonCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MediaEventReasonCode"/> values are not the same. </summary>
        public static bool operator !=(MediaEventReasonCode left, MediaEventReasonCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MediaEventReasonCode"/>. </summary>
        public static implicit operator MediaEventReasonCode(string value) => new MediaEventReasonCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MediaEventReasonCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MediaEventReasonCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary>
        /// Retrieves the integer value associated with the specified ReasonCode.
        /// </summary>
        /// <returns>The integer value corresponding to the provided ReasonCode.</returns>
        /// <exception cref="Exception"></exception>
        public int GetReasonCodeValue()
        {
            int result;
            if (int.TryParse(_value, out result))
            {
                return result;
            }
            else
            {
                throw new Exception("Unable to parse ReasonCode value.");
            }
        }
    }
}
