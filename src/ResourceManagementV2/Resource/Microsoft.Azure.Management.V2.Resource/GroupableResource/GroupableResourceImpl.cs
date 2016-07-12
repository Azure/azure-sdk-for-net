using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;

namespace Microsoft.Azure.Management.V2.Resource.GroupableResource
{
    public abstract class GroupableResourceImpl<IFluentResourceT, InnerResourceT, FluentResourceT> :
        ResourceBase<IFluentResourceT, InnerResourceT, FluentResourceT>,
        IGroupableResource
        where FluentResourceT : GroupableResourceImpl<IFluentResourceT, InnerResourceT, FluentResourceT>
        where IFluentResourceT : class
        where InnerResourceT : class
    {
        protected ICreatable<IResourceGroup> newGroup;
        private string groupName;

        protected GroupableResourceImpl(string key, InnerResourceT innerObject) :base(key, innerObject)
        {}

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

        public FluentResourceT WithNewResourceGroup()
        {
            return WithNewResourceGroup(this.Name + "group");
        }

        public FluentResourceT WithNewResourceGroup(string groupName)
        {
            this.groupName = groupName;
            return this as FluentResourceT;
        }

        public FluentResourceT WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            groupName = creatable.Key;
            newGroup = creatable;
            AddCreatableDependency(creatable as ICreatable<IResource>);
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
    }
}
