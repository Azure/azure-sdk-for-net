// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net.Mail;
using Azure.Core;

namespace Azure.Communication.Email.Models
{
    [CodeGenModel("EmailAddress")]
    public partial class EmailAddress
    {
        /// <summary> Initializes a new instance of EmailAddress. </summary>
        /// <param name="email"> Email address of the receipient</param>
        /// <param name="displayName">The display name of the recepient</param>
        /// <exception cref="ArgumentNullException"> <paramref name="email"/> is null. </exception>
        public EmailAddress(string email, string displayName)
            :this(email)
        {
            DisplayName = displayName;
        }

        internal void ValidateEmailAddress()
        {
            MailAddress mailAddress = ToMailAddress();

            var hostParts = mailAddress.Host.Trim().Split('.');
            if (hostParts.Length < 2)
            {
                throw new ArgumentException($"{Address}" + ErrorMessages.InvalidEmailAddress);
            }
        }

        private MailAddress ToMailAddress()
        {
            try
            {
                return new MailAddress(Address);
            }
            catch
            {
                throw new ArgumentException($"{Address}" + ErrorMessages.InvalidEmailAddress);
            }
        }
    }
}
