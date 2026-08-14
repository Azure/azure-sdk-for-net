// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataSourceSetInfo
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public System.Uri ResourceUri { get; set; }
    }
}
