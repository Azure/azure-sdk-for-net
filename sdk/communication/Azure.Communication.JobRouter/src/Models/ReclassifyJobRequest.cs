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
    internal class ReclassifyJobRequest : IUtf8JsonSerializable
    {
        /// <summary>
        /// Write empty object.
        /// </summary>
        /// <param name="writer"></param>
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
