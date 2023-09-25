// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The SnapshotFields. </summary>
    public readonly partial struct SnapshotFields : IEquatable<SnapshotFields>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SnapshotFields"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SnapshotFields(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NameValue = "name";
        private const string StatusValue = "status";
        private const string FiltersValue = "filters";
        private const string SnapshotCompositionValue = "composition_type";
        private const string CreatedOnValue = "created";
        private const string ExpiresOnValue = "expires";
        private const string RetentionPeriodValue = "retention_period";
        private const string SizeInBytesValue = "size";
        private const string ItemCountValue = "items_count";
        private const string TagsValue = "tags";
        private const string ETagValue = "etag";

        /// <summary> name. </summary>
        public static SnapshotFields Name { get; } = new SnapshotFields(NameValue);
        /// <summary> status. </summary>
        public static SnapshotFields Status { get; } = new SnapshotFields(StatusValue);
        /// <summary> filters. </summary>
        public static SnapshotFields Filters { get; } = new SnapshotFields(FiltersValue);
        /// <summary> composition_type. </summary>
        public static SnapshotFields SnapshotComposition { get; } = new SnapshotFields(SnapshotCompositionValue);
        /// <summary> created. </summary>
        public static SnapshotFields CreatedOn { get; } = new SnapshotFields(CreatedOnValue);
        /// <summary> expires. </summary>
        public static SnapshotFields ExpiresOn { get; } = new SnapshotFields(ExpiresOnValue);
        /// <summary> retention_period. </summary>
        public static SnapshotFields RetentionPeriod { get; } = new SnapshotFields(RetentionPeriodValue);
        /// <summary> size. </summary>
        public static SnapshotFields SizeInBytes { get; } = new SnapshotFields(SizeInBytesValue);
        /// <summary> items_count. </summary>
        public static SnapshotFields ItemCount { get; } = new SnapshotFields(ItemCountValue);
        /// <summary> tags. </summary>
        public static SnapshotFields Tags { get; } = new SnapshotFields(TagsValue);
        /// <summary> etag. </summary>
        public static SnapshotFields ETag { get; } = new SnapshotFields(ETagValue);
        /// <summary> Determines if two <see cref="SnapshotFields"/> values are the same. </summary>
        public static bool operator ==(SnapshotFields left, SnapshotFields right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SnapshotFields"/> values are not the same. </summary>
        public static bool operator !=(SnapshotFields left, SnapshotFields right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SnapshotFields"/>. </summary>
        public static implicit operator SnapshotFields(string value) => new SnapshotFields(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SnapshotFields other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SnapshotFields other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
