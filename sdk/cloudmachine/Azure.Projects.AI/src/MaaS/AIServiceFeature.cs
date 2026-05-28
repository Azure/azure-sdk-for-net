// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;

namespace Azure.Projects;

/// <summary>
/// AIServices feature.
/// </summary>
public class AIModelsFeature : AzureProjectFeature
{
    private string _model;
    private string _modelVersion;

    /// <summary>
    /// Creates a new instance of the AIServices feature.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="modelVersion"></param>
    public AIModelsFeature(string model, string modelVersion)
    {
        _model = model;
        _modelVersion = modelVersion;
    }

    /// <summary>
    /// Adds the feature to the project infrastructure.
    /// </summary>
    /// <param name="infrastructure"></param>
    protected override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        CognitiveServicesAccount cognitiveServices = new("aiservices")
        {
            Name = infrastructure.ProjectId,
            Kind = "AIServices",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = infrastructure.ProjectId,
                DisableLocalAuth = true,
                NetworkAcls = new CognitiveServicesNetworkRuleSet()
                {
                    DefaultAction = CognitiveServicesNetworkRuleAction.Allow
                },
            },
        };

        CognitiveServicesAccountDeployment deployment = new($"aimodel", "2024-06-01-preview")
        {
            Parent = cognitiveServices,
            Name = $"{infrastructure.ProjectId}_chat",
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel()
                {
                    Name = _model,
                    Format = "DeepSeek",
                    Version = _modelVersion
                },
                VersionUpgradeOption = DeploymentModelVersionUpgradeOption.OnceNewDefaultVersionAvailable,
                RaiPolicyName = "Microsoft.DefaultV2",
            },
            Sku = new CognitiveServicesSku
            {
                Capacity = 1,
                Name = "GlobalStandard"
            },
        };

        infrastructure.AddConstruct(Id, cognitiveServices);
        infrastructure.AddConstruct(Id + "_deployment", deployment);

        infrastructure.AddSystemRole(
            cognitiveServices,
            CognitiveServicesBuiltInRole.GetBuiltInRoleName(CognitiveServicesBuiltInRole.CognitiveServicesContributor),
            CognitiveServicesBuiltInRole.CognitiveServicesContributor.ToString()
        );

        EmitConnection(infrastructure, "Azure.AI.Models.ModelsClient", $"https://{infrastructure.ProjectId}.services.ai.azure.com/models");
    }
}
