// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KeyVault.Models
{
    [CodeGenModel(Usage = new[] { "Input" })]
    public partial class ManagedHsmPrivateLinkResourceData : TrackedResourceData
    {
    }
}
