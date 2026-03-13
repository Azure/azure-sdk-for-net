// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn
{
    // Suppress colliding GetAll extension methods so regenerated code can add back compat wrappers.
    [CodeGenSuppress("GetAllAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class CdnExtensions
    {
    }
}
