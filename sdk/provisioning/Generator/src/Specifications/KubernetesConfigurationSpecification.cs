// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.KubernetesConfiguration;

namespace Azure.Provisioning.Generator.Specifications;

public class KubernetesConfigurationSpecification() :
    Specification("KubernetesConfiguration", typeof(KubernetesConfigurationExtensions))
{
    protected override void Customize()
    {
        // Naming requirements
        Roles.Add(new Role("AzureContainerStorageContributor", "95dd08a6-00bd-4661-84bf-f6726f83a4d0", "Install Azure Container Storage and manage its storage resources. Includes an ABAC condition to constrain role assignments."));
        Roles.Add(new Role("AzureContainerStorageOperator", "08d4c71a-cc63-4ce4-a9c8-5dd251b4d619", "Enable a managed identity to perform Azure Container Storage operations, such as manage virtual machines and manage virtual networks."));
        Roles.Add(new Role("AzureContainerStorageOwner", "95de85bd-744d-4664-9dde-11430bc34793", "Install Azure Container Storage, grant access to its storage resources, and configure Azure Elastic storage area network (SAN). Includes an ABAC condition to constrain role assignments."));
        Roles.Add(new Role("KubernetesExtensionContributor", "85cb6faf-e071-4c9b-8136-154b5a04f717", "Can create, update, get, list and delete Kubernetes Extensions, and get extension async operations"));

        // Assign Roles
        CustomizeResource<KubernetesClusterExtensionResource>(r => r.GenerateRoleAssignment = true);
        CustomizeResource<KubernetesFluxConfigurationResource>(r => r.GenerateRoleAssignment = true);
    }
}
