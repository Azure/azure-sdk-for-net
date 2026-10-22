// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

[NonParallelizable]
public class VoiceAgentTelemetryConfigurationTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task ProjectTracingOptionAppliesToVoiceRestSubclient(bool enabled)
    {
        const string variable = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";
        string previous = Environment.GetEnvironmentVariable(variable);
        List<Activity> activities = new();
        using ActivityListener listener = new()
        {
            ShouldListenTo = source => source.Name == "Azure.AI.Projects.Agents.BetaVoiceAgentsConversations",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => activities.Add(activity)
        };
        ActivitySource.AddActivityListener(listener);
        try
        {
            Environment.SetEnvironmentVariable(variable, "true");
            RefreshConfiguration();
            MockPipelineTransport transport = new(_ => new MockPipelineResponse(204))
            {
                ExpectSyncPipeline = false
            };
            AIProjectClient client = new(new Uri("https://fake-account.services.ai.azure.com/api/projects/test"),
                new MockCredential(), new AIProjectClientOptions
                {
                    Transport = transport,
                    EnableDistributedTracing = enabled
                });

            await client.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations()
                .DeleteAgentConversationAsync("agent", "conversation");

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(activities.FindAll(activity => activity.DisplayName == "BetaVoiceAgentsConversations.DeleteAgentConversation"),
                Has.Count.EqualTo(enabled ? 1 : 0));
        }
        finally
        {
            Environment.SetEnvironmentVariable(variable, previous);
            RefreshConfiguration();
        }
    }

    private static void RefreshConfiguration()
    {
        Type type = typeof(AgentAdministrationClient).Assembly.GetType("Azure.AI.Projects.Agents.Telemetry.OpenTelemetryScope");
        Assert.That(type, Is.Not.Null);
        MethodInfo method = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.That(method, Is.Not.Null);
        method.Invoke(null, null);
    }
}
