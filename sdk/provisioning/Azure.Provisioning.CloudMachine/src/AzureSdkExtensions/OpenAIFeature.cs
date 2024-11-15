// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;

namespace Azure.CloudMachine.OpenAI;

internal class OpenAIFeature : CloudMachineFeature
{
    public OpenAIFeature()
    {
    }

    public override void AddTo(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = CreateAccount(cloudMachine);
        cloudMachine.AddResource(cognitiveServices);

        cloudMachine.AddResource(cognitiveServices.CreateRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            cloudMachine.PrincipalIdParameter)
        );
    }

    internal CognitiveServicesAccount CreateAccount(CloudMachineInfrastructure cm)
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
