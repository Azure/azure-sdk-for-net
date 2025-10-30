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

namespace Azure.AI.Agents.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class ClientCreationAndAuthenticationSamples : AgentsTestBase
{
    [RecordedTest]
    public void CreateAgentsClientDirectlyFromProjectEndpoint()
    {
        #region Snippet:CreateAgentsClientDirectlyFromProjectEndpoint
        AgentsClient agentsClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        #endregion
    }

    [Test]
    public void CreateAgentsClientFromProjectsClient()
    {
        #region Snippet:CreateAgentsClientFromProjectsClient
        AIProjectClient projectClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());
        AgentsClient agentsClient = projectClient.GetAgentsClient();
        #endregion
    }

    [Test]
    public void GetOpenAIClientsFromAgents()
    {
        AgentsClient agentsClient = new(
            endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
            tokenProvider: new AzureCliCredential());

        #region Snippet:GetOpenAIClientsFromAgents
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();

        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient("MODEL_DEPLOYMENT");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = openAIClient.GetVectorStoreClient();
        #endregion
    }

    public ClientCreationAndAuthenticationSamples(bool isAsync) : base(isAsync) { }
}
