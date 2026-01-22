// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class ReleaseKeyOptionsTests
    {
        [Test]
        public void ConstructorArgumentValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new ReleaseKeyOptions(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentException>(() => new ReleaseKeyOptions(string.Empty, null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentNullException>(() => new ReleaseKeyOptions("test", null));
            Assert.That(ex.ParamName, Is.EqualTo("targetAttestationToken"));

            ex = Assert.Throws<ArgumentException>(() => new ReleaseKeyOptions("test", string.Empty));
            Assert.That(ex.ParamName, Is.EqualTo("targetAttestationToken"));
        }
    }
}
