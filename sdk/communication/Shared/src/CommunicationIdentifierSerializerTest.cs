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
        private const string TestPhoneNumberRawId = "4:+12223334444";
        private const string TestTeamsUserId = "Microsoft Teams User Id";
        private const string TestTeamsAppId = "Microsoft Teams App Id";
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
                 new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestTeamsAppId),
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsAppId, CommunicationCloudEnvironmentModel.Public),
                },
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestTeamsAppId),
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsAppId, CommunicationCloudEnvironmentModel.Dod),
                },
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestTeamsAppId),
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsAppId, CommunicationCloudEnvironmentModel.Gcch),
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
                new CommunicationIdentifierModel { RawId = TestRawId, MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsUserId) } // Missing cloud
            };

            foreach (CommunicationIdentifierModel item in modelsWithMissingMandatoryProperty)
                Assert.Throws<JsonException>(() => CommunicationIdentifierSerializer.Deserialize(item));
        }

        [Test]
        public void SerializeCommunicationUser()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new CommunicationUserIdentifier(TestUserId));

            Assert.That(model.CommunicationUser.Id, Is.EqualTo(TestUserId));
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

            CommunicationUserIdentifier expectedIdentifier = new(TestUserId);

            Assert.That(identifier.Id, Is.EqualTo(expectedIdentifier.Id));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeCommunicationUser_WithKind_DeserializesSuccessfully()
        {
            CommunicationUserIdentifier identifier = (CommunicationUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.CommunicationUser,
                    CommunicationUser = new CommunicationUserIdentifierModel(TestUserId),
                    RawId = TestRawId,
                });

            CommunicationUserIdentifier expectedIdentifier = new(TestUserId);

            Assert.That(identifier.Id, Is.EqualTo(expectedIdentifier.Id));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeCommunicationUser_WithKindAndNoUser_DeserializesUnknownIdentifier()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.MicrosoftTeamsUser,
                    RawId = TestRawId,
                });

            UnknownIdentifier expectedIdentifier = new(TestRawId);

            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void SerializeUnknown()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new UnknownIdentifier(TestRawId));

            Assert.That(model.RawId, Is.EqualTo(TestRawId));
        }

        [Test]
        public void DeserializeUnknown()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    RawId = TestRawId,
                });
            UnknownIdentifier expectedIdentifier = new(TestRawId);

            Assert.That(identifier.Id, Is.EqualTo(expectedIdentifier.Id));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        [TestCase(null)]
        [TestCase(TestPhoneNumberRawId)]
        public void SerializePhoneNumber(string? rawId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(new PhoneNumberIdentifier(TestPhoneNumber, rawId));

            Assert.That(model.PhoneNumber.Value, Is.EqualTo(TestPhoneNumber));
            Assert.That(model.RawId, Is.EqualTo(TestPhoneNumberRawId));
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

            PhoneNumberIdentifier expectedIdentifier = new(TestPhoneNumber, TestRawId);

            Assert.That(identifier.PhoneNumber, Is.EqualTo(expectedIdentifier.PhoneNumber));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializePhoneNumber_WithKind_DeserializesSuccessfully()
        {
            PhoneNumberIdentifier identifier = (PhoneNumberIdentifier)CommunicationIdentifierSerializer.Deserialize(
                            new CommunicationIdentifierModel
                            {
                                Kind = CommunicationIdentifierModelKind.PhoneNumber,
                                PhoneNumber = new PhoneNumberIdentifierModel(TestPhoneNumber),
                                RawId = TestRawId,
                            });

            PhoneNumberIdentifier expectedIdentifier = new(TestPhoneNumber, TestRawId);

            Assert.That(identifier.PhoneNumber, Is.EqualTo(expectedIdentifier.PhoneNumber));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializePhoneNumber_WithKindAndNoNumber_DeserializesUnknownIdentifier()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.PhoneNumber,
                    RawId = TestRawId,
                });

            UnknownIdentifier expectedIdentifier = new(TestRawId);

            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        [TestCase(false, null)]
        [TestCase(true, null)]
        [TestCase(false, TestRawId)]
        [TestCase(true, TestRawId)]
        public void SerializeMicrosoftTeamsUser(bool isAnonymous, string? rawId)
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(
                new MicrosoftTeamsUserIdentifier(TestTeamsUserId, isAnonymous, CommunicationCloudEnvironment.Dod, rawId));

            Assert.That(model.MicrosoftTeamsUser.UserId, Is.EqualTo(TestTeamsUserId));
            Assert.That(model.MicrosoftTeamsUser.Cloud, Is.EqualTo(CommunicationCloudEnvironmentModel.Dod));
            Assert.That(model.MicrosoftTeamsUser.IsAnonymous, Is.EqualTo(isAnonymous));
            Assert.That(model.RawId, Is.EqualTo(rawId ?? $"8:{(isAnonymous ? "teamsvisitor" : "dod")}:{TestTeamsUserId}"));
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

            MicrosoftTeamsUserIdentifier expectedIdentifier = new(TestTeamsUserId, isAnonymous, CommunicationCloudEnvironment.Gcch, TestRawId);

            Assert.That(identifier.UserId, Is.EqualTo(expectedIdentifier.UserId));
            Assert.That(identifier.IsAnonymous, Is.EqualTo(expectedIdentifier.IsAnonymous));
            Assert.That(identifier.Cloud, Is.EqualTo(expectedIdentifier.Cloud));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeMicrosoftTeamsUser_WithKind_DeserializesSuccessfully()
        {
            MicrosoftTeamsUserIdentifier identifier = (MicrosoftTeamsUserIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.MicrosoftTeamsUser,
                    MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(TestTeamsUserId)
                    {
                        IsAnonymous = false,
                        Cloud = TestTeamsCloud,
                    },
                    RawId = TestRawId,
                });

            MicrosoftTeamsUserIdentifier expectedIdentifier = new(TestTeamsUserId, false, CommunicationCloudEnvironment.Gcch, TestRawId);

            Assert.That(identifier.UserId, Is.EqualTo(expectedIdentifier.UserId));
            Assert.That(identifier.IsAnonymous, Is.EqualTo(expectedIdentifier.IsAnonymous));
            Assert.That(identifier.Cloud, Is.EqualTo(expectedIdentifier.Cloud));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeMicrosoftTeamsUser_WithKindAndNoUser_DeserializesUnknownIdentifier()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.MicrosoftTeamsUser,
                    RawId = TestRawId,
                });

            UnknownIdentifier expectedIdentifier = new(TestRawId);

            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void SerializeMicrosoftTeamsApp()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(
                new MicrosoftTeamsAppIdentifier(TestTeamsAppId, CommunicationCloudEnvironment.Dod));

            Assert.That(model.MicrosoftTeamsApp.AppId, Is.EqualTo(TestTeamsAppId));
            Assert.That(model.MicrosoftTeamsApp.Cloud, Is.EqualTo(CommunicationCloudEnvironmentModel.Dod));
            Assert.That(model.RawId, Is.EqualTo($"28:dod:{TestTeamsAppId}"));
        }

        [Test]
        public void DeserializeMicrosoftTeamsApp()
        {
            MicrosoftTeamsAppIdentifier identifier = (MicrosoftTeamsAppIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsAppId)
                    {
                        Cloud = TestTeamsCloud,
                    },
                    RawId = TestRawId,
                });

            MicrosoftTeamsAppIdentifier expectedIdentifier = new(TestTeamsAppId, CommunicationCloudEnvironment.Gcch);

            Assert.That(identifier.AppId, Is.EqualTo(expectedIdentifier.AppId));
            Assert.That(identifier.Cloud, Is.EqualTo(expectedIdentifier.Cloud));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeMicrosoftTeamsApp_WithKind_DeserializesSuccessfully()
        {
            MicrosoftTeamsAppIdentifier identifier = (MicrosoftTeamsAppIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.MicrosoftTeamsApp,
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(TestTeamsAppId)
                    {
                        Cloud = TestTeamsCloud,
                    },
                    RawId = TestRawId,
                });

            MicrosoftTeamsAppIdentifier expectedIdentifier = new(TestTeamsAppId, CommunicationCloudEnvironment.Gcch);

            Assert.That(identifier.AppId, Is.EqualTo(expectedIdentifier.AppId));
            Assert.That(identifier.Cloud, Is.EqualTo(expectedIdentifier.Cloud));
            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }

        [Test]
        public void DeserializeMicrosoftTeamsApp_WithKindAndNoUser_DeserializesUnknownIdentifier()
        {
            UnknownIdentifier identifier = (UnknownIdentifier)CommunicationIdentifierSerializer.Deserialize(
                new CommunicationIdentifierModel
                {
                    Kind = CommunicationIdentifierModelKind.MicrosoftTeamsApp,
                    RawId = TestRawId,
                });

            UnknownIdentifier expectedIdentifier = new(TestRawId);

            Assert.That(identifier.RawId, Is.EqualTo(expectedIdentifier.RawId));
            Assert.That(identifier, Is.EqualTo(expectedIdentifier));
        }
    }
}
