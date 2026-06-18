// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    // AutoRest generated scheduled query rules as tracked resources; TypeSpec currently emits ResourceData.
    // Restore TrackedResourceData to preserve the stable public API.
    public partial class ScheduledQueryRuleData : TrackedResourceData
    {
    }
}
