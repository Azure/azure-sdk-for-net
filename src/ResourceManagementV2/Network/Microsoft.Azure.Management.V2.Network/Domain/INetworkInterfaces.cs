/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    /// <summary>
    /// Entry point to network interface management.
    /// </summary>
    public interface INetworkInterfaces  :
        ISupportsCreating<IBlank>,
        ISupportsListing<INetworkInterface>,
        ISupportsListingByGroup<INetworkInterface>,
        ISupportsGettingByGroup<INetworkInterface>,
        ISupportsGettingById<INetworkInterface>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}