// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Projects;
using Microsoft.ClientModel.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class ClientCreationAndAuthenticationSamples : AgentsTestBase
{
    [RecordedTest]
    public void CreateAgentClientDirectlyFromProjectEndpoint()
    {
        #region Snippet:CreateAgentClientDirectlyFromProjectEndpoint
        AgentClient agentClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        #endregion
    }

    [Test]
    public void CreateAgentClientFromProjectsClient()
    {
        #region Snippet:CreateAgentClientFromProjectsClient
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        AgentClient agentClient = projectClient.GetAgentClient();
        #endregion
    }

    [Test]
    public void GetOpenAIClientsFromAgents()
    {
        AgentClient agentClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());

        #region Snippet:GetOpenAIClientsFromAgents
        OpenAIClient openAIClient = agentClient.GetOpenAIClient();

        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient("MODEL_DEPLOYMENT");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = openAIClient.GetVectorStoreClient();
        #endregion
    }

    public ClientCreationAndAuthenticationSamples(bool isAsync) : base(isAsync) { }
}
