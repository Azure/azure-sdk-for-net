// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Communication.Email.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Email.Tests
{
    public class EmailRecipientsTests : ClientTestBase
    {
        public EmailRecipientsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [SyncOnly]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 1, 1)]
        public void MultipleRecipients(int toCount, int ccCount, int bccCount)
        {
            var recipients = new EmailRecipients(DefaultRecipients(toCount), DefaultRecipients(ccCount), DefaultRecipients(bccCount));

            Assert.AreEqual(recipients.CC.Count, ccCount);
            Assert.AreEqual(recipients.BCC.Count, bccCount);
            Assert.AreEqual(recipients.To.Count, toCount);
        }

        private static List<EmailAddress> DefaultRecipients(int count = 1)
        {
            return count == 0 ? null : Enumerable.Repeat(new EmailAddress("customer@Contoso.com", "Customer Name"), count).ToList();
        }
    }
}
