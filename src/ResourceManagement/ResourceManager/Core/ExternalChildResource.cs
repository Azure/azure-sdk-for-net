// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Externalized child resource abstract implementation.
    /// In order to be eligible for an external child resource following criteria must be satisfied:
    /// 1. It's is always associated with a parent resource and has no existence without parent
    /// i.e. if you delete parent then child resource will be deleted automatically.
    /// 2. Parent may or may not contain collection of child resources (i.e. as inline collection property).
    /// It's has an ID and can be created, updated, fetched and deleted independent of the parent
    /// i.e.CRUD on child resource does not require CRUD on the parent
    /// (Internal use only)
    /// </summary>
    /// <typeparam name="FluentModelT">the external child resource fluent interface</typeparam>
    /// <typeparam name="InnerModelT">Azure inner resource class type representing the child resource</typeparam>
    /// <typeparam name="IParentT">parent fluent interface</typeparam>
    /// <typeparam name="ParentImplT">parent resource implementation type</typeparam>
    public abstract class ExternalChildResource<FluentModelT,
        InnerModelT,
        IParentT,
        ParentImplT> : ChildResource<InnerModelT, ParentImplT, IParentT>, IRefreshable<FluentModelT>
        where FluentModelT : class, IExternalChildResource<FluentModelT, IParentT>
        where ParentImplT : IParentT
    {
        private readonly string name;

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">the name of this external child resource</param>
        /// <param name="parent">reference to the parent of this external child resource</param>
        /// <param name="innerObject">reference to the inner object representing this external child resource</param>
        public ExternalChildResource(string name, ParentImplT parent, InnerModelT innerObject) : base(innerObject, parent)
        {
            this.name = name;
            this.PendingOperation = PendingOperation.None;
        }

        public override string Name()
        {
            return this.name;
        }

        /// <returns>the in-memory state of this child resource and state represents any pending action on the child resource.</returns>
        public PendingOperation PendingOperation
        {
            get; internal set;
        }

        /// <returns>key of this child resource in the collection maintained by ExternalChildResourceCollectionImpl
        public virtual string ChildResourceKey
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Creates this external child resource.
        /// </summary>
        /// <returns>the task to track the create action</returns>
        public abstract Task<FluentModelT> CreateAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates this external child resource.
        /// </summary>
        /// <returns>the task to track the update action</returns>
        public abstract Task<FluentModelT> UpdateAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Deletes this external child resource.
        /// </summary>
        /// <returns>the task to track the delete action</returns>
        public abstract Task DeleteAsync(CancellationToken cancellationToken);

        public virtual FluentModelT Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        public virtual async Task<FluentModelT> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            this.SetInner(inner);
            return this as FluentModelT;
        }

        protected abstract Task<InnerModelT> GetInnerAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// The possible states of a child resource in-memory.
    /// </summary>
    public enum PendingOperation
    {
        /// <summary>
        /// No action needs to be taken on resource.
        /// </summary>
        None,

        /// <summary>
        /// Child resource required to be created.
        /// </summary>
        ToBeCreated,

        /// <summary>
        /// Child resource required to be updated.
        /// </summary>
        ToBeUpdated,

        /// <summary>
        /// Child resource required to be deleted.
        /// </summary>
        ToBeRemoved
    }
}
