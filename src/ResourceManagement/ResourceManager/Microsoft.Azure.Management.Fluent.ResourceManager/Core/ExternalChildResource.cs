// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    /// <summary>
    /// Externalized child resource abstract implementation.
    /// Inorder to be eligible for an external child resource following criteria must be satisfied:
    /// 1. It's is always associated with a parent resource and has no existence without parent
    /// i.e. if you delete parent then child resource will be deleted automatically.
    /// 2. Parent will contain collection of child resources. this is not a hard requirement.
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
        ParentImplT> : ChildResource<InnerModelT, ParentImplT, IParentT>
        where FluentModelT : IExternalChildResource<FluentModelT, IParentT>
        where ParentImplT : IParentT
    {
        private readonly string name;

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">the name of this external child resource</param>
        /// <param name="parent">reference to the parent of this external child resource</param>
        /// <param name="innerObject">reference to the inner object representing this external child resource</param>
        public ExternalChildResource(string name, ParentImplT parent, InnerModelT innerObject) : base(name, innerObject, parent)
        {
            this.name = name;
            this.PendingOperation = PendingOperation.None;
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <returns>the in-memory state of this child resource and state represents any pending action on the child resource.</returns>
        public PendingOperation PendingOperation
        {
            get; internal set;
        }

        /// <summary>
        /// Creates this external child resource.
        /// </summary>
        /// <returns>the task to track the create action</returns>
        public abstract Task<FluentModelT> CreateAsync(CancellationToken cancellationToke);

        /// <summary>
        /// Updates this external child resource.
        /// </summary>
        /// <returns>the task to track the update action</returns>
        public abstract Task<FluentModelT> UpdateAsync(CancellationToken cancellationToke);

        /// <summary>
        /// Deletes this external child resource.
        /// </summary>
        /// <returns>the task to track the delete action</returns>
        public abstract Task DeleteAsync(CancellationToken cancellationToke);
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
