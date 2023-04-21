// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

//[assembly: CodeGenSuppressType("DataSourceSetInfo")]
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> DatasourceSet details of datasource to be backed up. </summary>
    public partial class DataSourceSetInfo
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public System.Uri ResourceUri { get; set; }
    }
}
