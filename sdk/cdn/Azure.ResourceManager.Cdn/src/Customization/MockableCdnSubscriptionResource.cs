// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Mocking
{
    // Suppress colliding GetAll members so regenerated code can restore the old resource-usage surface.
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class MockableCdnSubscriptionResource
    {
    }
}
