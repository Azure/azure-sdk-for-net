// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class ServiceEndpointPolicy
{
    /// <summary>
    /// Creates a new ServiceEndpointPolicy as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public ServiceEndpointPolicy() : base("serviceEndpointPolicies", "Microsoft.Network/serviceEndpointPolicies")
    {
    }
}
