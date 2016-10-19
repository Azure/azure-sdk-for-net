// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager
{
    public partial class SubscriptionClient
    {
        /// <summary>
        /// Create a Subscription client targeting the provided azure context
        /// </summary>
        /// <param name="context">The context to use for service Http communication</param>
        /// <returns>A subscription client using the configuration values provided in the context</returns>
        public static SubscriptionClient CreateClient(IAzureContext context)
        {
            return context.InitializeServiceClient((ctx) =>
                new SubscriptionClient
                {
                    HttpClient = ctx.HttpClient,
                    FirstMessageHandler = ctx.Handler,
                    HttpClientHandler = ctx.RootHandler,
                    Credentials = ctx.Credentials
                });
        }
    }
}
