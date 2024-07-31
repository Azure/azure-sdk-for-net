﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Developer.MicrosoftPlaywrightTesting;
using System;

namespace Azure.Developer.MicrosoftPlaywrightTesting.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlaywrightServiceSettingsTest
{
    [Test]
    public void Constructor_ShouldInitializeProperties()
    {
        var os = ServiceOs.LINUX;
        var runId = "test-run-id";
        var exposeNetwork = "true";
        var defaultAuth = ServiceAuth.ENTRA;
        var useCloudHostedBrowsers = "true";
        var azureTokenCredentialType = AzureTokenCredentialType.ManagedIdentityCredential;
        var managedIdentityClientId = "test-client-id";

        var settings = new PlaywrightServiceSettings(
            os, runId, exposeNetwork, defaultAuth, useCloudHostedBrowsers, azureTokenCredentialType, managedIdentityClientId);

        Assert.Multiple(() =>
        {
            Assert.That(settings.Os, Is.EqualTo(os));
            Assert.That(settings.RunId, Is.EqualTo(runId));
            Assert.That(settings.ExposeNetwork, Is.EqualTo(exposeNetwork));
            Assert.That(settings.DefaultAuth, Is.EqualTo(defaultAuth));
            Assert.That(settings.UseCloudHostedBrowsers, Is.True);
            Assert.That(settings.AzureTokenCredential, Is.InstanceOf<ManagedIdentityCredential>());
        });
    }

    [Test]
    public void Constructor_ShouldUseDefaultValues()
    {
        var settings = new PlaywrightServiceSettings();
        Assert.Multiple(() =>
        {
            Assert.That(settings.Os, Is.Null);
            Assert.That(settings.RunId, Is.Null);
            Assert.That(settings.ExposeNetwork, Is.Null);
            Assert.That(settings.DefaultAuth, Is.EqualTo(ServiceAuth.ENTRA));
            Assert.That(settings.UseCloudHostedBrowsers, Is.True);
            Assert.That(settings.AzureTokenCredential, Is.InstanceOf<DefaultAzureCredential>());
        });
    }

    [Test]
    public void Validate_ShouldThrowExceptionForInvalidOs()
    {
        var invalidOs = "InvalidOS";
        var ex = Assert.Throws<Exception>(() => new PlaywrightServiceSettings(os: invalidOs));
        Assert.That(ex!.Message, Does.Contain("Invalid value for Os"));
    }

    [Test]
    public void Validate_ShouldThrowExceptionForInvalidDefaultAuth()
    {
        var invalidAuth = "InvalidAuth";
        var ex = Assert.Throws<Exception>(() => new PlaywrightServiceSettings(defaultAuth: invalidAuth));
        Assert.That(ex!.Message, Does.Contain("Invalid value for DefaultAuth"));
    }

    [TestCase("ManagedIdentityCredential", typeof(ManagedIdentityCredential))]
    [TestCase("WorkloadIdentityCredential", typeof(WorkloadIdentityCredential))]
    [TestCase("EnvironmentCredential", typeof(EnvironmentCredential))]
    [TestCase("AzureCliCredential", typeof(AzureCliCredential))]
    [TestCase("AzurePowerShellCredential", typeof(AzurePowerShellCredential))]
    [TestCase("AzureDeveloperCliCredential", typeof(AzureDeveloperCliCredential))]
    [TestCase("InteractiveBrowserCredential", typeof(InteractiveBrowserCredential))]
    [TestCase("SharedTokenCacheCredential", typeof(SharedTokenCacheCredential))]
    [TestCase("VisualStudioCredential", typeof(VisualStudioCredential))]
    [TestCase("VisualStudioCodeCredential", typeof(VisualStudioCodeCredential))]
    [TestCase("DefaultAzureCredential", typeof(DefaultAzureCredential))]
    [TestCase("", typeof(DefaultAzureCredential))]
    [TestCase(null, typeof(DefaultAzureCredential))]
    public void GetTokenCredential_ShouldReturnCorrectCredential(string? credentialType, Type expectedType)
    {
        var settings = new PlaywrightServiceSettings(azureTokenCredentialType: credentialType);
        Assert.That(settings.AzureTokenCredential, Is.InstanceOf(expectedType));
    }
}
