// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class ClientSettingsCredentialProviderTests
{
    [SetUp]
    public void SetUp()
    {
        // Cross-test cache pollution would let a prior call's resolver leak
        // its provider into a later call; clear the global cache between tests.
        Type cacheType = typeof(AuthenticationTokenProvider).Assembly
            .GetType("System.ClientModel.Primitives.CredentialCache", throwOnError: true)!;
        var field = cacheType.GetField("s_cache", BindingFlags.NonPublic | BindingFlags.Static)!;
        var dict = (System.Collections.IDictionary)field.GetValue(null)!;
        dict.Clear();

        CountingResolver.ResetCount();
        ThrowingResolver.ResetCount();
    }

    [Test]
    public void Setter_OnLegacyCredentialProvider_PropagatesToCredential()
    {
        TestClientSettings settings = new();
        settings.Bind(BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
        }).GetSection("TestClient"));

        var provider = new StubTokenProvider("legacy");
        settings.CredentialProvider = provider;

        Assert.That(settings.Credential, Is.Not.Null);
        Assert.That(settings.Credential!.CredentialProvider, Is.SameAs(provider),
            "Setting ClientSettings.CredentialProvider must propagate to Credential.CredentialProvider.");
    }

    [Test]
    public void Reading_LegacyCredentialProvider_ReflectsNewLocation_WhenNewIsSet()
    {
        TestClientSettings settings = new();
        settings.Bind(BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
        }).GetSection("TestClient"));

        var provider = new StubTokenProvider("new-location");
        // Direct mutation of the new home — the legacy property reads through.
        settings.Credential!.CredentialProvider = provider;

        Assert.That(settings.CredentialProvider, Is.SameAs(provider),
            "ClientSettings.CredentialProvider getter must reflect Credential.CredentialProvider when set.");
    }

    [Test]
    public void Setting_Credential_WithItsOwnProvider_ReflectedThroughLegacyProperty()
    {
        TestClientSettings settings = new();
        var provider = new StubTokenProvider("on-credential");

        IConfigurationSection section = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
        }).GetSection("TestClient:Credential");

        settings.Credential = new CredentialSettings(section)
        {
            CredentialProvider = provider,
        };

        Assert.That(settings.CredentialProvider, Is.SameAs(provider));
    }

    [Test]
    public void DI_AddClient_WhenConfigureSettingsAssignsLegacyCredentialProvider_DoesNotInvokeResolver()
    {
        // CreateSettings guards `if (settings.CredentialProvider is null)` to
        // skip the resolver pipeline when configureSettings already supplied
        // a provider. The unified getter must observe the dual-write so a
        // legacy assignment short-circuits the resolver — protecting against
        // wasteful resolver work and against null-erasing the user's value.
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
        });

        builder.AddCredentialResolver<CountingResolver>();
        var supplied = new StubTokenProvider("by-configure");
        builder.AddClient<TestClient, TestClientSettings>(
            "TestClient",
            settings => settings.CredentialProvider = supplied);

        using IHost host = builder.Build();
        TestClient client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.CredentialProvider, Is.SameAs(supplied));
        Assert.That(CountingResolver.CallCount, Is.EqualTo(0),
            "Resolver must not run when configureSettings already supplied a provider via the legacy property.");
    }

    [Test]
    public void DI_AddClient_WhenConfigureSettingsAssignsCredentialProviderOnNewLocation_DoesNotInvokeResolver()
    {
        // Regression: the DI guard `if (settings.CredentialProvider is null)`
        // must observe a provider placed by configureSettings into the new
        // Credential.CredentialProvider location. Without the unified
        // getter, the guard would see null and re-run the resolver pipeline,
        // potentially erasing the user's value with a null result.
        var builder = Host.CreateEmptyApplicationBuilder(null);
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
        });

        // A throwing resolver makes the test fail loudly if the guard is
        // bypassed and the resolver runs. (Counting is also asserted.)
        builder.AddCredentialResolver<ThrowingResolver>();
        var supplied = new StubTokenProvider("by-configure-on-credential");
        builder.AddClient<TestClient, TestClientSettings>(
            "TestClient",
            settings => settings.Credential!.CredentialProvider = supplied);

        using IHost host = builder.Build();
        TestClient client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Credential!.CredentialProvider, Is.SameAs(supplied));
        Assert.That(client.Settings.CredentialProvider, Is.SameAs(supplied),
            "Unified getter must surface the new-location value through the legacy property.");
        Assert.That(ThrowingResolver.CallCount, Is.EqualTo(0),
            "Resolver must not run when configureSettings supplied a provider on Credential.CredentialProvider.");
    }

    [Test]
    public void GetClientSettings_WithResolvers_PopulatesBothLocations()
    {
        // Top-down integration: a matching resolver claims the credential
        // section, GetClientSettings stores the provider, and the dual-write
        // surfaces it on both Credential.CredentialProvider and the legacy
        // ClientSettings.CredentialProvider — same instance from both reads.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
            ["TestClient:Credential:TenantId"] = "tenant-1",
        });

        var resolver = new MatchSourceResolver("TokenCredential", "matched");

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>(
            "TestClient",
            new[] { (CredentialResolver)resolver },
            _ => { });

        Assert.That(settings.CredentialProvider, Is.Not.Null);
        Assert.That(settings.Credential, Is.Not.Null);
        Assert.That(settings.Credential!.CredentialProvider, Is.SameAs(settings.CredentialProvider),
            "Both locations must surface the same instance after resolution completes.");
    }

    private static IConfigurationRoot BuildConfig(Dictionary<string, string?> values)
    {
        return new ConfigurationBuilder().AddInMemoryCollection(values).Build();
    }

    private sealed class MatchSourceResolver : CredentialResolver
    {
        private readonly string _matchSource;
        private readonly string _name;

        public MatchSourceResolver(string matchSource, string name)
        {
            _matchSource = matchSource;
            _name = name;
        }

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            string? source = credentialSection["CredentialSource"];
            if (string.Equals(source, _matchSource, StringComparison.OrdinalIgnoreCase))
            {
                provider = new StubTokenProvider(_name);
                return true;
            }
            provider = null;
            return false;
        }
    }

    private sealed class CountingResolver : CredentialResolver
    {
        public static int CallCount;
        public static void ResetCount() => Interlocked.Exchange(ref CallCount, 0);

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            Interlocked.Increment(ref CallCount);
            provider = null;
            return false;
        }
    }

    private sealed class ThrowingResolver : CredentialResolver
    {
        public static int CallCount;
        public static void ResetCount() => Interlocked.Exchange(ref CallCount, 0);

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            Interlocked.Increment(ref CallCount);
            throw new InvalidOperationException(
                "Resolver should not run — DI guard must observe the value placed on Credential.CredentialProvider.");
        }
    }

    private sealed class StubTokenProvider : AuthenticationTokenProvider
    {
        public string Name { get; }
        public StubTokenProvider(string name) => Name = name;

        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => null;
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken) => default!;
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken) => default!;
    }
}
