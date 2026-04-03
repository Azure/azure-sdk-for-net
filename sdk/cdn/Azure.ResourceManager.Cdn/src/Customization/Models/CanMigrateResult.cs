// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CanMigrateResult
    {
        // Backward compatibility: old API exposed ResourceId, new generator uses Id
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ResourceId => Id;

        // Backward compatibility: old API used CanMigrateResultType, new uses Type
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CanMigrateResultType => Type;
    }
}
