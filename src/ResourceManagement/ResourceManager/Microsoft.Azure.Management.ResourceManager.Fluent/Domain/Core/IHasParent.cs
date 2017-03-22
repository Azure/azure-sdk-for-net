// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// An interface representing a child resource model that exposes its parent.
    /// </summary>
    /// <typeparam name="ParentT">the parent type</typeparam>
    public interface IHasParent<ParentT>
    {
        /// <summary>
        /// Gets the parent of this child resource.
        /// </summary>
        ParentT Parent { get; }
    }
}
