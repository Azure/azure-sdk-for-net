// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.CloudMachine;
using Azure.Provisioning.CognitiveServices;

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
            Kind = "AIServices",
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
    public static object GetOpenAIClient(this CloudMachineClient client)
    {
        throw new NotImplementedException();
        //return new(new($"https://{client.Id}.vault.azure.net/"), client.Credential);
    }
}
