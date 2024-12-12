// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.OpenAI;

internal class OpenAIFeature : CloudMachineFeature
{
    public OpenAIFeature()
    { }

    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cloudMachine)
    {
        CognitiveServicesAccount cognitiveServices = CreateOpenAIAccount(cloudMachine);
        cloudMachine.AddResource(cognitiveServices);

        RequiredSystemRoles.Add(cognitiveServices, [(CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor) ,CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString())]);

        return cognitiveServices;
    }

    protected override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        ClientConnection connection = new("Azure.AI.OpenAI.AzureOpenAIClient", $"https://{cmId}.openai.azure.com");

        if (!connections.Contains(connection))
        {
            connections.Add(connection);
        }
    }
    internal void EmitConnectionsInternal(ConnectionCollection connections, string cmId)
        => EmitConnections(connections, cmId);

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
