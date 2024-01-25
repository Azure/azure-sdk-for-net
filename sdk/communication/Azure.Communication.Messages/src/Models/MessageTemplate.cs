// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Messages
{
    /// <summary> The template object used to create templates. </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTemplate"/> class.
        /// </summary>
        /// <param name="name">Name of the template.</param>
        /// <param name="language">The codes for the supported languages for templates.</param>
        /// <param name="values">The template values.</param>
        /// <param name="bindings">The binding object to link values to the template specific locations.</param>
        public MessageTemplate(string name, string language, IEnumerable<MessageTemplateValue> values = null, MessageTemplateBindings bindings = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            Values = values;
            Bindings = bindings;
        }

        /// <summary> Name of the template. </summary>
        public string Name { get; }
        /// <summary> The codes for the supported languages for templates. </summary>
        public string Language { get; }
        /// <summary> The template values. </summary>
        public IEnumerable<MessageTemplateValue> Values { get; }
        /// <summary> The binding object to link values to the template specific locations. </summary>
        public MessageTemplateBindings Bindings { get; }

        internal MessageTemplateInternal ToMessageTemplateInternal()
        {
            var messageTemplateInternal = new MessageTemplateInternal(Name, Language);

            if (Values != null)
            {
                foreach (MessageTemplateValue value in Values)
                {
                    messageTemplateInternal.Values.Add(value.Name, value.ToMessageTemplateValueInternal());
                }
            }

            if (Bindings != null)
            {
                messageTemplateInternal.Bindings = Bindings.ToMessageTemplateBindingsInternal();
            }

            return messageTemplateInternal;
        }
    }
}
