// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class UpdateHistoryEntry
    {
        // Constructor overload to fix generator backward-compat factory method bug:
        // The generated factory passes Guid? tenantId but the constructor expects string.
        internal UpdateHistoryEntry(ImmutabilityPolicyUpdateType? update, int? immutabilityPeriodSinceCreationInDays, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : this(update, immutabilityPeriodSinceCreationInDays, timestamp, objectIdentifier, tenantId?.ToString(), upn, allowProtectedAppendWrites, allowProtectedAppendWritesAll, additionalBinaryDataProperties)
        {
        }
    }
}
