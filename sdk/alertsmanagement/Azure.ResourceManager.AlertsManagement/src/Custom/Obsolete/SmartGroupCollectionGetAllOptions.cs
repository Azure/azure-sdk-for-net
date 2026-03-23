// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SmartGroupCollectionGetAllOptions
    {
        /// <summary> Initializes a new instance. </summary>
        public SmartGroupCollectionGetAllOptions() { throw new NotSupportedException(); }

        /// <summary> Gets or sets the monitor condition. </summary>
        public MonitorCondition? MonitorCondition { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the monitor service. </summary>
        public MonitorServiceSourceForAlert? MonitorService { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the page count. </summary>
        public long? PageCount { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the severity. </summary>
        public ServiceAlertSeverity? Severity { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the smart group state. </summary>
        public ServiceAlertState? SmartGroupState { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the sort by. </summary>
        public SmartGroupsSortByField? SortBy { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the sort order. </summary>
        public AlertsManagementQuerySortOrder? SortOrder { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the target resource. </summary>
        public string TargetResource { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the target resource group. </summary>
        public string TargetResourceGroup { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the target resource type. </summary>
        public string TargetResourceType { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the time range. </summary>
        public TimeRangeFilter? TimeRange { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }
    }
}
