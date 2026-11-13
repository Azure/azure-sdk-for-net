// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceBus.Models
{
    public static partial class ArmServiceBusModelFactory
    {
        // Preserve the previously shipped model-factory signature for source and binary compatibility.
        /// <param name="applicationProperties"> Dictionary object for custom filters. </param>
        /// <param name="correlationId"> Identifier of the correlation. </param>
        /// <param name="messageId"> Identifier of the message. </param>
        /// <param name="sendTo"> Address to send to. </param>
        /// <param name="replyTo"> Address of the queue to reply to. </param>
        /// <param name="subject"> Application specific label. </param>
        /// <param name="sessionId"> Session identifier. </param>
        /// <param name="replyToSessionId"> Session identifier to reply to. </param>
        /// <param name="contentType"> Content type of the message. </param>
        /// <param name="requiresPreprocessing"> Value that indicates whether the rule action requires preprocessing. </param>
        /// <returns> A new <see cref="global::Azure.ResourceManager.ServiceBus.Models.ServiceBusCorrelationFilter"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Create a ServiceBusCorrelationFilter and populate Properties instead.")]
        public static ServiceBusCorrelationFilter ServiceBusCorrelationFilter(IDictionary<string, object> applicationProperties, string correlationId = default, string messageId = default, string sendTo = default, string replyTo = default, string subject = default, string sessionId = default, string replyToSessionId = default, string contentType = default, bool? requiresPreprocessing = default)
        {
            var result = new ServiceBusCorrelationFilter
            {
                CorrelationId = correlationId,
                MessageId = messageId,
                SendTo = sendTo,
                ReplyTo = replyTo,
                Subject = subject,
                SessionId = sessionId,
                ReplyToSessionId = replyToSessionId,
                ContentType = contentType,
                RequiresPreprocessing = requiresPreprocessing
            };
            result.SetApplicationProperties(applicationProperties);
            return result;
        }
    }
}
