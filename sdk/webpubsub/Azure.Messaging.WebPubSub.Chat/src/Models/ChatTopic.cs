// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.WebPubSub.Chat
{
    [CodeGenSuppress("ChatTopic", typeof(string), typeof(ChatTopicState))]
    public partial class ChatTopic
    {
        /// <summary> Initializes a new instance of <see cref="ChatTopic"/>. </summary>
        /// <param name="title"> Topic title. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="title"/> is null. </exception>
        public ChatTopic(string title)
        {
            Argument.AssertNotNull(title, nameof(title));

            Title = title;
        }

        /// <summary> Gets or sets the current lifecycle state of the topic. When unset, the state is omitted from requests. </summary>
        public ChatTopicState? State { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatTopic>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatTopic)} does not support writing '{format}' format.");
            }

            if (options.Format != "W")
            {
                writer.WriteString("id"u8, Id);
            }
            writer.WriteString("title"u8, Title);
            if (options.Format != "W")
            {
                writer.WritePropertyName("createdAt"u8);
                writer.WriteStringValue(CreatedOn, "O");
                writer.WriteString("createdBy"u8, CreatedBy);
            }
            if (State.HasValue)
            {
                writer.WriteString("state"u8, State.Value.ToString());
            }
            if (options.Format != "W")
            {
                writer.WriteString("conversationId"u8, ConversationId);
                writer.WriteString("etag"u8, Etag.ToString());
                if (_additionalBinaryDataProperties != null)
                {
                    foreach (var item in _additionalBinaryDataProperties)
                    {
                        writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                        writer.WriteRawValue(item.Value);
#else
                        using (JsonDocument document = JsonDocument.Parse(item.Value))
                        {
                            JsonSerializer.Serialize(writer, document.RootElement);
                        }
#endif
                    }
                }
            }
        }
    }
}
