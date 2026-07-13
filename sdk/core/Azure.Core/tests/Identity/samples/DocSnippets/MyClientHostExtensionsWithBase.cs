// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets.WithBaseClient
{
    /// <summary>
    /// Snippet for library-author "Composing with AddClient Instead of AddAzureClient".
    /// </summary>
    public static class MyClientHostExtensionsWithBase
    {
        #region Snippet:Azure_Core_Samples_AzureClient_AddMyClientWithBase
        public static IClientBuilder AddMyClient(
            this IHostApplicationBuilder builder,
            string sectionName)
        {
            builder.AddAzureCredentialResolver();
            builder.Services.AddCredentialResolver<MyVaultCredentialResolver>();
            return builder.AddClient<MyClient, MyClientSettings>(sectionName);
        }
        #endregion
    }
}
