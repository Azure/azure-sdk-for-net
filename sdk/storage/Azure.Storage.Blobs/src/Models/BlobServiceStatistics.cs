// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    public partial class BlobServiceStatistics
    {
        /// <summary>
        /// The request priority the service applied to this request.
        /// </summary>
        public int? EffectiveRequestPriority { get; internal set; }
    }
}
