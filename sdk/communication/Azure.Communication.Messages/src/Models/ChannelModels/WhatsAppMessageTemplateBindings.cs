// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary> The binding object to link values to the template specific locations. </summary>
    public class WhatsAppMessageTemplateBindings : MessageTemplateBindings
    {
        /// <summary> Initializes a new instance of MessageTemplateWhatsAppBindings. </summary>
        public WhatsAppMessageTemplateBindings() : base ("whatsApp")
        {
        }

        /// <summary> Gets the header. </summary>
        public IList<string> Header { get; set; }
        /// <summary> Gets the body. </summary>
        public IList<string> Body { get; set; }
        /// <summary> Gets the footer. </summary>
        public IList<string> Footer { get; set; }
        /// <summary> Gets the buttons. </summary>
        public IList<KeyValuePair<string, WhatsAppMessageTemplateValueSubType>> Buttons { get; set; }

        internal override MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal()
        {
            var whatsApp = new WhatsAppMessageTemplateBindingsInternal();

            if (Header != null)
            {
                foreach (string item in Header)
                {
                    whatsApp.Header.Add(new WhatsAppMessageTemplateBindingsComponent(item));
                }
            };

            if (Body != null)
            {
                foreach (string item in Body)
                {
                    whatsApp.Body.Add(new WhatsAppMessageTemplateBindingsComponent(item));
                }
            };

            if (Footer != null)
            {
                foreach (string item in Footer)
                {
                    whatsApp.Footer.Add(new WhatsAppMessageTemplateBindingsComponent(item));
                }
            };

            if (Buttons != null)
            {
                foreach (var item in Buttons)
                {
                    whatsApp.Button.Add(new WhatsAppMessageTemplateBindingsButton(item.Key) { SubType = item.Value });
                }
            };

            whatsApp.Kind = Kind;

            return whatsApp;
        }
    }
}
