// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_Responses_Tracing : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task ResponseTracingToConsoleAsync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        #region Snippet:Sample_ResponsesEnableGenAITracing
        AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
        #endregion
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);

        #region Snippet:Sample_ResponsesSetupTracingToConsole
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Projects.*")
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ResponseTracingSample"))
                        .AddConsoleExporter()
                        .Build();
        #endregion

        using (tracerProvider)
        {
            AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
            ResponseResult response = await responseClient.CreateResponseAsync("What is the capital of France?");
            Console.WriteLine(response.GetOutputText());
        }
    }

    [Test]
    [SyncOnly]
    public void ResponseTracingToConsole()
    {
        IgnoreSampleMayBe();
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
                        .AddSource("Azure.AI.Projects.*")
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ResponseTracingSample"))
                        .AddConsoleExporter()
                        .Build();

        using (tracerProvider)
        {
            AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

            ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
            ResponseResult response = responseClient.CreateResponse("What is the capital of France?");
            Console.WriteLine(response.GetOutputText());
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ResponseTracingToAzureMonitorAsync()
    {
        IgnoreSampleMayBe();
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

        #region Snippet:Sample_ResponsesSetupTracingToAzureMonitor
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ResponseTracingSample"))
            .AddAzureMonitorTraceExporter().Build();
        #endregion

        using (tracerProvider)
        {
            ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
            ResponseResult response = await responseClient.CreateResponseAsync("What is the capital of France?");
            Console.WriteLine(response.GetOutputText());
        }
    }

    [Test]
    [SyncOnly]
    public void ResponseTracingToAzureMonitor()
    {
        IgnoreSampleMayBe();
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
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ResponseTracingSample"))
            .AddAzureMonitorTraceExporter().Build();

        using (tracerProvider)
        {
            ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
            ResponseResult response = responseClient.CreateResponse("What is the capital of France?");
            Console.WriteLine(response.GetOutputText());
        }
    }

    public Sample_Responses_Tracing(bool isAsync) : base(isAsync)
    { }
}
