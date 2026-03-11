// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary>
    /// The WhatsApp-specific template response contract.
    /// This type is provided for backward compatibility; use <see cref="Azure.Communication.Messages.WhatsAppMessageTemplateItem"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Azure.Communication.Messages.WhatsAppMessageTemplateItem instead.")]
    public class WhatsAppMessageTemplateItem : Azure.Communication.Messages.WhatsAppMessageTemplateItem,
        IJsonModel<WhatsAppMessageTemplateItem>,
        IPersistableModel<WhatsAppMessageTemplateItem>
    {
        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateItem"/>. </summary>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        internal WhatsAppMessageTemplateItem(string language, MessageTemplateStatus status) : base(language, status)
        {
        }

        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateItem"/>. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="content"> WhatsApp platform's template content. </param>
        internal WhatsAppMessageTemplateItem(string name, string language, MessageTemplateStatus status, BinaryData content)
            : base(name, language, status, CommunicationMessagesChannel.WhatsApp, null, content)
        {
        }

        void IJsonModel<WhatsAppMessageTemplateItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        WhatsAppMessageTemplateItem IJsonModel<WhatsAppMessageTemplateItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateItem instead.");

        BinaryData IPersistableModel<WhatsAppMessageTemplateItem>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        WhatsAppMessageTemplateItem IPersistableModel<WhatsAppMessageTemplateItem>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateItem instead.");

        string IPersistableModel<WhatsAppMessageTemplateItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
