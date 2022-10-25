// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Misc
{
    public class RepeatabilityHeadersTests
    {
        [Test]
        public void RepeatablityHeaders_IsNotOverwrittenByDefaultIfSet()
        {
            // arrange
            var repeatablityRequestId = Guid.NewGuid();
            var repeatabilityFirstSent = DateTime.UtcNow;
            // arrange
            var options = new AnswerCallOptions("context", new Uri("https://contoso.com/callback"))
            {
                RepeatabilityHeaders = new RepeatabilityHeaders(repeatablityRequestId, repeatabilityFirstSent)
            };

            // act & assert
            Assert.AreEqual(repeatablityRequestId, options.RepeatabilityHeaders.RepeatabilityRequestId);
            Assert.AreEqual(repeatabilityFirstSent.ToString("R"), options.RepeatabilityHeaders.GetRepeatabilityFirstSentString());
        }
    }
}
