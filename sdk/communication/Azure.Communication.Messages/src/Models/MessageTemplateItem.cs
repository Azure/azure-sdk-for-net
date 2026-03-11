// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The message template as returned from the service.
    /// </summary>
    public abstract partial class MessageTemplateItem
    {
        /// <summary> Initializes a new instance of <see cref="MessageTemplateItem"/>. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="status"> The aggregated template status. </param>
        protected MessageTemplateItem(string name, MessageTemplateStatus status)
            : this(name, default, status, default(CommunicationMessagesChannel), null)
        {
        }
    }
}
