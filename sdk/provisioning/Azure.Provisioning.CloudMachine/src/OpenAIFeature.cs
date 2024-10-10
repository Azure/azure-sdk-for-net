// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
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
            AzureOpenAIClient aoia = cm.ClientCache.Get("aoai", () =>
            {
                Uri endpoint = new("https://mochiai.openai.azure.com/");
                var clientOptions = new AzureOpenAIClientOptions();
                clientOptions.AddPolicy(new LoggingPolicy(), PipelinePosition.BeforeTransport);
                string key = Environment.GetEnvironmentVariable("openai_cm_key");
                //AzureOpenAIClient aoai = new(endpoint, new System.ClientModel.ApiKeyCredential(key), op);
                AzureOpenAIClient aoai = new(endpoint, cm.Credential, clientOptions);
                return aoai;
            });

            ChatClient chat = aoia.GetChatClient("gpt-4");
            return chat;
        });

        return client;
    }
}
