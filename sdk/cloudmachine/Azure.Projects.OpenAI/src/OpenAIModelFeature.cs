// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;

namespace Azure.Projects.OpenAI;

/// <summary>
/// Projects feature for OpenAI models.
/// </summary>
public class OpenAIModelFeature : AzureProjectFeature
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

    internal OpenAIAccountFeature Account { get; set; } = default!;

    /// <summary>
    /// Creates client connection for the resource.
    /// </summary>
    /// <param name="cmId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ClientConnection CreateConnection(string cmId)
    {
        ClientConnection connection = new("Azure.AI.OpenAI.AzureOpenAIClient", $"https://{cmId}.openai.azure.com", ClientAuthenticationMethod.Credential);
        return connection;
    }
    /// <summary>
    /// Emit the feature.
    /// </summary>
    /// <param name="features"></param>
    /// <param name="cmId"></param>
    protected override void EmitFeatures(FeatureCollection features, string cmId)
    {
        // TODO: is it OK that we return the first one?

        if (!features.TryGet(out OpenAIAccountFeature? openAI))
        {
            openAI = new OpenAIAccountFeature();
            features.Append(openAI);
        }

        Account = openAI!;
    }

    /// <summary>
    /// Emit the resources.
    /// </summary>
    /// <param name="infrastructure"></param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    protected override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        string name = Kind switch
        {
            AIModelKind.Chat => $"{infrastructure.ProjectId}_chat",
            AIModelKind.Embedding => $"{infrastructure.ProjectId}_embedding",
            _ => throw new NotImplementedException()
        };

        CognitiveServicesAccount parent = infrastructure.GetConstruct<CognitiveServicesAccount>(Account.Id);

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

        // deployments need to have DependsOn property set!
        OpenAIModelFeature? previous = FindPrevious(infrastructure, this);
        if (previous != null)
        {
            CognitiveServicesAccountDeployment previousDeployment = infrastructure.GetConstruct<CognitiveServicesAccountDeployment>(previous.Id);
            deployment.DependsOn.Add(previousDeployment);
        }

        infrastructure.AddConstruct(Id, deployment);

        string key = Kind == AIModelKind.Chat ? "OpenAI.Chat.ChatClient" : "OpenAI.Embeddings.EmbeddingClient";
        string locator = Kind == AIModelKind.Chat ? $"{infrastructure.ProjectId}_chat" : $"{infrastructure.ProjectId}_embedding";
        EmitConnections(infrastructure, key, locator);

        OpenAIModelFeature? FindPrevious(ProjectInfrastructure cm, OpenAIModelFeature current)
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

/// <summary>
/// OpenAI feature for Azure OpenAI.
/// </summary>
public class OpenAIChatFeature : OpenAIModelFeature
{
    /// <summary>
    /// Create a new OpenAI chat model deployment.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="modelVersion"></param>
    public OpenAIChatFeature(string model, string modelVersion)
        : base(model, modelVersion)
    {
    }
}

/// <summary>
/// OpenAI feature for Azure OpenAI.
/// </summary>
public class OpenAIEmbeddingFeature : OpenAIModelFeature
{
    /// <summary>
    /// Create a new OpenAI embedding model deployment.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="modelVersion"></param>
    public OpenAIEmbeddingFeature(string model, string modelVersion)
        : base(model, modelVersion, AIModelKind.Embedding)
    {
    }
}
