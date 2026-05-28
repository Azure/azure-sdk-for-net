// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ServiceBusExceptionTests
    {
        public static IEnumerable<object> GetFailureReasons()
        {
            foreach (ServiceBusFailureReason reason in Enum.GetValues(typeof(ServiceBusFailureReason)))
            {
                yield return new object[] { reason, true };
                yield return new object[] { reason, false };
            }
        }

        [Test]
        [TestCaseSource(nameof(GetFailureReasons))]
        public void MessageIncludesTroubleshootingGuideLink(ServiceBusFailureReason reason, bool includeEntityPath)
        {
            var exception = new ServiceBusException("test", reason, entityPath: includeEntityPath ? "entityPath" : null);
            StringAssert.Contains(Constants.TroubleshootingMessage, exception.Message);

            // test the other constructor
            exception = new ServiceBusException(true, "test", reason: reason);
            StringAssert.Contains(Constants.TroubleshootingMessage, exception.Message);
        }
    }
}