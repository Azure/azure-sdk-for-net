// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ServiceAssociationLink type. </summary>
    public partial class ServiceAssociationLink
    {
        /// <summary> Gets or sets the AllowDelete compatibility property. </summary>
        public System.Nullable<System.Boolean> AllowDelete { get; set; }

        /// <summary> Gets or sets the Link compatibility property. </summary>
        public Azure.Core.ResourceIdentifier Link { get; set; }

        /// <summary> Gets or sets the LinkedResourceType compatibility property. </summary>
        public System.Nullable<Azure.Core.ResourceType> LinkedResourceType { get; set; }
    }
}
