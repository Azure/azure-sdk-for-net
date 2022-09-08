// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class AuthenticationEndpointTests
    {
        [TestCase("mixedreality.com", "sts.mixedreality.com")]
        [TestCase("eastus2.mixedreality.com", "sts.mixedreality.com")]
        [TestCase("westus2.mixedreality.com", "sts.westus2.mixedreality.com")]
        public void ConstructFromDomain(string input, string expected)
        {
            Uri actual = AuthenticationEndpoint.ConstructFromDomain(input);

            Assert.AreEqual(expected, actual.Host);
        }

        [Test]
        public void ConstructFromDomainWithInvalidParameters()
        {
            ArgumentException? ex = Assert.Throws<ArgumentNullException>(() => AuthenticationEndpoint.ConstructFromDomain(null!));
            Assert.AreEqual("accountDomain", ex!.ParamName);

            ex = Assert.Throws<ArgumentException>(() => AuthenticationEndpoint.ConstructFromDomain(string.Empty));
            Assert.AreEqual("accountDomain", ex!.ParamName);

            ex = Assert.Throws<ArgumentException>(() => AuthenticationEndpoint.ConstructFromDomain(" "));
            Assert.AreEqual("accountDomain", ex!.ParamName);
        }
    }
}
