// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT, IUpdatableT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT>, 
        ICreatable<IFluentResourceT>, 
        IUpdatable<IUpdatableT>
        where IFluentResourceT: class, IResourceT
        where FluentResourceT: class
        where IResourceT: class
        where IUpdatableT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) 
            : base(name, innerObject)
        {
        }
        
        public virtual IUpdatableT Update()
        {
            return this as IUpdatableT;
        }
        
        public IFluentResourceT Apply()
        {
            return Extensions.Synchronize(() =>  ApplyAsync(CancellationToken.None, true));
        }

        public virtual async Task<IFluentResourceT> ApplyAsync(
            CancellationToken cancellationToken = default(CancellationToken), 
            bool multiThreaded = true)
        {
            return await CreateAsync(cancellationToken, multiThreaded);
        }

    }
}
