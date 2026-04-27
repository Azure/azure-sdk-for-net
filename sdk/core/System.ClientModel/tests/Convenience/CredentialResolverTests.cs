// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class CredentialResolverTests
{
    [SetUp]
    public void SetUp()
    {
        // CredentialCache is internal with no public Clear hook; reach in via reflection
        // so each test starts with an empty process-wide cache.
        Type cacheType = typeof(AuthenticationTokenProvider).Assembly
            .GetType("System.ClientModel.Primitives.CredentialCache", throwOnError: true)!;
        var field = cacheType.GetField("s_cache", BindingFlags.NonPublic | BindingFlags.Static)!;
        var dict = (System.Collections.IDictionary)field.GetValue(null)!;
        dict.Clear();
    }

    [Test]
    public void GetCredential_NoResolvers_ReturnsNull()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TestCredential",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        AuthenticationTokenProvider? cred = config.GetCredential("TestClient:Credential");
        Assert.That(cred, Is.Null);
    }

    [Test]
    public void GetCredential_WalksResolversInOrder_FirstMatchWins()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        var first = new ScopedRecordingResolver("Match", "first");
        var second = new ScopedRecordingResolver("Match", "second");

        AuthenticationTokenProvider? cred = config.GetCredential("TestClient:Credential", first, second);

        Assert.That(cred, Is.SameAs(first.LastProvider));
        Assert.That(second.WasCalled, Is.False);
    }

    [Test]
    public void GetCredential_DefersToNextWhenResolverReturnsFalse()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Second",
        });

        var first = new ScopedRecordingResolver("First", "first");
        var second = new ScopedRecordingResolver("Second", "second");

        AuthenticationTokenProvider? cred = config.GetCredential("TestClient:Credential", first, second);

        Assert.That(cred, Is.SameAs(second.LastProvider));
    }

    [Test]
    public void GetCredential_MissingSection_ReturnsNull()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>());
        AuthenticationTokenProvider? cred = config.GetCredential(
            "TestClient:Credential",
            new ScopedRecordingResolver("Anything", "x"));
        Assert.That(cred, Is.Null);
    }

    [Test]
    public void GetCredential_ResolverThrows_ReturnsNull()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Throws"
        });

        AuthenticationTokenProvider? cred = config.GetCredential(
            "TestClient:Credential",
            new ThrowingResolver());

        Assert.That(cred, Is.Null);
    }

    [Test]
    public void GetCredential_OverridesAreApplied()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "original-tenant"
        });

        var resolver = new ScopedRecordingResolver("Match", "override");
        var resolvers = new CredentialResolver[] { resolver };

        config.GetCredential("TestClient:Credential", resolvers, section =>
        {
            section["TenantId"] = "override-tenant";
            section["ClientId"] = "added-client";
        });

        Assert.That(resolver.LastSection!["TenantId"], Is.EqualTo("override-tenant"));
        Assert.That(resolver.LastSection!["ClientId"], Is.EqualTo("added-client"));
    }

    [Test]
    public void GetCredential_OverrideUsingReferenceSyntax_Resolves()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "original-tenant",
            ["Shared:TenantId"] = "shared-tenant",
        });

        var resolver = new ScopedRecordingResolver("Match", "override");
        var resolvers = new CredentialResolver[] { resolver };

        config.GetCredential("TestClient:Credential", resolvers, section =>
        {
            section["TenantId"] = "$Shared:TenantId";
        });

        Assert.That(resolver.LastSection!["TenantId"], Is.EqualTo("shared-tenant"));
    }

    [Test]
    public void GetCredential_OverrideSetToNullRemovesKey()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "original-tenant"
        });

        var resolver = new ScopedRecordingResolver("Match", "p");
        var resolvers = new CredentialResolver[] { resolver };

        config.GetCredential("TestClient:Credential", resolvers, section =>
        {
            section["TenantId"] = null;
        });

        Assert.That(resolver.LastSection!["TenantId"], Is.Null);
    }

    [Test]
    public void GetCredential_CachesByMergedContent()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        var resolver = new ScopedRecordingResolver("Match", "cached");

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolver);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(c1, Is.SameAs(c2));
        Assert.That(resolver.CallCount, Is.EqualTo(1));
    }

    [Test]
    public void GetCredential_DifferentOverrides_ProduceDifferentEntries()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        var resolver = new ScopedRecordingResolver("Match", "p");
        var resolvers = new CredentialResolver[] { resolver };

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolvers,
            s => s["TenantId"] = "a");
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolvers,
            s => s["TenantId"] = "b");

        Assert.That(c1, Is.Not.SameAs(c2));
        Assert.That(resolver.CallCount, Is.EqualTo(2));
    }

    [Test]
    public void AddCredentialResolver_IsIdempotentByImplementationType()
    {
        var services = new ServiceCollection();
        services.AddCredentialResolver<ScopedDefaultResolver>();
        services.AddCredentialResolver<ScopedDefaultResolver>();
        services.AddCredentialResolver<ScopedDefaultResolver>();

        IServiceProvider sp = services.BuildServiceProvider();
        IEnumerable<CredentialResolver> registered = sp.GetServices<CredentialResolver>();

        Assert.That(registered, Has.Exactly(1).Items);
    }

    [Test]
    public void AddCredentialResolver_DifferentTypes_BothRegistered()
    {
        var services = new ServiceCollection();
        services.AddCredentialResolver<ScopedDefaultResolver>();
        services.AddCredentialResolver<OtherResolver>();

        IServiceProvider sp = services.BuildServiceProvider();
        IEnumerable<CredentialResolver> registered = sp.GetServices<CredentialResolver>();

        Assert.That(registered, Has.Exactly(2).Items);
    }

    [Test]
    public void AddClient_NoCredentialSection_LeavesProviderNullAndDoesNotThrow()
    {
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        using IHost host = builder.Build();
        TestClient client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.CredentialProvider, Is.Null);
        Assert.That(client.Settings.Credential, Is.Not.Null);
        Assert.That(client.Settings.Credential!.CredentialSource, Is.Null);
    }

    [Test]
    public void AddClient_AutoResolvesCredentialFromRegisteredResolvers()
    {
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        using IHost host = builder.Build();
        TestClient client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(client.Settings.CredentialProvider, Is.InstanceOf<StubTokenProvider>());
    }

    [Test]
    public void AddClient_ConfigureCredential_AppliesOverridesBeforeResolver()
    {
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "original",
        });

        var resolver = new RecordingMatchAllResolver();
        builder.Services.AddSingleton<CredentialResolver>(resolver);
        builder.AddClient<TestClient, TestClientSettings>("TestClient")
               .ConfigureCredential(section =>
               {
                   section["TenantId"] = "overridden";
               });

        using IHost host = builder.Build();
        _ = host.Services.GetRequiredService<TestClient>();

        Assert.That(resolver.LastTenantId, Is.EqualTo("overridden"));
    }

    [Test]
    public void GetCredential_Params_ResolvesReferencesInCredentialSection()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "$Shared:TenantId",
            ["Shared:TenantId"] = "real-tenant",
        });

        var resolver = new RecordingMatchAllResolver();
        AuthenticationTokenProvider? cred = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(cred, Is.Not.Null);
        Assert.That(resolver.LastTenantId, Is.EqualTo("real-tenant"));
    }

    [Test]
    public void GetCredential_WithOverrides_ResolvesReferencesInCredentialSection()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "$Shared:TenantId",
            ["Shared:TenantId"] = "real-tenant",
        });

        var resolver = new RecordingMatchAllResolver();
        CredentialResolver[] resolvers = new CredentialResolver[] { resolver };

        AuthenticationTokenProvider? cred = config.GetCredential(
            "TestClient:Credential",
            resolvers,
            section => section["ClientId"] = "client-override");

        Assert.That(cred, Is.Not.Null);
        Assert.That(resolver.LastTenantId, Is.EqualTo("real-tenant"));
        Assert.That(resolver.LastClientId, Is.EqualTo("client-override"));
    }

    [Test]
    public void GetClientSettings_Params_ResolvesReferencesInBothCredentialAndSettings()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "$Shared:Endpoint",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "$Shared:TenantId",
            ["Shared:Endpoint"] = "https://shared.example.com/",
            ["Shared:TenantId"] = "real-tenant",
        });

        var resolver = new RecordingMatchAllResolver();
        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient", resolver);

        Assert.That(settings.Endpoint?.ToString(), Is.EqualTo("https://shared.example.com/"));
        Assert.That(settings.CredentialProvider, Is.Not.Null);
        Assert.That(resolver.LastTenantId, Is.EqualTo("real-tenant"));
    }

    [Test]
    public void GetClientSettings_WithOverrides_ResolvesReferencesInCredentialSection()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com/",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "$Shared:TenantId",
            ["Shared:TenantId"] = "real-tenant",
        });

        var resolver = new RecordingMatchAllResolver();
        CredentialResolver[] resolvers = new CredentialResolver[] { resolver };

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>(
            "TestClient",
            resolvers,
            section => section["ClientId"] = "overridden-client");

        Assert.That(settings.CredentialProvider, Is.Not.Null);
        Assert.That(resolver.LastTenantId, Is.EqualTo("real-tenant"));
        Assert.That(resolver.LastClientId, Is.EqualTo("overridden-client"));
    }

    [Test]
    public void AddClient_AutoResolve_ResolvesReferencesInCredentialSection()
    {
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "$Shared:Endpoint",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "$Shared:TenantId",
            ["Shared:Endpoint"] = "https://shared.example.com/",
            ["Shared:TenantId"] = "real-tenant",
        });

        var resolver = new RecordingMatchAllResolver();
        builder.Services.AddSingleton<CredentialResolver>(resolver);
        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        using IHost host = builder.Build();
        TestClient client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint?.ToString(), Is.EqualTo("https://shared.example.com/"));
        Assert.That(client.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(resolver.LastTenantId, Is.EqualTo("real-tenant"));
    }

    private sealed class MatchEverythingResolver : CredentialResolver
    {
        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = new StubTokenProvider("auto");
            return true;
        }
    }

    private sealed class RecordingMatchAllResolver : CredentialResolver
    {
        public string? LastTenantId { get; private set; }
        public string? LastClientId { get; private set; }

        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            LastTenantId = credentialSection["TenantId"];
            LastClientId = credentialSection["ClientId"];
            provider = new StubTokenProvider("recorded");
            return true;
        }
    }

    private static IConfigurationRoot BuildConfig(Dictionary<string, string?> values)
    {
        return new ConfigurationBuilder().AddInMemoryCollection(values).Build();
    }

    private sealed class ScopedRecordingResolver : CredentialResolver
    {
        private readonly string _matchSource;
        private readonly string _name;

        public ScopedRecordingResolver(string matchSource, string name)
        {
            _matchSource = matchSource;
            _name = name;
        }

        public int CallCount { get; private set; }
        public bool WasCalled => CallCount > 0;
        public IConfigurationSection? LastSection { get; private set; }
        public AuthenticationTokenProvider? LastProvider { get; private set; }

        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            CallCount++;
            LastSection = credentialSection;
            string? source = credentialSection["CredentialSource"];
            if (string.Equals(source, _matchSource, StringComparison.OrdinalIgnoreCase))
            {
                LastProvider = new StubTokenProvider(_name);
                provider = LastProvider;
                return true;
            }
            provider = null;
            return false;
        }
    }

    private sealed class ScopedDefaultResolver : CredentialResolver
    {
        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = null;
            return false;
        }
    }

    private sealed class OtherResolver : CredentialResolver
    {
        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = null;
            return false;
        }
    }

    private sealed class ThrowingResolver : CredentialResolver
    {
        public override bool TryCreate(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
            => throw new InvalidOperationException("boom");
    }

    private sealed class StubTokenProvider : AuthenticationTokenProvider
    {
        public string Name { get; }
        public StubTokenProvider(string name) => Name = name;

        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => null;
        public override AuthenticationToken GetToken(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
        public override Threading.Tasks.ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
    }
}
