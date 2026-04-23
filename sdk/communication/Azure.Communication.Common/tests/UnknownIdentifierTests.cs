// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication
{
    public class UnknownIdentifierTests
    {
        private readonly string _id = "some id";
        [Test]
        public void constructWithNullOrEmptyIdShouldThrow()
        {
            ClassicAssert.Throws<ArgumentNullException>(() => { new UnknownIdentifier(null); }, "The initialization parameter [id] cannot be null");
            ClassicAssert.Throws<ArgumentException>(() => { new UnknownIdentifier(""); }, "The initialization parameter [id] cannot be empty");
        }

        [Test]
        public void compareEqualUnknownIdentifiers()
        {
            UnknownIdentifier identifier1 = new(_id);
            UnknownIdentifier identifier2 = new(_id);

            ClassicAssert.True(identifier1.Equals(identifier1));
            ClassicAssert.True(identifier1.Equals(identifier2));
        }

        [Test]
        public void compareWithNonUnknownIdentifier()
        {
            UnknownIdentifier identifier1 = new(_id);
            object identifier2 = new();
            ClassicAssert.False(identifier1.Equals(identifier2));
        }

        [Test]
        public void constructWithValidId()
        {
            UnknownIdentifier result = new(_id);
            ClassicAssert.NotNull(result.Id);
            ClassicAssert.NotNull(result.GetHashCode());
        }
    }
}
