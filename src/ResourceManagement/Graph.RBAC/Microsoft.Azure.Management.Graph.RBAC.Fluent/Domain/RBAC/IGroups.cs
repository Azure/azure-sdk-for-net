// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to AD group management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IGroups  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ActiveDirectoryGroup.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById
    {
        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="objectId">The unique object id.</param>
        /// <return>An immutable representation of the resource.</return>
        /// <throws>CloudException exceptions thrown from the cloud.</throws>
        /// <throws>IOException exceptions thrown from serialization/deserialization.</throws>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup GetByObjectId(string objectId);

        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="displayNamePrefix">The partial prefix of the display name to search.</param>
        /// <return>An immutable representation of the resource.</return>
        /// <throws>CloudException exceptions thrown from the cloud.</throws>
        /// <throws>IOException exceptions thrown from serialization/deserialization.</throws>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> SearchByDisplayName(string displayNamePrefix);
    }
}