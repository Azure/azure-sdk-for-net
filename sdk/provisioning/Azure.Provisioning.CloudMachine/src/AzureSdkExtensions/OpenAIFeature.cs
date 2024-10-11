// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.Contracts;
using Azure.AI.OpenAI;
using Azure.CloudMachine;
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

    public override void AddTo(CloudMachineInfrastructure infrastructure)
    {
        CognitiveServicesAccount cognitiveServices = new("openai", "2023-05-01")
        {
            Name = infrastructure.Id,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = infrastructure.Id
            },
        };

        infrastructure.AddResource(cognitiveServices.CreateRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            infrastructure.PrincipalIdParameter)
        );

        // TODO: if we every support more than one deployment, they need to be chained using DependsOn.
        // The reason is that deployments need to be deployed/created serially.
        CognitiveServicesAccountDeployment deployment = new("openai_deployment", "2023-05-01")
        {
            Parent = cognitiveServices,
            Name = infrastructure.Id,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel() {
                    Name = this.Model,
                    Format = "OpenAI",
                    Version = this.ModelVersion
                }
            },
        };

        infrastructure.AddResource(cognitiveServices);
        infrastructure.AddResource(deployment);
    }
}

public static class OpenAIFeatureExtensions
{
    public static ChatClient GetOpenAIChatClient(this WorkspaceClient workspace)
    {
        string chatClientId = typeof(ChatClient).FullName;

        ChatClient client = workspace.Subclients.Get(chatClientId, () =>
        {
            string azureOpenAIClientId = typeof(AzureOpenAIClient).FullName;

            AzureOpenAIClient aoia = workspace.Subclients.Get(azureOpenAIClientId, () =>
            {
                ClientConfiguration? connectionMaybe = workspace.GetConfiguration(typeof(AzureOpenAIClient).FullName);
                if (connectionMaybe == null) throw new Exception("Connection not found");

                ClientConfiguration connection = connectionMaybe.Value;
                Uri endpoint = new(connection.Endpoint);
                var clientOptions = new AzureOpenAIClientOptions();
                if (connection.CredentailType == CredentialType.EntraId)
                {
                    AzureOpenAIClient aoai = new(endpoint, workspace.Credential, clientOptions);
                    return aoai;
                }
                else
                {
                    AzureOpenAIClient aoai = new(endpoint, new ApiKeyCredential(connection.ApiKey!), clientOptions);
                    return aoai;
                }
            });

            string azureOpenAIChatClientId = typeof(ChatClient).FullName;
            ClientConfiguration? connectionMaybe = workspace.GetConfiguration(azureOpenAIChatClientId);
            if (connectionMaybe == null) throw new Exception("Connection not found");
            var connection = connectionMaybe.Value;
            ChatClient chat = aoia.GetChatClient(connection.Endpoint);
            return chat;
        });

        return client;
    }
}
