// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using IndependentChild.Definition;
    using ResourceActions;

    /// <summary>
    /// Implementation for the child resource which can be CRUDed independently from the parent resource.
    /// (internal use only).
    /// </summary>
    /// <typeparam name="FluentModel">The fluent model type.</typeparam>
    /// <typeparam name="FluentParentModel">The fluent model for parent resource.</typeparam>
    /// <typeparam name="InnerModel">Azure inner resource class type.</typeparam>
    /// <typeparam name="FluentModelImpl">The implementation type of the fluent model type.</typeparam>
    public abstract class IndependentChildImpl<IFluentResourceT, FluentParentModelT, InnerResourceT, FluentResourceT, IResourceT, IUpdatableT>  :
        CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT, IUpdatableT>,
        IIndependentChild,
        IWithParentResource<IFluentResourceT, FluentParentModelT>
        where IResourceT : class
        where IUpdatableT : class
        where IFluentResourceT : class, IResourceT
        where FluentResourceT : class
        where FluentParentModelT: class, IGroupableResource
    {
        private string groupName;
        protected string parentName;
        private string creatableParentResourceKey;

        /// <summary>
        /// Getters.
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                if (groupName == null) {
                    return ResourceUtils.GroupFromResourceId(Id);
                } else {
                    return groupName;
                }
            }
        }

        public abstract string Id { get; }

        public ICreatable<IFluentResourceT> WithNewParentResource(ICreatable<FluentParentModelT> parentResourceCreatable)
        {
            if (creatableParentResourceKey == null) {
                creatableParentResourceKey = parentResourceCreatable.Key;
                AddCreatableDependency(parentResourceCreatable as IResourceCreator<IResourceT>);
            }
            return this;
        }

        public override void SetInner(InnerResourceT inner)
        {
            SetParentName(inner);
            base.SetInner(inner);
        }

        /// <return><tt>true</tt> if currently in define..create mode.</return>
        public bool IsInCreateMode()
        {
            return Id == null;
        }

        protected abstract Task<IFluentResourceT> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken));

        protected virtual void SetParentName(InnerResourceT inner)
        {
            if (this.Id != null)
            {
                this.parentName = ResourceId.ParseResourceId(this.Id).Parent.Name;
            }
        }

        public async override Task<IFluentResourceT> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (creatableParentResourceKey != null) {
                FluentParentModelT parentResource = CreatedResource(creatableParentResourceKey) as FluentParentModelT;
                WithExistingParentResource(parentResource);
            }
            return await CreateChildResourceAsync();
        }

        /// <summary>
        /// Creates a new instance of IndependentChildResourceImpl.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="innerObject">The inner object.</param>
        protected  IndependentChildImpl(string name, InnerResourceT innerObject)
            : base(name, innerObject)
        {

        }

        public ICreatable<IFluentResourceT> WithExistingParentResource(string groupName, string parentName)
        {
            this.groupName = groupName;
            this.parentName = parentName;

            return this;
        }

        public virtual ICreatable<IFluentResourceT> WithExistingParentResource(FluentParentModelT existingParentResource)
        {
            return WithExistingParentResource(existingParentResource.ResourceGroupName, existingParentResource.Name);
        }
    }
}