// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
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

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        string name = (Name == null) ? infrastructure.ProjectId : Name;
        var rg = new ResourceGroup(name, ResourceGroup.ResourceVersions.V2023_07_01);
        infrastructure.AddConstruct(Id, rg);
    }
}
