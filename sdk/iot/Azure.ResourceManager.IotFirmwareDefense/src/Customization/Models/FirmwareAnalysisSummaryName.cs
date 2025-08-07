// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> The FirmwareAnalysisSummaryName. </summary>
    public readonly partial struct FirmwareAnalysisSummaryName : IEquatable<FirmwareAnalysisSummaryName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirmwareAnalysisSummaryName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FirmwareAnalysisSummaryName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FirmwareValue = "Firmware";
        private const string CveValue = "CVE";
        private const string BinaryHardeningValue = "BinaryHardening";
        private const string CryptoCertificateValue = "CryptoCertificate";
        private const string CryptoKeyValue = "CryptoKey";

        /// <summary> Firmware. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisSummaryName Firmware { get; } = new FirmwareAnalysisSummaryName(FirmwareValue);
        /// <summary> CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisSummaryName Cve { get; } = new FirmwareAnalysisSummaryName(CveValue);
        /// <summary> BinaryHardening. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisSummaryName BinaryHardening { get; } = new FirmwareAnalysisSummaryName(BinaryHardeningValue);
        /// <summary> CryptoCertificate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisSummaryName CryptoCertificate { get; } = new FirmwareAnalysisSummaryName(CryptoCertificateValue);
        /// <summary> CryptoKey. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisSummaryName CryptoKey { get; } = new FirmwareAnalysisSummaryName(CryptoKeyValue);
        /// <summary> Determines if two <see cref="FirmwareAnalysisSummaryName"/> values are the same. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(FirmwareAnalysisSummaryName left, FirmwareAnalysisSummaryName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirmwareAnalysisSummaryName"/> values are not the same. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(FirmwareAnalysisSummaryName left, FirmwareAnalysisSummaryName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="FirmwareAnalysisSummaryName"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator FirmwareAnalysisSummaryName(string value) => new FirmwareAnalysisSummaryName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirmwareAnalysisSummaryName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirmwareAnalysisSummaryName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _value;
    }
}
