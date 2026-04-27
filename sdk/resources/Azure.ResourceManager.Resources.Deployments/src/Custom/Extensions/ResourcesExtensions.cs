// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Resources
{
    [CodeGenSuppress("WhatIfAtSubscriptionScopeAsync", typeof(WaitUntil), typeof(string), typeof(ArmDeploymentWhatIfContent), typeof(CancellationToken))]   // The WhatIf operations are all moved to ArmDeploymentResource. Not scope out this operation from the client.tsp is intentional for genrating other related classes for the customized WhatIf operations.
    [CodeGenSuppress("WhatIfAtSubscriptionScope", typeof(WaitUntil), typeof(string), typeof(ArmDeploymentWhatIfContent), typeof(CancellationToken))]        // The WhatIf operations are all moved to ArmDeploymentResource. Not scope out this operation from the client.tsp is intentional for genrating other related classes for the customized WhatIf operations.
    public static partial class ResourcesExtensions
    {
    }
}
