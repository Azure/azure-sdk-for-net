// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify a match mode when no action is taken on a job.
    /// </summary>
    public partial class SuspendMode : IUtf8JsonSerializable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SuspendMode() : this("suspend")
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
