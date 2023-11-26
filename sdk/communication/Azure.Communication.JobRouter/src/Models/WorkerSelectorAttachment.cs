// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public abstract partial class WorkerSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> The type discriminator describing a sub-type of WorkerSelectorAttachment. </summary>
        public WorkerSelectorAttachmentKind Kind { get; protected set; }

        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            writer.WriteEndObject();
        }
    }
}
