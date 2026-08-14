// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This model has been deleted from the TypeSpec spec. The serialization interfaces are kept
// only for backward API compatibility (ApiCompat). All methods throw NotSupportedException
// because this type is obsolete and should not be serialized or deserialized directly.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    public partial class NotificationHubCreateOrUpdateContent : IJsonModel<NotificationHubCreateOrUpdateContent>
    {
        void IJsonModel<NotificationHubCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubCreateOrUpdateContent IJsonModel<NotificationHubCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and does not support deserialization.");

        BinaryData IPersistableModel<NotificationHubCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubCreateOrUpdateContent IPersistableModel<NotificationHubCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and does not support deserialization.");

        string IPersistableModel<NotificationHubCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
