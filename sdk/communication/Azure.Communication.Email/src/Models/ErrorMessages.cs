// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Email
{
    internal static class ErrorMessages
    {
        internal const string EmptyContent = "Email content must have either HTML or PlainText";
        internal const string EmptyHeaderValue = "Empty Value is not allowed in Email Header";
        internal const string EmptySubject = "Email subject can not be empty";
        internal const string EmptyToRecipients = "ToRecipients cannot be empty";
        internal const string InvalidAttachmentContent = "Attachment Content cannot be empty.";
        internal const string InvalidEmailAddress = " is not a valid email address";
        internal const string InvalidSenderEmail = "Sender must be a valid email address";
    }
}
