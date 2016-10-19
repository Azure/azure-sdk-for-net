// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager
{
    public partial class FeatureClient
    {
        /// <summary>
        /// Create a feature client targeting the given Azure context.  This provides operations to discover, enable, and disable the 
        /// custom resource manager features in the provided Azure context
        /// </summary>
        /// <param name="context">The context to target</param>
        /// <returns>The feature client for the given context.</returns>
        public static FeatureClient CreateClient(IAzureContext context)
        {
            return context.InitializeServiceClient((ctx) => 
                new FeatureClient
                {
                    HttpClient = ctx.HttpClient,
                    FirstMessageHandler = ctx.Handler,
                    HttpClientHandler = ctx.RootHandler,
                    Credentials = ctx.Credentials
                });
        }
    }
}
