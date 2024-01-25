// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateText: MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateText(string name, string text) : base(name)
        {
            Text = text;
        }

        /// <summary> The message template's text value information. </summary>
        public string Text { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Text)
            {
                Text = new MessageTemplateValueText(Text)
            };
        }
    }
}
