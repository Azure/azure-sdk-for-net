// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines the type of an Azure Search datasource.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<BlobExtractionMode>))]
    public sealed class BlobExtractionMode : ExtensibleEnum<BlobExtractionMode>
    {
        /// <summary>
        /// Indicates an Azure SQL datasource.
        /// </summary>
        public static readonly BlobExtractionMode StorageMetadata = new BlobExtractionMode("storageMetadata");

        public static readonly BlobExtractionMode AllMetadata = new BlobExtractionMode("allMetadata");

        public static readonly BlobExtractionMode ContentAndMetadata = new BlobExtractionMode("contentAndMetadata");

        private BlobExtractionMode(string mode) : base(mode)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new BlobExtractionMode instance, or returns an existing instance if the given name matches that of a
        /// known blob extraction mode.
        /// </summary>
        /// <param name="name">Name of the blob extraction mode.</param>
        /// <returns>A BlobExtractionMode instance with the given name.</returns>
        public static BlobExtractionMode Create(string name)
        {
            // Data source type names are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new BlobExtractionMode(name);
        }
    }
}
