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
using Azure.AI.Projects.OpenAI;

namespace Azure.AI.Projects.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class ClientCreationAndAuthenticationSamples : AgentsTestBase
{
    [RecordedTest]
    public void CreateAgentClientDirectlyFromProjectEndpoint()
    {
        #region Snippet:CreateAgentClientDirectlyFromProjectEndpoint
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        AIProjectAgentsOperations agentClient = projectClient.Agents;
        #endregion
    }

    [Test]
    public void CreateAgentClientFromProjectsClient()
    {
        #region Snippet:CreateAgentClientFromProjectsClient
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        ProjectOpenAIClient agentClient = projectClient.OpenAI;
        #endregion
    }

    [Test]
    public void GetOpenAIClientsFromAgents()
    {
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());

        #region Snippet:GetOpenAIClientsFromProjects
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent("AGENT_NAME");
        OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = projectClient.OpenAI.GetVectorStoreClient();
        #endregion
    }

    public ClientCreationAndAuthenticationSamples(bool isAsync) : base(isAsync) { }
}
