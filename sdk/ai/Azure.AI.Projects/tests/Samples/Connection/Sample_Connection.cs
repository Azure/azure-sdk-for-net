// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Connection : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void ConnectionExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        AIProjectClient client = new AIProjectClient(connectionString, new DefaultAzureCredential());
        var connectionsClient = client.GetConnectionsClient();

        ConnectionResponse connection = connectionsClient.GetDefaultConnection(ConnectionType.Serverless, true);

        if (connection.Properties.AuthType == AuthenticationType.ApiKey)
        {
            var apiKeyAuthProperties = connection.Properties as ConnectionPropertiesApiKeyAuth;
            if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
            {
                throw new ArgumentException("The API key authentication target URI is missing or invalid.");
            }

            if (!Uri.TryCreate(apiKeyAuthProperties.Target, UriKind.Absolute, out var endpoint))
            {
                throw new UriFormatException("Invalid URI format in API key authentication target.");
            }

            var credential = new AzureKeyCredential(apiKeyAuthProperties.Credentials.Key);
            ChatCompletionsClient chatClient = new ChatCompletionsClient(endpoint, credential);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                Model = modelDeploymentName
            };

            Response<ChatCompletions> response = chatClient.Complete(requestOptions);
            Console.WriteLine(response.Value.Content);
        }
    }
}
