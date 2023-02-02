// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The Snapshot. </summary>
    public partial class ConfigurationSettingsSnapshot
    {
        /// <summary> Initializes a new instance of Snapshot. </summary>
        /// <param name="filters"> A list of filters used to filter the key-values included in the snapshot. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filters"/> is null. </exception>
        public ConfigurationSettingsSnapshot(IEnumerable<ConfigurationSettingFilter> filters)
        {
            Argument.AssertNotNull(filters, nameof(filters));

            Filters = filters.ToList();
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of Snapshot. </summary>
        /// <param name="name"> The name of the snapshot. </param>
        /// <param name="status"> The current status of the snapshot. </param>
        /// <param name="statusCode"> Provides additional information about the status of the snapshot. The status code values are modeled after HTTP status codes. </param>
        /// <param name="filters"> A list of filters used to filter the key-values included in the snapshot. </param>
        /// <param name="compositionType"> The composition type describes how the key-values within the snapshot are composed. The &apos;all&apos; composition type includes all key-values. The &apos;group_by_key&apos; composition type ensures there are no two key-values containing the same key. </param>
        /// <param name="created"> The time that the snapshot was created. </param>
        /// <param name="expires"> The time that the snapshot will expire. </param>
        /// <param name="retentionPeriod"> The amount of time, in seconds, that a snapshot will remain in the archived state before expiring. This property is only writable during the creation of a snapshot. If not specified, the default lifetime of key-value revisions will be used. </param>
        /// <param name="size"> The size in bytes of the snapshot. </param>
        /// <param name="itemsCount"> The amount of key-values in the snapshot. </param>
        /// <param name="tags"> The tags of the snapshot. </param>
        /// <param name="etag"> A value representing the current state of the snapshot. </param>
        internal ConfigurationSettingsSnapshot(string name, SnapshotStatus? status, int? statusCode, IList<ConfigurationSettingFilter> filters, CompositionType? compositionType, DateTimeOffset? created, DateTimeOffset? expires, long? retentionPeriod, long? size, long? itemsCount, IDictionary<string, string> tags, string etag)
        {
            Name = name;
            Status = status;
            StatusCode = statusCode;
            Filters = filters;
            CompositionType = compositionType;
            Created = created;
            Expires = expires;
            RetentionPeriod = retentionPeriod;
            Size = size;
            ItemsCount = itemsCount;
            Tags = tags;
            Etag = etag;
        }

        /// <summary> The name of the snapshot. </summary>
        public string Name { get; }
        /// <summary> The current status of the snapshot. </summary>
        public SnapshotStatus? Status { get; }
        /// <summary> Provides additional information about the status of the snapshot. The status code values are modeled after HTTP status codes. </summary>
        public int? StatusCode { get; }
        /// <summary> A list of filters used to filter the key-values included in the snapshot. </summary>
        public IList<ConfigurationSettingFilter> Filters { get; }
        /// <summary> The composition type describes how the key-values within the snapshot are composed. The &apos;all&apos; composition type includes all key-values. The &apos;group_by_key&apos; composition type ensures there are no two key-values containing the same key. </summary>
        public CompositionType? CompositionType { get; set; }
        /// <summary> The time that the snapshot was created. </summary>
        public DateTimeOffset? Created { get; }
        /// <summary> The time that the snapshot will expire. </summary>
        public DateTimeOffset? Expires { get; }
        /// <summary> The amount of time, in seconds, that a snapshot will remain in the archived state before expiring. This property is only writable during the creation of a snapshot. If not specified, the default lifetime of key-value revisions will be used. </summary>
        public long? RetentionPeriod { get; set; }
        /// <summary> The size in bytes of the snapshot. </summary>
        public long? Size { get; }
        /// <summary> The amount of key-values in the snapshot. </summary>
        public long? ItemsCount { get; }
        /// <summary> The tags of the snapshot. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> A value representing the current state of the snapshot. </summary>
        public string Etag { get; }
    }
}
