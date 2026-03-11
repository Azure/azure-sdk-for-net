// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary>
    /// The WhatsApp-specific message template bindings.
    /// This type is provided for backward compatibility; use <see cref="Azure.Communication.Messages.WhatsAppMessageTemplateBindings"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Azure.Communication.Messages.WhatsAppMessageTemplateBindings instead.")]
    public class WhatsAppMessageTemplateBindings : Azure.Communication.Messages.WhatsAppMessageTemplateBindings,
        IJsonModel<WhatsAppMessageTemplateBindings>,
        IPersistableModel<WhatsAppMessageTemplateBindings>
    {
        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageTemplateBindings"/>. </summary>
        public WhatsAppMessageTemplateBindings() : base()
        {
        }

        /// <summary> The header template bindings. </summary>
        public new IList<WhatsAppMessageTemplateBindingsComponent> Header { get; } = new List<WhatsAppMessageTemplateBindingsComponent>();

        /// <summary> The body template bindings. </summary>
        public new IList<WhatsAppMessageTemplateBindingsComponent> Body { get; } = new List<WhatsAppMessageTemplateBindingsComponent>();

        /// <summary> The footer template bindings. </summary>
        public new IList<WhatsAppMessageTemplateBindingsComponent> Footer { get; } = new List<WhatsAppMessageTemplateBindingsComponent>();

        /// <summary> The button template bindings. </summary>
        public new IList<WhatsAppMessageTemplateBindingsButton> Buttons { get; } = new List<WhatsAppMessageTemplateBindingsButton>();

        void IJsonModel<WhatsAppMessageTemplateBindings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        WhatsAppMessageTemplateBindings IJsonModel<WhatsAppMessageTemplateBindings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindings instead.");

        BinaryData IPersistableModel<WhatsAppMessageTemplateBindings>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        WhatsAppMessageTemplateBindings IPersistableModel<WhatsAppMessageTemplateBindings>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This obsolete type does not support deserialization. Use Azure.Communication.Messages.WhatsAppMessageTemplateBindings instead.");

        string IPersistableModel<WhatsAppMessageTemplateBindings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
