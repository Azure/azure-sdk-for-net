// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class HostBuilderExtensionsTests
{
    [Test]
    public void AddClient_RegistersClientWithSettings()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Timeout"] = "00:01:30",
            ["TestClient:CustomProperty"] = "TestValue"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Settings, Is.Not.Null);
        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Timeout, Is.EqualTo(TimeSpan.FromSeconds(90)));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("TestValue"));
    }

    [Test]
    public void AddClient_LoadsNestedOptions()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:ApiVersion"] = "2024-01-01"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ApiVersion, Is.EqualTo("2024-01-01"));
    }

    [Test]
    public void AddClient_LoadsClientPipelineOptions()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:NetworkTimeout"] = "00:02:00",
            ["TestClient:Options:EnableDistributedTracing"] = "false"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.NetworkTimeout, Is.EqualTo(TimeSpan.FromMinutes(2)));
        Assert.That(client.Settings.Options.EnableDistributedTracing, Is.False);
    }

    [Test]
    public void AddClient_LoadsClientLoggingOptions()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:ClientLoggingOptions:EnableLogging"] = "true",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageLogging"] = "true",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageContentLogging"] = "false",
            ["TestClient:Options:ClientLoggingOptions:MessageContentSizeLimit"] = "2048"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ClientLoggingOptions, Is.Not.Null);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageContentLogging, Is.False);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.MessageContentSizeLimit, Is.EqualTo(2048));
    }

    [Test]
    public void AddClient_WithConfigureSettings_ModifiesSettings()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:CustomProperty"] = "Original"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient", settings =>
        {
            settings.CustomProperty = "Modified";
        });

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("Modified"));
    }

    [Test]
    public void AddKeyedClient_RegistersClientWithKey()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:CustomProperty"] = "KeyedValue"
        });

        builder.AddKeyedClient<TestClient, TestClientSettings>("MyKey", "TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredKeyedService<TestClient>("MyKey");

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Settings, Is.Not.Null);
        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("KeyedValue"));
    }

    [Test]
    public void AddKeyedClient_WithConfigureSettings_ModifiesSettings()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:CustomProperty"] = "Original"
        });

        builder.AddKeyedClient<TestClient, TestClientSettings>("MyKey", "TestClient", settings =>
        {
            settings.CustomProperty = "KeyedModified";
        });

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredKeyedService<TestClient>("MyKey");

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("KeyedModified"));
    }

    [Test]
    public void AddClient_RegistersAsSingleton()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client1 = host.Services.GetRequiredService<TestClient>();
        TestClient? client2 = host.Services.GetRequiredService<TestClient>();

        Assert.That(ReferenceEquals(client1, client2), Is.True);
    }

    [Test]
    public void AddKeyedClient_RegistersAsSingleton()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["TestClient:Endpoint"] = "https://test.example.com"
        });

        builder.AddKeyedClient<TestClient, TestClientSettings>("MyKey", "TestClient");

        IHost host = builder.Build();
        TestClient? client1 = host.Services.GetRequiredKeyedService<TestClient>("MyKey");
        TestClient? client2 = host.Services.GetRequiredKeyedService<TestClient>("MyKey");

        Assert.That(ReferenceEquals(client1, client2), Is.True);
    }

    [Test]
    public void AddClient_WithReferenceToIndividualProperty_ResolvesCorrectly()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedValues:ProductionEndpoint"] = "https://prod.example.com",
            ["SharedValues:DefaultTimeout"] = "00:05:00",
            ["TestClient:Endpoint"] = "$SharedValues:ProductionEndpoint",
            ["TestClient:Timeout"] = "$SharedValues:DefaultTimeout",
            ["TestClient:CustomProperty"] = "TestValue"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://prod.example.com")));
        Assert.That(client.Settings.Timeout, Is.EqualTo(TimeSpan.FromMinutes(5)));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("TestValue"));
    }

    [Test]
    public void AddClient_WithReferenceToNestedOptions_ResolvesCorrectly()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedOptions:ApiVersion"] = "2025-01-01",
            ["SharedOptions:NetworkTimeout"] = "00:03:30",
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:ApiVersion"] = "$SharedOptions:ApiVersion",
            ["TestClient:Options:NetworkTimeout"] = "$SharedOptions:NetworkTimeout",
            ["TestClient:Options:EnableDistributedTracing"] = "true"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ApiVersion, Is.EqualTo("2025-01-01"));
        Assert.That(client.Settings.Options.NetworkTimeout, Is.EqualTo(TimeSpan.Parse("00:03:30")));
        Assert.That(client.Settings.Options.EnableDistributedTracing, Is.True);
    }

    [Test]
    public void AddClient_WithReferenceToLoggingOptions_ResolvesCorrectly()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedLogging:EnableLogging"] = "true",
            ["SharedLogging:EnableMessageLogging"] = "false",
            ["SharedLogging:MessageContentSizeLimit"] = "4096",
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:ClientLoggingOptions:EnableLogging"] = "$SharedLogging:EnableLogging",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageLogging"] = "$SharedLogging:EnableMessageLogging",
            ["TestClient:Options:ClientLoggingOptions:EnableMessageContentLogging"] = "true",
            ["TestClient:Options:ClientLoggingOptions:MessageContentSizeLimit"] = "$SharedLogging:MessageContentSizeLimit"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ClientLoggingOptions, Is.Not.Null);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageLogging, Is.False);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageContentLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.MessageContentSizeLimit, Is.EqualTo(4096));
    }

    [Test]
    public void AddClient_WithReferenceToEntireOptionsObject_ResolvesCorrectly()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedOptions:ApiVersion"] = "2026-01-01",
            ["SharedOptions:NetworkTimeout"] = "00:02:30",
            ["SharedOptions:EnableDistributedTracing"] = "false",
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:CustomProperty"] = "TestValue",
            ["TestClient:Options"] = "$SharedOptions"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.CustomProperty, Is.EqualTo("TestValue"));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ApiVersion, Is.EqualTo("2026-01-01"));
        Assert.That(client.Settings.Options.NetworkTimeout, Is.EqualTo(TimeSpan.Parse("00:02:30")));
        Assert.That(client.Settings.Options.EnableDistributedTracing, Is.False);
    }

    [Test]
    public void AddClient_WithReferenceToEntireLoggingOptionsObject_ResolvesCorrectly()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["SharedLogging:EnableLogging"] = "true",
            ["SharedLogging:EnableMessageLogging"] = "true",
            ["SharedLogging:EnableMessageContentLogging"] = "false",
            ["SharedLogging:MessageContentSizeLimit"] = "8192",
            ["TestClient:Endpoint"] = "https://test.example.com",
            ["TestClient:Options:ApiVersion"] = "2026-01-01",
            ["TestClient:Options:ClientLoggingOptions"] = "$SharedLogging"
        });

        builder.AddClient<TestClient, TestClientSettings>("TestClient");

        IHost host = builder.Build();
        TestClient? client = host.Services.GetRequiredService<TestClient>();

        Assert.That(client.Settings.Endpoint, Is.EqualTo(new Uri("https://test.example.com")));
        Assert.That(client.Settings.Options, Is.Not.Null);
        Assert.That(client.Settings.Options!.ApiVersion, Is.EqualTo("2026-01-01"));
        Assert.That(client.Settings.Options!.ClientLoggingOptions, Is.Not.Null);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageLogging, Is.True);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.EnableMessageContentLogging, Is.False);
        Assert.That(client.Settings.Options!.ClientLoggingOptions!.MessageContentSizeLimit, Is.EqualTo(8192));
    }
}
