// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.Email
{
    [CodeGenModel("EmailRecipients")]
    public partial class EmailRecipients
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipients"/> class.
        /// </summary>
        /// <param name="to">Email to recipients.</param>
        /// <param name="cc">Email cc recipients. </param>
        /// <param name="bcc">Email bcc recipients. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> is null. </exception>
        public EmailRecipients(
            IEnumerable<EmailAddress> to = null,
            IEnumerable<EmailAddress> cc = null,
            IEnumerable<EmailAddress> bcc = null)
            :this(to ?? Enumerable.Empty<EmailAddress>())
        {
            if (cc != null)
            {
                CC = new ChangeTrackingList<EmailAddress>(new Optional<IList<EmailAddress>>(cc.ToList()));
            }

            if (bcc != null)
            {
                BCC = new ChangeTrackingList<EmailAddress>(new Optional<IList<EmailAddress>>(bcc.ToList()));
            }
        }

        internal void Validate()
        {
            if (To.Count == 0 && CC.Count == 0 && BCC.Count == 0)
            {
                throw new ArgumentException(ErrorMessages.EmptyToRecipients);
            }
        }
    }
}
