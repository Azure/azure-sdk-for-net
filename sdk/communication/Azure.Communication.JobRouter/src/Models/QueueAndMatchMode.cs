// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify default behavior of greedy matching of jobs and worker.
    /// </summary>
    public partial class QueueAndMatchMode : IUtf8JsonSerializable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public QueueAndMatchMode() : this("queue-and-match")
        {
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
