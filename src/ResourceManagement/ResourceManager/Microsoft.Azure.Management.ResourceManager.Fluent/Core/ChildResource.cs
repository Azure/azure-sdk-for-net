// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Child resource abstract implementation.
    /// (Internal use only)
    /// </summary>
    /// <typeparam name="InnerT">Azure inner child class type</typeparam>
    /// <typeparam name="ParentImplT">Parent fluent interface implementation</typeparam>
    /// <typeparam name="IParentT">Parent fluent interface</typeparam>
    public abstract class ChildResource<InnerT, ParentImplT, IParentT>
        : IndexableWrapper<InnerT>,
          IChildResource<IParentT>
        where ParentImplT : IParentT
    {
        public ChildResource(InnerT innerObject, ParentImplT parent)
                : base(innerObject)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Gets the reference to the parent implementation, this is used by
        /// the child resource impls to invoke methods in the parent such as
        /// method to add the child resource impl to collection of child resources
        /// maintained by the parent.
        /// </summary>
        public ParentImplT Parent { get; private set; }

        public abstract string Name();

        string IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <returns>the parent fluent interface</returns>
        IParentT IHasParent<IParentT>.Parent
        {
            get
            {
                return this.Parent;
            }
        }
    }
}