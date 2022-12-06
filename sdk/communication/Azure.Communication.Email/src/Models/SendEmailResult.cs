// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Communication.Email.Models
{
    /// <summary>
    /// The type containing the results of a sent email.
    /// </summary>
    public class SendEmailResult
    {
        /// <summary> MessageId of the sent email </summary>
        public string MessageId { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="SendEmailResult"/>
        /// </summary>
        /// <param name="messageId"></param>
        internal SendEmailResult(string messageId)
        {
            MessageId = messageId;
        }
    }
}
