// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter;

namespace Azure.AI.Agents.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public partial class Sample_Agents_Telemetry : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task TracingToConsoleExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Agents.Persistent.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();

        using (tracerProvider)
        {
            AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = await client.CreateAgentVersionAsync(
                agentName: "myAgent1",
                definition: agentDefinition, options: null);

            DeleteAgentVersionResponse response = await client.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {response.Name}, version: {response.Version}, deleted: {response.Deleted})");
        }
    }

    [Test]
    [SyncOnly]
    public void TracingToConsoleExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #region Snippet:EnableActivitySourceToGetAgentTraces
        AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
        #endregion
        #region Snippet:DisableContentRecordingForAgentTraces
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        #endregion
        #region Snippet:AgentTelemetrySetupTracingToConsole
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Agents.Persistent.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();
        #endregion

        using (tracerProvider)
        {
            AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = client.CreateAgentVersion(
                agentName: "myAgent1",
                definition: agentDefinition, options: null);

            DeleteAgentVersionResponse response = client.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {response.Name}, version: {response.Version}, deleted: {response.Deleted})");
        }
    }

    [Test]
    [AsyncOnly]
    public async Task TracingToAzureMonitorExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Agents.Persistent.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();

        using (tracerProvider)
        {
            AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = await client.CreateAgentVersionAsync(
                agentName: "myAgent1",
                definition: agentDefinition, options: null);

            DeleteAgentVersionResponse response = await client.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {response.Name}, version: {response.Version}, deleted: {response.Deleted})");
        }
    }

    [Test]
    [SyncOnly]
    public void TracingToAzureMonitorExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #region Snippet:AgentTelemetrySetupTracingToAzureMonitor
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Agents.Persistent.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();
        #endregion

        using (tracerProvider)
        {
            AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = client.CreateAgentVersion(
                agentName: "myAgent1",
                definition: agentDefinition, options: null);

            DeleteAgentVersionResponse response = client.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {response.Name}, version: {response.Version}, deleted: {response.Deleted})");
        }
    }

    public Sample_Agents_Telemetry(bool isAsync) : base(isAsync)
    { }
}
