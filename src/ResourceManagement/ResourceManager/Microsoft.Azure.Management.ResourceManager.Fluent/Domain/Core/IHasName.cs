// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// An interface representing a model that has a name.
    /// </summary>
    public interface IHasName
    {
        /// <summary>
        /// Gets the name of the resource
        /// </summary>
        string Name { get; }
    }
}
