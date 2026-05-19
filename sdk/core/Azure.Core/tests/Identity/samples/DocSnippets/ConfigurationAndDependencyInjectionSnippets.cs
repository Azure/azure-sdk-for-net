// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets
{
    /// <summary>
    /// Compile-validated snippets backing the Azure.Core
    /// ConfigurationAndDependencyInjection.md documentation. Methods are not
    /// annotated with [Test] because they reference appsettings.json files that
    /// don't exist at runtime — they exist solely so the snippet bodies are
    /// type-checked by the compiler.
    /// </summary>
    public class ConfigurationAndDependencyInjectionSnippets
    {
        public void SimpleConfiguration()
        {
            #region Snippet:Azure_Core_Samples_AzureClient_SimpleConfiguration
            ConfigurationManager configuration = new();
            configuration.AddJsonFile("appsettings.json");

            // GetAzureClientSettings resolves the credential automatically via the built-in AzureCredentialResolver
            MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>("MyClient");
            MyClient client = new(settings);
            #endregion
        }

        public void SimpleDependencyInjection()
        {
            #region Snippet:Azure_Core_Samples_AzureClient_SimpleDI
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            // AddAzureClient resolves the credential automatically via the built-in AzureCredentialResolver
            builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

            IServiceProvider provider = builder.Services.BuildServiceProvider();
            MyClient client = provider.GetRequiredService<MyClient>();
            #endregion
        }

        public void SimpleDependencyInjectionWithOverride()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            #region Snippet:Azure_Core_Samples_AzureClient_SimpleDIOverride
            builder.AddAzureClient<MyClient, MyClientSettings>("MyClient", settings =>
            {
                settings.Options.NetworkTimeout = TimeSpan.FromSeconds(60);
            });
            #endregion
        }

        public void KeyedServices()
        {
            #region Snippet:Azure_Core_Samples_AzureClient_KeyedServices
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddKeyedAzureClient<MyClient, MyClientSettings>("primary", "PrimaryClient");
            builder.AddKeyedAzureClient<MyClient, MyClientSettings>("secondary", "SecondaryClient");

            IServiceProvider provider = builder.Services.BuildServiceProvider();
            MyClient primary = provider.GetRequiredKeyedService<MyClient>("primary");
            MyClient secondary = provider.GetRequiredKeyedService<MyClient>("secondary");
            #endregion
        }

        public void GetAzureCredentialSettings()
        {
            ConfigurationManager configuration = new();

            #region Snippet:Azure_Core_Samples_AzureClient_GetCredentialSettings
            CredentialSettings credential = configuration.GetAzureCredentialSettings("MyClient:Credential");

            if (credential?.TokenProvider is TokenCredential token)
            {
                // Use the resolved TokenCredential.
            }
            else if (credential?.CredentialSource == "apikeycredential" && credential.Key is string key)
            {
                // Use the inline API key.
            }
            else
            {
                // Section missing, or no resolver claimed it.
            }
            #endregion
        }

        public void ChainingAdditionalConfiguration()
        {
            #region Snippet:Azure_Core_Samples_AzureClient_ChainingAdditionalConfiguration
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            builder.AddAzureClient<MyClient, MyClientSettings>("MyClient", settings =>
            {
                settings.Options.NetworkTimeout = TimeSpan.FromSeconds(60);
            });
            #endregion
        }

        public void ConfigurationReferenceSyntax()
        {
            #region Snippet:Azure_Core_Samples_AzureClient_ConfigReference
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc1", "Client1");
            builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc2", "Client2");
            #endregion
        }

        public void WithAzureCredentialEquivalence()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            #region Snippet:Azure_Core_Samples_AzureClient_AddAzureClientEquivalence
#pragma warning disable SCME0002

            // These two are equivalent:
            builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

            builder.AddAzureCredentialResolver();
            builder.AddClient<MyClient, MyClientSettings>("MyClient");

#pragma warning restore SCME0002
            #endregion
        }

        public void StandaloneCustomResolver()
        {
            ConfigurationManager configuration = new();

            #region Snippet:Azure_Core_Samples_AzureClient_StandaloneCustomResolver
            MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>(
                "MyClient",
                new MyVaultCredentialResolver());

            CredentialSettings credential = configuration.GetAzureCredentialSettings(
                "MyClient:Credential",
                new MyVaultCredentialResolver());
            #endregion
        }
    }
}
