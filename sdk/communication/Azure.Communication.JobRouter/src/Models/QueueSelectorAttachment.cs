﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public abstract partial class QueueSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> The type discriminator describing a sub-type of QueueSelectorAttachment. </summary>
        public QueueSelectorAttachmentKind Kind { get; protected set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            writer.WriteEndObject();
        }
    }
}
