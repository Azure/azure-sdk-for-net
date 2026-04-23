// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication
{
    public class CommunicationUserIdentifierTests
    {
        private readonly string _id = "Some id";

        [Test]
        public void constructWithNullOrEmptyIdShouldThrow()
        {
            ClassicAssert.Throws<ArgumentNullException>(() => { new CommunicationUserIdentifier(null); }, "The initialization parameter [id] cannot be null");
            ClassicAssert.Throws<ArgumentException>(() => { new CommunicationUserIdentifier(""); }, "The initialization parameter [id] cannot be empty");
        }

        [Test]
        public void compareEqualUserIdentifiers()
        {
            CommunicationUserIdentifier identifier1 = new(_id);
            CommunicationUserIdentifier identifier2 = new(_id);

            ClassicAssert.True(identifier1.Equals(identifier1));
            ClassicAssert.True(identifier1.Equals(identifier2));
        }

        [Test]
        public void compareWithNonUserIdentifier()
        {
            CommunicationUserIdentifier identifier1 = new(_id);
            object identifier2 = new();
            ClassicAssert.False(identifier1.Equals(identifier2));
        }

        [Test]
        public void constructWithValidId()
        {
            CommunicationUserIdentifier result = new(_id);
            ClassicAssert.NotNull(result.Id);
            ClassicAssert.NotNull(result.GetHashCode());
        }
    }
}
