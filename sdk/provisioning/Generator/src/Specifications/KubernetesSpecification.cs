// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Kubernetes;

namespace Azure.Provisioning.Generator.Specifications;

public class KubernetesSpecification() :
    Specification("Kubernetes", typeof(KubernetesExtensions))
{
    protected override void Customize()
    {
        // Naming requirements
        AddNameRequirements<ConnectedClusterResource>(min: 1, max: 63, lower: true, upper: true, digits: true, hyphen: true, underscore: true);

        // Roles
        Roles.Add(new Role("KubernetesClusterAzureArcOnboarding", "34e09817-6cbe-4d01-b1a2-e0eac5743d41", "Role definition to authorize any user/service to create connectedClusters resource"));

        // Assign Roles
        CustomizeResource<ConnectedClusterResource>(r => r.GenerateRoleAssignment = true);
    }
}
