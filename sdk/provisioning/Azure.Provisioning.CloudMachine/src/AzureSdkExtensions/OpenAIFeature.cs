// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.OpenAI;
using Azure.Core;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CognitiveServices;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Provisioning.CloudMachine.OpenAI;

public class OpenAIFeature : CloudMachineFeature
{
    private AiModel _chatDeployment;
    private AiModel? _embeddingsDeployment;

    public OpenAIFeature(AiModel chatDeployment, AiModel? embeddingsDeployment = default)
    {
        if (chatDeployment == null)
        {
            throw new ArgumentNullException(nameof(chatDeployment));
        }
        _chatDeployment = chatDeployment;
        _embeddingsDeployment = embeddingsDeployment;
    }

    public override void AddTo(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = new("openai")
        {
            Name = $"{cloudMachine.Id}/{cloudMachine.Id}",
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = cloudMachine.Id
            },
        };
        cloudMachine.AddResource(cognitiveServices);

        cloudMachine.AddResource(cognitiveServices.CreateRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            cloudMachine.PrincipalIdParameter)
        );

        CognitiveServicesAccountDeployment chat = new("openai_deployment", "2023-05-01")
        {
            Parent = cognitiveServices,
            Name = cloudMachine.Id,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel()
                {
                    Name = _chatDeployment.Model,
                    Format = "OpenAI",
                    Version = _chatDeployment.ModelVersion
                }
            },
        };
        cloudMachine.AddResource(chat);

        if (_embeddingsDeployment != null)
        {
            CognitiveServicesAccountDeployment embeddings = new("openai_deployment", "2023-05-01")
            {
                Parent = cognitiveServices,
                Name = $"{cloudMachine.Id}/{cloudMachine.Id}-embedding",
                Properties = new CognitiveServicesAccountDeploymentProperties()
                {
                    Model = new CognitiveServicesAccountDeploymentModel()
                    {
                        Name = _embeddingsDeployment.Model,
                        Format = "OpenAI",
                        Version = _embeddingsDeployment.ModelVersion
                    }
                },
            };

            // Ensure that additional deployments, are chained using DependsOn.
            // The reason is that deployments need to be deployed/created serially.
            embeddings.DependsOn.Add(chat);
            cloudMachine.AddResource(embeddings);
        }
    }
}

public static class AzureOpenAIExtensions
{
    public static ChatClient GetOpenAIChatClient(this ClientWorkspace workspace)
    {
        ChatClient chatClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateChatClient(aoiaClient);
        });

        return chatClient;
    }

    public static EmbeddingClient GetOpenAIEmbeddingsClient(this ClientWorkspace workspace)
    {
        EmbeddingClient embeddingsClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateEmbeddingsClient(aoiaClient);
        });

        return embeddingsClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ClientWorkspace workspace)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(AzureOpenAIClient));
        if (connection.ConnectionKind == ClientConnectionKind.EntraId)
        {
            return new(connection.Endpoint, connection.TokenCredential);
        }
        else
        {
            return new(connection.Endpoint, new ApiKeyCredential(connection.ApiKeyCredential!));
        }
    }

    private static ChatClient CreateChatClient(this ClientWorkspace workspace, AzureOpenAIClient client)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(ChatClient));
        ChatClient chat = client.GetChatClient(connection.Id);
        return chat;
    }

    private static EmbeddingClient CreateEmbeddingsClient(this ClientWorkspace workspace, AzureOpenAIClient client)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(EmbeddingClient));
        EmbeddingClient embeddings = client.GetEmbeddingClient(connection.Id);
        return embeddings;
    }
}
