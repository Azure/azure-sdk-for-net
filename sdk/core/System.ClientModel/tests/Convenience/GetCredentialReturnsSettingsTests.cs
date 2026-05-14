// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

// Companion suite to CredentialResolverTests focused on contracts that are
// specific to the new GetCredential(...) -> CredentialSettings? shape:
//   - Bound metadata (Key, CredentialSource, AdditionalProperties, indexer)
//     surfaces on the returned settings even when no resolver claims the
//     section.
//   - Overrides supplied via the (resolvers, configureOverrides) overload
//     are reflected in the bound metadata of the returned settings (as a
//     deliberate asymmetry with GetClientSettings<T>, which binds metadata
//     from the original section).
//   - Missing-section vs. no-resolver-match distinction.
public class GetCredentialReturnsSettingsTests
{
    [SetUp]
    public void SetUp()
    {
        Type cacheType = typeof(AuthenticationTokenProvider).Assembly
            .GetType("System.ClientModel.Primitives.CredentialCache", throwOnError: true)!;
        var field = cacheType.GetField("s_cache", BindingFlags.NonPublic | BindingFlags.Static)!;
        var dict = (System.Collections.IDictionary)field.GetValue(null)!;
        dict.Clear();
    }

    [Test]
    public void GetCredential_MissingSection_WithOverridesAttemptingToCreateCredential_ReturnsNull()
    {
        // Pin the early-return contract: when the named section does not exist
        // in the underlying configuration, GetCredential returns null even if
        // the override callback would have populated values. This matches
        // CredentialResolverEngine.Resolve semantics.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>());

        CredentialSettings? settings = config.GetCredential(
            "TestClient:Credential",
            new[] { new MatchAllResolver("anything") },
            section =>
            {
                section["CredentialSource"] = "ApiKey";
                section["Key"] = "would-be-key";
            });

        Assert.That(settings, Is.Null);
    }

