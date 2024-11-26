// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.OpenAI;

internal class OpenAIFeature : CloudMachineFeature
{
    private List<OpenAIModel> _models = new List<OpenAIModel>();

    public OpenAIFeature()
    { }

    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = CreateOpenAIAccount(cloudMachine);
        cloudMachine.AddResource(cognitiveServices);

        RequiredSystemRoles.Add(cognitiveServices, [(CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor) ,CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString())]);

        Emitted = cognitiveServices;

        OpenAIModel? previous = null;
        foreach (OpenAIModel model in _models)
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

    internal void AddModel(OpenAIModel model)
    {
        if (model.Account != null)
        {
            throw new InvalidOperationException("Model already added to an account");
        }
        model.Account = this;
        _models.Add(model);
    }

    internal CognitiveServicesAccount CreateOpenAIAccount(CloudMachineInfrastructure cm)
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
