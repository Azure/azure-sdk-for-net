// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> An optional modifier of a date/time instance. </summary>
    public readonly partial struct TemporalModifier : IEquatable<TemporalModifier>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TemporalModifier"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TemporalModifier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AfterApproxValue = "AfterApprox";
        private const string BeforeValue = "Before";
        private const string BeforeStartValue = "BeforeStart";
        private const string ApproxValue = "Approx";
        private const string ReferenceUndefinedValue = "ReferenceUndefined";
        private const string SinceEndValue = "SinceEnd";
        private const string AfterMidValue = "AfterMid";
        private const string StartValue = "Start";
        private const string AfterValue = "After";
        private const string BeforeEndValue = "BeforeEnd";
        private const string UntilValue = "Until";
        private const string EndValue = "End";
        private const string LessValue = "Less";
        private const string SinceValue = "Since";
        private const string AfterStartValue = "AfterStart";
        private const string BeforeApproxValue = "BeforeApprox";
        private const string MidValue = "Mid";
        private const string MoreValue = "More";

        /// <summary> AfterApprox. </summary>
        public static TemporalModifier AfterApprox { get; } = new TemporalModifier(AfterApproxValue);
        /// <summary> Before. </summary>
        public static TemporalModifier Before { get; } = new TemporalModifier(BeforeValue);
        /// <summary> BeforeStart. </summary>
        public static TemporalModifier BeforeStart { get; } = new TemporalModifier(BeforeStartValue);
        /// <summary> Approx. </summary>
        public static TemporalModifier Approx { get; } = new TemporalModifier(ApproxValue);
        /// <summary> ReferenceUndefined. </summary>
        public static TemporalModifier ReferenceUndefined { get; } = new TemporalModifier(ReferenceUndefinedValue);
        /// <summary> SinceEnd. </summary>
        public static TemporalModifier SinceEnd { get; } = new TemporalModifier(SinceEndValue);
        /// <summary> AfterMid. </summary>
        public static TemporalModifier AfterMid { get; } = new TemporalModifier(AfterMidValue);
        /// <summary> Start. </summary>
        public static TemporalModifier Start { get; } = new TemporalModifier(StartValue);
        /// <summary> After. </summary>
        public static TemporalModifier After { get; } = new TemporalModifier(AfterValue);
        /// <summary> BeforeEnd. </summary>
        public static TemporalModifier BeforeEnd { get; } = new TemporalModifier(BeforeEndValue);
        /// <summary> Until. </summary>
        public static TemporalModifier Until { get; } = new TemporalModifier(UntilValue);
        /// <summary> End. </summary>
        public static TemporalModifier End { get; } = new TemporalModifier(EndValue);
        /// <summary> Less. </summary>
        public static TemporalModifier Less { get; } = new TemporalModifier(LessValue);
        /// <summary> Since. </summary>
        public static TemporalModifier Since { get; } = new TemporalModifier(SinceValue);
        /// <summary> AfterStart. </summary>
        public static TemporalModifier AfterStart { get; } = new TemporalModifier(AfterStartValue);
        /// <summary> BeforeApprox. </summary>
        public static TemporalModifier BeforeApprox { get; } = new TemporalModifier(BeforeApproxValue);
        /// <summary> Mid. </summary>
        public static TemporalModifier Mid { get; } = new TemporalModifier(MidValue);
        /// <summary> More. </summary>
        public static TemporalModifier More { get; } = new TemporalModifier(MoreValue);
        /// <summary> Determines if two <see cref="TemporalModifier"/> values are the same. </summary>
        public static bool operator ==(TemporalModifier left, TemporalModifier right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TemporalModifier"/> values are not the same. </summary>
        public static bool operator !=(TemporalModifier left, TemporalModifier right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TemporalModifier"/>. </summary>
        public static implicit operator TemporalModifier(string value) => new TemporalModifier(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TemporalModifier other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TemporalModifier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
