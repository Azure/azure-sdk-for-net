// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;
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
        // TODO: is it OK that we return the first one?
        OpenAIFeature? openAI = cm.Features.FindAll<OpenAIFeature>().FirstOrDefault();
        if (openAI != default) return openAI;

        openAI = new OpenAIFeature();
        cm.AddFeature(openAI);

        return openAI;
    }

    protected internal override void AddTo(CloudMachineInfrastructure cm)
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

        cm.AddConstruct(deployment);

        return deployment;
    }
}

public enum AIModelKind
{
    Chat,
    Embedding,
}
