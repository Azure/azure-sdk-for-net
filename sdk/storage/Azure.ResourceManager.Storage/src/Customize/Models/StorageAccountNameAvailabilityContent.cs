// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds public constructor matching prior GA shape (name only).
// Provides fields/properties referenced by the generated partial and serialization.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to check the availability of the storage account name. </summary>
    public partial class StorageAccountNameAvailabilityContent
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StorageAccountNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StorageAccountNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Name = name;
        }

        /// <summary> The storage account name. </summary>
        [WirePath("name")]
        public string Name { get; }

        /// <summary> The type of resource, Microsoft.Storage/storageAccounts. </summary>
        [WirePath("type")]
        public ResourceType ResourceType { get; } = new ResourceType("Microsoft.Storage/storageAccounts");
    }
}
