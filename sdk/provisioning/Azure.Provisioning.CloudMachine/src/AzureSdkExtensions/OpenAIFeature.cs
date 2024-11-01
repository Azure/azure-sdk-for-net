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
    public OpenAIFeature()
    {
    }

    public AIModel? Chat { get; set; }
    public AIModel? Embeddings { get; set; }

    public override void AddTo(CloudMachineInfrastructure cloudMachine)
    {
        if (Chat == default && Embeddings == default)
        {
            throw new InvalidOperationException("At least one of Chat or Embeddings must be specified.");
        }
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
        cloudMachine.AddResource(cognitiveServices);

        cloudMachine.AddResource(cognitiveServices.CreateRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            cloudMachine.PrincipalIdParameter)
        );

        CognitiveServicesAccountDeployment? chat = default;
        if (Chat != default)
        {
            chat = new("openai_deployment_chat", "2024-06-01-preview")
            {
                Parent = cognitiveServices,
                Name = cloudMachine.Id,
                Properties = new CognitiveServicesAccountDeploymentProperties()
                {
                    Model = new CognitiveServicesAccountDeploymentModel()
                    {
                        Name = Chat.Model,
                        Format = "OpenAI",
                        Version = Chat.ModelVersion
                    },
                    VersionUpgradeOption = DeploymentModelVersionUpgradeOption.OnceNewDefaultVersionAvailable,
                    RaiPolicyName = "Microsoft.DefaultV2",
                },
                Sku = new CognitiveServicesSku
                {
                    Capacity = 120,
                    Name = "Standard"
                }
            };
            cloudMachine.AddResource(chat);
        }

        if (Embeddings != null)
        {
            CognitiveServicesAccountDeployment embeddings = new("openai_deployment_embedding", "2024-06-01-preview")
            {
                Parent = cognitiveServices,
                Name = $"{cloudMachine.Id}-embedding",
                Properties = new CognitiveServicesAccountDeploymentProperties()
                {
                    Model = new CognitiveServicesAccountDeploymentModel()
                    {
                        Name = Embeddings.Model,
                        Format = "OpenAI",
                        Version = Embeddings.ModelVersion
                    }
                },
                Sku = new CognitiveServicesSku
                {
                    Capacity = 120,
                    Name = "Standard"
                }
            };

            // Ensure that additional deployments, are chained using DependsOn.
            // The reason is that deployments need to be deployed/created serially.
            if (chat != default)
            {
                embeddings.DependsOn.Add(chat);
            }
            cloudMachine.AddResource(embeddings);
        }
    }
}
