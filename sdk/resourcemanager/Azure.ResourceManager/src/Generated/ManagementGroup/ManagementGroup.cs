// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management.Models;

namespace Azure.ResourceManager.Management
{
    /// <summary>
    /// A class representing a ManagementGroup along with the instance operations that can be performed on it.
    /// </summary>
    public class ManagementGroup : ManagementGroupOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroup"/> class for mocking.
        /// </summary>
        protected ManagementGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroup"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The ManagementGroupData to use in these operations. </param>
        internal ManagementGroup(ResourceOperations operations, ManagementGroupData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this ManagementGroup.
        /// </summary>
        public virtual ManagementGroupData Data { get; }
    }
}
