// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary> The binding object to link values to the template specific locations. </summary>
    public abstract class MessageTemplateBindings
    {
        /// <summary> Initializes a new instance of MessageTemplateBindings. </summary>
        public MessageTemplateBindings()
        {
        }

        internal abstract MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal();
    }
}
