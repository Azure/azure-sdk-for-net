/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core
{

    /// <summary>
    /// Base interface for resources in resource groups.
    /// </summary>
    public interface IGroupableResource  :
        IResource
    {
        /// <returns>the name of the resource group</returns>
        string ResourceGroupName { get; }

    }
}