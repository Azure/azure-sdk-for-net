// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Fabric.Models
{
    // Add the property back for backward compatibility
    public partial class FabricCapacityPatch
    {
        /// <summary> An array of administrator user identities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> AdministrationMembers
        {
            get
            {
                if (Properties is null)
                    Properties = new FabricCapacityUpdateProperties();
                return Properties.AdministrationMembers;
            }
        }
    }
}
