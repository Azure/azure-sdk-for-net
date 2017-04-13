// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Cdn.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Output of check resource usage API.
    /// </summary>
    public class ResourceUsage : Wrapper<ResourceUsageInner>
    {
        /// <summary>
        /// Initializes a new instance of the ResourceUsage class.
        /// </summary>
        public ResourceUsage(ResourceUsageInner inner)
            : base(inner)
        {
        }
        
        /// <summary>
        /// Gets or sets resource type of the usages.
        /// </summary>
        public string ResourceType { get { return this.Inner.ResourceType; } }

        /// <summary>
        /// Gets or sets unit of the usage. e.g. Count.
        /// </summary>
        public string Unit { get { return this.Inner.Unit; } }

        /// <summary>
        /// Gets or sets actual value of the resource type.
        /// </summary>
        public int CurrentValue { get { return this.Inner.CurrentValue.Value; } }

        /// <summary>
        /// Gets or sets quota of the resource type.
        /// </summary>
        public int Limit { get { return this.Inner.Limit.Value; } }

    }
}
