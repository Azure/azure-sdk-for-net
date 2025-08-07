// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.AppContainers;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class AppContainersSpecification() :
    Specification("AppContainers", typeof(AppContainersExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ContainerAppManagedEnvironmentResource>("SkuName");
        RemoveProperty<ContainerAppResource>("WorkloadProfileType");
        RemoveProperty<ContainerAppResource>("OutboundIPAddresses");
        RemoveProperty<ContainerAppVnetConfiguration>("RuntimeSubnetId");
        RemoveProperty<ContainerAppVnetConfiguration>("OutboundSettings");
        RemoveProperty<ContainerAppWorkloadProfile>("MinimumCount");
        RemoveProperty<ContainerAppWorkloadProfile>("MaximumCount");
        RemoveProperty<ContainerAppRegistryInfo>("RegistryUri");
        RemoveModel<AppContainersSkuName>();
        RemoveModel<ContainerAppManagedEnvironmentOutboundSettings>();

        // Patch models
        CustomizeModel<Affinity>(m => m.Name = "StickySessionAffinity");

        // Naming requirements
        AddNameRequirements<ContainerAppResource>(min: 2, max: 32, lower: true, upper: true, digits: true, hyphen: true);

        // Copying over a few of the standard roles because we don't have
        // anything custom for AppContainers
        Roles.Add(new Role("Contributor", "b24988ac-6180-42a0-ab88-20f7382dd24c", "Grants full access to manage all resources, but does not allow you to assign roles in Azure RBAC, manage assignments in Azure Blueprints, or share image galleries."));
        Roles.Add(new Role("Owner", "8e3af657-a8ff-443c-a75c-2fe8c4bcb635", "Grants full access to manage all resources, including the ability to assign roles in Azure RBAC."));
        Roles.Add(new Role("Reader", "acdd72a7-3385-48ef-bd42-f606fba81ae7", "View all resources, but does not allow you to make any changes."));

        // Assign Roles
        CustomizeResource<ContainerAppManagedEnvironmentResource>(r => r.GenerateRoleAssignment = true);
    }
}
