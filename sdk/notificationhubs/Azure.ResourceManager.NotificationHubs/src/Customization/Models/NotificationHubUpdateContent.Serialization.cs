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
    public partial class NotificationHubUpdateContent : IJsonModel<NotificationHubUpdateContent>
    {
        void IJsonModel<NotificationHubUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubUpdateContent IJsonModel<NotificationHubUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubUpdateContent)} is obsolete and does not support deserialization.");

        BinaryData IPersistableModel<NotificationHubUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubUpdateContent IPersistableModel<NotificationHubUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubUpdateContent)} is obsolete and does not support deserialization.");

        string IPersistableModel<NotificationHubUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
