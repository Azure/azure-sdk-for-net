// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class ServiceEndpointPolicyDefinition
{
    /// <summary>
    /// Creates a new ServiceEndpointPolicyDefinition as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public ServiceEndpointPolicyDefinition() : base("serviceEndpointPolicyDefinitions", "Microsoft.Network/serviceEndpointPolicies/serviceEndpointPolicyDefinitions")
    {
    }
}
