// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class ExternalChildResourcesNonCached<FluentModelTImpl, IFluentModelT, InnerModelT, IParentT, ParentImplT> :
        ExternalChildResourceCollection<FluentModelTImpl, IFluentModelT, InnerModelT, IParentT, ParentImplT>
        where ParentImplT : IParentT
        where IFluentModelT : class, IExternalChildResource<IFluentModelT, IParentT>
        where FluentModelTImpl : ExternalChildResource<IFluentModelT, InnerModelT, IParentT, ParentImplT>, IFluentModelT
    {
        /// <summary>
        /// Creates a new ExternalChildResourcesNonCached.
        /// </summary>
        /// <param name="parent">the parent Azure resource</param>
        /// <param name="childResourceName">the child resource name</param>
        protected ExternalChildResourcesNonCached(ParentImplT parent, string childResourceName) : base(parent, childResourceName)
        {
        }

        /// <summary>
        /// Prepare a given model of an external child resource for create.
        /// </summary>
        /// <param name="model">the model to track create changes</param>
        /// <returns>the external child resource prepared for create</returns>
        protected FluentModelTImpl PrepareDefine(FluentModelTImpl model)
        {
            FluentModelTImpl childResource = Find(model.ChildResourceKey);
            if (childResource != null)
            {
                throw new ArgumentException(PendingOperationMessage(model.Name(), model.ChildResourceKey));
            }
            model.PendingOperation = PendingOperation.ToBeCreated;
            this.collection.AddOrUpdate(model.ChildResourceKey,
                key => model,
                (string key, FluentModelTImpl oldVal) => { return model; });
            return model;
        }

        /// <summary>
        /// Prepare a given model of an external child resource for update.
        /// </summary>
        /// <param name="model">the model to track update changes</param>
        /// <returns>the external child resource prepared for update</returns>
        protected FluentModelTImpl PrepareUpdate(FluentModelTImpl model)
        {
            FluentModelTImpl childResource = Find(model.ChildResourceKey);
            if (childResource != null)
            {
                throw new ArgumentException(PendingOperationMessage(model.Name(), model.ChildResourceKey));
            }
            model.PendingOperation = PendingOperation.ToBeUpdated;
            this.collection.AddOrUpdate(model.ChildResourceKey,
                key => model,
                (string key, FluentModelTImpl oldVal) => { return model; });
            return model;
        }

        /// <summary>
        /// Prepare a given model of an external child resource for remove.
        /// </summary>
        /// <param name="model">the model representing child resource to remove</param>
        protected void PrepareRemove(FluentModelTImpl model)
        {
            FluentModelTImpl childResource = Find(model.ChildResourceKey);
            if (childResource != null)
            {
                throw new ArgumentException(PendingOperationMessage(model.Name(), model.ChildResourceKey));
            }
            model.PendingOperation = PendingOperation.ToBeRemoved;
            this.collection.AddOrUpdate(model.ChildResourceKey,
                key => model,
                (string key, FluentModelTImpl oldVal) => { return model; });
        }

        protected override bool ClearAfterCommit()
        {
            return true;
        }

        private string PendingOperationMessage(string name, string key)
        {
            return string.Format("There is already an operation pending on the child resource ('{0}') with name (key) '{1} ({2})'", childResourceName, name, key);
        }
    }
}
