// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class AppConfigurationSpecification() :
    Specification("AppConfiguration", typeof(AppConfigurationExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<AppConfigurationPrivateEndpointConnectionReference>("ResourceType");

        // Patch models
        CustomizeProperty<AppConfigurationStoreApiKey>("Value", p => p.IsSecure = true);
        CustomizeProperty<AppConfigurationStoreApiKey>("ConnectionString", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<AppConfigurationStoreResource>(min: 5, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<AppConfigurationReplicaResource>(min: 1, max: 50, lower: true, upper: true, digits: true);

        // Roles
        Roles.Add(new Role("AppConfigurationDataOwner", "5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b", "Allows full access to App Configuration data."));
        Roles.Add(new Role("AppConfigurationDataReader", "516239f1-63e1-4d78-a4de-a74fb236a071", "Allows read access to App Configuration data."));

        // Assign Roles
        CustomizeResource<AppConfigurationStoreResource>(r => r.GenerateRoleAssignment = true);
    }
}
