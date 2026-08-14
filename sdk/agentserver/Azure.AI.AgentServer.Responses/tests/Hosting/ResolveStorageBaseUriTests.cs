// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

[TestFixture]
public class ResolveStorageBaseUriTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void Throws_WhenEndpointNotSet()
    {
        FoundryEnvironment.Reload();

        var ex = Assert.Throws<InvalidOperationException>(
            () => ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri());
        Assert.That(ex!.Message, Does.Contain("ProjectEndpoint is required"));
    }

    [Test]
    public void Throws_WhenEndpointIsInvalidUri()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "not a uri");
        FoundryEnvironment.Reload();

        var ex = Assert.Throws<InvalidOperationException>(
            () => ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri());
        Assert.That(ex!.Message, Does.Contain("invalid absolute URI"));
    }

    [Test]
    public void Throws_WhenHttpUsedInProduction()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "http://example.com");
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
        FoundryEnvironment.Reload();

        var ex = Assert.Throws<InvalidOperationException>(
            () => ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri());
        Assert.That(ex!.Message, Does.Contain("HTTPS"));
    }

    [Test]
    public void Throws_WhenHttpUsedAndNoEnvironmentSet()
    {
        // No ASPNETCORE_ENVIRONMENT means not-development (default is production-like)
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "http://example.com");
        FoundryEnvironment.Reload();

        Assert.Throws<InvalidOperationException>(
            () => ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri());
    }

    [Test]
    public void AllowsHttp_WhenAspNetCoreEnvironmentIsDevelopment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "http://localhost:5000");
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        FoundryEnvironment.Reload();

        var uri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri();

        Assert.That(uri.Scheme, Is.EqualTo("http"));
        Assert.That(uri.ToString(), Is.EqualTo("http://localhost:5000/storage/"));
    }

    [Test]
    public void AllowsHttp_WhenDotNetEnvironmentIsDevelopment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "http://localhost:5000/my-project");
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");
        FoundryEnvironment.Reload();

        var uri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri();

        Assert.That(uri.Scheme, Is.EqualTo("http"));
        Assert.That(uri.ToString(), Is.EqualTo("http://localhost:5000/my-project/storage/"));
    }

    [Test]
    public void AllowsHttps_InProduction()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com");
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
        FoundryEnvironment.Reload();

        var uri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri();

        Assert.That(uri.Scheme, Is.EqualTo("https"));
        Assert.That(uri.ToString(), Is.EqualTo("https://example.com/storage/"));
    }

    [Test]
    public void AllowsHttps_InDevelopment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://localhost:5001");
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        FoundryEnvironment.Reload();

        var uri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri();

        Assert.That(uri.Scheme, Is.EqualTo("https"));
        Assert.That(uri.ToString(), Is.EqualTo("https://localhost:5001/storage/"));
    }

    [Test]
    public void AppendsStoragePath_StrippingTrailingSlash()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com/project/");
        FoundryEnvironment.Reload();

        var uri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri();

        Assert.That(uri.ToString(), Is.EqualTo("https://example.com/project/storage/"));
    }
}
