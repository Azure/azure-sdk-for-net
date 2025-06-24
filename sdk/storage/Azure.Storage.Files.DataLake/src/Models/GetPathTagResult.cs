// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The result of DataLakePathClient.GetTags() call.
    /// </summary>
    public class GetPathTagResult
    {
        /// <summary>
        /// Path Tags.
        /// </summary>
        public Tags Tags { get; internal set; }
    }
}
