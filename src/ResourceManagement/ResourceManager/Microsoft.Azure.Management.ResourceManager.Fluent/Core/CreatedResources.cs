// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Implementation of <see cref="ICreatedResources{ResourceT}"> interface.
    /// </summary>
    /// <typeparam name="ResourceT">the type of the resources in the batch</typeparam>
    internal class CreatedResources<ResourceT> : ICreatedResources<ResourceT>
        where ResourceT : class, IHasId
    {
        /// <summary>
        /// The dummy root resource for this batch.
        /// </summary>
        private ICreatableUpdatableResourcesRoot<ResourceT> creatableUpdatableResourcesRoot;

        /// <summary>
        /// The top level resources created in this batch.
        /// </summary>
        private IEnumerable<ResourceT> topLevelResources;

        internal CreatedResources(ICreatableUpdatableResourcesRoot<ResourceT> creatableUpdatableResourcesRoot)
        {
            this.creatableUpdatableResourcesRoot = creatableUpdatableResourcesRoot;
            this.topLevelResources = this.creatableUpdatableResourcesRoot.CreatedTopLevelResources();
        }

        #region Implementation of ICreatedResources interface

        public IHasId CreatedRelatedResource(string key)
        {
            return this.creatableUpdatableResourcesRoot.CreatedRelatedResource(key);
        }

        public IEnumerator<ResourceT> GetEnumerator()
        {
            return this.topLevelResources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
