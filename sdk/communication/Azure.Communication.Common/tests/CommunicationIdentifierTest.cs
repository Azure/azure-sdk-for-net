// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Communication
{
    public class CommunicationIdentifierTest
    {
        private const string TestUserId = "User Id";
        private const string TestRawId = "Raw Id";
        private const string TestPhoneNumber = "+14255550123";
        private const string TestTeamsUserId = "Microsoft Teams User Id";

        [Test]
        public void IfIdIsOptional_EqualityOnlyTestIfPresentOnBothSide()
        {
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true, rawId: TestRawId), new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true));
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true), new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true));
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true), new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true, rawId: TestRawId));
            Assert.AreNotEqual(new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true, rawId: TestRawId), new MicrosoftTeamsUserIdentifier(TestUserId, isAnonymous: true, rawId: "Another Raw Id"));

            Assert.AreEqual(new PhoneNumberIdentifier(TestPhoneNumber, TestRawId), new PhoneNumberIdentifier(TestPhoneNumber));
            Assert.AreEqual(new PhoneNumberIdentifier(TestPhoneNumber), new PhoneNumberIdentifier(TestPhoneNumber));
            Assert.AreEqual(new PhoneNumberIdentifier(TestPhoneNumber), new PhoneNumberIdentifier(TestPhoneNumber, TestRawId));
            Assert.AreNotEqual(new PhoneNumberIdentifier(TestPhoneNumber, TestRawId), new PhoneNumberIdentifier(TestPhoneNumber, "Another Raw Id"));
        }

        [Test]
        public void MicrosoftTeamsUserIdentifier_DefaultCloudIsPublic()
            => Assert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsUserIdentifier(TestTeamsUserId, isAnonymous: true, rawId: TestRawId).Cloud);
    }
}
