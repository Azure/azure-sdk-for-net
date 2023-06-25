// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Properties of function key info. </summary>
    public partial class WebAppKeyInfoProperties
    {
        /// <summary> Initializes a new instance of WebAppKeyInfoProperties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebAppKeyInfoProperties()
        {
        }

        /// <summary> Key name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete]
        public string Name { get; set; }
        /// <summary> Key value. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete]
        public string Value { get; set; }
    }
}
