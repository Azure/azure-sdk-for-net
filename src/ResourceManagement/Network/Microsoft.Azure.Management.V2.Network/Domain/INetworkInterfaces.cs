// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition;
    /// <summary>
    /// Entry point to network interface management.
    /// </summary>
    public interface INetworkInterfaces  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>
    {
    }
}