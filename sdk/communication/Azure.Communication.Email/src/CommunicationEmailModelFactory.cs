// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Communication.Email.Models;
using Azure.Core;

namespace Azure.Communication.Email
{
    /// <summary> Model factory for read-only models. </summary>
    [CodeGenModel("CommunicationEmailModelFactory")]
    public static partial class CommunicationEmailModelFactory
    {
        /// <summary> Initializes a new instance of SendEmailResult. </summary>
        /// <param name="messageId"> System generated id of an email message sent. </param>
        /// <returns> A new <see cref="SendEmailResult"/> instance for mocking. </returns>
        public static SendEmailResult SendEmailResult(string messageId = null)
        {
            return new SendEmailResult(messageId);
        }
    }
}
