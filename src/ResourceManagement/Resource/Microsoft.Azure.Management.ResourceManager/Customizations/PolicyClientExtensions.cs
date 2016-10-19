// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class PolicyClientExtensions
    {
        /// <summary>
        /// Get the Policy client for the given context.  This client provides operations that manage 
        /// resource policies in the given context.
        /// </summary>
        /// <param name="context">The context for the client to target.</param>
        /// <returns>The policy client for the given context.</returns>
        public static IPolicyClient GetPolicyClient(this IAzureContext context)
        {
           return PolicyClient.CreateClient(context);
        }
    }
}
