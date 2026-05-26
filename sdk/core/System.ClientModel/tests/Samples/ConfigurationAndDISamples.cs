// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Samples;

public class ConfigurationAndDISamples
{
    [Test]
    [Ignore("Used for documentation")]
    public void SimpleConfigurationExample()
    {
        #region Snippet:SimpleConfigurationExample

        ConfigurationManager configuration = new();
        configuration.AddJsonFile("appsettings.json");

        MyClientSettings settings = configuration.GetClientSettings<MyClientSettings>("MyClient");
        MyClient client = new(settings);

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void AdvancedConfigurationExample()
    {
        #region Snippet:AdvancedConfigurationExample

        ConfigurationManager configuration = new();
        configuration.AddJsonFile("appsettings.json");
        configuration.AddEnvironmentVariables();

        MyClientSettings settings = configuration.GetClientSettings<MyClientSettings>("MyClient");
        MyClient client = new(settings);

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void SimpleDependencyInjectionExample()
    {
        #region Snippet:SimpleDependencyInjectionExample

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.AddClient<MyClient, MyClientSettings>("MyClient");

        IServiceProvider provider = builder.Services.BuildServiceProvider();

        MyClient client = provider.GetRequiredService<MyClient>();

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void KeyedServicesExample()
    {
        #region Snippet:KeyedServicesExample

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.AddKeyedClient<MyClient, MyClientSettings>("client1", "Client1");
        builder.AddKeyedClient<MyClient, MyClientSettings>("client2", "Client2");

        IServiceProvider provider = builder.Services.BuildServiceProvider();

        MyClient client1 = provider.GetRequiredKeyedService<MyClient>("client1");
        MyClient client2 = provider.GetRequiredKeyedService<MyClient>("client2");

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void OverridingCredentialsExample()
    {
        #region Snippet:OverridingCredentialsExample

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.AddClient<MyClient, MyClientSettings>("MyClient")
            .PostConfigure(settings => settings.CredentialProvider = new MyTokenProvider());

        IServiceProvider provider = builder.Services.BuildServiceProvider();

        MyClient client = provider.GetRequiredService<MyClient>();

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void CustomCredentialResolverExample()
    {
        #region Snippet:CustomCredentialResolverExample

        ConfigurationManager configuration = new();
        configuration.AddJsonFile("appsettings.json");

        // Resolve the credential by walking a chain of CredentialResolver
        // instances against the named section. The first resolver whose
        // TryResolve returns true wins.
        AuthenticationTokenProvider? credential = configuration.GetCredential(
            "MyClient:Credential",
            new MyCredentialResolver());

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void DependencyInjectionWithCredentialResolverExample()
    {
        #region Snippet:DependencyInjectionWithCredentialResolverExample

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        // Register the resolver once. AddClient/AddKeyedClient will then
        // auto-resolve credentials from the registered resolver chain — no
        // PostConfigure(settings => settings.CredentialProvider = ...) needed.
        builder.AddCredentialResolver<MyCredentialResolver>();
        builder.AddClient<MyClient, MyClientSettings>("MyClient");

        IServiceProvider provider = builder.Services.BuildServiceProvider();

        MyClient client = provider.GetRequiredService<MyClient>();

        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void ReferenceSyntaxExample()
    {
        #region Snippet:ReferenceSyntaxExample

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.AddKeyedClient<MyClient, MyClientSettings>("client1", "Client1");
        builder.AddKeyedClient<MyClient, MyClientSettings>("client2", "Client2");

        IServiceProvider provider = builder.Services.BuildServiceProvider();

        MyClient client1 = provider.GetRequiredKeyedService<MyClient>("client1");
        MyClient client2 = provider.GetRequiredKeyedService<MyClient>("client2");

        #endregion
    }

    // Helper classes for samples
    private class MyClient
    {
        public MyClient(MyClientSettings settings)
        {
            Settings = settings;
        }

        public MyClientSettings Settings { get; }
    }

    private class MyClientSettings : ClientSettings
    {
        public Uri? Endpoint { get; set; }
        public MyClientOptions? Options { get; set; }

        protected override void BindCore(IConfigurationSection section)
        {
            string? endpoint = section["Endpoint"];
            if (!string.IsNullOrEmpty(endpoint))
            {
                Endpoint = new Uri(endpoint);
            }

            IConfigurationSection? optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new MyClientOptions(optionsSection);
            }
        }
    }

    private class MyClientOptions : ClientPipelineOptions
    {
        public MyClientOptions()
        {
        }

        internal MyClientOptions(IConfigurationSection section) : base(section)
        {
            string? apiVersion = section["ApiVersion"];
            if (!string.IsNullOrEmpty(apiVersion))
            {
                ApiVersion = apiVersion;
            }
        }

        public string? ApiVersion { get; set; }
    }

    private class MyTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
        {
            return new GetTokenOptions(properties);
        }

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
        {
            // In a real scenario, this would get a token from your custom authentication system
            string token = "custom-token-from-provider";
            return new AuthenticationToken(token, "Bearer", DateTimeOffset.UtcNow.AddHours(1));
        }

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
        {
            string token = "custom-token-from-provider";
            return new ValueTask<AuthenticationToken>(new AuthenticationToken(token, "Bearer", DateTimeOffset.UtcNow.AddHours(1)));
        }
    }

    private class MyCredentialResolver : CredentialResolver
    {
        public override bool TryResolve(
            IConfigurationSection credentialSection,
            [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            // Only handle sections that opt into this resolver via CredentialSource.
            if (string.Equals(credentialSection["CredentialSource"], "MyCredential", StringComparison.OrdinalIgnoreCase))
            {
                provider = new MyTokenProvider();
                return true;
            }

            // Defer to the next resolver in the chain.
            provider = null;
            return false;
        }
    }
}
