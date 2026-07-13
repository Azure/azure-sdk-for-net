// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the TroubleshootingContent type. </summary>
    public partial class TroubleshootingContent
    {
        /// <summary> Invokes the this compatibility operation. </summary>
        public TroubleshootingContent(ResourceIdentifier targetResourceId, ResourceIdentifier storageId, System.Uri storagePath) : this(targetResourceId, storageId, storagePath?.AbsoluteUri)
        {
        }
    }
}
