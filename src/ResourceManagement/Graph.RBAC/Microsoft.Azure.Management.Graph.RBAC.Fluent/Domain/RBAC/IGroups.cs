// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition;
    /// <summary>
    /// Entry point to AD group management API.
    /// </summary>
    public interface IGroups  :
        ISupportsCreating<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>,
        ISupportsDeletingById
    {
        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup GetByObjectId(string objectId);

        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="displayNamePrefix">displayNamePrefix the partial prefix of the display name to search</param>
        /// <returns>an immutable representation of the resource</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> SearchByDisplayName(string displayNamePrefix);

    }
}