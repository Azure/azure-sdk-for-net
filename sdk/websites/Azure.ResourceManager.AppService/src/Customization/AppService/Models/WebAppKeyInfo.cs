// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class WebAppKeyInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Value { get; set; }
    }
}
