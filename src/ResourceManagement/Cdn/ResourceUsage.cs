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
        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:EF285135CC1DC1A040A456FE6F79DF8C
        public string ResourceType { get { return this.Inner.ResourceType; } }

        /// <summary>
        /// Gets or sets unit of the usage. e.g. Count.
        /// </summary>
        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:75D0179020FBF5E8CFE92E1F66EDBAF7
        public string Unit { get { return this.Inner.Unit; } }

        /// <summary>
        /// Gets or sets actual value of the resource type.
        /// </summary>
        ///GENMHASH:4CC577A7C618816C07F6CE452B96D1E6:579B7AF955F207E31B607E32B9FC21F2
        public int CurrentValue { get { return this.Inner.CurrentValue.Value; } }

        /// <summary>
        /// Gets or sets quota of the resource type.
        /// </summary>
        ///GENMHASH:9D196E486CC1E35756FD0BEDAB3F3BE4:CA5FA4794F6E5C5FDAE63FBF699B9739
        public int Limit { get { return this.Inner.Limit.Value; } }

    }
}
