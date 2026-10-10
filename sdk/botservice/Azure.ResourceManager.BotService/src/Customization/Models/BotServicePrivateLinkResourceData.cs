// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.BotService.Models
{
    // Backward compatibility: BotServicePrivateLinkResourceData is a resource, but the generated code does not inherit from ResourceData.
    // This class is added to provide the correct inheritance.
    public partial class BotServicePrivateLinkResourceData : ResourceData
    {
    }
}
