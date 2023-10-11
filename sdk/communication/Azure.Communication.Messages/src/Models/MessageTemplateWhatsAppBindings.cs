// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Linq;

namespace Azure.Communication.Messages
{
    /// <summary> The binding object to link values to the template specific locations. </summary>
    public class MessageTemplateWhatsAppBindings: MessageTemplateBindings
    {
        /// <summary> Initializes a new instance of MessageTemplateWhatsAppBindings. </summary>
        public MessageTemplateWhatsAppBindings(IEnumerable<string> header = null, IEnumerable<string> body = null, IEnumerable<string> footer = null, IEnumerable<KeyValuePair<string, MessageTemplateValueWhatsAppSubType>> button = null)
        {
            Header = header;
            Body = body;
            Footer = footer;
            Button = button;
        }

        /// <summary> Gets the header. </summary>
        public IEnumerable<string> Header { get; }
        /// <summary> Gets the body. </summary>
        public IEnumerable<string> Body { get; }
        /// <summary> Gets the footer. </summary>
        public IEnumerable<string> Footer { get; }
        /// <summary> Gets the button. </summary>
        public IEnumerable<KeyValuePair<string, MessageTemplateValueWhatsAppSubType>> Button { get; }

        internal override MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal()
        {
            var whatsApp = new MessageTemplateBindingsWhatsApp();

            if (Header != null)
            {
                foreach (string item in Header)
                {
                    whatsApp.Header.Add(new MessageTemplateBindingsWhatsAppComponent(item));
                }
            };

            if (Body != null)
            {
                foreach (string item in Body)
                {
                    whatsApp.Body.Add(new MessageTemplateBindingsWhatsAppComponent(item));
                }
            };

            if (Footer != null)
            {
                foreach (string item in Footer)
                {
                    whatsApp.Footer.Add(new MessageTemplateBindingsWhatsAppComponent(item));
                }
            };

            if (Button != null)
            {
                foreach (var item in Button)
                {
                    whatsApp.Button.Add(new MessageTemplateBindingsWhatsAppButton(item.Key) { SubType = item.Value });
                }
            };

            return new MessageTemplateBindingsInternal() { WhatsApp = whatsApp };
        }
    }
}
