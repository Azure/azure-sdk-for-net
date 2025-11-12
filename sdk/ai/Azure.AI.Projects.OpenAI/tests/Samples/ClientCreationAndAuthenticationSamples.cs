// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ClientModel.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class ClientCreationAndAuthenticationSamples : ProjectsOpenAITestBase
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
        ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent("AGENT_NAME");
        OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = projectClient.OpenAI.GetVectorStoreClient();
        #endregion
    }

    public ClientCreationAndAuthenticationSamples(bool isAsync) : base(isAsync) { }
}
