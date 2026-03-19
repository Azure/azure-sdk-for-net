// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_Agents_Tracing : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentTracingToConsoleAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif

        #region Snippet:Sample_Agents_EnableGenAITracing
        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        #endregion
        #region Snippet:Sample_Agents_ResponsesEnableGenAITracing
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        #endregion
        #region Snippet:Sample_Agents_SetupTracingToConsole
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Projects.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();
        #endregion
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

        agentsClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
    }

    [Test]
    [SyncOnly]
    public void AgentTelemetryToConsole()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif

        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Projects.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();

        using (tracerProvider)
        {
            AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            agentsClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    [Test]
    [AsyncOnly]
    public async Task AgentTracingToAzureMonitorAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var connectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var connectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        #region Snippet:Sample_Agents_SetupTracingToAzureMonitor
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();
        #endregion

        using (tracerProvider)
        {
            DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            agentsClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    [Test]
    [SyncOnly]
    public void AgentTelemetryToAzureMonitor()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var connectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var connectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        Console.WriteLine("Assign the retrieved string to the required environment variable.");
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", connectionString);

        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();

        using (tracerProvider)
        {
            DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            agentsClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    public Sample_Agents_Tracing(bool isAsync) : base(isAsync)
    { }
}
