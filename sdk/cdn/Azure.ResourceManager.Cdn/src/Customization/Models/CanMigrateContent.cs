// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor to CanMigrateContent for backward API compatibility with the previous SDK.
    // Reason: The old SDK constructor accepted a WritableSubResource-typed classicResourceReference parameter,
    // but after the TypeSpec migration, the parameter type was changed to CdnResourceReference.
    // The old constructor accepting WritableSubResource is preserved here, internally converting it to CdnResourceReference,
    // and marked as EditorBrowsable.Never to avoid a breaking change.
    public partial class CanMigrateContent
    {
        // Backward compatibility: old API used ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CanMigrateContent(WritableSubResource classicResourceReference) : this()
        {
            if (classicResourceReference != null)
            {
                ClassicResourceReference = new CdnResourceReference { Id = classicResourceReference.Id };
            }
        }
    }
}
