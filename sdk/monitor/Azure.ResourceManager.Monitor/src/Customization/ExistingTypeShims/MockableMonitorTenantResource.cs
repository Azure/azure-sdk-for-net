// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorTenantResource
    {
        /// <summary> Gets event categories. </summary>
        public virtual Pageable<MonitorLocalizableString> GetEventCategories(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets event categories. </summary>
        public virtual AsyncPageable<MonitorLocalizableString> GetEventCategoriesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets tenant activity logs. </summary>
        public virtual Pageable<EventDataInfo> GetTenantActivityLogs(string filter, string select, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets tenant activity logs. </summary>
        public virtual AsyncPageable<EventDataInfo> GetTenantActivityLogsAsync(string filter, string select, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}
