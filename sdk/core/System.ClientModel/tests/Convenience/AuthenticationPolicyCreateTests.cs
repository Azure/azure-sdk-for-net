// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class AuthenticationPolicyCreateTests
{
    private static string? GetScopeFromBearerTokenPolicy(BearerTokenPolicy policy)
    {
        // Use reflection to access the private _flowContext field
        FieldInfo? flowContextField = typeof(BearerTokenPolicy).GetField("_flowContext", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.That(flowContextField, Is.Not.Null, "Could not find _flowContext field");

        GetTokenOptions? flowContext = flowContextField!.GetValue(policy) as GetTokenOptions;
        if (flowContext == null)
        {
            return null;
        }

        // Get the Scopes property from GetTokenOptions
        if (flowContext.Properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out object? scopesObj) && scopesObj is ReadOnlyMemory<string> scopes)
        {
            return scopes.Length > 0 ? scopes.Span[0] : null;
        }

        return null;
    }

    private static string? GetKeyFromApiKeyPolicy(ApiKeyAuthenticationPolicy policy)
    {
        // Use reflection to access the private _credential field
        FieldInfo? credentialField = typeof(ApiKeyAuthenticationPolicy).GetField("_credential", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.That(credentialField, Is.Not.Null, "Could not find _credential field");

        ApiKeyCredential? credential = credentialField!.GetValue(policy) as ApiKeyCredential;
        if (credential == null)
        {
            return null;
        }

        // Use Deconstruct to get the key value
        credential.Deconstruct(out string key);
        return key;
    }

    [Test]
    public void Create_WithNullSettings_ThrowsArgumentNullException()
    {
        ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() =>
            AuthenticationPolicy.Create(null!));

        Assert.That(ex!.ParamName, Is.EqualTo("settings"));
    }

    [Test]
    public void Create_WithNullCredential_ThrowsArgumentNullException()
    {
        TestClientSettings settings = new();
        settings.Credential = null;

        ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("settings.Credential"));
    }

    [Test]
    public void Create_WithNullCredentialSource_ThrowsArgumentNullException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:Key"] = "test-key"
                // CredentialSource intentionally not set
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("settings.Credential.CredentialSource"));
    }

    [Test]
    public void Create_WithApiKeyCredentialSource_AndKey_ReturnsApiKeyAuthenticationPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = "test-api-key-12345"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());

        // Verify the API key credential was set
        ApiKeyAuthenticationPolicy apiKeyPolicy = (ApiKeyAuthenticationPolicy)policy;
        string? key = GetKeyFromApiKeyPolicy(apiKeyPolicy);
        Assert.That(key, Is.Not.Null);
        Assert.That(key, Is.EqualTo("test-api-key-12345"));
    }

    [Test]
    public void Create_WithApiKeyCredentialSource_AndNullKey_ThrowsInvalidOperationException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey"
                // Key intentionally not set
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("API key is not provided"));
    }

    [Test]
    public void Create_WithApiKeyCredentialSource_AndEmptyKey_ThrowsArgumentException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = ""
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        ArgumentException? ex = Assert.Throws<ArgumentException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.ParamName, Is.EqualTo("key"));
    }

    [Test]
    public void Create_WithApiKeyCredentialSource_AndTokenProvider_ReturnsApiKeyAuthenticationPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("provider-api-key");

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());

        // Verify the API key from token provider was used
        ApiKeyAuthenticationPolicy apiKeyPolicy = (ApiKeyAuthenticationPolicy)policy;
        string? key = GetKeyFromApiKeyPolicy(apiKeyPolicy);
        Assert.That(key, Is.Not.Null);
        Assert.That(key, Is.EqualTo("provider-api-key"));
    }

    [Test]
    public void Create_WithApiKeyCredentialSource_AndScope_ThrowsInvalidOperationException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:AdditionalProperties:Scope"] = "https://example.com/.default"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("api-key");

        // Debug: Verify scope is actually in AdditionalProperties
        Assert.That(settings.Credential, Is.Not.Null);
        Assert.That(settings.Credential!.AdditionalProperties, Is.Not.Null);
        string? scopeValue = settings.Credential.AdditionalProperties!["Scope"];
        Assert.That(scopeValue, Is.EqualTo("https://example.com/.default"), "Scope should be readable from AdditionalProperties");

        // This should throw because scope is not applicable for ApiKey
        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("Scope is not applicable for API key authentication"));
    }

    [Test]
    public void Create_WithTokenCredentialSource_AndNoScope_ThrowsInvalidOperationException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "TokenCredential"
                // Scope intentionally not set
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("test-token");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("Scope must be provided in configuration"));
        Assert.That(ex.Message, Does.Contain("'TokenCredential'"));
    }

    [Test]
    public void Create_WithTokenCredentialSource_AndNoCredentialObject_ThrowsInvalidOperationException()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "TokenCredential",
                ["TestClient:Credential:AdditionalProperties:Scope"] = "https://example.com/.default"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        // CredentialObject intentionally not set

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() =>
            AuthenticationPolicy.Create(settings));

        Assert.That(ex!.Message, Does.Contain("No AuthenticationTokenProvider was provided"));
    }

    [Test]
    public void Create_WithTokenCredentialSource_AndTokenProvider_ReturnsBearerTokenPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "TokenCredential",
                ["TestClient:Credential:AdditionalProperties:Scope"] = "https://example.com/.default"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("test-token");

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<BearerTokenPolicy>());

        // Verify scope was passed through correctly
        BearerTokenPolicy bearerPolicy = (BearerTokenPolicy)policy;
        string? scope = GetScopeFromBearerTokenPolicy(bearerPolicy);
        Assert.That(scope, Is.EqualTo("https://example.com/.default"));
    }

    [Test]
    public void Create_WithUnknownCredentialSource_AndTokenProvider_ReturnsBearerTokenPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "CustomCredentialType",
                ["TestClient:Credential:AdditionalProperties:Scope"] = "https://example.com/.default"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("test-token");

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<BearerTokenPolicy>());

        // Verify scope was passed through correctly
        BearerTokenPolicy bearerPolicy = (BearerTokenPolicy)policy;
        string? scope = GetScopeFromBearerTokenPolicy(bearerPolicy);
        Assert.That(scope, Is.EqualTo("https://example.com/.default"));
    }

    [Test]
    public void Create_WithApiKeyFromTokenProvider_UsesProviderKey()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = "config-key"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        // When CredentialObject is a TokenProvider, it should take precedence
        TestTokenProvider provider = new("provider-key");
        settings.CredentialObject = provider;

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
        Assert.That(provider.GetTokenCalled, Is.True);

        // Verify the provider key was used, not the config key
        ApiKeyAuthenticationPolicy apiKeyPolicy = (ApiKeyAuthenticationPolicy)policy;
        string? key = GetKeyFromApiKeyPolicy(apiKeyPolicy);
        Assert.That(key, Is.Not.Null);
        Assert.That(key, Is.EqualTo("provider-key"));
    }

    [Test]
    public void Create_WithMultipleCallsSameSettings_CreatesNewPolicyEachTime()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = "test-key"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        AuthenticationPolicy policy1 = AuthenticationPolicy.Create(settings);
        AuthenticationPolicy policy2 = AuthenticationPolicy.Create(settings);

        Assert.That(policy1, Is.Not.Null);
        Assert.That(policy2, Is.Not.Null);
        Assert.That(ReferenceEquals(policy1, policy2), Is.False);

        // Verify both are ApiKey policies with the same key
        Assert.That(policy1, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
        Assert.That(policy2, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
        string? key1 = GetKeyFromApiKeyPolicy((ApiKeyAuthenticationPolicy)policy1);
        string? key2 = GetKeyFromApiKeyPolicy((ApiKeyAuthenticationPolicy)policy2);
        Assert.That(key1, Is.EqualTo("test-key"));
        Assert.That(key2, Is.EqualTo("test-key"));
    }

    [Test]
    public void Create_WithSpecialCharactersInApiKey_CreatesPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = "key-with-special-chars!@#$%^&*()_+-={}[]|:;<>?,./"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());

        // Verify special characters in key are preserved
        ApiKeyAuthenticationPolicy apiKeyPolicy = (ApiKeyAuthenticationPolicy)policy;
        string? key = GetKeyFromApiKeyPolicy(apiKeyPolicy);
        Assert.That(key, Is.Not.Null);
        Assert.That(key, Is.EqualTo("key-with-special-chars!@#$%^&*()_+-={}[]|:;<>?,./"));
    }

    [Test]
    public void Create_WithVeryLongApiKey_CreatesPolicy()
    {
        string longKey = new string('a', 10000);
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "ApiKey",
                ["TestClient:Credential:Key"] = longKey
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings);

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());

        // Verify long key is preserved
        ApiKeyAuthenticationPolicy apiKeyPolicy = (ApiKeyAuthenticationPolicy)policy;
        string? key = GetKeyFromApiKeyPolicy(apiKeyPolicy);
        Assert.That(key, Is.Not.Null);
        Assert.That(key, Is.EqualTo(longKey));
        Assert.That(key!.Length, Is.EqualTo(10000));
    }

    private class TestTokenProvider : AuthenticationTokenProvider
    {
        private readonly string _tokenValue;
        public bool GetTokenCalled { get; private set; }

        public TestTokenProvider(string tokenValue)
        {
            _tokenValue = tokenValue;
        }

        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
        {
            return new GetTokenOptions(properties);
        }

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
        {
            GetTokenCalled = true;
            return new AuthenticationToken(_tokenValue, "Bearer", DateTimeOffset.UtcNow.AddHours(1));
        }

        public override async ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
        {
            GetTokenCalled = true;
            return await Task.FromResult(new AuthenticationToken(_tokenValue, "Bearer", DateTimeOffset.UtcNow.AddHours(1)));
        }
    }
}
