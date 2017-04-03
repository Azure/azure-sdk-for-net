// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    /// <summary>
    /// Providing access to creating a batch of Azure top level resources of same type.
    /// </summary>
    /// <typeparam name="IFluentResourceT">the top level Azure resource type</typeparam>
    public interface ISupportsBatchCreation<IFluentResourceT>
        where IFluentResourceT : IHasId
    {
        /// <summary>
        /// Creates a set (batch) of resources.
        /// </summary>
        /// <param name="creatables">the creatables in the batch</param>
        /// <returns></returns>
        ICreatedResources<IFluentResourceT> Create(IEnumerable<ICreatable<IFluentResourceT>> creatables);

        /// <summary>
        /// Creates a set (batch) of resources.
        /// </summary>
        /// <param name="creatables">the creatables in the batch</param>
        ICreatedResources<IFluentResourceT> Create(params ICreatable<IFluentResourceT>[] creatables);

        /// <summary>
        /// Creates a set (batch) of resources.
        /// </summary>
        /// <param name="creatables">the creatables in the batch</param>
        /// <returns></returns>
        Task<ICreatedResources<IFluentResourceT>> CreateAsync(
            IEnumerable<ICreatable<IFluentResourceT>> creatables,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
