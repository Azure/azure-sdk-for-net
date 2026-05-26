// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity.Broker.Tests.Samples.DocSnippets
{
    /// <summary>
    /// Compile-validated snippets backing the Azure.Identity.Broker
    /// ConfigurationAndDependencyInjection.md documentation. Methods are not
    /// annotated with [Test] because they reference appsettings.json files
    /// that don't exist at runtime — they exist solely so the snippet bodies
    /// are type-checked by the compiler.
    /// </summary>
    public class ConfigurationAndDependencyInjectionSnippets
    {
        public void DependencyInjection(string[] args)
        {
            #region Snippet:Azure_Identity_Broker_Samples_DependencyInjection
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            // Register broker first so it claims BrokerCredential sections.
            builder.AddBrokerCredentialResolver();

            // AddAzureClient registers AzureCredentialResolver internally as the fallback.
            builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

            IHost host = builder.Build();
            #endregion
        }

        public void GetAzureClientSettings()
        {
            #region Snippet:Azure_Identity_Broker_Samples_GetAzureClientSettings
            ConfigurationManager configuration = new();
            configuration.AddJsonFile("appsettings.json");

            MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>(
                "MyClient",
                BrokerCredentialResolver.Default);

            MyClient client = new(settings);
            #endregion
        }

        public void GetAzureCredentialSettings()
        {
            #region Snippet:Azure_Identity_Broker_Samples_GetAzureCredentialSettings
            ConfigurationManager configuration = new();
            configuration.AddJsonFile("appsettings.json");

            CredentialSettings credential = configuration.GetAzureCredentialSettings(
                "MyClient:Credential",
                BrokerCredentialResolver.Default);

            if (credential.TokenProvider is TokenCredential tokenCredential)
            {
                // Use the resolved TokenCredential.
            }
            #endregion
        }

        public void GetCredentialSettings(IConfiguration configuration)
        {
            #region Snippet:Azure_Identity_Broker_Samples_GetCredentialSettings
            CredentialSettings? credential = configuration.GetCredentialSettings(
                "MyClient:Credential",
                BrokerCredentialResolver.Default,
                new AzureCredentialResolver()); // omit if you don't need non-broker sources

            if (credential is null)
            {
                // No matching credential section was found (or no resolver claimed it).
                throw new InvalidOperationException("MyClient:Credential is not configured.");
            }

            if (credential.TokenProvider is TokenCredential tokenCredential)
            {
                // Use the resolved TokenCredential.
            }
            #endregion
        }

        public void ResolverOrdering(IServiceCollection services)
        {
            #region Snippet:Azure_Identity_Broker_Samples_ResolverOrdering
            services.AddBrokerCredentialResolver(); // first — claims BrokerCredential / VisualStudioCodeCredential
            services.AddAzureCredentialResolver();  // second — fallback for everything else
            #endregion
        }
    }
}