    [Test]
    public void GetCredential_ApiKeyAlias_NormalizesCredentialSourceCasing()
    {
        // Both "ApiKey" and "ApiKeyCredential" (any casing) normalize to
        // "apikeycredential" so callers can match a single canonical value.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "ApiKeyCredential",
            ["TestClient:Credential:Key"] = "alias-secret",
        });

        CredentialSettings? settings = config.GetCredential("TestClient:Credential");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings!.CredentialSource, Is.EqualTo("apikeycredential"));
        Assert.That(settings.Key, Is.EqualTo("alias-secret"));
    }

    [Test]
    public void GetCredential_OverridesAreAppliedBeforeResolverSeesSection()
    {
        // Pre-resolve overlay: the resolver receives a section with the
        // overrides applied (overlaid TenantId + injected ClientId), not
        // the original.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "Match",
            ["TestClient:Credential:TenantId"] = "original-tenant",
        });

        var resolver = new MatchSourceResolver("Match", "p");

        config.GetCredential(
            "TestClient:Credential",
            new[] { (CredentialResolver)resolver },
            section =>
            {
                section["TenantId"] = "override-tenant";
                section["ClientId"] = "added-client";
            });

        Assert.That(resolver.LastSection, Is.Not.Null);
        Assert.That(resolver.LastSection!["TenantId"], Is.EqualTo("override-tenant"));
        Assert.That(resolver.LastSection!["ClientId"], Is.EqualTo("added-client"));
    }

    [Test]
    public void GetCredential_OverridesReflectedInReturnedSettings_KeyAndIndexer()
    {
        // The returned CredentialSettings is constructed from the post-overlay
        // merged section, so Key and the indexer reflect overrides. This is
        // the asymmetry with GetClientSettings<T> below.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "ApiKey",
            ["TestClient:Credential:Key"] = "config-key",
            ["TestClient:Credential:Region"] = "us-east-1",
        });

        CredentialSettings? settings = config.GetCredential(
            "TestClient:Credential",
            Array.Empty<CredentialResolver>(),
            section =>
            {
                section["Key"] = "overridden-key";
                section["Region"] = "us-west-2";
            });

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings!.Key, Is.EqualTo("overridden-key"));
        Assert.That(settings["Region"], Is.EqualTo("us-west-2"));
    }

    [Test]
    public void GetCredential_OverridesRemovingCredentialSourceAndKey_StillReturnsSettings()
    {
        // Even when overrides null out CredentialSource and Key, the section
        // still exists, so a CredentialSettings is returned. CredentialProvider
        // is null (no resolver claims a section without a CredentialSource)
        // and the bound metadata reflects the overlay.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "ApiKey",
            ["TestClient:Credential:Key"] = "config-key",
        });

        CredentialSettings? settings = config.GetCredential(
            "TestClient:Credential",
            Array.Empty<CredentialResolver>(),
            section =>
            {
                section["CredentialSource"] = null;
                section["Key"] = null;
            });

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings!.CredentialProvider, Is.Null);
        Assert.That(settings.Key, Is.Null);
        Assert.That(settings.CredentialSource, Is.Null);
    }

    [Test]
    public void GetCredential_Indexer_ReadsArbitraryProperties()
    {
        // Library authors can extend the credential schema with custom keys
        // and read them via the indexer without exposing the underlying
        // IConfigurationSection.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
            ["TestClient:Credential:Region"] = "westus2",
            ["TestClient:Credential:Audience:Primary"] = "https://primary.example/.default",
        });

        CredentialSettings? settings = config.GetCredential("TestClient:Credential");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings!["Region"], Is.EqualTo("westus2"));
        Assert.That(settings["Audience:Primary"], Is.EqualTo("https://primary.example/.default"));
    }

    [Test]
    public void GetCredential_AdditionalProperties_BoundFromSection()
    {
        // AdditionalProperties bound to the Credential:AdditionalProperties
        // subsection is exposed on the returned CredentialSettings so callers
        // can read scopes / extra metadata without re-reading IConfiguration.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Credential:CredentialSource"] = "TokenCredential",
            ["TestClient:Credential:AdditionalProperties:Scope"] = "https://example.com/.default",
            ["TestClient:Credential:AdditionalProperties:TenantId"] = "tenant-1",
        });

        CredentialSettings? settings = config.GetCredential("TestClient:Credential");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings!.AdditionalProperties, Is.Not.Null);
        Assert.That(settings.AdditionalProperties!["Scope"], Is.EqualTo("https://example.com/.default"));
        Assert.That(settings.AdditionalProperties!["TenantId"], Is.EqualTo("tenant-1"));
    }

    [Test]
    public void GetCredential_AsymmetryWithGetClientSettings_OverridesReflectedHereButNotThere()
    {
        // GetClientSettings<T> binds metadata from the original section and
        // only feeds overlay values to the resolver pipeline; the returned
        // Credential.Key reflects the original section. GetCredential, by
        // contrast, constructs the returned CredentialSettings from the
        // post-overlay merged section so the overlay is visible. Pin both
        // behaviors here so neither contract drifts silently.
        IConfigurationRoot config = BuildConfig(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Credential:CredentialSource"] = "ApiKey",
            ["TestClient:Credential:Key"] = "original-key",
        });

        TestClientSettings clientSettings = config.GetClientSettings<TestClientSettings>(
            "TestClient",
            Array.Empty<CredentialResolver>(),
            section => section["Key"] = "overlay-key");

        CredentialSettings? credentialSettings = config.GetCredential(
            "TestClient:Credential",
            Array.Empty<CredentialResolver>(),
            section => section["Key"] = "overlay-key");

        Assert.That(clientSettings.Credential, Is.Not.Null);
        Assert.That(clientSettings.Credential!.Key, Is.EqualTo("original-key"),
            "GetClientSettings<T> binds Key from the original section — the overlay is not reflected here.");

        Assert.That(credentialSettings, Is.Not.Null);
        Assert.That(credentialSettings!.Key, Is.EqualTo("overlay-key"),
            "GetCredential binds Key from the post-overlay merged section.");
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

        public IConfigurationSection? LastSection { get; private set; }

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            LastSection = credentialSection;
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

    private sealed class MatchAllResolver : CredentialResolver
    {
        private readonly string _name;
        public MatchAllResolver(string name) => _name = name;

        public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            provider = new StubTokenProvider(_name);
            return true;
        }
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
