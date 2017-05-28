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
        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:9FCCB4B796E8FFF1419FB39498ED40F5
        public string Id { get { return this.Inner.Id; } }

        /// <summary>
        /// Gets or sets Edge node resource name.
        /// </summary>
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:8CC68A07507378BC8AFC6AE910E81D29
        public string Name { get { return this.Inner.Name; } }

        /// <summary>
        /// Gets or sets Edge node type string.
        /// </summary>
        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:A9EA4F75D3D56479553CCA0690945C5F
        public string Type { get { return this.Inner.Type; } }

        /// <summary>
        /// Gets or sets Edge node location string.
        /// </summary>
        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:9E497AA37DDE08EF101307CC90F4CF3D
        public string Location { get { return this.Inner.Location; } }

        /// <summary>
        /// Gets or sets Edge node location string.
        /// </summary>
        ///GENMHASH:E79DEA8536A01A029A312EBBD37133E8:3E1FC986663BDABE78E6EC82FD67918B
        public IDictionary<string,string> Tags { get { return this.Inner.Tags; } }

        /// <summary>
        /// Gets or sets list of ip address groups.
        /// </summary>
        ///GENMHASH:807D876269CCAA880FB100F304312776:CB33157308FCFF2A79EDFBD441CFBEDB
        public IList<IpAddressGroup> IpAddressGroups { get { return this.Inner.IpAddressGroups;} }
    }
}
