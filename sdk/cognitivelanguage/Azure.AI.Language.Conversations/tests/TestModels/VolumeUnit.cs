// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The Volume Unit of measurement. </summary>
    public readonly partial struct VolumeUnit : IEquatable<VolumeUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VolumeUnit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VolumeUnit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnspecifiedValue = "Unspecified";
        private const string CubicMeterValue = "CubicMeter";
        private const string CubicCentimeterValue = "CubicCentimeter";
        private const string CubicMillimeterValue = "CubicMillimeter";
        private const string HectoliterValue = "Hectoliter";
        private const string DecaliterValue = "Decaliter";
        private const string LiterValue = "Liter";
        private const string CentiliterValue = "Centiliter";
        private const string MilliliterValue = "Milliliter";
        private const string CubicYardValue = "CubicYard";
        private const string CubicInchValue = "CubicInch";
        private const string CubicFootValue = "CubicFoot";
        private const string CubicMileValue = "CubicMile";
        private const string FluidOunceValue = "FluidOunce";
        private const string TeaspoonValue = "Teaspoon";
        private const string TablespoonValue = "Tablespoon";
        private const string PintValue = "Pint";
        private const string QuartValue = "Quart";
        private const string CupValue = "Cup";
        private const string GillValue = "Gill";
        private const string PinchValue = "Pinch";
        private const string FluidDramValue = "FluidDram";
        private const string BarrelValue = "Barrel";
        private const string MinimValue = "Minim";
        private const string CordValue = "Cord";
        private const string PeckValue = "Peck";
        private const string BushelValue = "Bushel";
        private const string HogsheadValue = "Hogshead";

        /// <summary> Unspecified. </summary>
        public static VolumeUnit Unspecified { get; } = new VolumeUnit(UnspecifiedValue);
        /// <summary> CubicMeter. </summary>
        public static VolumeUnit CubicMeter { get; } = new VolumeUnit(CubicMeterValue);
        /// <summary> CubicCentimeter. </summary>
        public static VolumeUnit CubicCentimeter { get; } = new VolumeUnit(CubicCentimeterValue);
        /// <summary> CubicMillimeter. </summary>
        public static VolumeUnit CubicMillimeter { get; } = new VolumeUnit(CubicMillimeterValue);
        /// <summary> Hectoliter. </summary>
        public static VolumeUnit Hectoliter { get; } = new VolumeUnit(HectoliterValue);
        /// <summary> Decaliter. </summary>
        public static VolumeUnit Decaliter { get; } = new VolumeUnit(DecaliterValue);
        /// <summary> Liter. </summary>
        public static VolumeUnit Liter { get; } = new VolumeUnit(LiterValue);
        /// <summary> Centiliter. </summary>
        public static VolumeUnit Centiliter { get; } = new VolumeUnit(CentiliterValue);
        /// <summary> Milliliter. </summary>
        public static VolumeUnit Milliliter { get; } = new VolumeUnit(MilliliterValue);
        /// <summary> CubicYard. </summary>
        public static VolumeUnit CubicYard { get; } = new VolumeUnit(CubicYardValue);
        /// <summary> CubicInch. </summary>
        public static VolumeUnit CubicInch { get; } = new VolumeUnit(CubicInchValue);
        /// <summary> CubicFoot. </summary>
        public static VolumeUnit CubicFoot { get; } = new VolumeUnit(CubicFootValue);
        /// <summary> CubicMile. </summary>
        public static VolumeUnit CubicMile { get; } = new VolumeUnit(CubicMileValue);
        /// <summary> FluidOunce. </summary>
        public static VolumeUnit FluidOunce { get; } = new VolumeUnit(FluidOunceValue);
        /// <summary> Teaspoon. </summary>
        public static VolumeUnit Teaspoon { get; } = new VolumeUnit(TeaspoonValue);
        /// <summary> Tablespoon. </summary>
        public static VolumeUnit Tablespoon { get; } = new VolumeUnit(TablespoonValue);
        /// <summary> Pint. </summary>
        public static VolumeUnit Pint { get; } = new VolumeUnit(PintValue);
        /// <summary> Quart. </summary>
        public static VolumeUnit Quart { get; } = new VolumeUnit(QuartValue);
        /// <summary> Cup. </summary>
        public static VolumeUnit Cup { get; } = new VolumeUnit(CupValue);
        /// <summary> Gill. </summary>
        public static VolumeUnit Gill { get; } = new VolumeUnit(GillValue);
        /// <summary> Pinch. </summary>
        public static VolumeUnit Pinch { get; } = new VolumeUnit(PinchValue);
        /// <summary> FluidDram. </summary>
        public static VolumeUnit FluidDram { get; } = new VolumeUnit(FluidDramValue);
        /// <summary> Barrel. </summary>
        public static VolumeUnit Barrel { get; } = new VolumeUnit(BarrelValue);
        /// <summary> Minim. </summary>
        public static VolumeUnit Minim { get; } = new VolumeUnit(MinimValue);
        /// <summary> Cord. </summary>
        public static VolumeUnit Cord { get; } = new VolumeUnit(CordValue);
        /// <summary> Peck. </summary>
        public static VolumeUnit Peck { get; } = new VolumeUnit(PeckValue);
        /// <summary> Bushel. </summary>
        public static VolumeUnit Bushel { get; } = new VolumeUnit(BushelValue);
        /// <summary> Hogshead. </summary>
        public static VolumeUnit Hogshead { get; } = new VolumeUnit(HogsheadValue);
        /// <summary> Determines if two <see cref="VolumeUnit"/> values are the same. </summary>
        public static bool operator ==(VolumeUnit left, VolumeUnit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VolumeUnit"/> values are not the same. </summary>
        public static bool operator !=(VolumeUnit left, VolumeUnit right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VolumeUnit"/>. </summary>
        public static implicit operator VolumeUnit(string value) => new VolumeUnit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VolumeUnit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VolumeUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
