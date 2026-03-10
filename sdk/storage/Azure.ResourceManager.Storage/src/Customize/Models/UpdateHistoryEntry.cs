// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class UpdateHistoryEntry
    {
        // Internal constructor used by serialization (deserializer passes Guid? tenantId directly)
        internal UpdateHistoryEntry(ImmutabilityPolicyUpdateType? update, int? immutabilityPeriodSinceCreationInDays, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            UpdateType = update;
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            Timestamp = timestamp;
            ObjectIdentifier = objectIdentifier;
            TenantId = tenantId;
            Upn = upn;
            AllowProtectedAppendWrites = allowProtectedAppendWrites;
            AllowProtectedAppendWritesAll = allowProtectedAppendWritesAll;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
