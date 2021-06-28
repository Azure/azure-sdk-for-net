// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AzureKeyCredentialTests
    {
        [Test]
        public void KeyChanged()
        {
            var akc = new AzureKeyCredential("1");
            var updateTo = "2";

            akc.KeyChanged += (object sender, string newKey) =>
            {
                Assert.AreEqual(updateTo, newKey);
                Assert.AreEqual(updateTo, akc.Key);
                Assert.AreEqual(sender, akc);
            };

            akc.Update(updateTo);
        }
    }
}
