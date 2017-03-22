// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// The local root resource that is used as dummy parent resource for the batch creatable resources
    /// added via <see cref="ISupportsBatchCreation{IFluentResourceT}.CreateAsync(ICreatable{IFluentResourceT}[])">
    /// </summary>
    /// <typeparam name="IFluentResourceT">the type of resources in the batch</typeparam>
    internal interface ICreatableUpdatableResourcesRoot<IFluentResourceT> : IHasId
        where IFluentResourceT : IHasId
    {
        IEnumerable<IFluentResourceT> CreatedTopLevelResources();
        IHasId CreatedRelatedResource(string key);
    }
}
