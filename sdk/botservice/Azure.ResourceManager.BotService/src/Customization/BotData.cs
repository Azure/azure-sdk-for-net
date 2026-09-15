// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.BotService
{
    // Backward compatibility: BotData is a tracked resource, but the generated code does not inherit from TrackedResourceData.
    // This class is added to provide the correct inheritance.
    public partial class BotData : TrackedResourceData
    {
    }
}
