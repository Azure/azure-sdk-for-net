// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Context;

namespace Azure.AI.AgentServer.Core.Unit.Tests.Context;

[NonParallelizable]
public class FoundryProjectEndpointResolverTests
{
    [Test]
    public void TryResolveProjectEndpointFromEnvironment_WithMissingEnvironmentVariable_ReturnsFalse()
    {
        WithProjectEndpointEnvironmentVariable(
            value: null,
            action: () =>
            {
                var resolved = FoundryProjectEndpointResolver.TryResolveProjectEndpointFromEnvironment(
                    out var endpoint);

                Assert.That(resolved, Is.False);
                Assert.That(endpoint, Is.Null);
            });
    }

    [Test]
    public void TryResolveProjectEndpointFromEnvironment_WithInvalidEnvironmentVariable_ReturnsFalse()
    {
        WithProjectEndpointEnvironmentVariable(
            value: "not-a-valid-uri",
            action: () =>
            {
                var resolved = FoundryProjectEndpointResolver.TryResolveProjectEndpointFromEnvironment(
                    out var endpoint);

                Assert.That(resolved, Is.False);
                Assert.That(endpoint, Is.Null);
            });
    }

    [Test]
    public void TryResolveProjectEndpointFromEnvironment_WithValidEnvironmentVariable_ReturnsTrue()
    {
        const string endpointText = "https://contoso.services.ai.azure.com/api/projects/demo";
        WithProjectEndpointEnvironmentVariable(
            value: endpointText,
            action: () =>
            {
                var resolved = FoundryProjectEndpointResolver.TryResolveProjectEndpointFromEnvironment(
                    out var endpoint);

                Assert.That(resolved, Is.True);
                Assert.That(endpoint, Is.Not.Null);
                Assert.That(endpoint!.AbsoluteUri, Is.EqualTo(endpointText));
            });
    }

    [Test]
    public void ResolveProjectEndpointFromEnvironment_WithMissingEnvironmentVariable_Throws()
    {
        WithProjectEndpointEnvironmentVariable(
            value: null,
            action: () =>
            {
                Assert.Throws<InvalidOperationException>(
                    () => FoundryProjectEndpointResolver.ResolveProjectEndpointFromEnvironment());
            });
    }

    [Test]
    public void ResolveProjectEndpointFromEnvironment_WithValidEnvironmentVariable_ReturnsEndpoint()
    {
        const string endpointText = "https://contoso.services.ai.azure.com/api/projects/demo";
        WithProjectEndpointEnvironmentVariable(
            value: endpointText,
            action: () =>
            {
                var endpoint = FoundryProjectEndpointResolver.ResolveProjectEndpointFromEnvironment();
                Assert.That(endpoint.AbsoluteUri, Is.EqualTo(endpointText));
            });
    }

    private static void WithProjectEndpointEnvironmentVariable(string? value, Action action)
    {
        var variableName = FoundryProjectEndpointResolver.ProjectEndpointEnvironmentVariableName;
        var original = Environment.GetEnvironmentVariable(variableName);
        try
        {
            Environment.SetEnvironmentVariable(variableName, value);
            action();
        }
        finally
        {
            Environment.SetEnvironmentVariable(variableName, original);
        }
    }
}
