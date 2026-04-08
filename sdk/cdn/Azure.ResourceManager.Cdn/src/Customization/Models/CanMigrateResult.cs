// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CanMigrateResult
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id => ResourceId?.ToString();
    }
}
