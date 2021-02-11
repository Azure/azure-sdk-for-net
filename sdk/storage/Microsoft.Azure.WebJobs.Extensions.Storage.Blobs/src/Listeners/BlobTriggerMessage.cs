// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

        // $$$ Ignored this?
        [JsonConverter(typeof(StringEnumConverter))]
        public BlobType BlobType { get; set; }

        public string ContainerName { get; set; }

        public string BlobName { get; set; }

        public string ETag { get; set; }
    }
}
