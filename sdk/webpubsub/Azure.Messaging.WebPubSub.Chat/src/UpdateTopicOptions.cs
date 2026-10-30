// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Properties to update on a topic. Unset properties are unchanged. </summary>
    public class UpdateTopicOptions
    {
        /// <summary> Gets or sets the topic title. Null leaves the title unchanged. </summary>
        public string Title { get; set; }

        /// <summary> Gets or sets the topic state. Null leaves the state unchanged. </summary>
        public ChatTopicState? State { get; set; }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            if (Title != null)
            {
                content.JsonWriter.WriteString("title"u8, Title);
            }
            if (State.HasValue)
            {
                content.JsonWriter.WriteString("state"u8, State.Value.ToString());
            }
            content.JsonWriter.WriteEndObject();
            return content;
        }
    }
}
