// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// An interface representing a model that exposes a management client.
    /// </summary>
    /// <typeparam name="ManagerT">the manager client type</typeparam>
    public interface IHasManager<ManagerT>
    {
        /// <summary>
        /// Gets the manager client type of this resource type.
        /// </summary>
        ManagerT Manager { get; }
    }
}
