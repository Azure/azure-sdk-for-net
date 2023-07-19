// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpAuthorizationTests
    {
        [Test]
        public void NullOrWhiteSpaceParameters()
        {
            Assert.Throws<ArgumentNullException>(() => new HttpAuthorization(null, "parameter"));
            Assert.Throws<ArgumentNullException>(() => new HttpAuthorization("scheme", null));

            Assert.Throws<ArgumentException>(() => new HttpAuthorization(" ", "parameter"));
            Assert.Throws<ArgumentException>(() => new HttpAuthorization("scheme", " "));
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            string scheme = "scheme";
            string parameter = "parameter";
            HttpAuthorization httpAuthorization = new HttpAuthorization(scheme, parameter);

            // Act
            string s = httpAuthorization.ToString();

            // Assert

            Assert.AreEqual($"{scheme} {parameter}", s);
        }
    }
}
