// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Base class for creatable resource collection, i.e.those where the member of the collection is of Resource
    /// type <see cref="IResource"> and are creatable.
    /// </summary>
    /// <typeparam name="IFluentResourceT">the fluent resource interface</typeparam>
    /// <typeparam name="FluentResourceT">the fluent resource implementation</typeparam>
    /// <typeparam name="InnerResourceT">the type that fluent resource wraps</typeparam>
    public abstract class CreatableResources<IFluentResourceT, FluentResourceT, InnerResourceT> 
        : CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsBatchCreation<IFluentResourceT>
        where IFluentResourceT : class, IHasId
        where FluentResourceT : IFluentResourceT
    {

        public ICreatedResources<IFluentResourceT> Create(params ICreatable<IFluentResourceT>[] creatables)
        {
            return Create(creatables as IEnumerable<ICreatable<IFluentResourceT>>);
        }

        public ICreatedResources<IFluentResourceT> Create(IEnumerable<ICreatable<IFluentResourceT>> creatables)
        {
            return Extensions.Synchronize(() => CreateAsync(creatables));
        }

        public async Task<ICreatedResources<IFluentResourceT>> CreateAsync(
            IEnumerable<ICreatable<IFluentResourceT>> creatables,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var rootResource = new CreatableUpdatableResourcesRoot<IFluentResourceT, InnerResourceT>();
            rootResource.AddCreatableDependencies(creatables);
            var creatableUpdatableResourcesRoot = await rootResource.CreateAsync(cancellationToken);
            return new CreatedResources<IFluentResourceT>(creatableUpdatableResourcesRoot);
        }
    }
}
