// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

[TestFixture]
public class ResolveStorageBaseUriTests
{
    private static Uri Resolve(string? endpoint, bool isDevelopment)
        => ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri(
            endpoint is null ? null : new Uri(endpoint, UriKind.Absolute),
            isDevelopment);

    [Test]
    public void Throws_WhenEndpointNotSet()
    {
        var ex = Assert.Throws<InvalidOperationException>(
            () => Resolve(endpoint: null, isDevelopment: false));
        Assert.That(ex!.Message, Does.Contain("endpoint is required"));
    }

    [Test]
    public void Throws_WhenHttpUsedInProduction()
    {
        var ex = Assert.Throws<InvalidOperationException>(
            () => Resolve("http://example.com", isDevelopment: false));
        Assert.That(ex!.Message, Does.Contain("HTTPS"));
    }

    [Test]
    public void AllowsHttp_WhenDevelopment()
    {
        var uri = Resolve("http://localhost:5000", isDevelopment: true);

        Assert.That(uri.Scheme, Is.EqualTo("http"));
        Assert.That(uri.ToString(), Is.EqualTo("http://localhost:5000/storage/"));
    }

    [Test]
    public void AllowsHttp_WithPath_WhenDevelopment()
    {
        var uri = Resolve("http://localhost:5000/my-project", isDevelopment: true);

        Assert.That(uri.Scheme, Is.EqualTo("http"));
        Assert.That(uri.ToString(), Is.EqualTo("http://localhost:5000/my-project/storage/"));
    }

    [Test]
    public void AllowsHttps_InProduction()
    {
        var uri = Resolve("https://example.com", isDevelopment: false);

        Assert.That(uri.Scheme, Is.EqualTo("https"));
        Assert.That(uri.ToString(), Is.EqualTo("https://example.com/storage/"));
    }

    [Test]
    public void AllowsHttps_InDevelopment()
    {
        var uri = Resolve("https://localhost:5001", isDevelopment: true);

        Assert.That(uri.Scheme, Is.EqualTo("https"));
        Assert.That(uri.ToString(), Is.EqualTo("https://localhost:5001/storage/"));
    }

    [Test]
    public void AppendsStoragePath_StrippingTrailingSlash()
    {
        var uri = Resolve("https://example.com/project/", isDevelopment: false);

        Assert.That(uri.ToString(), Is.EqualTo("https://example.com/project/storage/"));
    }
}
