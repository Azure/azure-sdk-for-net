// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Misc
{
    public class RepeatabilityHeadersTests
    {
        [Test]
        public void RepeatablityHeaders_IsSetInConstructor()
        {
            // arrange & act
            var repeatabilityHeaders = new RepeatabilityHeaders();

            // assert
            Assert.IsNotNull(repeatabilityHeaders.RepeatabilityFirstSent);
            Assert.IsNotNull(repeatabilityHeaders.RepeatabilityRequestId);
        }
    }
}
