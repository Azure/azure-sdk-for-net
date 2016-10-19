// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager
{
    public partial class ResourceManagementClient
    {
        /// <summary>
        /// Create a ResourceManagement client for the given context.  This client provides operations that manage 
        /// resources, respource groups, resource providers, and resource deployments.
        /// </summary>
        /// <param name="context">The context for the client to target.</param>
        /// <returns>A resource manageemnt client targeting the given context.</returns>
        public static ResourceManagementClient CreateClient(IAzureContext context)
        {
            return context.InitializeServiceClient((ctx) =>
                new ResourceManagementClient
                {
                    HttpClient = ctx.HttpClient,
                    FirstMessageHandler = ctx.Handler,
                    HttpClientHandler = ctx.RootHandler,
                    Credentials = ctx.Credentials
                });
        }
    }
}
