// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class VariantUsage
    {
        [Test]
        public void CanUseVariantAsString()
        {
            Variant variant = "hi";

            Assert.AreEqual("hi", (string)variant);

            Assert.IsTrue("hi" == (string)variant);
            Assert.IsTrue((string)variant == "hi");

            Assert.AreEqual("hi", $"{(string)variant}");
        }

        [Test]
        public void CanTestForNull()
        {
            Variant variant = Variant.Null;

            Assert.IsTrue(Variant.IsNull(variant));
        }
    }
}
