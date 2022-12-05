// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.StorageSync.Models
{
    /// <summary> Parameters for a check name availability request. </summary>
    [CodeGenSuppress("StorageSyncNameAvailabilityContent", typeof(string))]
    public partial class StorageSyncNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of StorageSyncNameAvailabilityContent. </summary>
        /// <param name="name"> The name to check for availability. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StorageSyncNameAvailabilityContent(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            ResourceType = StorageSyncResourceType.Microsoft_StorageSync_StorageSyncServices;
        }
    }
}
