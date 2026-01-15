// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class AuthenticationPolicyCreateTests
{
    [Test]
    public void Create_WithNullSettings_ThrowsArgumentNullException()
    {
        ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() =>
            AuthenticationPolicy.Create(null!, "scope"));

        Assert.That(ex!.ParamName, Is.EqualTo("settings"));
    }

    [Test]
    public void Create_WithNullCredential_ThrowsArgumentNullException()
    {
        TestClientSettings settings = new();
        settings.Credential = null;

        ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() =>
            AuthenticationPolicy.Create(settings, "scope"));

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
            AuthenticationPolicy.Create(settings, "scope"));

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

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
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
            AuthenticationPolicy.Create(settings, "https://example.com/.default"));

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
            AuthenticationPolicy.Create(settings, "https://example.com/.default"));

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

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
    }

    [Test]
    public void Create_WithTokenCredentialSource_AndTokenProvider_ReturnsBearerTokenPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "TokenCredential"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("test-token");

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<BearerTokenPolicy>());
    }

    [Test]
    public void Create_WithUnknownCredentialSource_AndTokenProvider_ReturnsBearerTokenPolicy()
    {
        TestClientSettings settings = new();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "CustomCredentialType"
            })
            .Build();
        settings.Bind(config.GetSection("TestClient"));
        settings.CredentialObject = new TestTokenProvider("test-token");

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<BearerTokenPolicy>());
    }

    [Test]
    public void Create_WithNullScope_DoesNotThrow()
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

        Assert.DoesNotThrow(() => AuthenticationPolicy.Create(settings, null!));
    }

    [Test]
    public void Create_WithEmptyScope_DoesNotThrow()
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

        Assert.DoesNotThrow(() => AuthenticationPolicy.Create(settings, string.Empty));
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

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
        Assert.That(provider.GetTokenCalled, Is.True);
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

        AuthenticationPolicy policy1 = AuthenticationPolicy.Create(settings, "scope1");
        AuthenticationPolicy policy2 = AuthenticationPolicy.Create(settings, "scope2");

        Assert.That(policy1, Is.Not.Null);
        Assert.That(policy2, Is.Not.Null);
        Assert.That(ReferenceEquals(policy1, policy2), Is.False);
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

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
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

        AuthenticationPolicy policy = AuthenticationPolicy.Create(settings, "https://example.com/.default");

        Assert.That(policy, Is.Not.Null);
        Assert.That(policy, Is.InstanceOf<ApiKeyAuthenticationPolicy>());
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
