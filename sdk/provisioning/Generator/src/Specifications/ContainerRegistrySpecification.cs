// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class ContainerRegistrySpecification() :
    Specification("ContainerRegistry", typeof(ContainerRegistryExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ContainerRegistryPrivateEndpointConnectionData>("ResourceType");
        RemoveProperty<ContainerRegistryRunData>("ResourceType");

        // Patch models
        CustomizeResource<ContainerRegistryResource>(r => r.Name = "ContainerRegistryService");
        CustomizeSimpleModel<ContainerRegistryDockerBuildStep>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "Docker"; });
        CustomizeSimpleModel<ContainerRegistryEncodedTaskStep>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "EncodedTask"; });
        CustomizeSimpleModel<ContainerRegistryFileTaskStep>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "FileTask"; });
        CustomizeSimpleModel<ContainerRegistryDockerBuildContent>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "DockerBuildRequest"; });
        CustomizeSimpleModel<ContainerRegistryEncodedTaskRunContent>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "EncodedTaskRunRequest"; });
        CustomizeSimpleModel<ContainerRegistryFileTaskRunContent>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "FileTaskRunRequest"; });
        CustomizeSimpleModel<ContainerRegistryTaskRunContent>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "TaskRunRequest"; });
        CustomizeProperty<ConnectedRegistryResource>("Parent", p => p.Name = "ConnectedRegistryParent");

        // Naming requirements
        AddNameRequirements<ContainerRegistryResource>(min: 5, max: 50, lower: true, upper: true, digits: true);
        AddNameRequirements<ContainerRegistryReplicationResource>(min: 5, max: 50, lower: true, upper: true, digits: true);
        AddNameRequirements<ScopeMapResource>(min: 5, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<ContainerRegistryTaskResource>(min: 5, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<ContainerRegistryTokenResource>(min: 5, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<ContainerRegistryWebhookResource>(min: 5, max: 50, lower: true, upper: true, digits: true);

        // Roles
        Roles.Add(new Role("AcrDelete", "c2f4ef07-c644-48eb-af81-4b1b4947fb11", "Delete repositories, tags, or manifests from a container registry."));
        Roles.Add(new Role("AcrImageSigner", "6cef56e8-d556-48e5-a04f-b8e64114680f", "Push trusted images to or pull trusted images from a container registry enabled for content trust."));
        Roles.Add(new Role("AcrPull", "7f951dda-4ed3-4680-a7ca-43fe172d538d", "Pull artifacts from a container registry."));
        Roles.Add(new Role("AcrPush", "8311e382-0749-4cb8-b61a-304f252e45ec", "Push artifacts to or pull artifacts from a container registry."));
        Roles.Add(new Role("AcrQuarantineReader", "cdda3590-29a3-44f6-95f2-9f980659eb04", "Pull quarantined images from a container registry."));
        Roles.Add(new Role("AcrQuarantineWriter", "c8d4ff99-41c3-41a8-9f60-21dfdad59608", "Push quarantined images to or pull quarantined images from a container registry."));

        // Assign Roles
        CustomizeResource<ContainerRegistryResource>(r => r.GenerateRoleAssignment = true);
    }
}
