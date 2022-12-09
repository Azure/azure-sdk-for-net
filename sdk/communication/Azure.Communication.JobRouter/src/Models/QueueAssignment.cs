// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// An assignment of a worker to a queue.
    /// </summary>
    public class QueueAssignment : IUtf8JsonSerializable
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public QueueAssignment()
        {
        }

#pragma warning disable AZC0014 // Avoid using banned types in public API
        /// <summary>
        /// Write empty object.
        /// </summary>
        /// <param name="writer"></param>
        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
