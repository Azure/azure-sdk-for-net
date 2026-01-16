// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication
{
    public class UnknownIdentifierTests
    {
        private readonly string _id = "some id";
        [Test]
        public void constructWithNullOrEmptyIdShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => { new UnknownIdentifier(null); }, "The initialization parameter [id] cannot be null");
            Assert.Throws<ArgumentException>(() => { new UnknownIdentifier(""); }, "The initialization parameter [id] cannot be empty");
        }

        [Test]
        public void compareEqualUnknownIdentifiers()
        {
            UnknownIdentifier identifier1 = new(_id);
            UnknownIdentifier identifier2 = new(_id);

            Assert.That(identifier1.Equals(identifier1), Is.True);
            Assert.That(identifier1.Equals(identifier2), Is.True);
        }

        [Test]
        public void compareWithNonUnknownIdentifier()
        {
            UnknownIdentifier identifier1 = new(_id);
            object identifier2 = new();
            Assert.That(identifier1.Equals(identifier2), Is.False);
        }

        [Test]
        public void constructWithValidId()
        {
            UnknownIdentifier result = new(_id);
            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.GetHashCode(), Is.Not.Null);
        }
    }
}
