// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication
{
    public class CommunicationUserIdentifierTests
    {
        private readonly string _id = "Some id";

        [Test]
        public void constructWithNullOrEmptyIdShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => { new CommunicationUserIdentifier(null); }, "The initialization parameter [id] cannot be null");
            Assert.Throws<ArgumentException>(() => { new CommunicationUserIdentifier(""); }, "The initialization parameter [id] cannot be empty");
        }

        [Test]
        public void compareEqualUserIdentifiers()
        {
            CommunicationUserIdentifier identifier1 = new(_id);
            CommunicationUserIdentifier identifier2 = new(_id);

            Assert.True(identifier1.Equals(identifier1));
            Assert.True(identifier1.Equals(identifier2));
        }

        [Test]
        public void compareWithNonUserIdentifier()
        {
            CommunicationUserIdentifier identifier1 = new(_id);
            object identifier2 = new();
            Assert.False(identifier1.Equals(identifier2));
        }

        [Test]
        public void constructWithValidId()
        {
            CommunicationUserIdentifier result = new(_id);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.GetHashCode());
        }
    }
}
