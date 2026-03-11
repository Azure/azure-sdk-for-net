// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary>
    /// The template bindings component for WhatsApp.
    /// This type is provided for backward compatibility; use <see cref="Azure.Communication.Messages.WhatsAppMessageTemplateBindingsComponent"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsComponent instead.")]
    public class WhatsAppMessageTemplateBindingsComponent : Azure.Communication.Messages.WhatsAppMessageTemplateBindingsComponent,
        IJsonModel<WhatsAppMessageTemplateBindingsComponent>,
        IPersistableModel<WhatsAppMessageTemplateBindingsComponent>
    {
        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateBindingsComponent"/>. </summary>
        /// <param name="refValue"> The name of the referenced item in the template values. </param>
        public WhatsAppMessageTemplateBindingsComponent(string refValue) : base(refValue)
        {
        }

        void IJsonModel<WhatsAppMessageTemplateBindingsComponent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        WhatsAppMessageTemplateBindingsComponent IJsonModel<WhatsAppMessageTemplateBindingsComponent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsComponent instead.");

        BinaryData IPersistableModel<WhatsAppMessageTemplateBindingsComponent>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        WhatsAppMessageTemplateBindingsComponent IPersistableModel<WhatsAppMessageTemplateBindingsComponent>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindingsComponent instead.");

        string IPersistableModel<WhatsAppMessageTemplateBindingsComponent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
