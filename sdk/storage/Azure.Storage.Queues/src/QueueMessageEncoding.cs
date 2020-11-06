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
        /// The <see cref="QueueMessage.Body"/> is prepresented as UTF8 encoded string in HTTP requests and responses.
        /// </summary>
        UTF8 = 0,

        /// <summary>
        /// The <see cref="QueueMessage.Body"/> is prepresented as Base64 encoded string in HTTP requests and responses.
        /// </summary>
        Base64 = 1,
    }
}
