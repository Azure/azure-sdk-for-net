// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary> The binding object to link values to the template specific locations. </summary>
    public abstract partial class MessageTemplateBindings
    {
        /// <summary> Initializes a new instance of <see cref="MessageTemplateBindings"/>. </summary>
        /// <param name="kind"> Discriminator. </param>
        public MessageTemplateBindings(string kind)
        {
            Kind = kind;
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }

        internal abstract MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal();
    }
}
