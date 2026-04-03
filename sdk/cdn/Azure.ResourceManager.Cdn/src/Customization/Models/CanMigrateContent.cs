// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CanMigrateContent
    {
        // Backward compatibility: old API used ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CanMigrateContent(WritableSubResource classicResourceReference) : this()
        {
            if (classicResourceReference != null)
            {
                ClassicResourceReference = new ResourceReference { Id = classicResourceReference.Id };
            }
        }
    }
}
