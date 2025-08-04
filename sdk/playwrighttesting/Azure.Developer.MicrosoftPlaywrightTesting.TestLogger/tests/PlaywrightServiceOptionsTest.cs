// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using System;
using System.Runtime.InteropServices;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlaywrightServiceOptionsTest
{
    [Test]
    public void Constructor_ShouldInitializeProperties()
    {
        var os = OSPlatform.Linux;
        var runId = "test-run-id";
        var exposeNetwork = "true";
        var serviceAuth = ServiceAuthType.EntraId;
        var useCloudHostedBrowsers = "true";
        var azureTokenCredentialType = AzureTokenCredentialType.ManagedIdentityCredential;
        var managedIdentityClientId = "test-client-id";

        var settings = new PlaywrightServiceOptions(
            os, runId, exposeNetwork, serviceAuth, useCloudHostedBrowsers, azureTokenCredentialType, managedIdentityClientId);

        Assert.Multiple(() =>
        {
            Assert.That(settings.Os, Is.EqualTo(os));
            Assert.That(settings.RunId, Is.EqualTo(runId));
            Assert.That(settings.ExposeNetwork, Is.EqualTo(exposeNetwork));
            Assert.That(settings.ServiceAuth, Is.EqualTo(serviceAuth));
            Assert.That(settings.UseCloudHostedBrowsers, Is.True);
            Assert.That(settings.AzureTokenCredential, Is.InstanceOf<ManagedIdentityCredential>());
        });
    }

    [Test]
    public void Constructor_ShouldUseDefaultValues()
    {
        var settings = new PlaywrightServiceOptions();
        Assert.Multiple(() =>
        {
            Assert.That(settings.Os, Is.Null);
            Assert.That(settings.RunId, Is.Null);
            Assert.That(settings.ExposeNetwork, Is.Null);
            Assert.That(settings.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
            Assert.That(settings.UseCloudHostedBrowsers, Is.True);
            Assert.That(settings.AzureTokenCredential, Is.InstanceOf<DefaultAzureCredential>());
        });
    }

    [Test]
    public void Validate_ShouldThrowExceptionForInvalidOs()
    {
        Exception? ex = Assert.Throws<Exception>(() => new PlaywrightServiceOptions(os: OSPlatform.Create("invalid")));
        Assert.That(ex!.Message, Does.Contain("Invalid value for Os"));
    }

    [Test]
    public void Validate_ShouldThrowExceptionForInvalidDefaultAuth()
    {
        var invalidAuth = "InvalidAuth";
        Exception? ex = Assert.Throws<Exception>(() => new PlaywrightServiceOptions(serviceAuth: invalidAuth));
        Assert.That(ex!.Message, Does.Contain("Invalid value for ServiceAuth"));
    }

    [TestCase("ManagedIdentityCredential", typeof(ManagedIdentityCredential))]
    [TestCase("WorkloadIdentityCredential", typeof(WorkloadIdentityCredential))]
    [TestCase("EnvironmentCredential", typeof(EnvironmentCredential))]
    [TestCase("AzureCliCredential", typeof(AzureCliCredential))]
    [TestCase("AzurePowerShellCredential", typeof(AzurePowerShellCredential))]
    [TestCase("AzureDeveloperCliCredential", typeof(AzureDeveloperCliCredential))]
    [TestCase("InteractiveBrowserCredential", typeof(InteractiveBrowserCredential))]
#pragma warning disable CS0618 // Type or member is obsolete
    [TestCase("SharedTokenCacheCredential", typeof(SharedTokenCacheCredential))]
#pragma warning restore CS0618 // Type or member is obsolete
    [TestCase("VisualStudioCredential", typeof(VisualStudioCredential))]
    [TestCase("DefaultAzureCredential", typeof(DefaultAzureCredential))]
    [TestCase("", typeof(DefaultAzureCredential))]
    [TestCase(null, typeof(DefaultAzureCredential))]
    public void GetTokenCredential_ShouldReturnCorrectCredential(string? credentialType, Type expectedType)
    {
        var settings = new PlaywrightServiceOptions(azureTokenCredentialType: credentialType);
        Assert.That(settings.AzureTokenCredential, Is.InstanceOf(expectedType));
    }
}
