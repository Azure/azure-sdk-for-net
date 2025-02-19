// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Projects.AIFoundry;

/// <summary>
/// Simple no-op resource that satisfies the base class contract without actually deploying anything.
/// </summary>
internal sealed class NoOpResource : ProvisionableResource
{
    public NoOpResource()
        : base(bicepIdentifier: "noOpFoundry", resourceType: new Azure.Core.ResourceType("No Op"))
    {
        // no-op
    }
}
