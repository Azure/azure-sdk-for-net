// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.OpenAI;
using Azure.Core;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CognitiveServices;
using OpenAI.Chat;

namespace Azure.Provisioning.CloudMachine.OpenAI;

public class OpenAIFeature : CloudMachineFeature
{
    public string Model { get; }
    public string ModelVersion { get; }

    public OpenAIFeature(string model, string modelVersion) {  Model = model; ModelVersion = modelVersion; }

    public override void AddTo(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = new("openai")
        {
            Name = cloudMachine.Id,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = cloudMachine.Id
            },
        };

        cloudMachine.AddResource(cognitiveServices.CreateRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            cloudMachine.PrincipalIdParameter)
        );

        // TODO: if we every support more than one deployment, they need to be chained using DependsOn.
        // The reason is that deployments need to be deployed/created serially.
        CognitiveServicesAccountDeployment deployment = new("openai_deployment", "2023-05-01")
        {
            Parent = cognitiveServices,
            Name = cloudMachine.Id,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel() {
                    Name = this.Model,
                    Format = "OpenAI",
                    Version = this.ModelVersion,
                }
            },
        };

        cloudMachine.AddResource(cognitiveServices);
        cloudMachine.AddResource(deployment);
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

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ClientWorkspace workspace)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(AzureOpenAIClient));
        if (connection.ConnectionKind == ClientConnectionKind.EntraId)
        {
            return new(connection.Endpoint, connection.TokenCredential);
        }
        else
        {
            return  new(connection.Endpoint, new ApiKeyCredential(connection.ApiKeyCredential!));
        }
    }

    private static ChatClient CreateChatClient(this ClientWorkspace workspace, AzureOpenAIClient client)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(ChatClient));
        ChatClient chat = client.GetChatClient(connection.Id);
        return chat;
    }
}
