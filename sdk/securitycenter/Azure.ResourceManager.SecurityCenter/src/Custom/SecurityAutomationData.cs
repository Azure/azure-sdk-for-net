// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The TypeSpec resource derives from ProxyResource, but the GA SDK exposed this data type as
    // TrackedResourceData because the payload includes tracked-resource envelope fields.
    public partial class SecurityAutomationData : TrackedResourceData
    {
    }
}
