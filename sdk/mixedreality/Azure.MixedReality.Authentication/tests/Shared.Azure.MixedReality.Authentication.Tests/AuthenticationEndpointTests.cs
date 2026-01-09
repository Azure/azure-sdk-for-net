// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class AuthenticationEndpointTests
    {
        [Test]
        public void ConstructFromDomain()
        {
            Uri expected = new Uri("https://sts.eastus2.mixedreality.com");
            Uri actual = AuthenticationEndpoint.ConstructFromDomain("eastus2.mixedreality.com");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ConstructFromDomainWithInvalidParameters()
        {
            ArgumentException? ex = Assert.Throws<ArgumentNullException>(() => AuthenticationEndpoint.ConstructFromDomain(null!));
            Assert.That(ex!.ParamName, Is.EqualTo("accountDomain"));

            ex = Assert.Throws<ArgumentException>(() => AuthenticationEndpoint.ConstructFromDomain(string.Empty));
            Assert.That(ex!.ParamName, Is.EqualTo("accountDomain"));

            ex = Assert.Throws<ArgumentException>(() => AuthenticationEndpoint.ConstructFromDomain(" "));
            Assert.That(ex!.ParamName, Is.EqualTo("accountDomain"));
        }
    }
}
