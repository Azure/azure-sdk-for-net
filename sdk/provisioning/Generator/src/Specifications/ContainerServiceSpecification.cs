// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ContainerService;
using Azure.ResourceManager.ContainerService.Models;
using Generator.Model;

namespace Azure.Provisioning.Generator.Specifications;

public class ContainerServiceSpecification() :
    Specification("ContainerService", typeof(ContainerServiceExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ContainerServiceAgentPoolResource>("UpgradeMaxSurge");
        RemoveProperty<ContainerServiceManagedClusterResource>("Identity");
        RemoveProperty<ContainerServiceManagedClusterResource>("SecurityAzureDefender");
        RemoveProperty<ContainerServiceManagedClusterResource>("UpgradeChannel");
        RemoveProperty<ManagedClusterAgentPoolProfile>("UpgradeMaxSurge");
        RemoveProperty<ContainerServiceNetworkProfile>("DockerBridgeCidr");
        RemoveModel<ManagedClusterSecurityProfileAzureDefender>();

        // Patch models
        CustomizeProperty<ManagedClusterIdentity>("PrincipalId", p => p.Path = ["principalId"]);
        CustomizeProperty<ManagedClusterIdentity>("TenantId", p => p.Path = ["tenantId"]);
        CustomizeProperty<ManagedClusterIdentity>("ResourceIdentityType", p => p.Path = ["type"]);
        CustomizeProperty<ManagedClusterIdentity>("UserAssignedIdentities", p => p.Path = ["userAssignedIdentities"]);
        CustomizeProperty<ManagedClusterIdentity>("DelegatedResources", p => p.Path = ["delegatedResources"]);
        // these properties are incorrectly hidden in mgmt SDK
        CustomizeProperty<ManagedClusterStorageProfile>("IsDiskCsiDriverEnabled", p => { p.HideLevel = PropertyHideLevel.DoNotHide; p.Path = ["diskCSIDriver", "enabled"]; });
        CustomizeProperty<ManagedClusterStorageProfile>("IsFileCsiDriverEnabled", p => { p.HideLevel = PropertyHideLevel.DoNotHide; p.Path = ["fileCSIDriver", "enabled"]; });
        CustomizeProperty<ManagedClusterStorageProfile>("IsSnapshotControllerEnabled", p => { p.HideLevel = PropertyHideLevel.DoNotHide; p.Path = ["snapshotController", "enabled"]; });
        CustomizeProperty<ManagedClusterStorageProfile>("IsBlobCsiDriverEnabled", p => { p.HideLevel = PropertyHideLevel.DoNotHide; p.Path = ["blobCSIDriver", "enabled"]; });

        // Naming requirements
        AddNameRequirements<ContainerServiceManagedClusterResource>(min: 1, max: 63, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<ContainerServiceAgentPoolResource>(min: 1, max: 12, lower: true, digits: true);

        // Roles
        Roles.Add(new Role("AzureKubernetesServiceClusterAdminRole", "0ab0b1a8-8aac-4efd-b8c2-3ee1fb270be8", "List cluster admin credential action."));
        Roles.Add(new Role("AzureKubernetesServiceClusterMonitoringUser", "1afdec4b-e479-420e-99e7-f82237c7c5e6", "List cluster monitoring user credential action."));
        Roles.Add(new Role("AzureKubernetesServiceClusterUserRole", "4abbcc35-e782-43d8-92c5-2d3f1bd2253f", "List cluster user credential action."));
        Roles.Add(new Role("AzureKubernetesServiceContributorRole", "ed7f3fbd-7b88-4dd4-9017-9adb7ce333f8", "Grants access to read and write Azure Kubernetes Service clusters"));
        Roles.Add(new Role("AzureKubernetesServiceRbacAdmin", "3498e952-d568-435e-9b2c-8d77e338d7f7", "Lets you manage all resources under cluster/namespace, except update or delete resource quotas and namespaces."));
        Roles.Add(new Role("AzureKubernetesServiceRbacClusterAdmin", "b1ff04bb-8a4e-4dc4-8eb5-8693973ce19b", "Lets you manage all resources in the cluster."));
        Roles.Add(new Role("AzureKubernetesServiceRbacReader", "7f6c6a51-bcf8-42ba-9220-52d62157d7db", "Allows read-only access to see most objects in a namespace. It does not allow viewing roles or role bindings. This role does not allow viewing Secrets, since reading the contents of Secrets enables access to ServiceAccount credentials in the namespace, which would allow API access as any ServiceAccount in the namespace (a form of privilege escalation). Applying this role at cluster scope will give access across all namespaces."));
        Roles.Add(new Role("AzureKubernetesServiceRbacWriter", "a7ffa36f-339b-4b5c-8bdf-e2c188b2c0eb", "Allows read/write access to most objects in a namespace. This role does not allow viewing or modifying roles or role bindings. However, this role allows accessing Secrets and running Pods as any ServiceAccount in the namespace, so it can be used to gain the API access levels of any ServiceAccount in the namespace. Applying this role at cluster scope will give access across all namespaces."));

        // Assign Roles
        CustomizeResource<ContainerServiceManagedClusterResource>(r => r.GenerateRoleAssignment = true);
    }
}
