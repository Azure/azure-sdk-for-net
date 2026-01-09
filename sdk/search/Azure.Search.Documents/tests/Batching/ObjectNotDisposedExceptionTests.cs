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
            Assert.That(ex.Message, Is.EqualTo(message));
        }

        [Test]
        public void IsInvalidOperationException()
        {
            var ex = new ObjectNotDisposedException("Work was not cleaned up.");
            Assert.That(ex is InvalidOperationException, Is.True);
        }
    }
}
