// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Fabric.Models
{
    public partial class FabricCapacityPatch
    {
        /// <summary> An array of administrator user identities. </summary>
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
