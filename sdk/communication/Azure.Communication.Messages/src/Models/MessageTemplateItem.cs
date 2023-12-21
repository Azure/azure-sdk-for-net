// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Communication.Messages.Models.Channels;

namespace Azure.Communication.Messages
{
    /// <summary> The Template Response. </summary>
    public class MessageTemplateItem
    {
        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        internal MessageTemplateItem()
        {
        }

        internal static MessageTemplateItem DeserializeMessageTemplateResponse(JsonElement element)
        {
            var messageTemplateResponse = MessageTemplateResponse.DeserializeMessageTemplateResponse(element);
            return messageTemplateResponse.ChannelType.ToString() switch
            {
                "whatsApp" => new WhatsAppMessageTemplateItem(messageTemplateResponse),
                 _ => new MessageTemplateItem(messageTemplateResponse),
            };
        }

        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        /// <param name="name"> Get the template&apos;s Name. </param>
        /// <param name="language"> Get the template&apos;s language. </param>
        /// <param name="channelType"></param>
        /// <param name="status"> The aggregated template status. </param>
        internal MessageTemplateItem(string name, string language, CommunicationMessagesChannel? channelType, MessageTemplateStatus? status)
        {
            Name = name;
            Language = language;
            ChannelType = channelType;
            Status = status;
        }

        /// <summary> Get the template&apos;s Name. </summary>
        public string Name { get; }
        /// <summary> Get the template&apos;s language. </summary>
        public string Language { get; }
        /// <summary> Gets the channel type. </summary>
        public CommunicationMessagesChannel? ChannelType { get; }
        /// <summary> The aggregated template status. </summary>
        public MessageTemplateStatus? Status { get; }

        internal MessageTemplateItem(MessageTemplateResponse templateResponseInternal)
        {
            Name = templateResponseInternal.Name;
            Language = templateResponseInternal.Language;
            ChannelType = templateResponseInternal.ChannelType;
            Status = templateResponseInternal.Status;
        }
    }
}
