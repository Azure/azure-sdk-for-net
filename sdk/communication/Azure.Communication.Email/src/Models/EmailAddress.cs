// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net.Mail;
using Azure.Core;

namespace Azure.Communication.Email
{
    [CodeGenModel("EmailAddress")]
    public partial class EmailAddress
    {
        /// <summary> Initializes a new instance of EmailAddress. </summary>
        /// <param name="address"> Email address of the receipient</param>
        /// <param name="displayName">The display name of the recepient</param>
        /// <exception cref="ArgumentNullException"> <paramref name="address"/> is null. </exception>
        public EmailAddress(string address, string displayName)
            :this(address)
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
