using System;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// The local root resource that is used as dummy parent resource for the batch creatable resources
    /// added via <see cref="ISupportsBatchCreation{IFluentResourceT}.CreateAsync(ICreatable{IFluentResourceT}[])">
    /// </summary>
    /// <typeparam name="IFluentResourceT">the type of resources in the batch</typeparam>
    internal interface ICreatableUpdatableResourcesRoot<IFluentResourceT> : IResource
        where IFluentResourceT : IResource
    {
        IEnumerable<IFluentResourceT> createdTopLevelResources();
        IResource CreatedRelatedResource(string key);
    }
}
