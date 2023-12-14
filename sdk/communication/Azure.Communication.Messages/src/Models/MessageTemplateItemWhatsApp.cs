// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Messages
{
    /// <summary> The WhatsApp-specific template response contract. </summary>
    public partial class MessageTemplateItemWhatsApp
    {
        /// <summary> Initializes a new instance of TemplateResponseWhatsApp. </summary>
        internal MessageTemplateItemWhatsApp()
        {
        }

        /// <summary>
        /// WhatsApp platform's template content
        /// This is the payload returned from WhatsApp API.
        /// </summary>
        public BinaryData Content { get; }

        internal MessageTemplateItemWhatsApp(TemplateResponseWhatsAppInternal templateResponseWhatsAppInternal)
        {
            Content = new BinaryData(templateResponseWhatsAppInternal.Content);
        }
    }
}
