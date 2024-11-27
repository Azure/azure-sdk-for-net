// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.OpenAI;

internal class OpenAIFeature : CloudMachineFeature
{
    private readonly List<OpenAIModelFeature> _models = [];

    public OpenAIFeature()
    { }

    protected override ProvisionableResource EmitInfrastructure(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = CreateOpenAIAccount(cloudMachine);
        cloudMachine.AddConstruct(cognitiveServices);

        RequiredSystemRoles.Add(cognitiveServices, [(CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor) ,CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString())]);

        Emitted = cognitiveServices;

        OpenAIModelFeature? previous = null;
        foreach (OpenAIModelFeature model in _models)
        {
            model.Emit(cloudMachine);
            if (previous != null)
            {
                model.Emitted.DependsOn.Add(previous.Emitted);
            }
            previous = model;
        }

        return cognitiveServices;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        ClientConnection connection = new("Azure.AI.OpenAI.AzureOpenAIClient", $"https://{cmId}.openai.azure.com");

        if (!connections.Contains(connection))
        {
            connections.Add(connection);
        }
    }

    internal void AddModel(OpenAIModelFeature model)
    {
        if (model.Account != null)
        {
            throw new InvalidOperationException("Model already added to an account");
        }
        model.Account = this;
        _models.Add(model);
    }

    internal static CognitiveServicesAccount CreateOpenAIAccount(CloudMachineInfrastructure cm)
    {
        return new("openai")
        {
            Name = cm.Id,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = cm.Id
            },
        };
    }
}
