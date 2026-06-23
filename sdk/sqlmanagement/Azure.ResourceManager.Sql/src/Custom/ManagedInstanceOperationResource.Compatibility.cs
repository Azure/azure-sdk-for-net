// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceOperationResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, Guid operationId)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, managedInstanceName, operationId.ToString());
    }
}
