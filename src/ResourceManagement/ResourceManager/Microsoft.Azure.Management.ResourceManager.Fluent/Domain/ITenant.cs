// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{

    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Management.ResourceManager.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure tenant.
    /// </summary>
    public interface ITenant  :
        IIndexable,
        IHasInner<TenantIdDescription>
    {
        /// <returns>a UUID of the tenant</returns>
        string TenantId { get; }

    }
}