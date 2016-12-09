// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for network resource usage management API.
    /// </summary>
    public interface INetworkUsages :
        ISupportsListingByRegion<Microsoft.Azure.Management.Network.Fluent.INetworkUsage>
    {
    }
}