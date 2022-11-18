// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The kind of range that the resolution object represents. </summary>
    public readonly partial struct RangeKind : IEquatable<RangeKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RangeKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RangeKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NumberValue = "Number";
        private const string SpeedValue = "Speed";
        private const string WeightValue = "Weight";
        private const string LengthValue = "Length";
        private const string VolumeValue = "Volume";
        private const string AreaValue = "Area";
        private const string AgeValue = "Age";
        private const string InformationValue = "Information";
        private const string TemperatureValue = "Temperature";
        private const string CurrencyValue = "Currency";

        /// <summary> Number. </summary>
        public static RangeKind Number { get; } = new RangeKind(NumberValue);
        /// <summary> Speed. </summary>
        public static RangeKind Speed { get; } = new RangeKind(SpeedValue);
        /// <summary> Weight. </summary>
        public static RangeKind Weight { get; } = new RangeKind(WeightValue);
        /// <summary> Length. </summary>
        public static RangeKind Length { get; } = new RangeKind(LengthValue);
        /// <summary> Volume. </summary>
        public static RangeKind Volume { get; } = new RangeKind(VolumeValue);
        /// <summary> Area. </summary>
        public static RangeKind Area { get; } = new RangeKind(AreaValue);
        /// <summary> Age. </summary>
        public static RangeKind Age { get; } = new RangeKind(AgeValue);
        /// <summary> Information. </summary>
        public static RangeKind Information { get; } = new RangeKind(InformationValue);
        /// <summary> Temperature. </summary>
        public static RangeKind Temperature { get; } = new RangeKind(TemperatureValue);
        /// <summary> Currency. </summary>
        public static RangeKind Currency { get; } = new RangeKind(CurrencyValue);
        /// <summary> Determines if two <see cref="RangeKind"/> values are the same. </summary>
        public static bool operator ==(RangeKind left, RangeKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RangeKind"/> values are not the same. </summary>
        public static bool operator !=(RangeKind left, RangeKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RangeKind"/>. </summary>
        public static implicit operator RangeKind(string value) => new RangeKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RangeKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RangeKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
