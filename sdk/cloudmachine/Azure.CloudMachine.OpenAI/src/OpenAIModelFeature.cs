// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.OpenAI;

/// <summary>
/// CloudMachine feature for OpenAI models.
/// </summary>
public class OpenAIModelFeature : CloudMachineFeature
{
    /// <summary>
    /// Create a new OpenAI model feature.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="modelVersion"></param>
    /// <param name="kind"></param>
    public OpenAIModelFeature(string model, string modelVersion, AIModelKind kind = AIModelKind.Chat) {
        Kind = kind;
        Model = model;
        ModelVersion = modelVersion;
    }

    /// <summary>
    /// The model name.
    /// </summary>
    public string Model { get; }

    /// <summary>
    /// The model version.
    /// </summary>
    public string ModelVersion { get; }
    private AIModelKind Kind { get; }

    internal OpenAIFeature Account { get; set; } = default!;

    /// <summary>
    /// Emit the feature.
    /// </summary>
    /// <param name="features"></param>
    /// <param name="cmId"></param>
    protected override void EmitFeatures(FeatureCollection features, string cmId)
    {
        // TODO: is it OK that we return the first one?
        OpenAIFeature? openAI = features.FindAll<OpenAIFeature>().FirstOrDefault();
        if (openAI == default)
        {
            openAI = new OpenAIFeature(); // TODO: we need to add connection
            features.Add(openAI);
        }
        Account = openAI;
        features.Add(this);
    }

    /// <summary>
    /// Emit the connections.
    /// </summary>
    /// <param name="connections"></param>
    /// <param name="cmId"></param>
    /// <exception cref="NotImplementedException"></exception>
    protected override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        Account.EmitConnectionsInternal(connections, cmId);
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

    /// <summary>
    /// Emit the resources.
    /// </summary>
    /// <param name="cm"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cm)
    {
        if (Account == null) throw new InvalidOperationException("Account must be set before emitting");
        if (Account.Resource == null) throw new InvalidOperationException("Account must be emitted before emitting");

        string name = Kind switch
        {
            AIModelKind.Chat => $"{cm.Id}_chat",
            AIModelKind.Embedding => $"{cm.Id}_embedding",
            _ => throw new NotImplementedException()
        };

        CognitiveServicesAccount parent = (CognitiveServicesAccount)Account.Resource;

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
                Capacity = 10,
                Name = "Standard"
            },
        };

        // deployments need to have dependson set!
        OpenAIModelFeature? previous = FindPrevious(cm, this);
        if (previous != null)
        {
            if (previous.Resource == null) throw new InvalidOperationException("Previous must be emitted");
            CognitiveServicesAccountDeployment previousDeployment = (CognitiveServicesAccountDeployment)previous.Resource;
            deployment.DependsOn.Add(previousDeployment);
        }

        cm.AddResource(deployment);
        return deployment;

        OpenAIModelFeature? FindPrevious(CloudMachineInfrastructure cm, OpenAIModelFeature current)
        {
            OpenAIModelFeature? previous = default;
            foreach (var feature in cm.Features)
            {
                if (feature == current)
                    return previous;
                if (feature is OpenAIModelFeature oaim)
                    previous = oaim;
            }
            throw new InvalidOperationException("current not found in infrastructure");
        }
    }
}

/// <summary>
/// The kind of OpenAI model.
/// </summary>
public enum AIModelKind
{
    /// <summary>
    /// Chat model.
    /// </summary>
    Chat,
    /// <summary>
    /// Embedding model.
    /// </summary>
    Embedding,
}
