// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    /// <summary>
    /// Entry point to network interface management.
    /// </summary>
    public interface INetworkInterfaces  :
        ISupportsCreating<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>
    {
    }
}