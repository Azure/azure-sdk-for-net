// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Azure.Communication
{
    public class CommunicationIdentifierSerializerTest
    {
        private const string TestUserId = "User Id";
        private const string TestRawId = "Raw Id";
        private const string TestPhoneNumber = "+12223334444";
        private const string TestTeamsUserId = "Microsoft Teams User Id";
        private const string TestTeamsCloud = "gcch";

        [Test]
        public void MoreThanOneNestedObject_DeserializerThrows()
        {
            CommunicationIdentifierModel[] modelsWithTooManyNestedObjects = new[]
            {
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestUserId),
                    PhoneNumber = new PhoneNumberIdentifierModel(TestPhoneNumber),
                },
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestUserId),
                    MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId, isAnonymous: true, CommunicationCloudEnvironmentModel.Public),
                },
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    PhoneNumber = new PhoneNumberIdentifierModel(TestPhoneNumber),
                    MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId, isAnonymous: true, CommunicationCloudEnvironmentModel.Public),
                },
            };

            foreach (CommunicationIdentifierModel item in modelsWithTooManyNestedObjects)
                Assert.Throws<JsonException>(() => CommunicationIdentifierSerializer.Deserialize(item));
        }

        [Test]
        public void MissingProperty_DeserializerThrows()
        {
            CommunicationIdentifierModel[] modelsWithMissingMandatoryProperty = new[]
            {
                new CommunicationIdentifierModel(), // Missing RawId
                new CommunicationIdentifierModel { RawId = TestRawId, MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId) { Cloud = CommunicationCloudEnvironmentModel.Public } }, // Missing IsAnonymous
                new CommunicationIdentifierModel { RawId = TestRawId, MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId) { IsAnonymous = true, } }, // Missing Cloud
            };

            foreach (CommunicationIdentifierModel item in modelsWithMissingMandatoryProperty)
                Assert.Throws<JsonException>(() => CommunicationIdentifierSerializer.Deserialize(item));
        }

        [Test]
        public void SerializeCommunicationUser()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new CommunicationUserIdentifier(TestUserId));

            Assert.AreEqual(TestUserId, model.CommunicationUser.Id);
        }

        [Test]
        public void DeserializeCommunicationUser()
        {
            CommunicationUserIdentifier identifier = (CommunicationUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    CommunicationUser = new CommunicationUserIdentifierModel(TestUserId),
                    RawId = TestRawId,
                });

            CommunicationUserIdentifier expectedIdentifier = new CommunicationUserIdentifier(TestUserId);

            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        public void SerializeUnknown()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new UnknownIdentifier(TestRawId));

            Assert.AreEqual(TestRawId, model.RawId);
        }

        [Test]
        public void DeserializeUnknown()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                });
            UnknownIdentifier expectedIdentifier = new UnknownIdentifier(TestRawId);

            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        [TestCase(null)]
        [TestCase(TestRawId)]
        public void SerializePhoneNumber(string? expectedRawId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new PhoneNumberIdentifier(TestPhoneNumber, expectedRawId));

            Assert.AreEqual(TestPhoneNumber, model.PhoneNumber.Value);
            Assert.AreEqual(expectedRawId, model.RawId);
        }

        [Test]
        public void DeserializePhoneNumber()
        {
            PhoneNumberIdentifier identifier = (PhoneNumberIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    PhoneNumber = new PhoneNumberIdentifierModel(TestPhoneNumber),
                    RawId = TestRawId,
                });

            PhoneNumberIdentifier expectedIdentifier = new PhoneNumberIdentifier(TestPhoneNumber, TestRawId);

            Assert.AreEqual(expectedIdentifier.PhoneNumber, identifier.PhoneNumber);
            Assert.AreEqual(expectedIdentifier.RawId, identifier.RawId);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        [TestCase(false, null)]
        [TestCase(true, null)]
        [TestCase(false, TestRawId)]
        [TestCase(true, TestRawId)]
        public void SerializeMicrosoftTeamsUser(bool isAnonymous, string? expectedRawId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new MicrosoftTeamsUserIdentifier(TestTeamsUserId, isAnonymous, CommunicationCloudEnvironment.Dod, expectedRawId));

            Assert.AreEqual(TestTeamsUserId, model.MicrosoftTeamsUser.UserId);
            Assert.AreEqual(CommunicationCloudEnvironmentModel.Dod, model.MicrosoftTeamsUser.Cloud);
            Assert.AreEqual(isAnonymous, model.MicrosoftTeamsUser.IsAnonymous);
            Assert.AreEqual(expectedRawId, model.RawId);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void DeserializeMicrosoftTeamsUser(bool isAnonymous)
        {
            MicrosoftTeamsUserIdentifier identifier = (MicrosoftTeamsUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId)
                    {
                        IsAnonymous = isAnonymous,
                        Cloud = TestTeamsCloud,
                    },
                    RawId = TestRawId,
                });

            MicrosoftTeamsUserIdentifier expectedIdentifier = new MicrosoftTeamsUserIdentifier(TestTeamsUserId, isAnonymous, CommunicationCloudEnvironment.Gcch, TestRawId);

            Assert.AreEqual(expectedIdentifier.UserId, identifier.UserId);
            Assert.AreEqual(expectedIdentifier.IsAnonymous, identifier.IsAnonymous);
            Assert.AreEqual(expectedIdentifier.Cloud, identifier.Cloud);
            Assert.AreEqual(expectedIdentifier.RawId, identifier.RawId);
            Assert.AreEqual(expectedIdentifier, identifier);
        }
    }
}
