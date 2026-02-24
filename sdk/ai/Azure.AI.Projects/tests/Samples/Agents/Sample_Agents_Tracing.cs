// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_Agents_Tracing : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentTracingToConsoleAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        #region Snippet:Sample_EnableGenAITracing
        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        #endregion
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);

        #region Snippet:Sample_SetupTracingToConsole
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Projects.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();
        #endregion

        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion1 = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
    }

    [Test]
    [SyncOnly]
    public void AgentTelemetryToConsole()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
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
            AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = projectClient.Agents.CreateAgentVersion(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    [Test]
    [AsyncOnly]
    public async Task AgentTracingToAzureMonitorAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        Console.WriteLine("Get the Application Insights connection string.");
        var connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();

        Console.WriteLine("Assign the retrieved string to the required environment variable.");
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", connectionString);

        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        #region Snippet:Sample_SetupTracingToAzureMonitor
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();
        #endregion

        using (tracerProvider)
        {
            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = await projectClient.Agents.CreateAgentVersionAsync(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    [Test]
    [SyncOnly]
    public void AgentTelemetryToAzureMonitor()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        Console.WriteLine("Get the Application Insights connection string.");
        var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();

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
            PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
            {
                Instructions = "You are a prompt agent."
            };
            AgentVersion agentVersion1 = projectClient.Agents.CreateAgentVersion(
                agentName: "myAgent1",
                options: new(agentDefinition));
            Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");

            projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
            Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        }
    }

    public Sample_Agents_Tracing(bool isAsync) : base(isAsync)
    { }
}
