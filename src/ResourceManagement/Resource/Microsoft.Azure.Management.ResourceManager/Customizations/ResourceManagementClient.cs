// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager
{
    public partial class ResourceManagementClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static ResourceManagementClient CreateClient(IAzureContext context)
        {
            return context.InitializeServiceClient<ResourceManagementClient>(() =>
                new ResourceManagementClient
                {
                    HttpClient = context.HttpClient,
                    FirstMessageHandler = context.Handler,
                    HttpClientHandler = context.RootHandler,
                    Credentials = context.Credentials
                });
        }
    }
}
