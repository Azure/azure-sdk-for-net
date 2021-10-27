// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AsyncAssertTests
    {
        [Test]
        public async Task ReturnsExpectedException()
        {
            var exception = await AsyncAssert.ThrowsAsync<ExpectedException>(() => throw new ExpectedException());
            Assert.NotNull(exception);
        }

        [Test]
        public async Task ThrowsWhenWrongException()
        {
            bool failed = false;
            try
            {
                await AsyncAssert.ThrowsAsync<ExpectedException>(() => throw new Exception());
            }
            catch (AssertionException)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [Test]
        public async Task ThrowsWhenNoException()
        {
            bool failed = false;
            try
            {
                await AsyncAssert.ThrowsAsync<ExpectedException>(() => Task.CompletedTask);
            }
            catch (AssertionException)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class ExpectedException : Exception
#pragma warning restore SA1402 // File may only contain a single type
    {
    }
}
