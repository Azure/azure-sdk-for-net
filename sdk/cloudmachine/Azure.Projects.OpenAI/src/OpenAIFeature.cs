// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;
using System.ClientModel.Primitives;

namespace Azure.Projects.OpenAI;

internal class OpenAIFeature : AzureProjectFeature
{
    public OpenAIFeature()
    { }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        CognitiveServicesAccount cognitiveServices = CreateOpenAIAccount(infrastructure);
        infrastructure.AddResource(cognitiveServices);

        FeatureRole openAIContributor =  new(
            CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor),
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString()
        );
        RequiredSystemRoles.Add(cognitiveServices, [openAIContributor]);

        return cognitiveServices;
    }

    protected override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
    {
        ClientConnection connection = new("Azure.AI.OpenAI.AzureOpenAIClient", $"https://{cmId}.openai.azure.com", ClientAuthenticationMethod.Credential);

        if (!connections.Contains(connection))
        {
            connections.Add(connection);
        }
    }
    internal void EmitConnectionsInternal(ICollection<ClientConnection> connections, string cmId)
        => EmitConnections(connections, cmId);

    internal static CognitiveServicesAccount CreateOpenAIAccount(ProjectInfrastructure cm)
    {
        return new("openai")
        {
            Name = cm.ProjectId,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = cm.ProjectId
            },
        };
    }
}
