// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public abstract class ExternalChildResourcesCached<FluentModelTImpl, IFluentModelT, InnerModelT, IParentT, ParentImplT> :
        ExternalChildResourceCollection<FluentModelTImpl, IFluentModelT, InnerModelT, IParentT, ParentImplT>
        where ParentImplT : IParentT
        where IFluentModelT : IExternalChildResource<IFluentModelT, IParentT>
        where FluentModelTImpl : ExternalChildResource<IFluentModelT, InnerModelT, IParentT, ParentImplT>, IFluentModelT
    {
        /// <summary>
        /// Creates a new ExternalChildResourcesCached.
        /// </summary>
        /// <param name="parent">the parent Azure resource</param>
        /// <param name="childResourceName">the child resource name</param>
        protected ExternalChildResourcesCached(ParentImplT parent, string childResourceName) : base(parent, childResourceName)
        {
        }

        /// <returns>the child resource collection as a read-only dictionary.</returns>
        protected IDictionary<string, FluentModelTImpl> Collection
        {
            get
            {
                return new ReadOnlyDictionary<string, FluentModelTImpl>(this.collection);
            }
        }

        /// <summary>
        /// Refresh the collection.
        /// </summary>
        public void Refresh()
        {
            CacheCollection();
        }

        /// <summary>
        /// Prepare for definition of a new external child resource.
        /// </summary>
        /// <param name="name">the name for the new external child resource</param>
        /// <returns>the child resource</returns>
        protected FluentModelTImpl PrepareDefine(string name)
        {
            return PrepareDefine(name, name);
        }

        /// <summary>
        /// Prepare for definition of a new external child resource.
        /// </summary>
        /// <param name="name">the name for the new external child resource</param>
        /// <param name="key">the key for the new external child resource</param>
        /// <returns>the child resource</returns>
        protected FluentModelTImpl PrepareDefine(string name, string key)
        {
            if (Find(key) != null)
            {
                throw new ArgumentException(string.Format("A child resource ('{0}') with name (key) '{1} ({2})' already exists", childResourceName, name, key));
            }
            FluentModelTImpl childResource = NewChildResource(key);
            childResource.PendingOperation = PendingOperation.ToBeCreated;
            return childResource;
        }

        /// <summary>
        /// Prepare for an external child resource update.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        /// <returns>the external child resource to be updated</returns>
        protected FluentModelTImpl PrepareUpdate(string name)
        {
            return PrepareUpdate(name, name);
        }

        /// <summary>
        /// Prepare for an external child resource update.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        /// <param name="key">the key for the external child resource</param>
        /// <returns>the external child resource to be updated</returns>
        protected FluentModelTImpl PrepareUpdate(string name, string key)
        {
            FluentModelTImpl childResource = Find(key);
            if (childResource == null
                    || childResource.PendingOperation == PendingOperation.ToBeCreated)
            {
                throw new ArgumentException(string.Format("A child resource ('{0}') with name  with name (key) '{1} ({2})' not found", childResourceName, name, key));
            }
            if (childResource.PendingOperation == PendingOperation.ToBeRemoved)
            {
                throw new ArgumentException(string.Format("A child resource ('{0}') with name (key) '{1} ({2})' is marked for deletion", childResourceName, name, key));
            }
            childResource.PendingOperation = PendingOperation.ToBeUpdated;
            return childResource;
        }

        /// <summary>
        /// Mark an external child resource with given name as to be removed.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        protected void PrepareRemove(string name)
        {
            PrepareRemove(name, name);
        }

        /// <summary>
        /// Mark an external child resource with given name as to be removed.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        /// <param name="key">the key for the external child resource</param>
        protected void PrepareRemove(string name, string key)
        {
            FluentModelTImpl childResource = Find(key);
            if (childResource == null
                    || childResource.PendingOperation == PendingOperation.ToBeCreated)
            {
                throw new ArgumentException(string.Format("A child resource ('{0}') with name  with name (key) '{1} ({2})' not found", childResourceName, name, key));
            }
            childResource.PendingOperation = PendingOperation.ToBeRemoved;
        }

        /// <summary>
        /// Adds an external child resource to the collection.
        /// </summary>
        /// <param name="childResource">childResource the external child resource</param>
        protected void AddChildResource(FluentModelTImpl childResource)
        {
            this.collection.AddOrUpdate(childResource.ChildResourceKey,
                key => childResource,
                (string key, FluentModelTImpl oldVal) => { return childResource; });
        }

        /// <summary>
        /// Initializes the external child resource collection.
        /// </summary>
        protected void CacheCollection()
        {
            this.collection.Clear();
            foreach (FluentModelTImpl childResource in this.ListChildResources())
            {
                this.collection.AddOrUpdate(childResource.ChildResourceKey, 
                    key => childResource, 
                    (string key, FluentModelTImpl oldVal) => { return childResource;});
            }
        }

        protected override bool ClearAfterCommit()
        {
            return false;
        }

        /// <summary>
        /// Gets the list of external child resources.
        /// </summary>
        /// <returns>the list of external child resources</returns>
        protected abstract IList<FluentModelTImpl> ListChildResources();

        /// <summary>
        /// Gets a new external child resource model instance.
        /// </summary>
        /// <param name="name">the name for the new child resource</param>
        /// <returns>the new child resource</returns>
        protected abstract FluentModelTImpl NewChildResource(string name);
    }
}
