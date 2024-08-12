// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ObjectNotDisposedExceptionTests
    {
        [Test]
        public void Construct()
        {
            string message = "Work was not cleaned up.";
            var ex = new ObjectNotDisposedException(message);
            Assert.AreEqual(message, ex.Message);
        }

        [Test]
        public void IsInvalidOperationException()
        {
            var ex = new ObjectNotDisposedException("Work was not cleaned up.");
            Assert.True(ex is InvalidOperationException);
        }
    }
}
