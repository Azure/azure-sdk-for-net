// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Extensions.AI;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_As_IChatClient : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task PersistentAgentsAsIChatClient()
    {
        #region Snippet:PersistentAgentsAsIChatClient_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:PersistentAgentsAsIChatClient_CreateAgentAsIChatClient
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.");

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        IChatClient chatClient = client.AsIChatClient(agent.Id, thread.Id);
        #endregion
        #region Snippet:PersistentAgentsAsIChatClient_GetResponseAsync
        ChatResponse response = await chatClient.GetResponseAsync([new ChatMessage(ChatRole.User, [new TextContent("Hello, tell me a joke")])]);

        Console.WriteLine(string.Join(Environment.NewLine, response.Messages.Select(c => c.Text)));
        #endregion
        #region Snippet:PersistentAgentsAsIChatClient_Cleanup
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }
}
