// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Messages
{
    /// <summary> The class describes a parameter of a template. </summary>
    public abstract class MessageTemplateValue
    {
        /// <summary> Initializes a new instance of MessageTemplateValueInternal. </summary>
        /// <param name="name"> The template value name. </param>
        public MessageTemplateValue(string name)
        {
            Name = name;
        }

        /// <summary> The template value name. </summary>
        public string Name { get; }

        internal abstract MessageTemplateValueInternal ToMessageTemplateValueInternal();
    }
}
