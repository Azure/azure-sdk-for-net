// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using RouteTable.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for route table management.
    /// </summary>
    public interface IRouteTable :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        IWrapper<Models.RouteTableInner>,
        IUpdatable<RouteTable.Update.IUpdate>,
        IHasAssociatedSubnets
    {
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IRoute> Routes { get; }
    }
}