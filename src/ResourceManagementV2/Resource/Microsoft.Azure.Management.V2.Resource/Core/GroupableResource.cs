using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;

namespace Microsoft.Azure.Management.V2.Resource
{
    /// <summary>
    /// Implementation of IGroupableResource.
    /// </summary>
    /// The implementation for IGroupableResource.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent wrapper interface for the resource</typeparam>
    /// <typeparam name="InnerResourceT">The autorest generated resource</typeparam>
    /// <typeparam name="InnerResourceBaseT">The autorest generated base class from which InnerResourceT inherits</typeparam>
    /// <typeparam name="FluentResourceT">The implementation for fluent wrapper interface</typeparam>
    /// <typeparam name="ManagerT"></typeparam
    /// <typeparam name="IDefintionAfterRegion">The definition stage to continue after defining the region</typeparam>
    /// <typeparam name="IDefintionAfterResourceGroup">The definition stage to continue after defining the resource gorup</typeparam>
    public abstract class GroupableResource<IFluentResourceT,
        InnerResourceT,
        InnerResourceBaseT,
        FluentResourceT,
        ManagerT,
        IDefintionAfterRegion,
        IDefintionAfterResourceGroup,
        DefTypeWithTags,
        UTypeWithTags> :
        ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT, IDefintionAfterRegion, DefTypeWithTags, UTypeWithTags>,
        IGroupableResource
        where FluentResourceT : GroupableResource<IFluentResourceT,
            InnerResourceT,
            InnerResourceBaseT,
            FluentResourceT,
            ManagerT,
            IDefintionAfterRegion,
            IDefintionAfterResourceGroup,
            DefTypeWithTags, 
            UTypeWithTags>, IFluentResourceT
        where ManagerT : IManagerBase
        where IFluentResourceT : class, IResource
        where InnerResourceBaseT: class
        where InnerResourceT : class, InnerResourceBaseT
        where IDefintionAfterRegion : class
        where IDefintionAfterResourceGroup : class
        where DefTypeWithTags : class
        where UTypeWithTags : class
    {
        protected ICreatable<IResourceGroup> newGroup;
        private string groupName;
        private ManagerT manager;

        protected GroupableResource(string key, InnerResourceT innerObject, ManagerT manager) :base(key, innerObject)
        {
            this.manager = manager;
        }

        public ManagerT MyManager
        {
            get
            {
                return this.manager;
            }
        }

        #region Getters [Implementation of IGroupableResource]

        public string ResourceGroupName
        {
            get
            {
                if (groupName != null)
                {
                    return groupName;
                }
                return ResourceUtils.GroupFromResourceId(Id);
            }
        }

        #endregion

        #region Fluent Setters [Implementation of GroupableResource.Definition interfaces]

        public IDefintionAfterResourceGroup WithNewResourceGroup()
        {
            return WithNewResourceGroup(this.Name + "group");
        }

        public IDefintionAfterResourceGroup WithNewResourceGroup(string groupName)
        {
            ICreatable<IResourceGroup> creatable = manager
                .ResourceManager
                .ResourceGroups
                .Define(groupName)
                .WithRegion(RegionName);
            return WithNewResourceGroup(creatable);
        }

        public IDefintionAfterResourceGroup WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            groupName = creatable.Key;
            newGroup = creatable;
            AddCreatableDependency(creatable as IResourceCreator<IResource>);
            return this as IDefintionAfterResourceGroup;
        }

        public IDefintionAfterResourceGroup WithExistingResourceGroup(String groupName)
        {
            this.groupName = groupName;
            return this as IDefintionAfterResourceGroup; 
        }

        public IDefintionAfterResourceGroup WithExistingResourceGroup(IResourceGroup group)
        {
            return WithExistingResourceGroup(group.Name);
        }

        #endregion
    }
}
