// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Implementation of <see cref="ICreatableUpdatableResourcesRoot{IFluentResourceT}">
    /// </summary>
    /// <typeparam name="IFluentResourceT">the type of resources in the batch</typeparam>
    /// <typeparam name="InnerResourceT">the type of inner resource that IFluentResourceT wraps</typeparam>
    internal class CreatableUpdatableResourcesRoot<IFluentResourceT, InnerResourceT> :
        CreatableUpdatable<ICreatableUpdatableResourcesRoot<IFluentResourceT>,
            InnerResourceT,
            CreatableUpdatableResourcesRoot<IFluentResourceT, InnerResourceT>,
            IHasId,
            object>,
        IHasId,
        ICreatableUpdatableResourcesRoot<IFluentResourceT>
        where IFluentResourceT : class, IHasId
    {
        private List<string> keys;

        internal CreatableUpdatableResourcesRoot() : base("CreatableUpdatableResourcesRoot", default(InnerResourceT))
        {
            this.keys = new List<string>();
        }

        internal void AddCreatableDependencies(params ICreatable<IFluentResourceT>[] creatables)
        {
            foreach (ICreatable<IFluentResourceT> item in creatables)
            {
                this.keys.Add(item.Key);
                this.AddCreatableDependency(item as IResourceCreator<IHasId>);
            }
        }

        public IHasId CreatedRelatedResource(string key)
        {
            return this.CreatorTaskGroup.CreatedResource(key);
        }

        public IEnumerable<IFluentResourceT> CreatedTopLevelResources()
        {
            List<IFluentResourceT> resources = new List<IFluentResourceT>();
            foreach (string resourceKey in keys)
            {
                resources.Add((IFluentResourceT)this.CreatorTaskGroup.CreatedResource(resourceKey));
            }
            return new ReadOnlyCollection<IFluentResourceT>(resources);
        }

        public override Task<ICreatableUpdatableResourcesRoot<IFluentResourceT>> CreateResourceAsync(CancellationToken cancellationToken)
        {
            TaskCompletionSource<ICreatableUpdatableResourcesRoot<IFluentResourceT>> tcs = new TaskCompletionSource<ICreatableUpdatableResourcesRoot<IFluentResourceT>>();
            tcs.SetResult(this as ICreatableUpdatableResourcesRoot<IFluentResourceT>);
            return tcs.Task;
        }

        #region IndexableRefreshable.Refresh empty Impl 
        public override ICreatableUpdatableResourcesRoot<IFluentResourceT> Refresh()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IHasId empty Impl
        public string Id
        {
            get
            {
                return null;
            }
        }
        #endregion
    }
}
