// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure AD group.
    /// </summary>
    public interface IActiveDirectoryGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ADGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ActiveDirectoryGroup.Update.IUpdate>
    {
        /// <summary>
        /// Lists the members in the group.
        /// </summary>
        /// <return>An unmodifiable set of the members.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject> ListMembers();

        /// <summary>
        /// Gets mail field.
        /// </summary>
        string Mail { get; }

        /// <summary>
        /// Gets security enabled field.
        /// </summary>
        bool SecurityEnabled { get; }

        /// <summary>
        /// Lists the members in the group.
        /// </summary>
        /// <return>An unmodifiable set of the members.</return>
        Task<IPagedCollection<IActiveDirectoryObject>> ListMembersAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}