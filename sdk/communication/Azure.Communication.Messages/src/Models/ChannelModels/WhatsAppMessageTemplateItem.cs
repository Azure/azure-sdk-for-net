// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary> The Template Response with WhatsApp-specific content. </summary>
    public class WhatsAppMessageTemplateItem : MessageTemplateItem
    {
        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        internal WhatsAppMessageTemplateItem()
        {
        }

        internal static new MessageTemplateItem DeserializeMessageTemplateResponse(JsonElement element)
        {
            var messageTemplateResponse = MessageTemplateResult.DeserializeMessageTemplateResponse(element);
            return new WhatsAppMessageTemplateItem(messageTemplateResponse);
        }

        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        /// <param name="name"> Get the template&apos;s Name. </param>
        /// <param name="language"> Get the template&apos;s language. </param>
        /// <param name="channelType"></param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="whatsApp"> The WhatsApp-specific template response contract. </param>
        internal WhatsAppMessageTemplateItem(string name, string language, CommunicationMessagesChannel? channelType, MessageTemplateStatus? status, MessageTemplateItemWhatsApp whatsApp)
            : base(name, language, channelType, status)
        {
            Content = whatsApp.Content;
        }

        /// <summary> The WhatsApp-specific template response contract. </summary>
        public BinaryData Content { get; }

        internal WhatsAppMessageTemplateItem(MessageTemplateResult templateResponseInternal)
            : base(templateResponseInternal)
        {
            Content = new BinaryData(templateResponseInternal.WhatsApp.Content);
        }
    }
}
