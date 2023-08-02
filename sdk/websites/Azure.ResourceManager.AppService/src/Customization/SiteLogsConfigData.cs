// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class SiteLogsConfigData
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public ResourceIdentifier idstring { get; set; }
    }
}
