// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed members.
    public readonly partial struct SnapshotFields : IEquatable<SnapshotFields>
    {
        /// <summary> composition_type. </summary>
        [CodeGenMember("CompositionType")]
        public static SnapshotFields SnapshotComposition { get; } = new SnapshotFields(CompositionTypeValue);

        /// <summary> created. </summary>
        [CodeGenMember("Created")]
        public static SnapshotFields CreatedOn { get; } = new SnapshotFields(CreatedValue);

        /// <summary> expires. </summary>
        [CodeGenMember("Expires")]
        public static SnapshotFields ExpiresOn { get; } = new SnapshotFields(ExpiresValue);
        /// <summary> retention_period. </summary>
        public static SnapshotFields RetentionPeriod { get; } = new SnapshotFields(RetentionPeriodValue);

        /// <summary> size. </summary>
        [CodeGenMember("Size")]
        public static SnapshotFields SizeInBytes { get; } = new SnapshotFields(SizeValue);

        /// <summary> items_count. </summary>
        [CodeGenMember("ItemsCount")]
        public static SnapshotFields ItemCount { get; } = new SnapshotFields(ItemsCountValue);

        /// <summary> etag. </summary>
        [CodeGenMember("Etag")]
        public static SnapshotFields ETag { get; } = new SnapshotFields(EtagValue);
    }
}
