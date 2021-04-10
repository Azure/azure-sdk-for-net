// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    /// <summary>Represents a parameter triggered on a blob in Azure Storage.</summary>
    internal class BlobTriggerParameterDescriptor : TriggerParameterDescriptor
    {
        /// <summary>Gets or sets the name of the storage account.</summary>
        public string AccountName { get; set; }

        /// <summary>Gets or sets the name of the container.</summary>
        public string ContainerName { get; set; }

        /// <summary>Gets or sets the name of the blob.</summary>
        public string BlobName { get; set; }

        /// <summary>Gets or sets the kind of access the parameter has to the blob.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FileAccess Access { get; set; }

        /// <inheritdoc />
        public override string GetTriggerReason(IDictionary<string, string> arguments)
        {
            string blobPath;
            if (arguments != null && arguments.TryGetValue(Name, out blobPath))
            {
                return "New blob detected: " + blobPath;
            }

            return null;
        }
    }
}
