// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class ConfigurationExtensionsTests
{
    [Test]
    public void GetClientSettings_CanLoadBasicProperties()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://example.com",
            ["TestClient:Timeout"] = "00:01:30",
            ["TestClient:CustomProperty"] = "CustomValue"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://example.com")));
        Assert.That(settings.Timeout, Is.EqualTo(TimeSpan.FromSeconds(90)));
        Assert.That(settings.CustomProperty, Is.EqualTo("CustomValue"));
    }

    [Test]
    public void GetClientSettings_CanLoadOptionsProperties()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Options:NetworkTimeout"] = "00:02:00",
            ["TestClient:Options:EnableDistributedTracing"] = "false"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.NetworkTimeout, Is.EqualTo(TimeSpan.FromMinutes(2)));
        Assert.That(settings.Options.EnableDistributedTracing, Is.False);
    }

    [Test]
    public void GetClientSettings_CanLoadCustomOptionsProperties()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Options:ApiVersion"] = "2024-01-01"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.ApiVersion, Is.EqualTo("2024-01-01"));
    }

    [Test]
    public void GetClientSettings_CanLoadClientLoggingOptions()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Options:ClientLoggingOptions:EnableLogging"] = "true",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageLogging"] = "false",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageContentLogging"] = "true",
            ["TestClient:Options:ClientLoggingOptions:MessageContentSizeLimit"] = "8192"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.ClientLoggingOptions, Is.Not.Null);
        Assert.That(settings.Options.ClientLoggingOptions!.EnableLogging, Is.True);
        Assert.That(settings.Options.ClientLoggingOptions.EnableMessageLogging, Is.False);
        Assert.That(settings.Options.ClientLoggingOptions.EnableMessageContentLogging, Is.True);
        Assert.That(settings.Options.ClientLoggingOptions.MessageContentSizeLimit, Is.EqualTo(8192));
    }

    [Test]
    public void GetClientSettings_CanLoadAllPropertiesTogether()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Timeout"] = "00:00:45",
            ["TestClient:CustomProperty"] = "AllProps",
            ["TestClient:Options:NetworkTimeout"] = "00:01:00",
            ["TestClient:Options:EnableDistributedTracing"] = "true",
            ["TestClient:Options:ApiVersion"] = "2024-12-01",
            ["TestClient:Options:ClientLoggingOptions:EnableLogging"] = "false",
            ["TestClient:Credential:CredentialSource"] = "ApiKey",
            ["TestClient:Credential:Key"] = "test-key-123"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(settings.Timeout, Is.EqualTo(TimeSpan.FromSeconds(45)));
        Assert.That(settings.CustomProperty, Is.EqualTo("AllProps"));
        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.NetworkTimeout, Is.EqualTo(TimeSpan.FromMinutes(1)));
        Assert.That(settings.Options.EnableDistributedTracing, Is.True);
        Assert.That(settings.Options.ApiVersion, Is.EqualTo("2024-12-01"));
        Assert.That(settings.Options.ClientLoggingOptions, Is.Not.Null);
        Assert.That(settings.Options.ClientLoggingOptions!.EnableLogging, Is.False);
        Assert.That(settings.Credential, Is.Not.Null);
        Assert.That(settings.Credential!.CredentialSource, Is.EqualTo("ApiKey"));
        Assert.That(settings.Credential.Key, Is.EqualTo("test-key-123"));
    }

    [Test]
    public void GetClientSettings_HandlesNullableTimeSpan()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Options:NetworkTimeout"] = "00:00:30"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.NetworkTimeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public void GetClientSettings_HandlesNullableBool()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Options:EnableDistributedTracing"] = "true"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.EnableDistributedTracing, Is.True);
    }

    [Test]
    public void GetClientSettings_HandlesMissingOptionalProperties()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://minimal.example.com"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://minimal.example.com")));
        Assert.That(settings.Timeout, Is.Null);
        Assert.That(settings.CustomProperty, Is.Null);
        Assert.That(settings.Options, Is.Null);
    }

    [Test]
    public void GetClientSettings_HandlesMissingSection()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>());
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("NonExistentSection");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Endpoint, Is.Null);
        Assert.That(settings.Timeout, Is.Null);
        Assert.That(settings.CustomProperty, Is.Null);
        Assert.That(settings.Options, Is.Null);
        Assert.That(settings.Credential, Is.Not.Null); // Credential is always created
    }

    [Test]
    public void GetClientSettings_CanUseReferenceForEndpoint()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedEndpoints:Production"] = "https://prod.example.com",
            ["TestClient:Endpoint"] = "$SharedEndpoints:Production",
            ["TestClient:CustomProperty"] = "RefTest"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://prod.example.com")));
        Assert.That(settings.CustomProperty, Is.EqualTo("RefTest"));
    }

    [Test]
    public void GetClientSettings_CanUseReferenceForNestedOptions()
    {
        ConfigurationBuilder builder = new();
        builder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedConfig:DefaultTimeout"] = "00:02:00",
            ["SharedConfig:ApiVersion"] = "2024-11-01",
            ["TestClient:Options:NetworkTimeout"] = "$SharedConfig:DefaultTimeout",
            ["TestClient:Options:ApiVersion"] = "$SharedConfig:ApiVersion",
            ["TestClient:Options:EnableDistributedTracing"] = "true"
        });
        IConfigurationRoot config = builder.Build();

        TestClientSettings settings = config.GetClientSettings<TestClientSettings>("TestClient");

        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.Options, Is.Not.Null);
        Assert.That(settings.Options!.NetworkTimeout, Is.EqualTo(TimeSpan.FromMinutes(2)));
        Assert.That(settings.Options.ApiVersion, Is.EqualTo("2024-11-01"));
        Assert.That(settings.Options.EnableDistributedTracing, Is.True);
    }
}
