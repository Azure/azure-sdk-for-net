// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CognitiveServices;

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
            chat = new("openai_deployment_chat", "2023-05-01")
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
                    }
                },
            };
            cloudMachine.AddResource(chat);
        }

        if (Embeddings != null)
        {
            CognitiveServicesAccountDeployment embeddings = new("openai_deployment_embedding", "2023-05-01")
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
