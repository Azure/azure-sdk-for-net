// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// Base class for creatable resource collection, i.e.those where the member of the collection is of Resource
    /// type <see cref="IResource"> and are creatable.
    /// (Internal use only)
    /// </summary>
    /// <typeparam name="IFluentResourceT"></typeparam>
    /// <typeparam name="FluentResourceT"></typeparam>
    /// <typeparam name="InnerResourceT"></typeparam>
    public abstract class CreatableResources<IFluentResourceT, FluentResourceT, InnerResourceT> :
        CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsBatchCreation<IFluentResourceT>
        where IFluentResourceT : class, IResource
        where FluentResourceT : IFluentResourceT
    {
        public ICreatedResources<IFluentResourceT> Create(params ICreatable<IFluentResourceT>[] creatables)
        {
            return CreateAsync(creatables).Result;
        }

        public async Task<ICreatedResources<IFluentResourceT>> CreateAsync(params ICreatable<IFluentResourceT>[] creatables)
        {
            CreatableUpdatableResourcesRoot<IFluentResourceT> rootResource = new CreatableUpdatableResourcesRoot<IFluentResourceT>();
            rootResource.AddCreatableDependencies(creatables);
            var creatableUpdatableResourcesRoot = await rootResource.CreateAsync(CancellationToken.None);
            return new CreatedResources<IFluentResourceT>(creatableUpdatableResourcesRoot);
        }
    }
}
