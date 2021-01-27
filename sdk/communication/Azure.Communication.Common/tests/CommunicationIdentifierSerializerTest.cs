// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Azure.Communication
{
    public class CommunicationIdentifierSerializerTest
    {
        [Test]
        public void MissingProperty_DeserializerThrows()
        {
            CommunicationIdentifierModel[] modelsWithMissingMandatoryProperty = new[]
            {
                new CommunicationIdentifierModel(CommunicationIdentifierKind.Unknown), // Missing Id
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CommunicationUser), // Missing Id
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CallingApplication), // Missing Id
                new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber) { Id = "some id" }, // Missing PhoneNumber
                new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber) { PhoneNumber = "+12223334444" }, // Missing Id
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { Id = "some id", MicrosoftTeamsUserId = "some id", Cloud = CommunicationCloudEnvironmentModel.Public }, // Missing IsAnonymous
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { Id = "some id", IsAnonymous = true, Cloud = CommunicationCloudEnvironmentModel.Public }, // Missing MicrosoftTeamsUserId
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { MicrosoftTeamsUserId = "some id", IsAnonymous = true, Cloud = CommunicationCloudEnvironmentModel.Public }, // Missing Id
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { Id = "some id", MicrosoftTeamsUserId = "some id", IsAnonymous = true, }, // Missing Cloud
            };

            foreach (CommunicationIdentifierModel item in modelsWithMissingMandatoryProperty)
                Assert.Throws<JsonException>(() => CommunicationIdentifierSerializer.Deserialize(item));
        }

        [Test]
        public void SerializeCommunicationUser()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new CommunicationUserIdentifier("some id"));

            Assert.AreEqual(CommunicationIdentifierKind.CommunicationUser, model.Kind);
            Assert.AreEqual("some id", model.Id);
        }

        [Test]
        public void DeserializeCommunicationUser()
        {
            CommunicationUserIdentifier identifier = (CommunicationUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CommunicationUser)
                {
                    Id = "some id",
                });

            CommunicationUserIdentifier expectedIdentifier = new CommunicationUserIdentifier("some id");

            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        public void SerializeUnknown()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new UnknownIdentifier("some id"));

            Assert.AreEqual(CommunicationIdentifierKind.Unknown, model.Kind);
            Assert.AreEqual("some id", model.Id);
        }

        [Test]
        public void DeserializeUnknown()
        {
            AssertCorrectness(
                new UnknownIdentifier("some id"),
                (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                    new CommunicationIdentifierModel(CommunicationIdentifierKind.Unknown)
                    {
                        Id = "some id",
                    }));

            AssertCorrectness(
                new UnknownIdentifier("some id"),
                (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                    new CommunicationIdentifierModel(new CommunicationIdentifierKind("Some Future Type"))
                    {
                        Id = "some id",
                    }));

            static void AssertCorrectness(UnknownIdentifier expectedIdentifier, UnknownIdentifier identifier)
            {
                Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
                Assert.AreEqual(expectedIdentifier, identifier);
            }
        }

        [Test]
        public void SerializeCallingApplication()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new CallingApplicationIdentifier("some id"));

            Assert.AreEqual(CommunicationIdentifierKind.CallingApplication, model.Kind);
            Assert.AreEqual("some id", model.Id);
        }

        [Test]
        public void DeserializeCallingApplication()
        {
            CallingApplicationIdentifier identifier = (CallingApplicationIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CallingApplication)
                {
                    Id = "some id",
                });

            CallingApplicationIdentifier expectedIdentifier = new CallingApplicationIdentifier("some id");

            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        [TestCase(null)]
        [TestCase("some id")]
        public void SerializePhoneNumber(string? expectedId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new PhoneNumberIdentifier("+12223334444", expectedId));

            Assert.AreEqual(CommunicationIdentifierKind.PhoneNumber, model.Kind);
            Assert.AreEqual("+12223334444", model.PhoneNumber);
            Assert.AreEqual(expectedId, model.Id);
        }

        [Test]
        public void DeserializePhoneNumber()
        {
            PhoneNumberIdentifier identifier = (PhoneNumberIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber)
                {
                    PhoneNumber = "+12223334444",
                    Id = "some id"
                });

            PhoneNumberIdentifier expectedIdentifier = new PhoneNumberIdentifier("+12223334444", "some id");

            Assert.AreEqual(expectedIdentifier.PhoneNumber, identifier.PhoneNumber);
            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        [TestCase(false, null)]
        [TestCase(true, null)]
        [TestCase(false, "some id")]
        [TestCase(true, "some id")]
        public void SerializeMicrosoftTeamsUser(bool isAnonymous, string? expectedId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new MicrosoftTeamsUserIdentifier("user id", isAnonymous, expectedId, CommunicationCloudEnvironment.Dod));

            Assert.AreEqual(CommunicationIdentifierKind.MicrosoftTeamsUser, model.Kind);
            Assert.AreEqual("user id", model.MicrosoftTeamsUserId);
            Assert.AreEqual(CommunicationCloudEnvironmentModel.Dod, model.Cloud);
            Assert.AreEqual(isAnonymous, model.IsAnonymous);
            Assert.AreEqual(expectedId, model.Id);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void DeserializeMicrosoftTeamsUser(bool isAnonymous)
        {
            MicrosoftTeamsUserIdentifier identifier = (MicrosoftTeamsUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser)
                {
                    MicrosoftTeamsUserId = "user id",
                    IsAnonymous = isAnonymous,
                    Id = "some id",
                    Cloud = "gcch"
                });

            MicrosoftTeamsUserIdentifier expectedIdentifier = new MicrosoftTeamsUserIdentifier("user id", isAnonymous, "some id", CommunicationCloudEnvironment.Gcch);

            Assert.AreEqual(expectedIdentifier.UserId, identifier.UserId);
            Assert.AreEqual(expectedIdentifier.IsAnonymous, identifier.IsAnonymous);
            Assert.AreEqual(expectedIdentifier.Cloud, identifier.Cloud);
            Assert.AreEqual(expectedIdentifier.Id, identifier.Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }
    }
}
