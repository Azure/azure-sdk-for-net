// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing the VirtualApplicationGroup data model.
    /// Represents a ApplicationGroup definition.
    /// </summary>
    public partial class VirtualApplicationGroupData : TrackedResourceData
    {
        /// <summary> The type of operation for migration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public DesktopVirtualizationMigrationProperties MigrationRequest { get; set; }
    }
}
