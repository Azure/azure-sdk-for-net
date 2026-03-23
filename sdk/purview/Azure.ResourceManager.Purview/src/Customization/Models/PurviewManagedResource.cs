// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Purview.Models
{
    // Backward compatibility: the new TypeSpec MPG generator doesn't emit a parameterless
    // internal constructor for PurviewManagedResource because the model is read-only
    // (eventHubNamespace, resourceGroup, storageAccount are all get-only).  The generator
    // only produces a full-parameter internal constructor for such output models.
    // The old SDK (1.1.0) included this parameterless constructor in the public API
    // surface (api/*.cs), and ApiCompat requires it to remain.  Re-adding to preserve compat.
    public partial class PurviewManagedResource
    {
        /// <summary> Initializes a new instance of <see cref="PurviewManagedResource"/>. </summary>
        internal PurviewManagedResource()
        {
        }
    }
}
