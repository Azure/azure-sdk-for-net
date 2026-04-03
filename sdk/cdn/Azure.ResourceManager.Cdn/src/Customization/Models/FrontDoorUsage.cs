// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class FrontDoorUsage
    {
        // Backward compatibility: old API exposed ResourceIdentifier Id, new uses string Id
        // The generated string Id property cannot be changed, so provide a new backward-compat property
        // Note: old API's FrontDoorUsage.Id returned ResourceIdentifier but generated now returns string.
        // This is a type change on an existing property name, which is a true breaking change.
        // We add the FrontDoorUsageId property as the closest backward-compat we can offer.
    }
}
