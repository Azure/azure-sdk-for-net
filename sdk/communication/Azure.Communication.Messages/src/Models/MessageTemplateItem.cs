// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary> The TemplateResponse. </summary>
    public partial class MessageTemplateItem
    {
        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        internal MessageTemplateItem()
        {
        }

        /// <summary> Initializes a new instance of MessageTemplateItem. </summary>
        /// <param name="name"> Get the template&apos;s Name. </param>
        /// <param name="language"> Get the template&apos;s language. </param>
        /// <param name="channelType"></param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="whatsApp"> The WhatsApp-specific template response contract. </param>
        internal MessageTemplateItem(string name, string language, CommunicationMessagesChannelType? channelType, TemplateStatus? status, MessageTemplateItemWhatsApp whatsApp)
        {
            Name = name;
            Language = language;
            ChannelType = channelType;
            Status = status;
            WhatsApp = whatsApp;
        }

        /// <summary> Get the template&apos;s Name. </summary>
        public string Name { get; }
        /// <summary> Get the template&apos;s language. </summary>
        public string Language { get; }
        /// <summary> Gets the channel type. </summary>
        public CommunicationMessagesChannelType? ChannelType { get; }
        /// <summary> The aggregated template status. </summary>
        public TemplateStatus? Status { get; }
        /// <summary> The WhatsApp-specific template response contract. </summary>
        public MessageTemplateItemWhatsApp WhatsApp { get; }

        internal MessageTemplateItem(TemplateResponseInternal templateResponseInternal)
        {
            Name = templateResponseInternal.Name;
            Language = templateResponseInternal.Language;
            ChannelType = templateResponseInternal.ChannelType;
            Status = templateResponseInternal.Status;
            WhatsApp = new MessageTemplateItemWhatsApp(templateResponseInternal.WhatsApp);
        }
    }
}
