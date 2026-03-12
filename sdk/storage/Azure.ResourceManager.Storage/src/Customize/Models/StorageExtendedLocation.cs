// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageExtendedLocation
    {
        /// <summary> Converts an <see cref="ExtendedLocation"/> to <see cref="StorageExtendedLocation"/>. </summary>
        public static implicit operator StorageExtendedLocation(ExtendedLocation location)
        {
            if (location == null)
                return null;

            return new StorageExtendedLocation
            {
                Name = location.Name,
                Type = location.ExtendedLocationType.HasValue
                    ? (StorageExtendedLocationTypes?)new StorageExtendedLocationTypes(location.ExtendedLocationType.Value.ToString())
                    : null,
            };
        }
    }
}
