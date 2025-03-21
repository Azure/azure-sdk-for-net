// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> The write behavior for the operation. Default is Bulk Insert. </summary>
    public readonly partial struct AzurePostgreSqlWriteMethodEnum : IEquatable<AzurePostgreSqlWriteMethodEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AzurePostgreSqlWriteMethodEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AzurePostgreSqlWriteMethodEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BulkInsertValue = "BulkInsert";
        private const string CopyCommandValue = "CopyCommand";
        private const string UpsertValue = "Upsert";

        /// <summary> BulkInsert. </summary>
        public static AzurePostgreSqlWriteMethodEnum BulkInsert { get; } = new AzurePostgreSqlWriteMethodEnum(BulkInsertValue);
        /// <summary> CopyCommand. </summary>
        public static AzurePostgreSqlWriteMethodEnum CopyCommand { get; } = new AzurePostgreSqlWriteMethodEnum(CopyCommandValue);
        /// <summary> Upsert. </summary>
        public static AzurePostgreSqlWriteMethodEnum Upsert { get; } = new AzurePostgreSqlWriteMethodEnum(UpsertValue);
        /// <summary> Determines if two <see cref="AzurePostgreSqlWriteMethodEnum"/> values are the same. </summary>
        public static bool operator ==(AzurePostgreSqlWriteMethodEnum left, AzurePostgreSqlWriteMethodEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AzurePostgreSqlWriteMethodEnum"/> values are not the same. </summary>
        public static bool operator !=(AzurePostgreSqlWriteMethodEnum left, AzurePostgreSqlWriteMethodEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AzurePostgreSqlWriteMethodEnum"/>. </summary>
        public static implicit operator AzurePostgreSqlWriteMethodEnum(string value) => new AzurePostgreSqlWriteMethodEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AzurePostgreSqlWriteMethodEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AzurePostgreSqlWriteMethodEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
