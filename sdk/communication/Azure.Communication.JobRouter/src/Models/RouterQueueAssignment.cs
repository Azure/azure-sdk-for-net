// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// An assignment of a worker to a queue.
    /// </summary>
    public partial class RouterQueueAssignment : IUtf8JsonSerializable
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public RouterQueueAssignment()
        {
        }

        /// <summary>
        /// Write empty object.
        /// </summary>
        /// <param name="writer"></param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
