// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;

namespace Azure.Projects.OpenAI;

internal class OpenAIAccountFeature : AzureProjectFeature
{
    public OpenAIAccountFeature()
    {}

    protected override void EmitConstructs(ProjectInfrastructure infrastructure)
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

        infrastructure.AddConstruct(Id, cognitiveServices);

        infrastructure.AddSystemRole(
            cognitiveServices,
            CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor),
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor.ToString()
        );

        EmitConnections(infrastructure, "Azure.AI.OpenAI.AzureOpenAIClient", $"https://{infrastructure.ProjectId}.openai.azure.com");
    }
}
