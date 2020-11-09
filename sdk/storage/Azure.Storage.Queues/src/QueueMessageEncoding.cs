// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Determines how <see cref="QueueMessage.Body"/> is represented in HTTP requests and responses.
    /// </summary>
    public enum QueueMessageEncoding
    {
        /// <summary>
        /// The <see cref="QueueMessage.Body"/> is represented verbatim in HTTP requests and responses. I.e. message is not transformed.
        /// </summary>
        None = 0,

        /// <summary>
        /// The <see cref="QueueMessage.Body"/> is represented as Base64 encoded string in HTTP requests and responses.
        ///
        /// This was the default in V11 and prior Storage SDK, see
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </summary>
        Base64 = 1,
    }
}
