// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email
{
    [CodeGenModel("EmailMessage")]
    [CodeGenSuppress("EmailMessage", typeof(string), typeof(EmailContent), typeof(EmailRecipients))]
    public partial class EmailMessage
    {
        /// <summary> Initializes a new instance of EmailMessage. </summary>
        /// <param name="senderAddress"> Sender email address from a verified domain. </param>
        /// <param name="content"> Email content to be sent. </param>
        /// <param name="recipientAddress"> Recipients for the email. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="senderAddress"/>, <paramref name="recipientAddress"/> or <paramref name="content"/> is null. </exception>
        public EmailMessage(string senderAddress, string recipientAddress, EmailContent content)
        {
            Argument.AssertNotNull(senderAddress, nameof(senderAddress));
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(recipientAddress, nameof(recipientAddress));

            Headers = new ChangeTrackingDictionary<string, string>();
            SenderAddress = senderAddress;
            Content = content;
            Recipients = new EmailRecipients(new ChangeTrackingList<EmailAddress>
            {
                new EmailAddress(recipientAddress)
            });
            Attachments = new ChangeTrackingList<EmailAttachment>();
            ReplyTo = new ChangeTrackingList<EmailAddress>();
        }

        /// <summary> Initializes a new instance of EmailMessage. </summary>
        /// <param name="senderAddress"> Sender email address from a verified domain. </param>
        /// <param name="recipients"> Recipients for the email. </param>
        /// <param name="content"> Email content to be sent. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="senderAddress"/>, <paramref name="content"/> or <paramref name="recipients"/> is null. </exception>
        public EmailMessage(string senderAddress, EmailRecipients recipients, EmailContent content)
        {
            Argument.AssertNotNull(senderAddress, nameof(senderAddress));
            Argument.AssertNotNull(recipients, nameof(recipients));
            Argument.AssertNotNull(content, nameof(content));

            Headers = new ChangeTrackingDictionary<string, string>();
            SenderAddress = senderAddress;
            Content = content;
            Recipients = recipients;
            Attachments = new ChangeTrackingList<EmailAttachment>();
            ReplyTo = new ChangeTrackingList<EmailAddress>();
        }
    }
}
