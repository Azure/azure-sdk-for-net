// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{

    /// <summary>
    /// Base interface for resources in resource groups.
    /// </summary>
    public interface IGroupableResource<ManagerT, InnerT>  :
        IResource, IHasResourceGroup, IHasManager<ManagerT>, IHasInner<InnerT>
    {
       
    }
}