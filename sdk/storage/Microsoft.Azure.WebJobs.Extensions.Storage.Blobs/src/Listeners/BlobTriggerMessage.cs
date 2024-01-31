// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobTriggerMessage
    {
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string Type
        {
            get
            {
                return "BlobTrigger";
            }
        }

        public string FunctionId { get; set; }

        // See BlobTypeInternal for exact serialization.
        [JsonIgnore]
        public BlobType BlobType { get; set; }

        // BlobType enum have different values in track 2 vs track 1, e.g. Block vs BlockBlob.
        // This internal property makes sure we serialize new type same way track 1 extension did.
        // This also makes sure we can read both formats since we already shipped few betas and don't want to disturb them.
        [JsonProperty(nameof(BlobType))]
        private string BlobTypeInternal {
            get
            {
                return BlobType.ToString() + "Blob";
            }
            set
            {
                BlobType = (BlobType)Enum.Parse(typeof(BlobType), value.Replace("Blob", ""), true);
            }
        }

        public string ContainerName { get; set; }

        public string BlobName { get; set; }

        public string ETag { get; set; }
    }
}
