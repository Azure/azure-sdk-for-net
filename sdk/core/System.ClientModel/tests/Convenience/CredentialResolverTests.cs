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
    public void GetCredential_ResolverThrows_ExceptionPropagates()
    {
        // A throwing resolver indicates a real bug in the resolver
        // implementation (e.g., a NullReferenceException), not "I can't
        // handle this credential source" — that case is signaled by
        // returning false from TryResolve. The engine surfaces the
        // exception so the bug isn't silently swallowed.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Throws"
        });

        Assert.Throws<InvalidOperationException>(() =>
            config.GetCredential("TestClient:Credential", new ThrowingResolver()));
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
    public void GetCredential_DifferentResolverChains_DoNotShareCacheEntries()
    {
        // Demonstrates a cache-leakage bug raised in PR review: with the cache
        // keyed only by merged section content, a second call with a DIFFERENT
        // resolver chain (different implementation type) returns the provider
        // produced by the first chain even though the second chain would have
        // produced a different provider. The fix salts the cache key with an
        // ordered fingerprint of the resolver implementation types.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", new MatchAllNamedBResolver());

        Assert.That(c1, Is.Not.Null);
        Assert.That(c2, Is.Not.Null);
        Assert.That(((StubTokenProvider)c1!).Name, Is.EqualTo("A"));
        Assert.That(((StubTokenProvider)c2!).Name, Is.EqualTo("B"),
            "Second chain (different resolver type) should produce its own provider; the cache must not leak across distinct resolver sets.");
        Assert.That(c1, Is.Not.SameAs(c2));
    }

    [Test]
    public void GetCredential_SameResolverInstance_SharesCacheEntry()
    {
        // Realistic DI case: a singleton resolver instance is reused for many
        // calls. The cache uses reference identity, so the same instance hits
        // the same cache entry and we share the produced provider.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        var resolver = new MatchAllNamedAResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolver);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(c1, Is.SameAs(c2));
    }

    [Test]
    public void GetCredential_DifferentInstancesOfSameType_DoNotShareCacheEntry()
    {
        // Reference-identity keying: even two distinct instances of the SAME
        // resolver type don't share a cache entry. This protects against
        // state-bearing custom resolvers (e.g., MyResolver(secretsA) vs
        // MyResolver(secretsB)) at the cost of cross-host sharing for stateless
        // resolvers (acceptable — provider construction is cheap and the
        // resolver's own internal caches are typically static).
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1"
        });

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());

        Assert.That(c1, Is.Not.SameAs(c2));
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

    [Test]
    public void Cache_OverlappingChains_SameWinningInstance_Share()
    {
        // The cache key depends on (section, winning-resolver-instance), NOT
        // on the whole chain. Two calls with overlapping chains where the same
        // resolver instance wins must share the produced provider.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        var resolverA = new MatchAllNamedAResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential",
            resolverA, new MatchAllNamedBResolver());
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolverA);

        Assert.That(c1, Is.SameAs(c2));
    }

    [Test]
    public void Cache_NonMatchingResolverBeforeMatch_DoesNotPreventSharing()
    {
        // Even if a non-matching resolver appears earlier in the chain, the
        // caching is keyed on the resolver that produces the provider — so a
        // later call with just the matching resolver shares the cache entry.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        var nonMatching = new ScopedRecordingResolver("Other", "x");
        var matching = new MatchAllNamedAResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential",
            nonMatching, matching);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", matching);

        Assert.That(c1, Is.SameAs(c2));
    }

    // -------- Cache key behavior: comprehensive coverage --------

    [Test]
    public void Cache_SameInstance_SameSection_SharesProvider()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });
        var resolver = new MatchAllNamedAResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolver);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(c1, Is.SameAs(c2));
    }

    [Test]
    public void Cache_SameInstance_DifferentSections_ProducesDifferentProviders()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["A:Credential:CredentialSource"] = "Match",
            ["A:Credential:TenantId"] = "tenant-A",
            ["B:Credential:CredentialSource"] = "Match",
            ["B:Credential:TenantId"] = "tenant-B",
        });
        var resolver = new MatchAllNamedAResolver();

        AuthenticationTokenProvider? cA = config.GetCredential("A:Credential", resolver);
        AuthenticationTokenProvider? cB = config.GetCredential("B:Credential", resolver);

        Assert.That(cA, Is.Not.SameAs(cB));
    }

    [Test]
    public void Cache_DifferentInstancesOfSameType_DoNotShare()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());

        Assert.That(c1, Is.Not.SameAs(c2));
    }

    [Test]
    public void Cache_DifferentResolverTypes_DoNotShare()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", new MatchAllNamedAResolver());
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", new MatchAllNamedBResolver());

        Assert.That(((StubTokenProvider)c1!).Name, Is.EqualTo("A"));
        Assert.That(((StubTokenProvider)c2!).Name, Is.EqualTo("B"));
        Assert.That(c1, Is.Not.SameAs(c2));
    }

    [Test]
    public void Cache_HonorsResolverChainOrder_SameSetReorderedDoesNotLeak()
    {
        // Different chain ORDER with overlapping types: the FIRST match wins,
        // so [A,B] vs [B,A] could legitimately produce different providers.
        // Reference-identity fingerprinting incorporates instance order.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        var a = new MatchAllNamedAResolver();
        var b = new MatchAllNamedBResolver();

        AuthenticationTokenProvider? ab = config.GetCredential("TestClient:Credential", a, b);
        AuthenticationTokenProvider? ba = config.GetCredential("TestClient:Credential", b, a);

        Assert.That(((StubTokenProvider)ab!).Name, Is.EqualTo("A"));
        Assert.That(((StubTokenProvider)ba!).Name, Is.EqualTo("B"));
    }

    [Test]
    public void Cache_DisposableProvider_IsNotCached()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        var resolver = new DisposableProviderResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolver);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(c1, Is.Not.Null);
        Assert.That(c2, Is.Not.Null);
        Assert.That(c1, Is.Not.SameAs(c2),
            "Disposable providers must never be cached — a disposed cached instance handed back to a later caller would throw ObjectDisposedException.");
        Assert.That(resolver.CallCount, Is.EqualTo(2));
    }

    [Test]
    public void Cache_AsyncDisposableProvider_IsNotCached()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        var resolver = new AsyncDisposableProviderResolver();

        AuthenticationTokenProvider? c1 = config.GetCredential("TestClient:Credential", resolver);
        AuthenticationTokenProvider? c2 = config.GetCredential("TestClient:Credential", resolver);

        Assert.That(c1, Is.Not.SameAs(c2));
        Assert.That(resolver.CallCount, Is.EqualTo(2));
    }

    [Test]
    public void Cache_NoMatchingResolver_DoesNotPolluteCache()
    {
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Unknown",
        });
        var matching = new MatchAllNamedAResolver();
        var nonMatching = new ScopedRecordingResolver("Other", "x");

        AuthenticationTokenProvider? miss = config.GetCredential("TestClient:Credential", nonMatching);
        Assert.That(miss, Is.Null);

        // A subsequent call with a matching resolver must NOT see a stale null.
        AuthenticationTokenProvider? hit = config.GetCredential("TestClient:Credential", matching);
        Assert.That(hit, Is.Not.Null);
        Assert.That(((StubTokenProvider)hit!).Name, Is.EqualTo("A"));
    }

    // -------- DI: cache interaction with the auto-resolve path --------

    [Test]
    public void DI_TwoClientsSameSectionInOneHost_ShareCachedProvider()
    {
        // Within one host, AddCredentialResolver<T>() registers as singleton
        // (TryAddEnumerable). Two AddClient calls referencing the same
        // credential section therefore use the same resolver instance and hit
        // the same cache entry → shared provider.
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddClient<TestClient, TestClientSettings>("TestClient");
        builder.AddKeyedClient<TestClient, TestClientSettings>("alt", "TestClient");

        using IHost host = builder.Build();
        TestClient c1 = host.Services.GetRequiredService<TestClient>();
        TestClient c2 = host.Services.GetRequiredKeyedService<TestClient>("alt");

        Assert.That(c1.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(c1.Settings.CredentialProvider, Is.SameAs(c2.Settings.CredentialProvider));
    }

    [Test]
    public void DI_TwoClientsDifferentSections_GetDifferentProviders()
    {
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["A:Endpoint"] = "https://a.example.com",
            ["A:Credential:CredentialSource"] = "Match",
            ["A:Credential:TenantId"] = "tenant-A",
            ["B:Endpoint"] = "https://b.example.com",
            ["B:Credential:CredentialSource"] = "Match",
            ["B:Credential:TenantId"] = "tenant-B",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddKeyedClient<TestClient, TestClientSettings>("A", "A");
        builder.AddKeyedClient<TestClient, TestClientSettings>("B", "B");

        using IHost host = builder.Build();
        TestClient cA = host.Services.GetRequiredKeyedService<TestClient>("A");
        TestClient cB = host.Services.GetRequiredKeyedService<TestClient>("B");

        Assert.That(cA.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(cB.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(cA.Settings.CredentialProvider, Is.Not.SameAs(cB.Settings.CredentialProvider));
    }

    [Test]
    public void DI_TwoHostsWithIdenticalConfig_DoNotShare()
    {
        // Each host registers its own resolver instance via AddCredentialResolver.
        // Reference-identity keying means the two instances do NOT share cache
        // entries → each host gets its own provider. This is the property that
        // makes per-host disposal safe (one host's shutdown can't break the other).
        AuthenticationTokenProvider? p1 = BuildHostAndGetProvider();
        AuthenticationTokenProvider? p2 = BuildHostAndGetProvider();

        Assert.That(p1, Is.Not.Null);
        Assert.That(p2, Is.Not.Null);
        Assert.That(p1, Is.Not.SameAs(p2));

        static AuthenticationTokenProvider? BuildHostAndGetProvider()
        {
            var b = Host.CreateEmptyApplicationBuilder(null);
            b.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Endpoint"] = "https://example.com",
                ["TestClient:Credential:CredentialSource"] = "Match",
                ["TestClient:Credential:TenantId"] = "tenant-1",
            });
            b.AddCredentialResolver<MatchEverythingResolver>();
            b.AddClient<TestClient, TestClientSettings>("TestClient");
            using IHost h = b.Build();
            return h.Services.GetRequiredService<TestClient>().Settings.CredentialProvider;
        }
    }

    [Test]
    public void DI_AddCredentialResolverCalledMultipleTimes_StillSharesProvider()
    {
        // Idempotent registration → still one resolver instance → still shares.
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddClient<TestClient, TestClientSettings>("TestClient");
        builder.AddKeyedClient<TestClient, TestClientSettings>("alt", "TestClient");

        using IHost host = builder.Build();
        TestClient c1 = host.Services.GetRequiredService<TestClient>();
        TestClient c2 = host.Services.GetRequiredKeyedService<TestClient>("alt");

        Assert.That(c1.Settings.CredentialProvider, Is.SameAs(c2.Settings.CredentialProvider));
    }

    [Test]
    public void DI_ConfigureCredential_OneClientDiverges_OtherClientUnaffected()
    {
        // Two clients on the same section: one customizes the credential via
        // ConfigureCredential. They must NOT share a provider.
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "default",
        });

        builder.AddCredentialResolver<MatchEverythingResolver>();
        builder.AddClient<TestClient, TestClientSettings>("TestClient");
        builder.AddKeyedClient<TestClient, TestClientSettings>("custom", "TestClient")
               .ConfigureCredential(s => s["TenantId"] = "custom-tenant");

        using IHost host = builder.Build();
        TestClient defaultClient = host.Services.GetRequiredService<TestClient>();
        TestClient customClient = host.Services.GetRequiredKeyedService<TestClient>("custom");

        Assert.That(defaultClient.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(customClient.Settings.CredentialProvider, Is.Not.Null);
        Assert.That(defaultClient.Settings.CredentialProvider,
            Is.Not.SameAs(customClient.Settings.CredentialProvider));
    }

    [Test]
    public void DI_DisposableProvider_NotCached_NoCrossHostDisposalIssue()
    {
        // Regression guard for the multi-host disposal sharp edge:
        // host A produces a disposable provider, disposes; host B must get a
        // fresh provider, not the one host A's DI just disposed.
        var builderA = Host.CreateEmptyApplicationBuilder(null);
        builderA.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        builderA.AddCredentialResolver<DisposableProviderResolver>();
        builderA.AddClient<TestClient, TestClientSettings>("TestClient");

        AuthenticationTokenProvider? providerA;
        using (IHost hostA = builderA.Build())
        {
            providerA = hostA.Services.GetRequiredService<TestClient>().Settings.CredentialProvider;
        }

        var builderB = Host.CreateEmptyApplicationBuilder(null);
        builderB.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "Match",
        });
        builderB.AddCredentialResolver<DisposableProviderResolver>();
        builderB.AddClient<TestClient, TestClientSettings>("TestClient");

        using IHost hostB = builderB.Build();
        AuthenticationTokenProvider? providerB =
            hostB.Services.GetRequiredService<TestClient>().Settings.CredentialProvider;

        Assert.That(providerA, Is.Not.Null);
        Assert.That(providerB, Is.Not.Null);
        Assert.That(providerA, Is.Not.SameAs(providerB));
    }

    private sealed class MatchAllNamedAResolver : CredentialResolver
    {
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = new StubTokenProvider("A");
            return true;
        }
    }

    private sealed class MatchAllNamedBResolver : CredentialResolver
    {
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = new StubTokenProvider("B");
            return true;
        }
    }

    private sealed class MatchEverythingResolver : CredentialResolver
    {
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = new StubTokenProvider("auto");
            return true;
        }
    }

    private sealed class RecordingMatchAllResolver : CredentialResolver
    {
        public string? LastTenantId { get; private set; }
        public string? LastClientId { get; private set; }

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
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

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
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
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = null;
            return false;
        }
    }

    private sealed class OtherResolver : CredentialResolver
    {
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = null;
            return false;
        }
    }

    private sealed class ThrowingResolver : CredentialResolver
    {
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
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

    private sealed class DisposableStubTokenProvider : AuthenticationTokenProvider, IDisposable
    {
        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => null;
        public override AuthenticationToken GetToken(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
        public override Threading.Tasks.ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
        public void Dispose() { }
    }

    private sealed class AsyncDisposableStubTokenProvider : AuthenticationTokenProvider, IAsyncDisposable
    {
        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => null;
        public override AuthenticationToken GetToken(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
        public override Threading.Tasks.ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, Threading.CancellationToken cancellationToken) => default!;
        public Threading.Tasks.ValueTask DisposeAsync() => default;
    }

    private sealed class DisposableProviderResolver : CredentialResolver
    {
        public int CallCount { get; private set; }
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            CallCount++;
            provider = new DisposableStubTokenProvider();
            return true;
        }
    }

    private sealed class AsyncDisposableProviderResolver : CredentialResolver
    {
        public int CallCount { get; private set; }
        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            CallCount++;
            provider = new AsyncDisposableStubTokenProvider();
            return true;
        }
    }
}
