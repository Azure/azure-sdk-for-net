// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// Child resource abstract implementation.
    /// (Internal use only)
    /// </summary>
    /// <typeparam name="InnerT">Azure inner child class type</typeparam>
    /// <typeparam name="IParentT">Parent fluent interface</typeparam>
    /// <typeparam name="ParentImplT">Parent fluent interface implementation</typeparam>
    public abstract class ChildResource<InnerT, IParentT, ParentImplT>
        : IndexableWrapper<InnerT>,
          IChildResource<IParentT>
        where ParentImplT : IParentT
    {
        protected ChildResource(string name, InnerT innerObject, ParentImplT parent)
                : base(name, innerObject)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Gets the reference to the parent implementation, this is used by
        /// the child resource impls to invoke methods in the parent such as
        /// method to add the child resource impl to collection of child resources
        /// maintined by the parent.
        /// </summary>
        protected ParentImplT Parent { get; private set; }

        public abstract string Name { get; }

        /// <returns>the parent fluent interface</returns>
        IParentT IChildResource<IParentT>.Parent
        {
            get
            {
                return this.Parent;
            }
        }
    }
}