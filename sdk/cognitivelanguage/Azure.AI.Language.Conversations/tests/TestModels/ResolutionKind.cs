// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The entity resolution object kind. </summary>
    public readonly partial struct ResolutionKind : IEquatable<ResolutionKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ResolutionKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ResolutionKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BooleanResolutionValue = "BooleanResolution";
        private const string DateTimeResolutionValue = "DateTimeResolution";
        private const string NumberResolutionValue = "NumberResolution";
        private const string OrdinalResolutionValue = "OrdinalResolution";
        private const string SpeedResolutionValue = "SpeedResolution";
        private const string WeightResolutionValue = "WeightResolution";
        private const string LengthResolutionValue = "LengthResolution";
        private const string VolumeResolutionValue = "VolumeResolution";
        private const string AreaResolutionValue = "AreaResolution";
        private const string AgeResolutionValue = "AgeResolution";
        private const string InformationResolutionValue = "InformationResolution";
        private const string TemperatureResolutionValue = "TemperatureResolution";
        private const string CurrencyResolutionValue = "CurrencyResolution";
        private const string NumericRangeResolutionValue = "NumericRangeResolution";
        private const string TemporalSpanResolutionValue = "TemporalSpanResolution";

        /// <summary> BooleanResolution. </summary>
        public static ResolutionKind BooleanResolution { get; } = new ResolutionKind(BooleanResolutionValue);
        /// <summary> DateTimeResolution. </summary>
        public static ResolutionKind DateTimeResolution { get; } = new ResolutionKind(DateTimeResolutionValue);
        /// <summary> NumberResolution. </summary>
        public static ResolutionKind NumberResolution { get; } = new ResolutionKind(NumberResolutionValue);
        /// <summary> OrdinalResolution. </summary>
        public static ResolutionKind OrdinalResolution { get; } = new ResolutionKind(OrdinalResolutionValue);
        /// <summary> SpeedResolution. </summary>
        public static ResolutionKind SpeedResolution { get; } = new ResolutionKind(SpeedResolutionValue);
        /// <summary> WeightResolution. </summary>
        public static ResolutionKind WeightResolution { get; } = new ResolutionKind(WeightResolutionValue);
        /// <summary> LengthResolution. </summary>
        public static ResolutionKind LengthResolution { get; } = new ResolutionKind(LengthResolutionValue);
        /// <summary> VolumeResolution. </summary>
        public static ResolutionKind VolumeResolution { get; } = new ResolutionKind(VolumeResolutionValue);
        /// <summary> AreaResolution. </summary>
        public static ResolutionKind AreaResolution { get; } = new ResolutionKind(AreaResolutionValue);
        /// <summary> AgeResolution. </summary>
        public static ResolutionKind AgeResolution { get; } = new ResolutionKind(AgeResolutionValue);
        /// <summary> InformationResolution. </summary>
        public static ResolutionKind InformationResolution { get; } = new ResolutionKind(InformationResolutionValue);
        /// <summary> TemperatureResolution. </summary>
        public static ResolutionKind TemperatureResolution { get; } = new ResolutionKind(TemperatureResolutionValue);
        /// <summary> CurrencyResolution. </summary>
        public static ResolutionKind CurrencyResolution { get; } = new ResolutionKind(CurrencyResolutionValue);
        /// <summary> NumericRangeResolution. </summary>
        public static ResolutionKind NumericRangeResolution { get; } = new ResolutionKind(NumericRangeResolutionValue);
        /// <summary> TemporalSpanResolution. </summary>
        public static ResolutionKind TemporalSpanResolution { get; } = new ResolutionKind(TemporalSpanResolutionValue);
        /// <summary> Determines if two <see cref="ResolutionKind"/> values are the same. </summary>
        public static bool operator ==(ResolutionKind left, ResolutionKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ResolutionKind"/> values are not the same. </summary>
        public static bool operator !=(ResolutionKind left, ResolutionKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ResolutionKind"/>. </summary>
        public static implicit operator ResolutionKind(string value) => new ResolutionKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ResolutionKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ResolutionKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
