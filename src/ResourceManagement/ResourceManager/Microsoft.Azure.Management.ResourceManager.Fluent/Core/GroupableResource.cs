﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using System;
using System.Text;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    /// <summary>
    /// Implementation of IGroupableResource.
    /// </summary>
    /// The implementation for IGroupableResource.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent wrapper interface for the resource</typeparam>
    /// <typeparam name="InnerResourceT">The autorest generated resource</typeparam>
    /// <typeparam name="FluentResourceT">The implementation for fluent wrapper interface</typeparam>
    /// <typeparam name="ManagerT"></typeparam
    /// <typeparam name="IDefintionAfterRegion">The definition stage to continue after defining the region</typeparam>
    /// <typeparam name="IDefintionAfterResourceGroup">The definition stage to continue after defining the resource gorup</typeparam>
    public abstract class GroupableResource<IFluentResourceT,
        InnerResourceT,
        FluentResourceT,
        ManagerT,
        IDefinitionAfterRegion,
        IDefinitionAfterResourceGroup,
        DefTypeWithTags,
        UTypeWithTags> :
        ResourceBase<IFluentResourceT, InnerResourceT, FluentResourceT, IDefinitionAfterRegion, DefTypeWithTags, UTypeWithTags>,
        IGroupableResource<ManagerT>
        where FluentResourceT : GroupableResource<IFluentResourceT,
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
        protected ICreatable<IResourceGroup> newGroup;
        private string groupName;

        protected GroupableResource(string key, InnerResourceT innerObject, ManagerT manager) :base(key, innerObject)
        {
            Manager = manager;
        }

        public ManagerT Manager { get; private set; }

        protected string ResourceIdBase
        {
            get
            {
                return new StringBuilder()
                .Append("/subscriptions/").Append(Manager.SubscriptionId)
                .Append("/resourceGroups/").Append(ResourceGroupName).ToString();
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

        public IDefinitionAfterResourceGroup WithNewResourceGroup()
        {
            return WithNewResourceGroup(this.Name + "group");
        }

        public IDefinitionAfterResourceGroup WithNewResourceGroup(string groupName)
        {
            ICreatable<IResourceGroup> creatable = Manager
                .ResourceManager
                .ResourceGroups
                .Define(groupName)
                .WithRegion(RegionName);
            return WithNewResourceGroup(creatable);
        }

        public IDefinitionAfterResourceGroup WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            groupName = creatable.Name;
            newGroup = creatable;
            AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this as IDefinitionAfterResourceGroup;
        }

        public IDefinitionAfterResourceGroup WithExistingResourceGroup(String groupName)
        {
            this.groupName = groupName;
            return this as IDefinitionAfterResourceGroup;
        }

        public IDefinitionAfterResourceGroup WithExistingResourceGroup(IResourceGroup group)
        {
            return WithExistingResourceGroup(group.Name);
        }

        public IDefinitionAfterResourceGroup WithNewResourceGroup(string name, Region region)
        {
            return this.WithNewResourceGroup(Manager.ResourceManager.ResourceGroups.Define(name).WithRegion(region));
        }

        public IDefinitionAfterResourceGroup WithNewResourceGroup(Region region)
        {
            return this.WithNewResourceGroup(this.Name + "group", region);
        }

        #endregion
    }
}
