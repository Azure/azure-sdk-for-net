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
    public partial class NotificationHubNamespaceCreateOrUpdateContent : IJsonModel<NotificationHubNamespaceCreateOrUpdateContent>
    {
        void IJsonModel<NotificationHubNamespaceCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubNamespaceCreateOrUpdateContent IJsonModel<NotificationHubNamespaceCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and does not support deserialization.");

        BinaryData IPersistableModel<NotificationHubNamespaceCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and does not support serialization.");

        NotificationHubNamespaceCreateOrUpdateContent IPersistableModel<NotificationHubNamespaceCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and does not support deserialization.");

        string IPersistableModel<NotificationHubNamespaceCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
