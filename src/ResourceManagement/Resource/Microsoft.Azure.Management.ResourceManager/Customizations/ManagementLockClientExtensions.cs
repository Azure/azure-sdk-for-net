// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class ManagementLockClientExtensions
    {
        /// <summary>
        /// Get the ManagementLock client for the given context.  This client provides operations that manage 
        /// resource locks in the given context.
        /// </summary>
        /// <param name="context">The context for the client to target.</param>
        /// <returns>The management lock client for the given context.</returns>
        public static IManagementLockClient GetManagementLockClient(this IAzureContext context)
        {
           return ManagementLockClient.CreateClient(context);
        }
    }
}
