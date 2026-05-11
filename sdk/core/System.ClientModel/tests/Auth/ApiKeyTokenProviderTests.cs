// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Auth;

public class ApiKeyTokenProviderTests
{
    [Test]
    public void Ctor_NullKey_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new ApiKeyTokenProvider(null!));
    }

    [Test]
    public void Ctor_EmptyKey_Throws()
    {
        Assert.Throws<ArgumentException>(() => _ = new ApiKeyTokenProvider(string.Empty));
    }

    [Test]
    public void GetToken_ReturnsConfiguredKeyAsTokenValue()
    {
        var provider = new ApiKeyTokenProvider("secret-key");

        AuthenticationToken token = provider.GetToken(BuildOptions("scope-a"), CancellationToken.None);

        Assert.That(token.TokenValue, Is.EqualTo("secret-key"));
    }

    [Test]
    public async Task GetTokenAsync_ReturnsSameTokenAsGetToken()
    {
        var provider = new ApiKeyTokenProvider("secret-key");

        AuthenticationToken sync = provider.GetToken(BuildOptions("scope-a"), CancellationToken.None);
        AuthenticationToken async = await provider.GetTokenAsync(BuildOptions("scope-a"), CancellationToken.None);

        Assert.That(async.TokenValue, Is.EqualTo(sync.TokenValue));
        Assert.That(async.TokenType, Is.EqualTo(sync.TokenType));
        Assert.That(async.ExpiresOn, Is.EqualTo(sync.ExpiresOn));
        Assert.That(async.RefreshOn, Is.EqualTo(sync.RefreshOn));
    }

    [Test]
    public void GetToken_IgnoresScope_AnyScopeProducesSameValue()
    {
        var provider = new ApiKeyTokenProvider("secret-key");

        AuthenticationToken a = provider.GetToken(BuildOptions("scope-a"), CancellationToken.None);
        AuthenticationToken b = provider.GetToken(BuildOptions("scope-b", "scope-c"), CancellationToken.None);

        Assert.That(a.TokenValue, Is.EqualTo("secret-key"));
        Assert.That(b.TokenValue, Is.EqualTo("secret-key"));
    }

    [Test]
    public void GetToken_NoExpiry()
    {
        var provider = new ApiKeyTokenProvider("secret-key");

        AuthenticationToken token = provider.GetToken(BuildOptions("scope-a"), CancellationToken.None);

        Assert.That(token.ExpiresOn, Is.EqualTo(DateTimeOffset.MaxValue));
        Assert.That(token.RefreshOn, Is.Null);
    }

    [Test]
    public void GetToken_SnapshotSemantics_KeyCapturedAtConstruction()
    {
        // Snapshot semantics: the provider keeps no reference to caller storage,
        // so subsequent mutations of the source string can't influence the
        // returned token value. (Strings are immutable in .NET so this is true
        // by construction; the test pins the contract for future maintainers.)
        string source = "key-1";
        var provider = new ApiKeyTokenProvider(source);
        source = "key-2";

        AuthenticationToken token = provider.GetToken(BuildOptions("scope-a"), CancellationToken.None);

        Assert.That(token.TokenValue, Is.EqualTo("key-1"));
    }

    [Test]
    public void CreateTokenOptions_ReturnsRoundTrippableOptions()
    {
        var provider = new ApiKeyTokenProvider("secret-key");
        var properties = new Dictionary<string, object>
        {
            { GetTokenOptions.ScopesPropertyName, new[] { "scope-a" } }
        };

        GetTokenOptions? options = provider.CreateTokenOptions(properties);

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Properties[GetTokenOptions.ScopesPropertyName], Is.EqualTo(new[] { "scope-a" }));
    }

    [Test]
    public void CreateTokenOptions_NullProperties_ReturnsNull()
    {
        var provider = new ApiKeyTokenProvider("secret-key");

        GetTokenOptions? options = provider.CreateTokenOptions(null!);

        Assert.That(options, Is.Null);
    }

    private static GetTokenOptions BuildOptions(params string[] scopes)
        => new(new Dictionary<string, object>
        {
            { GetTokenOptions.ScopesPropertyName, scopes }
        });
}
