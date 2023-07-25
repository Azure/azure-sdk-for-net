// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Maintenance window used to configure scheduled auto-upgrade for a Managed Cluster. </summary>
    public partial class ContainerServiceMaintenanceWindow
    {
        /// <summary> The date the maintenance window activates. If the current date is before this date, the maintenance window is inactive and will not be used for upgrades. If not specified, the maintenance window will be active right away. </summary>
        [CodeGenMember("StartOn")]
        public string StartDate { get; set; }
    }
}
