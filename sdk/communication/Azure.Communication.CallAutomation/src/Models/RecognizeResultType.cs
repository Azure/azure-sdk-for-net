// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Determines the sub-type of the recognize result.
    /// </summary>
    public readonly partial struct RecognizeResultType: IEquatable<RecognizeResultType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RecognizeResultType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RecognizeResultType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DtmfResultValue = "DtmfResultValue";
        private const string ChoiceResultValue = "ChoiceResultValue";
        private const string SpeechResultValue = "SpeechResultValue";

        /// <summary> DtmfResult. </summary>
        public static RecognizeResultType DtmfResult { get; } = new RecognizeResultType(DtmfResultValue);
        /// <summary> ChoiceResult. </summary>
        public static RecognizeResultType ChoiceResult { get; } = new RecognizeResultType(ChoiceResultValue);
        /// <summary> SpeechResult. </summary>
        public static RecognizeResultType SpeechResult { get; } = new RecognizeResultType(SpeechResultValue);
        /// <summary> Determines if two <see cref="RecognizeResultType"/> values are the same. </summary>
        public static bool operator ==(RecognizeResultType left, RecognizeResultType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RecognizeResultType"/> values are not the same. </summary>
        public static bool operator !=(RecognizeResultType left, RecognizeResultType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RecognizeResultType"/>. </summary>
        public static implicit operator RecognizeResultType(string value) => new RecognizeResultType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RecognizeResultType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RecognizeResultType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
