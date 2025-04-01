// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Connection : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void ConnectionExample()
    {
        #region Snippet:ConnectionExampleSync
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new(connectionString, new DefaultAzureCredential());
        ConnectionsClient connectionsClient = client.GetConnectionsClient();

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
            ChatCompletionsClient chatClient = new(endpoint, credential);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                Model = modelDeploymentName
            };

            ChatCompletions response = chatClient.Complete(requestOptions);
            Console.WriteLine(response.Content);
        }
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task ConnectionExampleAsync()
    {
        #region Snippet:ConnectionExampleAsync
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new(connectionString, new DefaultAzureCredential());
        ConnectionsClient connectionsClient = client.GetConnectionsClient();

        ConnectionResponse connection = await connectionsClient.GetDefaultConnectionAsync(ConnectionType.Serverless, true);

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
            ChatCompletionsClient chatClient = new(endpoint, credential);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                Model = modelDeploymentName
            };

            ChatCompletions response = await chatClient.CompleteAsync(requestOptions);
            Console.WriteLine(response.Content);
        }
        #endregion
    }
}
