// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{

    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Threading.Tasks;
    /// <summary>
    /// The implementation for {@link GroupableResource}.
    /// (Internal use only)
    /// 
    /// @param <FluentModelT> The fluent model type
    /// @param <InnerModelT> Azure inner resource class type
    /// @param <FluentModelImplT> the implementation type of the fluent model type
    /// @param <ManagerT> the service manager type
    /// </summary>
    public abstract partial class GroupableParentResource<IFluentResourceT,
        InnerResourceT,
        FluentResourceT,
        ManagerT,
        IDefinitionAfterRegion,
        IDefinitionAfterResourceGroup,
        DefTypeWithTags,
        UTypeWithTags> :
        GroupableResource<IFluentResourceT,
            InnerResourceT,
            FluentResourceT,
            ManagerT,
            IDefinitionAfterRegion,
            IDefinitionAfterResourceGroup,
            DefTypeWithTags,
            UTypeWithTags>
        where FluentResourceT : GroupableParentResource<IFluentResourceT,
            InnerResourceT,
            FluentResourceT,
            ManagerT,
            IDefinitionAfterRegion,
            IDefinitionAfterResourceGroup,
            DefTypeWithTags,
            UTypeWithTags>, IFluentResourceT
        where ManagerT : IManagerBase
        where IFluentResourceT : class, IResource
        where InnerResourceT : Microsoft.Azure.Management.Resource.Fluent.Resource
        where IDefinitionAfterRegion : class
        where IDefinitionAfterResourceGroup : class
        where DefTypeWithTags : class
        where UTypeWithTags : class

    {
        protected  GroupableParentResource (string name, InnerResourceT innerObject, ManagerT manager) : base(name, innerObject, manager)
        {
            InitializeChildrenFromInner();
        }

        protected abstract Task<InnerResourceT> CreateInner();

        protected abstract void InitializeChildrenFromInner ();

        protected abstract void BeforeCreating ();

        protected abstract void AfterCreating ();

        public override async Task<IFluentResourceT> CreateResourceAsync(CancellationToken cancellationToken)
        {
            BeforeCreating();
            var inner = await CreateInner();
            SetInner(inner);
            InitializeChildrenFromInner();
            AfterCreating();
            return (FluentResourceT) this;
        }
    }
}