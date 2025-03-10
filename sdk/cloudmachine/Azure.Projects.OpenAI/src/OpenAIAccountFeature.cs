// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.OpenAI;

internal class OpenAIAccountFeature : AzureProjectFeature
{
    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        CognitiveServicesAccount cognitiveServices = new("openai")
        {
            Name = infrastructure.ProjectId,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = infrastructure.ProjectId
            },
        };

        infrastructure.AddConstruct(cognitiveServices);

        infrastructure.AddSystemRole(
            cognitiveServices,
            CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor),
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString()
        );

        EmitConnection(infrastructure, "Azure.AI.OpenAI.AzureOpenAIClient", $"https://{infrastructure.ProjectId}.openai.azure.com");

        return cognitiveServices;
    }
}
