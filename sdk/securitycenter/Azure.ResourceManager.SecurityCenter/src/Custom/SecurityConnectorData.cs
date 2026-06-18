// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec schema does not generate the same ARM resource-data base type as the GA SDK; this partial restores the GA inheritance so resource data remains assignable to the same base class.
    public partial class SecurityConnectorData : TrackedResourceData
    {
    }
}
