// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class ResilientTaskHostExtensionsTests
{
    [Test]
    public void NamedSectionBindsCredentialAndEndpointTogether()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Tasks:Endpoint"] = "https://configured.example.com/api/projects/project",
        });
        var credential = new MockCredential();

        builder.AddResilientTasks(
            "Tasks",
            settings => settings.CredentialProvider = credential);

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        TaskHostEnvironment environment = provider.GetRequiredService<TaskHostEnvironment>();
        Assert.Multiple(() =>
        {
            Assert.That(environment.Credential, Is.SameAs(credential));
            Assert.That(
                environment.Endpoint,
                Is.EqualTo(new Uri("https://configured.example.com/api/projects/project")));
        });
    }

    [Test]
    public void ConfigureCallbackOverridesBoundEndpoint()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration["Tasks:Endpoint"] =
            "https://configured.example.com/api/projects/project";
        var credential = new MockCredential();
        var overrideEndpoint =
            new Uri("https://override.example.com/api/projects/project");

        builder.AddResilientTasks(
            "Tasks",
            settings =>
            {
                settings.CredentialProvider = credential;
                settings.Endpoint = overrideEndpoint;
            });

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<TaskHostEnvironment>().Endpoint,
            Is.SameAs(overrideEndpoint));
    }

    [Test]
    public void MalformedEndpointFailsDuringBinding()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration["Tasks:Endpoint"] = "not an endpoint";

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResilientTasks("Tasks"))!;

        Assert.That(exception.Message, Does.Contain("Tasks:Endpoint"));
        Assert.That(exception.Message, Does.Contain("not an endpoint"));
    }
}
