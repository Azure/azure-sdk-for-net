// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HashCodeCombinerTest
    {
        [Test]
        public void GivenTheSameInputs_ItProducesTheSameOutput()
        {
            var hashCode1 = new HashCodeCombiner();
            var hashCode2 = new HashCodeCombiner();

            hashCode1.Add(42);
            hashCode1.Add("foo");
            hashCode2.Add(42);
            hashCode2.Add("foo");

            Assert.That(hashCode1.CombinedHash, Is.EqualTo(hashCode2.CombinedHash));
        }

        [Test]
        public void HashCode_Is_OrderSensitive()
        {
            var hashCode1 = HashCodeCombiner.Start();
            var hashCode2 = HashCodeCombiner.Start();

            hashCode1.Add(42);
            hashCode1.Add("foo");

            hashCode2.Add("foo");
            hashCode2.Add(42);

            Assert.That(hashCode1.CombinedHash, Is.Not.EqualTo(hashCode2.CombinedHash));
        }
    }
}
