// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class RetryOnFailedRequestAttributeTests
    {
        private int attemptCount = 0;
        private DateTime lastAttempt;

        [Test]
        [RetryOnFailedRequest(2, 1, "foo")]
        public void ShouldPass()
        {
            try
            {
                attemptCount++;
                if (attemptCount == 1)
                {
                    throw new RequestFailedException("foo");
                }

                TimeSpan delta = DateTime.Now.Subtract(lastAttempt);
                Assert.AreEqual(2, attemptCount);
                Assert.IsTrue(delta.TotalSeconds > 1);
            }
            finally
            {
                lastAttempt = DateTime.Now;
            }
        }
    }
}
