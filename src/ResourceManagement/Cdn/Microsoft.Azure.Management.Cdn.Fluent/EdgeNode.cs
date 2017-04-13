// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Cdn.Fluent.Models
{
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    
    /// <summary>
    /// Edge node of CDN service.
    /// </summary>
    public class EdgeNode : Wrapper<EdgeNodeInner>
    {
        /// <summary>
        /// Initializes a new instance of the EdgeNodeInner class.
        /// </summary>
        public EdgeNode(EdgeNodeInner inner)
            : base(inner)
        {
        }

        /// <summary>
        /// Gets or sets Edge node resource ID string.
        /// </summary>
        public string Id { get { return this.Inner.Id; } }

        /// <summary>
        /// Gets or sets Edge node resource name.
        /// </summary>
        public string Name { get { return this.Inner.Name; } }

        /// <summary>
        /// Gets or sets Edge node type string.
        /// </summary>
        public string Type { get { return this.Inner.Type; } }

        /// <summary>
        /// Gets or sets Edge node location string.
        /// </summary>
        public string Location { get { return this.Inner.Location; } }
        
        /// <summary>
        /// Gets or sets Edge node location string.
        /// </summary>
        public IDictionary<string,string> Tags { get { return this.Inner.Tags; } }

        /// <summary>
        /// Gets or sets list of ip address groups.
        /// </summary>
        public IList<IpAddressGroup> IpAddressGroups { get { return this.Inner.IpAddressGroups;} }
    }
}
