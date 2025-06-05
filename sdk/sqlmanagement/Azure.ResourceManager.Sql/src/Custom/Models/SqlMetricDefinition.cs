// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlMetricDefinition
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public Uri ResourceUri => string.IsNullOrEmpty(ResourceUriString) ? null : new Uri(ResourceUriString);
    }
}
