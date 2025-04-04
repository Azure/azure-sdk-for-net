// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> The AssessmentDiskSize. </summary>
    public readonly partial struct AssessmentDiskSize : IEquatable<AssessmentDiskSize>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AssessmentDiskSize"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AssessmentDiskSize(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string StandardS4Value = "Standard_S4";
        private const string StandardS6Value = "Standard_S6";
        private const string StandardS10Value = "Standard_S10";
        private const string StandardS15Value = "Standard_S15";
        private const string StandardS20Value = "Standard_S20";
        private const string StandardS30Value = "Standard_S30";
        private const string StandardS40Value = "Standard_S40";
        private const string StandardS50Value = "Standard_S50";
        private const string StandardS60Value = "Standard_S60";
        private const string StandardS70Value = "Standard_S70";
        private const string StandardS80Value = "Standard_S80";
        private const string PremiumP4Value = "Premium_P4";
        private const string PremiumP6Value = "Premium_P6";
        private const string PremiumP10Value = "Premium_P10";
        private const string PremiumP15Value = "Premium_P15";
        private const string PremiumP20Value = "Premium_P20";
        private const string PremiumP30Value = "Premium_P30";
        private const string PremiumP40Value = "Premium_P40";
        private const string PremiumP50Value = "Premium_P50";
        private const string PremiumP60Value = "Premium_P60";
        private const string PremiumP70Value = "Premium_P70";
        private const string PremiumP80Value = "Premium_P80";
        private const string StandardSsdE10Value = "StandardSSD_E10";
        private const string StandardSsdE15Value = "StandardSSD_E15";
        private const string StandardSsdE20Value = "StandardSSD_E20";
        private const string StandardSsdE30Value = "StandardSSD_E30";
        private const string StandardSsdE40Value = "StandardSSD_E40";
        private const string StandardSsdE50Value = "StandardSSD_E50";
        private const string StandardSsdE60Value = "StandardSSD_E60";
        private const string StandardSsdE70Value = "StandardSSD_E70";
        private const string StandardSsdE80Value = "StandardSSD_E80";
        private const string StandardSsdE4Value = "StandardSSD_E4";
        private const string StandardSsdE6Value = "StandardSSD_E6";
        private const string StandardSsdE1Value = "StandardSSD_E1";
        private const string StandardSsdE2Value = "StandardSSD_E2";
        private const string StandardSsdE3Value = "StandardSSD_E3";
        private const string PremiumP1Value = "Premium_P1";
        private const string PremiumP2Value = "Premium_P2";
        private const string PremiumP3Value = "Premium_P3";
        private const string UltraValue = "Ultra";
        private const string PremiumV2Value = "PremiumV2";

        /// <summary> Unknown. </summary>
        public static AssessmentDiskSize Unknown { get; } = new AssessmentDiskSize(UnknownValue);
        /// <summary> Standard_S4. </summary>
        public static AssessmentDiskSize StandardS4 { get; } = new AssessmentDiskSize(StandardS4Value);
        /// <summary> Standard_S6. </summary>
        public static AssessmentDiskSize StandardS6 { get; } = new AssessmentDiskSize(StandardS6Value);
        /// <summary> Standard_S10. </summary>
        public static AssessmentDiskSize StandardS10 { get; } = new AssessmentDiskSize(StandardS10Value);
        /// <summary> Standard_S15. </summary>
        public static AssessmentDiskSize StandardS15 { get; } = new AssessmentDiskSize(StandardS15Value);
        /// <summary> Standard_S20. </summary>
        public static AssessmentDiskSize StandardS20 { get; } = new AssessmentDiskSize(StandardS20Value);
        /// <summary> Standard_S30. </summary>
        public static AssessmentDiskSize StandardS30 { get; } = new AssessmentDiskSize(StandardS30Value);
        /// <summary> Standard_S40. </summary>
        public static AssessmentDiskSize StandardS40 { get; } = new AssessmentDiskSize(StandardS40Value);
        /// <summary> Standard_S50. </summary>
        public static AssessmentDiskSize StandardS50 { get; } = new AssessmentDiskSize(StandardS50Value);
        /// <summary> Standard_S60. </summary>
        public static AssessmentDiskSize StandardS60 { get; } = new AssessmentDiskSize(StandardS60Value);
        /// <summary> Standard_S70. </summary>
        public static AssessmentDiskSize StandardS70 { get; } = new AssessmentDiskSize(StandardS70Value);
        /// <summary> Standard_S80. </summary>
        public static AssessmentDiskSize StandardS80 { get; } = new AssessmentDiskSize(StandardS80Value);
        /// <summary> Premium_P4. </summary>
        public static AssessmentDiskSize PremiumP4 { get; } = new AssessmentDiskSize(PremiumP4Value);
        /// <summary> Premium_P6. </summary>
        public static AssessmentDiskSize PremiumP6 { get; } = new AssessmentDiskSize(PremiumP6Value);
        /// <summary> Premium_P10. </summary>
        public static AssessmentDiskSize PremiumP10 { get; } = new AssessmentDiskSize(PremiumP10Value);
        /// <summary> Premium_P15. </summary>
        public static AssessmentDiskSize PremiumP15 { get; } = new AssessmentDiskSize(PremiumP15Value);
        /// <summary> Premium_P20. </summary>
        public static AssessmentDiskSize PremiumP20 { get; } = new AssessmentDiskSize(PremiumP20Value);
        /// <summary> Premium_P30. </summary>
        public static AssessmentDiskSize PremiumP30 { get; } = new AssessmentDiskSize(PremiumP30Value);
        /// <summary> Premium_P40. </summary>
        public static AssessmentDiskSize PremiumP40 { get; } = new AssessmentDiskSize(PremiumP40Value);
        /// <summary> Premium_P50. </summary>
        public static AssessmentDiskSize PremiumP50 { get; } = new AssessmentDiskSize(PremiumP50Value);
        /// <summary> Premium_P60. </summary>
        public static AssessmentDiskSize PremiumP60 { get; } = new AssessmentDiskSize(PremiumP60Value);
        /// <summary> Premium_P70. </summary>
        public static AssessmentDiskSize PremiumP70 { get; } = new AssessmentDiskSize(PremiumP70Value);
        /// <summary> Premium_P80. </summary>
        public static AssessmentDiskSize PremiumP80 { get; } = new AssessmentDiskSize(PremiumP80Value);
        /// <summary> StandardSSD_E10. </summary>
        public static AssessmentDiskSize StandardSsdE10 { get; } = new AssessmentDiskSize(StandardSsdE10Value);
        /// <summary> StandardSSD_E15. </summary>
        public static AssessmentDiskSize StandardSsdE15 { get; } = new AssessmentDiskSize(StandardSsdE15Value);
        /// <summary> StandardSSD_E20. </summary>
        public static AssessmentDiskSize StandardSsdE20 { get; } = new AssessmentDiskSize(StandardSsdE20Value);
        /// <summary> StandardSSD_E30. </summary>
        public static AssessmentDiskSize StandardSsdE30 { get; } = new AssessmentDiskSize(StandardSsdE30Value);
        /// <summary> StandardSSD_E40. </summary>
        public static AssessmentDiskSize StandardSsdE40 { get; } = new AssessmentDiskSize(StandardSsdE40Value);
        /// <summary> StandardSSD_E50. </summary>
        public static AssessmentDiskSize StandardSsdE50 { get; } = new AssessmentDiskSize(StandardSsdE50Value);
        /// <summary> StandardSSD_E60. </summary>
        public static AssessmentDiskSize StandardSsdE60 { get; } = new AssessmentDiskSize(StandardSsdE60Value);
        /// <summary> StandardSSD_E70. </summary>
        public static AssessmentDiskSize StandardSsdE70 { get; } = new AssessmentDiskSize(StandardSsdE70Value);
        /// <summary> StandardSSD_E80. </summary>
        public static AssessmentDiskSize StandardSsdE80 { get; } = new AssessmentDiskSize(StandardSsdE80Value);
        /// <summary> StandardSSD_E4. </summary>
        public static AssessmentDiskSize StandardSsdE4 { get; } = new AssessmentDiskSize(StandardSsdE4Value);
        /// <summary> StandardSSD_E6. </summary>
        public static AssessmentDiskSize StandardSsdE6 { get; } = new AssessmentDiskSize(StandardSsdE6Value);
        /// <summary> StandardSSD_E1. </summary>
        public static AssessmentDiskSize StandardSsdE1 { get; } = new AssessmentDiskSize(StandardSsdE1Value);
        /// <summary> StandardSSD_E2. </summary>
        public static AssessmentDiskSize StandardSsdE2 { get; } = new AssessmentDiskSize(StandardSsdE2Value);
        /// <summary> StandardSSD_E3. </summary>
        public static AssessmentDiskSize StandardSsdE3 { get; } = new AssessmentDiskSize(StandardSsdE3Value);
        /// <summary> Premium_P1. </summary>
        public static AssessmentDiskSize PremiumP1 { get; } = new AssessmentDiskSize(PremiumP1Value);
        /// <summary> Premium_P2. </summary>
        public static AssessmentDiskSize PremiumP2 { get; } = new AssessmentDiskSize(PremiumP2Value);
        /// <summary> Premium_P3. </summary>
        public static AssessmentDiskSize PremiumP3 { get; } = new AssessmentDiskSize(PremiumP3Value);
        /// <summary> Ultra. </summary>
        public static AssessmentDiskSize Ultra { get; } = new AssessmentDiskSize(UltraValue);
        /// <summary> PremiumV2. </summary>
        public static AssessmentDiskSize PremiumV2 { get; } = new AssessmentDiskSize(PremiumV2Value);
        /// <summary> Determines if two <see cref="AssessmentDiskSize"/> values are the same. </summary>
        public static bool operator ==(AssessmentDiskSize left, AssessmentDiskSize right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AssessmentDiskSize"/> values are not the same. </summary>
        public static bool operator !=(AssessmentDiskSize left, AssessmentDiskSize right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AssessmentDiskSize"/>. </summary>
        public static implicit operator AssessmentDiskSize(string value) => new AssessmentDiskSize(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssessmentDiskSize other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AssessmentDiskSize other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
