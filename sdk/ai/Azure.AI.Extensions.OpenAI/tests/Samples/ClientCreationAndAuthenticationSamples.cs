// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.VectorStores;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

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
        AgentAdministrationClient agentClient = projectClient.AgentAdministrationClient;
        #endregion
    }

    [Test]
    public void CreateAgentClientFromProjectsClient()
    {
        #region Snippet:CreateAgentClientFromProjectsClient
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        ProjectOpenAIClient agentClient = projectClient.ProjectOpenAIClient;
        #endregion
    }

    [Test]
    public void GetOpenAIClientsFromAgents()
    {
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());

        #region Snippet:GetOpenAIClientsFromProjects
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent("FOUNDRY_AGENT_NAME");
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = projectClient.ProjectOpenAIClient.GetVectorStoreClient();
        #endregion
    }

    [Test]
    public void SelectClientVersion()
    {
        #region Snippet:SelectAPIVersion
        ProjectOpenAIClientOptions option = new()
        {
            ApiVersion = "2025-11-15-preview"
        };
        ProjectOpenAIClient projectClient = new(
            projectEndpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        #endregion
    }

    public ClientCreationAndAuthenticationSamples(bool isAsync) : base(isAsync) { }
}
