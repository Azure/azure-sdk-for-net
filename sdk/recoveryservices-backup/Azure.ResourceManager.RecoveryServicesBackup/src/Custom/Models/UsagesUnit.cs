// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.RecoveryServicesBackup;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Unit of the usage. </summary>
    public readonly partial struct UsagesUnit : IEquatable<UsagesUnit>
    {
        private readonly string _value;
        private const string CountValue = "Count";
        private const string BytesValue = "Bytes";
        private const string SecondsValue = "Seconds";
        private const string PercentValue = "Percent";
        private const string CountPerSecondValue = "CountPerSecond";
        private const string BytesPerSecondValue = "BytesPerSecond";

        /// <summary> Initializes a new instance of <see cref="UsagesUnit"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UsagesUnit(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Gets the Count. </summary>
        public static UsagesUnit Count { get; } = new UsagesUnit(CountValue);

        /// <summary> Gets the Bytes. </summary>
        public static UsagesUnit Bytes { get; } = new UsagesUnit(BytesValue);

        /// <summary> Gets the Seconds. </summary>
        public static UsagesUnit Seconds { get; } = new UsagesUnit(SecondsValue);

        /// <summary> Gets the Percent. </summary>
        public static UsagesUnit Percent { get; } = new UsagesUnit(PercentValue);

        /// <summary> Gets the CountPerSecond. </summary>
        public static UsagesUnit CountPerSecond { get; } = new UsagesUnit(CountPerSecondValue);

        /// <summary> Gets the BytesPerSecond. </summary>
        public static UsagesUnit BytesPerSecond { get; } = new UsagesUnit(BytesPerSecondValue);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UsagesUnit other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(UsagesUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
