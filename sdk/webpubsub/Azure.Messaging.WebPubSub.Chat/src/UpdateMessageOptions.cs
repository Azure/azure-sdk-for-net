// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Properties to update on a message. Unset properties are unchanged. </summary>
    public class UpdateMessageOptions
    {
        private string _createdBy;
        private WebPubSubChatMessageContent _content;
        private bool _createdByIsSet;
        private bool _contentIsSet;

        /// <summary> Gets or sets the user who created the message. Leave unset to keep the creator unchanged; assign null to clear it. </summary>
        public string CreatedBy
        {
            get => _createdBy;
            set
            {
                _createdBy = value;
                _createdByIsSet = true;
            }
        }

        /// <summary> Gets or sets the replacement message content. Leave unset to keep the content unchanged; assign null to clear it to empty text. </summary>
        /// <remarks> Supply either text or binary content. The supplied content replaces the entire existing content, including its type. </remarks>
        public WebPubSubChatMessageContent Content
        {
            get => _content;
            set
            {
                _content = value;
                _contentIsSet = true;
            }
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            if (_createdByIsSet)
            {
                content.JsonWriter.WriteString("createdBy"u8, CreatedBy);
            }
            if (_contentIsSet)
            {
                content.JsonWriter.WritePropertyName("content"u8);
                if (Content == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
                    content.JsonWriter.WriteObjectValue(Content, ModelSerializationExtensions.WireOptions);
                }
            }
            content.JsonWriter.WriteEndObject();
            return content;
        }
    }
}
