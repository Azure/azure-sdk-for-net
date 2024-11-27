// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using Azure.Core;
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

    protected internal override void EmitFeatures(FeatureCollection features, string cmId)
    {
        // TODO: is it OK that we return the first one?
        OpenAIFeature? openAI = features.FindAll<OpenAIFeature>().FirstOrDefault();
        if (openAI == default)
        {
            openAI = new OpenAIFeature(); // TODO: we need to add connection
            features.Add(openAI);
        }
        openAI.AddModel(this);
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        Account.EmitConnections(connections, cmId);
        // add connections
        switch (Kind)
        {
            case AIModelKind.Chat:
                connections.Add(new ClientConnection("OpenAI.Chat.ChatClient", $"{cmId}_chat"));
                break;
            case AIModelKind.Embedding:
                connections.Add(new ClientConnection("OpenAI.Embeddings.EmbeddingClient", $"{cmId}_embedding"));
                break;
            default:
                throw new NotImplementedException();
        }
    }

    protected override ProvisionableResource EmitInfrastructure(CloudMachineInfrastructure cm)
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
