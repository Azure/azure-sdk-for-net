// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageExtendedLocation
    {
        /// <summary>
        /// Converts an ARM <see cref="ExtendedLocation"/> to a <see cref="StorageExtendedLocation"/>.
        /// Used by backward-compat factory methods that accept the ARM common type.
        /// </summary>
        public static implicit operator StorageExtendedLocation(ExtendedLocation source)
        {
            if (source == null)
                return null;

            return new StorageExtendedLocation(
                source.Name,
                source.ExtendedLocationType?.ToString(),
                null);
        }
    }
}
