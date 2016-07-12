using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;

namespace Microsoft.Azure.Management.V2.Resource.GroupableResource
{
    /// 
    /// <summary>
    /// The implementation for IGroupableResource.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent wrapper interface for the resource</typeparam>
    /// <typeparam name="InnerResourceT">The autorest generated resource</typeparam>
    /// <typeparam name="InnerResourceBaseT">The autorest generated base class from which InnerResourceT inherits</typeparam>
    /// <typeparam name="FluentResourceT">The implementation for fluent wrapper interface</typeparam>
    /// <typeparam name="ManagerT"></typeparam>
    public abstract class GroupableResourceImpl<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT, ManagerT> :
        ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT>,
        IGroupableResource
        where FluentResourceT : GroupableResourceImpl<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT, ManagerT>, IFluentResourceT
        where ManagerT : ManagerBase
        where IFluentResourceT : class, IResource
        where InnerResourceBaseT: class
        where InnerResourceT : class, InnerResourceBaseT
    {
        protected ICreatable<IResourceGroup> newGroup;
        private string groupName;
        private ManagerT manager;

        protected GroupableResourceImpl(string key, InnerResourceT innerObject, ManagerT manager) :base(key, innerObject)
        {
            this.manager = manager;
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
                return null; // TODO
            }
        }

        #endregion

        #region Fluent Setters [Implementation of GroupableResource.Definition interfaces]

        public FluentResourceT WithNewResourceGroup()
        {
            return WithNewResourceGroup(this.Name + "group");
        }

        public FluentResourceT WithNewResourceGroup(string groupName)
        {
            ICreatable<IResourceGroup> creatable = manager
                .ResourceManager
                .ResourceGroups
                .Define(groupName)
                .WithRegion(RegionName);
            return WithNewResourceGroup(creatable);
        }

        public FluentResourceT WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            groupName = creatable.Key;
            newGroup = creatable;
            AddCreatableDependency(creatable as IResourceCreator);
            return this as FluentResourceT;
        }

        public FluentResourceT WithExistingResourceGroup(String groupName)
        {
            this.groupName = groupName;
            return this as FluentResourceT; 
        }

        public FluentResourceT WithExistingResourceGroup(IResourceGroup group)
        {
            return this.WithExistingResourceGroup(group.Name);
        }

        #endregion
    }
}
