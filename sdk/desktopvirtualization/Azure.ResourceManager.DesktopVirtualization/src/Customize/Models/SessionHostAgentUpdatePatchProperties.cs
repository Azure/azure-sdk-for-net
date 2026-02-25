// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public partial class SessionHostAgentUpdatePatchProperties
    {
        /// <summary> List of maintenance windows. Maintenance windows are 2 hours long. </summary>
        [WirePath("maintenanceWindows")]
        public IList<MaintenanceWindowPatchProperties> MaintenanceWindows { get; set; }
    }
}
