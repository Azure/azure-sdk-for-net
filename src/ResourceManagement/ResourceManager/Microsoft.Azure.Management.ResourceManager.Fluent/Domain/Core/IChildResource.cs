// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// Base interface used by child resources.
    /// </summary>
    public interface IChildResource<IParentT> :
        IHasName,
        IIndexable
    {
        IParentT Parent { get; }
    }
}