// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NoValueResponseOfTTests
    {
        [Test]
        public void CtorValidatesArgs()
        {
            Assert.Throws<ArgumentNullException>(() => new NoValueResponse<string>(null));
        }

        [Test]
        public void ThrowsWhenValueIsAccessed()
        {
            var target = new NoValueResponse<string>(new MockResponse(200));
            Assert.That(target.HasValue, Is.False);
            var exception = Assert.Throws<InvalidOperationException>(() => { var val = target.Value; });
            Assert.That(exception.Message, Is.EqualTo(target.GetStatusMessage()));
        }

        [Test]
        public void GetRawResponseReturnsResponse()
        {
            var response = new MockResponse(200);
            var target = new NoValueResponse<string>(response);
            Assert.That(target.GetRawResponse(), Is.EqualTo(response));
        }
    }
}
