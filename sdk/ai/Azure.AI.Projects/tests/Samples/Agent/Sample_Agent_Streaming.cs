// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Agent_Streaming : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        public async Task Streaming()
        {
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

            Response<Agent> agentResponse = await client.CreateAgentAsync(
                model: "gpt-4-1106-preview",
                name: "My Friendly Test Assistant",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: new List<ToolDefinition> { new CodeInterpreterToolDefinition() });
            Agent agent = agentResponse.Value;

            Response<AgentThread> threadResponse = await client.CreateThreadAsync();
            AgentThread thread = threadResponse.Value;

            Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            ThreadMessage message = messageResponse.Value;

            await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine($"--- Run started! ---");
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                    if (contentUpdate.ImageFileId is not null)
                    {
                        Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
                    }
                }
            }
        }
    }
}
