// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class ResourcesMoveContent
    {
        /// <summary> The target resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TargetResourceGroup { get => TargetResourceGroupId.ToString(); set => TargetResourceGroupId = new ResourceIdentifier(value); }
    }
}
