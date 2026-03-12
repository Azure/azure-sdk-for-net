// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class UpdateHistoryEntry
    {
        // Internal constructor used by serialization (deserializer passes Guid? tenantId directly)
        internal UpdateHistoryEntry(ImmutabilityPolicyUpdateType? update, int? immutabilityPeriodSinceCreationInDays, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Update = update;
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            Timestamp = timestamp;
            ObjectIdentifier = objectIdentifier;
            TenantId = tenantId?.ToString();
            Upn = upn;
            AllowProtectedAppendWrites = allowProtectedAppendWrites;
            AllowProtectedAppendWritesAll = allowProtectedAppendWritesAll;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Backward-compat: The ImmutabilityPolicy update type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImmutabilityPolicyUpdateType? UpdateType => Update;
    }
}
