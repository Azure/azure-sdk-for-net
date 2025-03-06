// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.AppConfiguration;
using Azure.Provisioning.Primitives;
using System.ClientModel.Primitives;

namespace Azure.Projects.KeyVault;

public class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    {
    }

    protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
    {
        ClientConnection connection = new(
            "Azure.Data.AppConfiguration.ConfigurationClient",
            $"https://{cmId}.azconfig.io",
            ClientAuthenticationMethod.Credential
        );

        connections.Add(connection);
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore appConfigResource = new("cm_app_config")
        {
            Name = infrastructure.ProjectId,
            SkuName = "Free",
        };
        infrastructure.AddResource(appConfigResource);

        FeatureRole appConfigAdmin = new(AppConfigurationBuiltInRole.GetBuiltInRoleName(AppConfigurationBuiltInRole.AppConfigurationDataOwner), AppConfigurationBuiltInRole.AppConfigurationDataOwner.ToString());
        RequiredSystemRoles.Add(appConfigResource, [appConfigAdmin]);

        return appConfigResource;
    }
}
