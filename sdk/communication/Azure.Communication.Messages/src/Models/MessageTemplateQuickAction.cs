// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using static System.Net.Mime.MediaTypeNames;

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateQuickAction: MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateQuickAction(string name, string text = null, string payload = null) : base(name)
        {
            Text = text;
            Payload = payload;
        }

        /// <summary> The quick action text. </summary>
        public string Text { get; set; }
        /// <summary> The quick action payload. </summary>
        public string Payload { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.QuickAction)
            {
                QuickAction = new MessageTemplateValueQuickAction
                {
                    Payload = Payload,
                    Text = Text
                }
            };
        }
    }
}
