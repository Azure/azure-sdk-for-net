// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct DiskControllerType
    {
        // The pinned generator emits an untyped null that invokes the non-nullable conversion.
        // Remove this customization when the management emitter includes microsoft/typespec#12576.
        /// <summary> Converts a string to a <see cref="DiskControllerType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator DiskControllerType?(string value) => value == null ? (DiskControllerType?)null : new DiskControllerType(value);
    }
}
