// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager
{
    public partial class PolicyClient
    {
        /// <summary>
        /// Create a Policy client in the given context.  This client provides operations that manage 
        /// resource policies in the given context.
        /// </summary>
        /// <param name="context">The context for the client to target.</param>
        /// <returns>A policy client targeting the given context.</returns>
        public static PolicyClient CreateClient(IAzureContext context)
        {
            return context.InitializeServiceClient((ctx) =>
                new PolicyClient
                {
                    HttpClient = ctx.HttpClient,
                    FirstMessageHandler = ctx.Handler,
                    HttpClientHandler = ctx.RootHandler,
                    Credentials = ctx.Credentials
                });
        }
    }
}
