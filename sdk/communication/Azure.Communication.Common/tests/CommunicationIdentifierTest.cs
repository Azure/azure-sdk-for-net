// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Communication
{
    public class CommunicationIdentifierTest
    {
        [Test]
        public void IfIdIsOptional_EqualityOnlyTestIfPresentOnBothSide()
        {
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("user id", true, "some id"), new MicrosoftTeamsUserIdentifier("user id", true));
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("user id", true), new MicrosoftTeamsUserIdentifier("user id", true));
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("user id", true), new MicrosoftTeamsUserIdentifier("user id", true, "some id"));
            Assert.AreNotEqual(new MicrosoftTeamsUserIdentifier("user id", true, "some id"), new MicrosoftTeamsUserIdentifier("user id", true, "another id"));

            Assert.AreEqual(new PhoneNumberIdentifier("+12223334444", "some id"), new PhoneNumberIdentifier("+12223334444"));
            Assert.AreEqual(new PhoneNumberIdentifier("+12223334444"), new PhoneNumberIdentifier("+12223334444"));
            Assert.AreEqual(new PhoneNumberIdentifier("+12223334444"), new PhoneNumberIdentifier("+12223334444", "some id"));
            Assert.AreNotEqual(new PhoneNumberIdentifier("+12223334444", "some id"), new PhoneNumberIdentifier("+12223334444", "another id"));
        }

        [Test]
        public void MicrosoftTeamsUserIdentifier_DefaultCloudIsPublic()
            => Assert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsUserIdentifier("user id", true, "some id").Cloud);
    }
}
