// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;

namespace Azure.Projects;

/// <summary>
/// Represents the OpenAI account feature for Azure projects.
/// </summary>
internal class OpenAIAccountFeature : AzureProjectFeature
{
    /// <summary>
    /// Represents a feature or capability associated with an OpenAI account.
    /// </summary>
    public OpenAIAccountFeature(CognitiveServicesSku? sku = default)
    {
        Sku = sku ?? new CognitiveServicesSku { Name = "S0" };
    }

    /// <summary>
    /// Gets or sets the SKU (Stock Keeping Unit) for the Cognitive Services resource.
    /// </summary>
    public CognitiveServicesSku Sku { get; set; }

    /// <summary>
    /// emits the features for the OpenAI account.
    /// </summary>
    /// <param name="infrastructure"></param>
    protected override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        CognitiveServicesAccount cognitiveServices = new("openai")
        {
            Name = infrastructure.ProjectId,
            Kind = "OpenAI",
            Sku = Sku,
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

        EmitConnection(infrastructure, "Azure.AI.OpenAI.AzureOpenAIClient", $"https://{infrastructure.ProjectId}.openai.azure.com");
    }
}
