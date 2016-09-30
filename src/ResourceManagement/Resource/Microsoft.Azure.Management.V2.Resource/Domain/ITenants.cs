// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Resource
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;

    /// <summary>
    /// Entry point to tenant management API.
    /// </summary>
    public interface ITenants  :
        ISupportsListing<ITenant>
    {
    }
}