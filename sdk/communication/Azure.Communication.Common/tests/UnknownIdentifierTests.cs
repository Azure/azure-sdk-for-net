// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication
{
    public class UnknownIdentifierTests
    {
        private String _id = "some id";
        [Test]
        public void constructWithNullOrEmptyIdShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => { new UnknownIdentifier(null); }, "The initialization parameter [id] cannot be null");
            Assert.Throws<ArgumentException>(() => { new UnknownIdentifier(""); }, "The initialization parameter [id] cannot be empty");
        }

        [Test]
        public void compareEqualUnknownIdentifiers()
        {
            UnknownIdentifier identifier1 = new UnknownIdentifier(_id);
            UnknownIdentifier identifier2 = new UnknownIdentifier(_id);

            Assert.True(identifier1.Equals(identifier1));
            Assert.True(identifier1.Equals(identifier2));
        }

        [Test]
        public void compareWithNonUnknownIdentifier()
        {
            UnknownIdentifier identifier1 = new UnknownIdentifier(_id);
            Object identifier2 = new Object();
            Assert.False(identifier1.Equals(identifier2));
        }

        [Test]
        public void constructWithValidId()
        {
            UnknownIdentifier result = new UnknownIdentifier(_id);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.GetHashCode());
        }
    }
}
