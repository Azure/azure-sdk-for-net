// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="host"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IHostBuilder AddAzureCredential(this IHostBuilder host, string sectionName)
        {
            host.ConfigureServices((context, services) =>
            {
                DefaultAzureCredentialOptions options = new(context.Configuration.GetSection(sectionName));
                DefaultAzureCredential credential = new DefaultAzureCredential(options);
                services.AddSingleton<TokenCredential>(sp => credential);
                services.AddSingleton<AuthenticationTokenProvider>(sp => credential);
            });

            return host;
        }
    }
}
