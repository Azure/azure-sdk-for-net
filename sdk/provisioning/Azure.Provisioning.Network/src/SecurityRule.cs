// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class SecurityRule
{
    /// <summary>
    /// Creates a new SecurityRule as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public SecurityRule() : base("securityRules", "Microsoft.Network/networkSecurityGroups/securityRules")
    {
    }
}
