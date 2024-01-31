// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Maps
{
    /// <summary> The LocalizedMapView. </summary>
    public readonly struct LocalizedMapView : IEquatable<LocalizedMapView>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LocalizedMapView"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LocalizedMapView(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AEValue = "AE";
        private const string ARValue = "AR";
        private const string BHValue = "BH";
        private const string INValue = "IN";
        private const string IQValue = "IQ";
        private const string JOValue = "JO";
        private const string KWValue = "KW";
        private const string LBValue = "LB";
        private const string MAValue = "MA";
        private const string OMValue = "OM";
        private const string PKValue = "PK";
        private const string PSValue = "PS";
        private const string QAValue = "QA";
        private const string SAValue = "SA";
        private const string SYValue = "SY";
        private const string YEValue = "YE";
        private const string AutoValue = "Auto";
        private const string UnifiedValue = "Unified";

        /// <summary> United Arab Emirates (Arabic View). </summary>
        public static LocalizedMapView UnitedArabEmirates { get; } = new LocalizedMapView(AEValue);
        /// <summary> Argentina (Argentinian View). </summary>
        public static LocalizedMapView Argentina { get; } = new LocalizedMapView(ARValue);
        /// <summary> Bahrain (Arabic View). </summary>
        public static LocalizedMapView Bahrain { get; } = new LocalizedMapView(BHValue);
        /// <summary> India (Indian View). </summary>
        public static LocalizedMapView India { get; } = new LocalizedMapView(INValue);
        /// <summary> Iraq (Arabic View). </summary>
        public static LocalizedMapView Iraq { get; } = new LocalizedMapView(IQValue);
        /// <summary> Jordan (Arabic View). </summary>
        public static LocalizedMapView Jordan { get; } = new LocalizedMapView(JOValue);
        /// <summary> Kuwait (Arabic View). </summary>
        public static LocalizedMapView Kuwait { get; } = new LocalizedMapView(KWValue);
        /// <summary> Lebanon (Arabic View). </summary>
        public static LocalizedMapView Lebanon { get; } = new LocalizedMapView(LBValue);
        /// <summary> Morocco (Moroccan View). </summary>
        public static LocalizedMapView Morocco { get; } = new LocalizedMapView(MAValue);
        /// <summary> Oman (Arabic View). </summary>
        public static LocalizedMapView Oman { get; } = new LocalizedMapView(OMValue);
        /// <summary> Pakistan (Pakistani View). </summary>
        public static LocalizedMapView Pakistan { get; } = new LocalizedMapView(PKValue);
        /// <summary> Palestinian Authority (Arabic View). </summary>
        public static LocalizedMapView PalestinianAuthority { get; } = new LocalizedMapView(PSValue);
        /// <summary> Qatar (Arabic View). </summary>
        public static LocalizedMapView Qatar { get; } = new LocalizedMapView(QAValue);
        /// <summary> Saudi Arabia (Arabic View). </summary>
        public static LocalizedMapView SaudiArabia { get; } = new LocalizedMapView(SAValue);
        /// <summary> Syria (Arabic View). </summary>
        public static LocalizedMapView Syria { get; } = new LocalizedMapView(SYValue);
        /// <summary> Yemen (Arabic View). </summary>
        public static LocalizedMapView Yemen { get; } = new LocalizedMapView(YEValue);
        /// <summary> Return the map data based on the IP address of the request. </summary>
        public static LocalizedMapView Auto { get; } = new LocalizedMapView(AutoValue);
        /// <summary> Unified View (Others). </summary>
        public static LocalizedMapView Unified { get; } = new LocalizedMapView(UnifiedValue);
        /// <summary> Determines if two <see cref="LocalizedMapView"/> values are the same. </summary>
        public static bool operator ==(LocalizedMapView left, LocalizedMapView right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LocalizedMapView"/> values are not the same. </summary>
        public static bool operator !=(LocalizedMapView left, LocalizedMapView right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LocalizedMapView"/>. </summary>
        public static implicit operator LocalizedMapView(string value) => new LocalizedMapView(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LocalizedMapView other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LocalizedMapView other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
