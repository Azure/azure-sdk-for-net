// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old Id property to CanMigrateResult for backward API compatibility with the previous SDK.
    // Reason: The old SDK exposed a string-typed Id property, but after the TypeSpec migration it was changed to the ResourceIdentifier-typed ResourceId property.
    // The old string Id property is preserved here (delegating to ResourceId?.ToString()) and marked as EditorBrowsable.Never.
    public partial class CanMigrateResult
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id => ResourceId?.ToString();
    }
}
