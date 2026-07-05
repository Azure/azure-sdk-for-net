// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The MaintenanceWindows property was previously an IList<> with a
// public setter. The new generated code changed it to a read-only list. This restores the
// settable IList<SessionHostMaintenanceWindowProperties> property so existing callers are not broken.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public partial class SessionHostAgentUpdateProperties
    {
        /// <summary> List of maintenance windows. Maintenance windows are 2 hours long. </summary>
        [WirePath("maintenanceWindows")]
        public IList<SessionHostMaintenanceWindowProperties> MaintenanceWindows { get; set; }
    }
}
