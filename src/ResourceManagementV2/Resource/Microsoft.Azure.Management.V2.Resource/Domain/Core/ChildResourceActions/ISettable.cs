/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions
{

    /// <summary>
    /// The base interface for all template interfaces for child resources that support
    /// update operations.
    /// 
    /// @param <ParentT> the parent definition {@link Settable#parent()} returns to
    /// </summary>
    public interface ISettable<ParentT> 
    {
        /// <summary>
        /// Begins an update for a child resource.
        /// <p>
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is {@link Settable#parent()}.
        /// </summary>
        /// <returns>the stage of  parent resource update</returns>
        ParentT Parent ();

    }
}