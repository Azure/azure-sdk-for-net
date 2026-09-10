// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ScVmm.Models
{
    public abstract partial class ScVmmInventoryItemProperties
    {
        // The TypeSpec discriminator requires an internal discriminator constructor, but the AutoRest
        // SDK shipped a protected parameterless base constructor. Restore that inheritable shape.
        /// <summary> Initializes a new instance of <see cref="ScVmmInventoryItemProperties"/>. </summary>
        protected ScVmmInventoryItemProperties()
        {
        }
    }
}
