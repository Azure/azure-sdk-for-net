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
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new ReleaseKeyOptions(string.Empty, null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new ReleaseKeyOptions("test", null));
            Assert.AreEqual("targetAttestationToken", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new ReleaseKeyOptions("test", string.Empty));
            Assert.AreEqual("targetAttestationToken", ex.ParamName);
        }
    }
}
