// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Renamed properties.
    /// <summary> The Snapshot. </summary>
    [CodeGenType("Snapshot")]
    public partial class ConfigurationSnapshot
    {
        /// <summary> Initializes a new instance of Snapshot. </summary>
        /// <param name="name"> The name of the snapshot. </param>
        /// <param name="status"> The current status of the snapshot. </param>
        /// <param name="filters"> A list of filters used to filter the key-values included in the snapshot. </param>
        /// <param name="snapshotComposition"> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </param>
        /// <param name="createdOn"> The time that the snapshot was created. </param>
        /// <param name="expiresOn"> The time that the snapshot will expire. </param>
        /// <param name="retentionPeriod"> The amount of time, in seconds, that a snapshot will remain in the archived state before expiring. This property is only writable during the creation of a snapshot. If not specified, the default lifetime of key-value revisions will be used. </param>
        /// <param name="sizeInBytes"> The size in bytes of the snapshot. </param>
        /// <param name="itemCount"> The amount of key-values in the snapshot. </param>
        /// <param name="tags"> The tags of the snapshot. </param>
        /// <param name="eTag"> A value representing the current state of the snapshot. </param>
        internal ConfigurationSnapshot(string name, ConfigurationSnapshotStatus? status, IList<ConfigurationSettingsFilter> filters, SnapshotComposition? snapshotComposition, DateTimeOffset? createdOn, DateTimeOffset? expiresOn, long? retentionPeriod, long? sizeInBytes, long? itemCount, IDictionary<string, string> tags, ETag eTag)
        {
            Name = name;
            Status = status;
            Filters = filters;
            SnapshotComposition = snapshotComposition;
            CreatedOn = createdOn;
            ExpiresOn = expiresOn;
            _retentionPeriod = retentionPeriod;
            SizeInBytes = sizeInBytes;
            ItemCount = itemCount;
            Tags = tags;
            ETag = eTag;
        }

        /// <summary> The name of the snapshot. </summary>
        public string Name { get; }
        /// <summary> The current status of the snapshot. </summary>
        public ConfigurationSnapshotStatus? Status { get; }
        /// <summary> A list of filters used to filter the key-values included in the snapshot. </summary>
        public IList<ConfigurationSettingsFilter> Filters { get; }

        /// <summary> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
        [CodeGenMember("CompositionType")]
        public SnapshotComposition? SnapshotComposition { get; set; }

        /// <summary> The time that the snapshot was created. </summary>
        [CodeGenMember("Created")]
        public DateTimeOffset? CreatedOn { get; }

        /// <summary> The time that the snapshot will expire. </summary>
        [CodeGenMember("Expires")]
        public DateTimeOffset? ExpiresOn { get; }
        private long? _retentionPeriod;
        /// <summary> The amount of time that a snapshot will remain in the archived state before expiring. This property is only writable during the creation of a snapshot. If not specified, the default lifetime of key-value revisions will be used. </summary>
        public TimeSpan? RetentionPeriod {
            get
            {
                return _retentionPeriod != null ? TimeSpan.FromSeconds((double)_retentionPeriod) : null;
            }
            set
            {
                var seconds = value.Value.TotalSeconds;
                long secondsLong;
                try
                {
                    secondsLong = Convert.ToInt64(seconds);
                }
                catch (OverflowException)
                {
                    // We won't have negative seconds.
                    secondsLong = long.MaxValue;
                }
                _retentionPeriod = secondsLong;
            }
        }
        /// <summary> The size in bytes of the snapshot. </summary>
        [CodeGenMember("Size")]
        public long? SizeInBytes { get; }

        /// <summary> The amount of key-values in the snapshot. </summary>
        [CodeGenMember("ItemsCount")]
        public long? ItemCount { get; }
        /// <summary> The tags of the snapshot. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary> A value representing the current state of the snapshot. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }
    }
}
