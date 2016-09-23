// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure tenant.
    /// </summary>
    public interface ITenant  :
        IIndexable,
        IWrapper<TenantIdDescription>
    {
        /// <returns>a UUID of the tenant</returns>
        string TenantId { get; }

    }
}