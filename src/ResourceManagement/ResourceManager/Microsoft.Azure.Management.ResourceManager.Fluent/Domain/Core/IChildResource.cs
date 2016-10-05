// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;

    /// <summary>
    /// Base interface used by child resources.
    /// </summary>
    public interface IChildResource<IParentT> :
        IIndexable
    {
        /// <returns>the name of the child resource</returns>
        string Name { get; }

        IParentT Parent { get; }
    }
}