// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{

    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Base interface used by child resources.
    /// </summary>
    public interface IChildResource<IParentT> :
        IHasName,
        IIndexable,
        IHasParent<IParentT>
    {
    }
}