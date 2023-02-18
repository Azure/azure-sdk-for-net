// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Email.Extensions
{
    internal static class EmailAddressListExtensions
    {
        internal static void Validate(this IList<EmailAddress> emailAddresses)
        {
            foreach (EmailAddress email in emailAddresses)
            {
                email.ValidateEmailAddress();
            }
        }
    }
}
