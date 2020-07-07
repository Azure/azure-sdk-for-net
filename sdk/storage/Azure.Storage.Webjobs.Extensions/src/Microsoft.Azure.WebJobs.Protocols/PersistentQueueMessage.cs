// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a message in a persistent queue.</summary>
    [JsonConverter(typeof(PersistentQueueMessageConverter))]
#if PUBLICPROTOCOL
    public abstract class PersistentQueueMessage
#else
    internal abstract class PersistentQueueMessage
#endif
    {
        /// <summary>Gets or sets the message type.</summary>
        public string Type { get; set; }

        /// <summary>Gets or sets the blob object.</summary>
        [JsonIgnore]
        internal object Blob { get; set; } // It's a ICloudBlob, but use System.Object to break coupling. 

        /// <summary>Gets or sets the blob text.</summary>
        [JsonIgnore]
        internal string BlobText { get; set; }

        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [JsonIgnore]
        public DateTimeOffset EnqueuedOn { get; set; }

        /// <summary>Gets or sets a receipt from dequeueing the message.</summary>
        [JsonIgnore]
        public string PopReceipt { get; set; }

        internal abstract void AddMetadata(IDictionary<string, string> metadata);

        private class PersistentQueueMessageConverter : PolymorphicJsonConverter
        {
            public PersistentQueueMessageConverter()
                : base("Type", PolymorphicJsonConverter.GetTypeMapping<PersistentQueueMessage>())
            {
            }
        }
    }
}
