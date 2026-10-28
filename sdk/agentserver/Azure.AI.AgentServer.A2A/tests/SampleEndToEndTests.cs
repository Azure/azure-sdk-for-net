// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using global::A2A;
using Azure.AI.AgentServer.A2A.Tests.Snippets;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
public class SampleEndToEndTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task EchoSampleWorksThroughBothHostingEntryPoints(bool sharedHost)
    {
        WebApplication app;
        if (sharedHost)
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.AddA2A<ReadMeSnippets.EchoAgent>(ReadMeSnippets.CreateCard());
            app = builder.Build().App;
        }
        else
        {
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseTestServer();
            builder.Services.AddFoundryA2A<ReadMeSnippets.EchoAgent>(ReadMeSnippets.CreateCard());
            app = builder.Build();
            app.MapFoundryA2A();
        }

        await using (app)
        {
            await app.StartAsync();
            using var client = app.GetTestClient();
            using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
            var text = await response.Content.ReadAsStringAsync();
            using var json = JsonDocument.Parse(text);
            Assert.That(json.RootElement.GetProperty("result").GetProperty("message").GetProperty("parts")[0]
                .GetProperty("text").GetString(), Is.EqualTo("Echo: hello"));
        }
    }

    [Test]
    public async Task NativeTaskSampleEmitsCompletedTaskAndArtifact()
    {
        await using var app = await HostingTests.CreateAppAsync(services =>
            services.AddSingleton<IAgentHandler, ReadMeSnippets.TaskAgent>());
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
        using var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var task = json.RootElement.GetProperty("result").GetProperty("task");
        Assert.That(task.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_COMPLETED"));
        Assert.That(task.GetProperty("artifacts")[0].GetProperty("parts")[0].GetProperty("text").GetString(),
            Is.EqualTo("Echo: hello"));
    }
}
