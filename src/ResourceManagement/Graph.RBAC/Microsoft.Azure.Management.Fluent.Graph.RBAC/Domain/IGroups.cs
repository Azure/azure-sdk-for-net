// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.ActiveDirectoryGroup.Definition;
    using System.Collections.Generic;
    /// <summary>
    /// Entry point to AD group management API.
    /// </summary>
    public interface IGroups  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Graph.RBAC.ActiveDirectoryGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Graph.RBAC.IActiveDirectoryGroup>,
        ISupportsDeleting
    {
        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        IActiveDirectoryGroup GetByObjectId (string objectId);

        /// <summary>
        /// Gets the information about a group.
        /// </summary>
        /// <param name="displayNamePrefix">displayNamePrefix the partial prefix of the display name to search</param>
        /// <returns>an immutable representation of the resource</returns>
        IList<Microsoft.Azure.Management.Fluent.Graph.RBAC.IActiveDirectoryGroup> SearchByDisplayName (string displayNamePrefix);

    }
}