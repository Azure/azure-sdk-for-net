// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.OpenAI;

public class OpenAIModelFeature : CloudMachineFeature
{
    public OpenAIModelFeature(string model, string modelVersion, AIModelKind kind = AIModelKind.Chat) {
        Kind = kind;
        Model = model;
        ModelVersion = modelVersion;
    }

    public string Model { get; }
    public string ModelVersion { get; }
    private AIModelKind Kind { get; }

    internal OpenAIFeature Account { get; set; } = default!;

    private static OpenAIFeature GetOrCreateOpenAI(CloudMachineInfrastructure cm)
    {
        foreach (OpenAIFeature feature in cm.Features.FindAll<OpenAIFeature>())
        {
            return feature;
        }
        var openAI = new OpenAIFeature();
        cm.AddFeature(openAI);
        cm.Connections.Add("Azure.AI.OpenAI.AzureOpenAIClient", new Uri($"https://{cm.Id}.openai.azure.com"));
        return openAI;
    }

    public override void AddTo(CloudMachineInfrastructure cm)
    {
        OpenAIFeature openAI = GetOrCreateOpenAI(cm);

        openAI.AddModel(this);

        // add connections
        switch (Kind)
        {
            case AIModelKind.Chat:
                cm.Connections.Add("OpenAI.Chat.ChatClient", $"{cm.Id}_chat");
                break;
            case AIModelKind.Embedding:
                cm.Connections.Add("OpenAI.Embeddings.EmbeddingClient", $"{cm.Id}_embedding");
                break;
            default:
                throw new NotImplementedException();
        }
    }

    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure cm)
    {
        string name = Kind switch
        {
            AIModelKind.Chat => $"{cm.Id}_chat",
            AIModelKind.Embedding => $"{cm.Id}_embedding",
            _ => throw new NotImplementedException()
        };

        Debug.Assert(Account != null);
        ProvisionableResource emitted = Account!.Emitted;
        if (emitted == null)
        {
            Account.Emit(cm);
        }
        CognitiveServicesAccount parent = (CognitiveServicesAccount)Account!.Emitted;

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

        return deployment;
    }
}

public enum AIModelKind
{
    Chat,
    Embedding,
}
