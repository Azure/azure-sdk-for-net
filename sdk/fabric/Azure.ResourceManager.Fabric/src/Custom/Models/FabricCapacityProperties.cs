// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Fabric.Models
{
    public partial class FabricCapacityProperties
    {
        /// <summary> An array of administrator user identities. </summary>
        public IList<string> AdministrationMembers
        {
            get
            {
                if (Administration is null)
                {
                    Administration = new FabricCapacityAdministration();
                }
                return Administration.Members;
            }
            set
            {
                Administration = new FabricCapacityAdministration(value);
            }
        }
    }
}
