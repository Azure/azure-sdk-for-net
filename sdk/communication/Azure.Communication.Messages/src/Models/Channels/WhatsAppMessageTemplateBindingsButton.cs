// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary>
    /// The template bindings component button for WhatsApp.
    /// This type is provided for backward compatibility; use <see cref="Azure.Communication.Messages.WhatsAppMessageTemplateBindingsButton"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsButton instead.")]
    public class WhatsAppMessageTemplateBindingsButton : Azure.Communication.Messages.WhatsAppMessageTemplateBindingsButton,
        IJsonModel<WhatsAppMessageTemplateBindingsButton>,
        IPersistableModel<WhatsAppMessageTemplateBindingsButton>
    {
        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateBindingsButton"/>. </summary>
        /// <param name="subType"> The WhatsApp button sub type. </param>
        /// <param name="refValue"> The name of the referenced item in the template values. </param>
        public WhatsAppMessageTemplateBindingsButton(WhatsAppMessageButtonSubType subType, string refValue) : base(subType, refValue)
        {
        }

        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateBindingsButton"/>. </summary>
        /// <param name="subType"> The WhatsApp button sub type as a string. </param>
        /// <param name="refValue"> The name of the referenced item in the template values. </param>
        public WhatsAppMessageTemplateBindingsButton(string subType, string refValue)
            : base(new Azure.Communication.Messages.WhatsAppMessageButtonSubType(subType), refValue)
        {
        }

        /// <summary> The WhatsApp button sub type. </summary>
        public new string SubType
        {
            get => base.SubType.ToString();
            set => base.SubType = new Azure.Communication.Messages.WhatsAppMessageButtonSubType(value);
        }

        void IJsonModel<WhatsAppMessageTemplateBindingsButton>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        WhatsAppMessageTemplateBindingsButton IJsonModel<WhatsAppMessageTemplateBindingsButton>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsButton instead.");

        BinaryData IPersistableModel<WhatsAppMessageTemplateBindingsButton>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        WhatsAppMessageTemplateBindingsButton IPersistableModel<WhatsAppMessageTemplateBindingsButton>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsButton instead.");

        string IPersistableModel<WhatsAppMessageTemplateBindingsButton>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
