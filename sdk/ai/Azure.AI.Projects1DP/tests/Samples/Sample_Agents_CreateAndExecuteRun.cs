// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects1DP.Tests.Samples
{
    public partial class Projects1DPSamples: SamplesBase<Projects1DPClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateAndExecuteRunSample()
        {
            // Replace with your actual endpoint and credentials.
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("AGENT_ENDPOINT"));
            TokenCredential credential = new DefaultAzureCredential();

            // Create the AIProjectClient and Agents client.
            AIProjectClient projectClient = new AIProjectClient(endpoint, credential);
            Agents agentsClient = projectClient.GetAgentsClient(apiVersion: "2025-05-01-preview");

            // Build an instruction message.
            DeveloperMessage instruction = new DeveloperMessage(
                new AIContent[] { new TextContent("You are helpful assistant") }
            );

            // Create an Agent.
            Response<Agent> agentResponse = agentsClient.CreateAgent(
                new AzureAgentModel("gpt-4o"),
                name: "SampleAgent",
                instructions: new[] { instruction }
            );
            Agent agent = agentResponse.Value;

            // Prepare a user message.
            ChatMessage userInput = new UserMessage(
                new AIContent[] { new TextContent("Tell me a joke") }
            );

            // Create and execute the run.
            Runs runsClient = projectClient.GetRunsClient(apiVersion: "2025-05-01-preview");
            Response<Run> runResponse = runsClient.CreateAndExecuteRun(
                agent,
                new[] { userInput }
            );

            // Display the messages.
            foreach (ChatMessage chatMsg in runResponse.Value.RunOutputs.Messages)
            {
                foreach (AIContent item in chatMsg.Content)
                {
                    if (item is TextContent text)
                    {
                        Console.WriteLine("AGENT: " + text.Text);
                    }
                }
            }
        }
    }
}
