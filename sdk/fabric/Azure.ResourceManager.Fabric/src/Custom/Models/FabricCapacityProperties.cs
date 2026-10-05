// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Fabric.Models
{
    public partial class FabricCapacityProperties
    {
        /// <summary> Initializes a new instance of <see cref="FabricCapacityProperties"/>. </summary>
        /// <param name="administration"> The capacity administration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="administration"/> is null. </exception>
        public FabricCapacityProperties(FabricCapacityAdministration administration)
        {
            Argument.AssertNotNull(administration, nameof(administration));

            Overage = new CapacityOverageProperties();
            Administration = administration;
        }
    }
}
