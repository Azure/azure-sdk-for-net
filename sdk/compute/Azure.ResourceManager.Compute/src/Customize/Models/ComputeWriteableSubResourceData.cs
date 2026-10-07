// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ComputeWriteableSubResourceData
    {
        // Backward compatibility for generated setters that construct this type from only a ResourceIdentifier.
        // Without this constructor, generated convenience setters fail to compile after the base type gains additional serialization state.
        internal ComputeWriteableSubResourceData(ResourceIdentifier id) : this(id, null)
        {
        }

        // Backward compatibility: Id was virtual in the previously shipped SDK so derived VMSS configuration models inherited a virtual Id property.
        // Without this customization, ApiCompat reports that Id became non-virtual and that derived configuration models lost their inherited Id accessors.
        /// <summary> Resource Id. </summary>
        public virtual ResourceIdentifier Id { get; set; }
    }
}
