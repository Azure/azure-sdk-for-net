/* * Copyright(c) Microsoft Corporation.All rights reserved.
 * Licensed under the MIT License.See License.txt in the project root for
 * license information.*/

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /**
     * Child resource abstract implementation.
     * (Internal use only)
     * @param <InnerT> Azure inner child class type
     * @param <ParentImplT> parent implementation
     */
    public abstract class ChildResource<InnerT, ParentImplT>
        : IndexableWrapper<InnerT>, IChildResource
    {

        protected ChildResource(string name, InnerT innerObject, ParentImplT parent)
                : base(name, innerObject)
        {
            this.Parent = parent;
        }

        /**
         * @return parent resource for this child resource
         */
        public ParentImplT Parent { get; private set; }

        string IChildResource.Name
        {
            get
            {
                return base.Key;
            }
        }
    }
}