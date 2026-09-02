// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets.WithAzureClient
{
    /// <summary>
    /// Snippet for library-author "Registering the Resolver in Your AddXxxClient Extension".
    /// </summary>
    public static class MyClientHostExtensionsWithAzure
    {
        #region Snippet:Azure_Core_Samples_AzureClient_AddMyClientWithAzure
        public static IClientBuilder AddMyClient(
            this IHostApplicationBuilder builder,
            string sectionName)
        {
            builder.Services.AddCredentialResolver<MyVaultCredentialResolver>();
            return builder.AddAzureClient<MyClient, MyClientSettings>(sectionName);
        }
        #endregion
    }
}
