// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Diagnostics.CodeAnalysis;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary>
/// Subnet.
/// </summary>
[SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "This name has be to Subnet")]
public partial class Subnet
{
    /// <summary>
    /// Creates a new Subnet as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public Subnet() : base("subnet", "Microsoft.Network/virtualNetworks/subnets") // TODO -- the bicepIdentifier here cannot be empty, do we need some mechanism to allow that?
    {
    }
}
