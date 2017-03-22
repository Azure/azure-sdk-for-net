// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{

    /// <summary>
    /// An interface representing a model that has an Id.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Gets the resource id string
        /// </summary>
        string Id { get; }
    }
}
