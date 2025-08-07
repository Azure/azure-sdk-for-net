// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Inference
{
    public partial class ChatMessageAudioContentItem : IUtf8JsonSerializable, IJsonModel<ChatMessageAudioContentItem>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ChatMessageAudioContentItem>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ChatMessageAudioContentItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (_dataContentItem != null)
            {
                ((IJsonModel<ChatMessageAudioDataContentItem>)_dataContentItem).Write(writer, options);
            }
            else
            {
                ((IJsonModel<ChatMessageAudioUrlContentItem>)_urlContentItem).Write(writer, options);
            }
        }

        ChatMessageAudioContentItem IJsonModel<ChatMessageAudioContentItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            // This is a purely client side class, so it should never be received over the wire. Implementation here is only for interface compliance.
            return new ChatMessageAudioContentItem();
        }

        BinaryData IPersistableModel<ChatMessageAudioContentItem>.Write(ModelReaderWriterOptions options)
        {
            if (_dataContentItem != null)
            {
                return ((IJsonModel<ChatMessageAudioDataContentItem>)_dataContentItem).Write(options);
            }
            else
            {
                return ((IJsonModel<ChatMessageAudioUrlContentItem>)_urlContentItem).Write(options);
            }
        }

        ChatMessageAudioContentItem IPersistableModel<ChatMessageAudioContentItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            // This is a purely client side class, so it should never be received over the wire. Implementation here is only for interface compliance.
            return new ChatMessageAudioContentItem();
        }

        string IPersistableModel<ChatMessageAudioContentItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
