// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;

namespace Azure.CloudMachine.OpenAI;

public enum AIModelKind
{
    Chat,
    Embedding,
}
public class OpenAIModel : CloudMachineFeature
{
    public OpenAIModel(string model, string modelVersion, AIModelKind kind = AIModelKind.Chat) {
        Kind = kind;
        Model = model;
        ModelVersion = modelVersion;
    }

    public string Model { get; }
    public string ModelVersion { get; }
    private AIModelKind Kind { get; } // has to be $"{cloudMachine.Id}_embedding" or {cm.Id}
    public CognitiveServicesAccount? CognitiveServices { get; set; } = default;

    public override void AddTo(CloudMachineInfrastructure cm)
    {
        string name = Kind switch
        {
            AIModelKind.Chat => $"{cm.Id}_chat",
            AIModelKind.Embedding => $"{cm.Id}_embedding",
            _ => throw new NotImplementedException()
        };

        var parent = CognitiveServices;
        if (parent == default)
        {
            if (!cm.Features.TryFind(out OpenAIFeature? openAI)) {
                openAI = new OpenAIFeature();
                cm.AddFeature(openAI);
            }
            parent = openAI!.CreateAccount(cm);
        }

        CognitiveServicesAccountDeployment deployment = new($"openai_{name}", "2024-06-01-preview") {
            Parent = parent,
            Name = name,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel()
                {
                    Name = Model,
                    Format = "OpenAI",
                    Version = ModelVersion
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
        cm.AddResource(deployment);
    }
}
