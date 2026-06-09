// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class ExternalKeyTests
    {
        [Test]
        public void CtorThrowsOnNullId()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new ExternalKey(null));
            Assert.AreEqual("id", ex.ParamName);
        }

        [Test]
        public void CtorSetsId()
        {
            ExternalKey key = new ExternalKey("ext-key-01");
            Assert.AreEqual("ext-key-01", key.Id);
        }
    }
}