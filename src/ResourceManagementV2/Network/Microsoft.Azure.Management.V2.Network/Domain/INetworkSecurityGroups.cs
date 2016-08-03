/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    /// <summary>
    /// Entry point to network security group management.
    /// </summary>
    public interface INetworkSecurityGroups  :
        ISupportsCreating<IBlank>,
        ISupportsListing<INetworkSecurityGroup>,
        ISupportsListingByGroup<INetworkSecurityGroup>,
        ISupportsGettingByGroup<INetworkSecurityGroup>,
        ISupportsGettingById<INetworkSecurityGroup>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}