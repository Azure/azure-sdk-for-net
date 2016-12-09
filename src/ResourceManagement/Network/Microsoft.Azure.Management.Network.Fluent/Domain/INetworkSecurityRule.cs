// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A network security rule in a network security group.
    /// </summary>
    public interface INetworkSecurityRule :
        IWrapper<Models.SecurityRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>
    {
        string DestinationAddressPrefix { get; }

        string Protocol { get; }

        string Access { get; }

        string SourcePortRange { get; }

        string SourceAddressPrefix { get; }

        string DestinationPortRange { get; }

        string Description { get; }

        int Priority { get; }

        string Direction { get; }
    }
}