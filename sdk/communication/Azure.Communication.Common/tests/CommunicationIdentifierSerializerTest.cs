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
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { Id = "some id", MicrosoftTeamsUserId = "some id" }, // Missing IsAnonymous
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { Id = "some id", IsAnonymous = true }, // Missing MicrosoftTeamsUserId
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
            CommunicationIdentifier identifier = CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CommunicationUser)
                {
                    Id = "some id",
                });

            CommunicationUserIdentifier expectedIdentifier = new CommunicationUserIdentifier("some id");

            Assert.True(identifier is CommunicationUserIdentifier);
            Assert.AreEqual(expectedIdentifier.Id, ((CommunicationUserIdentifier)identifier).Id);
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
                CommunicationIdentifierSerializer.Deserialize(
                    new CommunicationIdentifierModel(CommunicationIdentifierKind.Unknown)
                    {
                        Id = "some id",
                    }));

            AssertCorrectness(
                new UnknownIdentifier("some id"),
                CommunicationIdentifierSerializer.Deserialize(
                    new CommunicationIdentifierModel(new CommunicationIdentifierKind("Some Future Type"))
                    {
                        Id = "some id",
                    }));

            static void AssertCorrectness(UnknownIdentifier expectedIdentifier, CommunicationIdentifier identifier)
            {
                Assert.True(identifier is UnknownIdentifier);
                Assert.AreEqual(expectedIdentifier.Id, ((UnknownIdentifier)identifier).Id);
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
            CommunicationIdentifier identifier = CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.CallingApplication)
                {
                    Id = "some id",
                });

            CallingApplicationIdentifier expectedIdentifier = new CallingApplicationIdentifier("some id");

            Assert.True(identifier is CallingApplicationIdentifier);
            Assert.AreEqual(expectedIdentifier.Id, ((CallingApplicationIdentifier)identifier).Id);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        public void SerializePhoneNumber()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new PhoneNumberIdentifier("+12223334444"));

            Assert.AreEqual(CommunicationIdentifierKind.PhoneNumber, model.Kind);
            Assert.AreEqual("+12223334444", model.PhoneNumber);
        }

        [Test]
        public void DeserializePhoneNumber()
        {
            CommunicationIdentifier identifier = CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber)
                {
                    PhoneNumber = "+12223334444",
                });

            PhoneNumberIdentifier expectedIdentifier = new PhoneNumberIdentifier("+12223334444");

            Assert.True(identifier is PhoneNumberIdentifier);
            Assert.AreEqual(expectedIdentifier.PhoneNumber, ((PhoneNumberIdentifier)identifier).PhoneNumber);
            Assert.AreEqual(expectedIdentifier, identifier);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void SerializeMicrosoftTeamsUser(bool isAnonymous)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new MicrosoftTeamsUserIdentifier("some id", isAnonymous));

            Assert.AreEqual(CommunicationIdentifierKind.MicrosoftTeamsUser, model.Kind);
            Assert.AreEqual("some id", model.MicrosoftTeamsUserId);
            Assert.AreEqual(isAnonymous, model.IsAnonymous);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void DeserializerMicrosoftTeamsUser(bool isAnonymous)
        {
            CommunicationIdentifier identifier = CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser)
                {
                    MicrosoftTeamsUserId = "some id",
                    IsAnonymous = isAnonymous,
                });

            MicrosoftTeamsUserIdentifier expectedIdentifier = new MicrosoftTeamsUserIdentifier("some id", isAnonymous);

            Assert.True(identifier is MicrosoftTeamsUserIdentifier);
            Assert.AreEqual(expectedIdentifier.UserId, ((MicrosoftTeamsUserIdentifier)identifier).UserId);
            Assert.AreEqual(expectedIdentifier.IsAnonymous, ((MicrosoftTeamsUserIdentifier)identifier).IsAnonymous);
            Assert.AreEqual(expectedIdentifier, identifier);
        }
    }
}
