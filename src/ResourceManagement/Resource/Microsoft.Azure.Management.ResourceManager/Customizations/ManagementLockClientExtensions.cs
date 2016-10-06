// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class ManagementLockClientExtensions
    {
        public static IManagementLockClient GetManagementLockClient(this IAzureContext context)
        {
           return ManagementLockClient.CreateClient(context);
        }
        public static IManagementLocksOperations GetManagementLockOperations(this IAzureContext context)
        {
            return context.GetManagementLockClient().ManagementLocks;
        }
    }
}
