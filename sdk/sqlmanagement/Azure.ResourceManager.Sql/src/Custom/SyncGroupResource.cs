// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SyncGroupResource
    {
        /// <summary> Backward-compatible overload that accepts <see cref="SyncGroupLogType"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SyncGroupLogProperties> GetLogsAsync(string startTime, string endTime, SyncGroupLogType type, string continuationToken = default, CancellationToken cancellationToken = default)
            => GetLogsAsync(startTime, endTime, new SyncGroupsType(type.ToString()), continuationToken, cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="SyncGroupLogType"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SyncGroupLogProperties> GetLogs(string startTime, string endTime, SyncGroupLogType type, string continuationToken = default, CancellationToken cancellationToken = default)
            => GetLogs(startTime, endTime, new SyncGroupsType(type.ToString()), continuationToken, cancellationToken);
    }
}
