// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.ScVmm.Models;

namespace Azure.ResourceManager.ScVmm
{
    // The TypeSpec resource now generates a parameterless data constructor, but the AutoRest
    // SDK exposed a constructor that accepts the polymorphic properties payload.
    public partial class ScVmmInventoryItemData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ScVmmInventoryItemData"/>. </summary>
        /// <param name="properties"> The resource-specific properties for this resource. </param>
        public ScVmmInventoryItemData(ScVmmInventoryItemProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }
    }
}
