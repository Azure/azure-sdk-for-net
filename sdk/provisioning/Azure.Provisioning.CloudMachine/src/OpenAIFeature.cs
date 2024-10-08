// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.OpenAI;
using Azure.CloudMachine;
using Azure.Provisioning.CognitiveServices;
using OpenAI.Chat;

namespace Azure.Provisioning.CloudMachine.OpenAI;

public class OpenAIFeature : CloudMachineFeature
{
    public string Model { get; }
    public string ModelVersion { get; }

    public OpenAIFeature(string model, string modelVersion) {  Model = model; ModelVersion = modelVersion; }

    public override void AddTo(CloudMachineInfrastructure cm)
    {
        CognitiveServicesAccount cs = new("openai", "2023-05-01")
        {
            Name = cm.Id,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled
            }
        };

        CognitiveServicesAccountDeployment deployment = new("openai_deployment", "2023-05-01")
        {
            Parent = cs,
            Name = cm.Id,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel() {
                    Name = this.Model,
                    Format = "OpenAI",
                    Version = this.ModelVersion
                }
            }
        };

        cm.AddResource(cs);
        cm.AddResource(deployment);
    }
}

public static class OpenAIFeatureExtensions
{
    public static ChatClient GetOpenAIClient(this CloudMachineClient cm)
    {
        ChatClient client = cm.ClientCache.Get("aiai_chat", () =>
        {
            AzureOpenAIClient sb = cm.ClientCache.Get("aoai", () =>
            {
                Uri endpoint = new("https://eastus.api.cognitive.microsoft.com/");
                AzureOpenAIClient aoai = new(endpoint, cm.Credential);
                return aoai;
            });

            ChatClient chat = sb.GetChatClient(cm.Id);
            return chat;
        });

        return client;
    }
}
