// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestMethodTests
    {
        [Test]
        public void DefaultToStringGetHashCode()
        {
            RequestMethod method = default;

            Assert.That(method.GetHashCode(), Is.EqualTo(0));
            Assert.That(method.ToString(), Is.EqualTo("<null>"));
        }

        public static object[][] Methods => new[]
        {
            new object[] { RequestMethod.Delete, "DELETE" },
            new object[] { RequestMethod.Get, "GET" },
            new object[] { RequestMethod.Patch, "PATCH" },
            new object[] { RequestMethod.Post, "POST" },
            new object[] { RequestMethod.Put, "PUT" },
            new object[] { RequestMethod.Head, "HEAD" },
            new object[] { RequestMethod.Options, "OPTIONS" },
            new object[] { RequestMethod.Trace, "TRACE" },
        };

        [Theory]
        [TestCaseSource(nameof(Methods))]
        public void ParseReturnsCachedValue(RequestMethod method, string stringValue)
        {
            Assert.That(RequestMethod.Parse(stringValue).Method, Is.SameAs(method.Method));
        }
    }
}
