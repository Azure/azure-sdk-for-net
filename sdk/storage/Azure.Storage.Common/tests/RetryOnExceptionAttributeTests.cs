// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class RetryOnExceptionAttributeTests
    {
        private int counter = 0;

        [Test]
        [RetryOnException(3, typeof(InvalidOperationException))]
        public void ShouldRetryOnException()
        {
            if (counter++ == 0)
            {
                throw new InvalidOperationException();
            }

            Assert.That(counter, Is.EqualTo(2));
        }
    }
}
