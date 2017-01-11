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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlc291cmNlcy5mbHVlbnRjb3JlLmFybS5tb2RlbHMuaW1wbGVtZW50YXRpb24uSW5kZXBlbmRlbnRDaGlsZEltcGw=
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

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:013BEEE1EB764D0E60EA1404992DA8D6
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

        ///GENMHASH:EFF5318E694B2A3BB5AEF7CA70DB29A5:7DCE188EC97FDEB5705826627CBEE021
        public ICreatable<IFluentResourceT> WithNewParentResource(ICreatable<FluentParentModelT> parentResourceCreatable)
        {
            if (creatableParentResourceKey == null) {
                creatableParentResourceKey = parentResourceCreatable.Key;
                AddCreatableDependency(parentResourceCreatable as IResourceCreator<IResourceT>);
            }
            return this;
        }

        ///GENMHASH:A2D6BF9298981588EEA8EC974E6AAB23:FF6621A0603EDECD42898228D2095D33
        public override void SetInner(InnerResourceT inner)
        {
            base.SetInner(inner);
            SetParentName(inner);
        }

        /// <return><tt>true</tt> if currently in define..create mode.</return>
        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:03A19677BFD2A2B4663A9345FE12C501
        public bool IsInCreateMode()
        {
            return Id == null;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<IFluentResourceT> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:E0086A72B4AEDDC8DA00BE9AF9B4C9F4:C4A562F786B0A39A4E03ADCFFA1A1FD8
        protected virtual void SetParentName(InnerResourceT inner)
        {
            if (this.Id != null)
            {
                this.parentName = ResourceId.FromString(this.Id).Parent.Name;
            }
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:6D8EE54225EBDB9ED59F76D4F478809E
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

        ///GENMHASH:1617CE892A84D9A577A083793AD878B1:FC7DBEE598C27F6B6A66D7C91DB5A9D3
        public ICreatable<IFluentResourceT> WithExistingParentResource(string groupName, string parentName)
        {
            this.groupName = groupName;
            this.parentName = parentName;

            return this;
        }

        ///GENMHASH:FFF0419E47F38B054FDA7E0468915FAD:5533CF175D46262F51B186E746948D9B
        public virtual ICreatable<IFluentResourceT> WithExistingParentResource(FluentParentModelT existingParentResource)
        {
            return WithExistingParentResource(existingParentResource.ResourceGroupName, existingParentResource.Name);
        }
    }
}
