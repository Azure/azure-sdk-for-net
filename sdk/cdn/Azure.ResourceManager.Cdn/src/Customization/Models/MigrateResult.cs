// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class MigrateResult
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id => ResourceId?.ToString();
    }
}
