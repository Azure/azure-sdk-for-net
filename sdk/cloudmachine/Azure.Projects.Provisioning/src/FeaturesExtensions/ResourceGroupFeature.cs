// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Projects;

/// <summary>
/// Simple no-op resource that satisfies the base class contract without actually deploying anything.
/// </summary>
internal sealed class ResourceGroupFeature : AzureProjectFeature
{
    public ResourceGroupFeature(string? name = default)
    {
        Name = name;
    }

    public string? Name { get; }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
    {
        string name = (Name == null) ? cm.ProjectId : Name;
        var rg = new ResourceGroup(name);
        cm.AddConstruct(rg);
        return rg;
    }
}
