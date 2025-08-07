using System;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class ConfigurationManagerTests
    {
        private const string testAudienceAppId = "00010001-0001-0001-0001-000100010001";
        private const string testAuthorizedPartyId = "00000000-0000-0000-0000-000000000000";
        private const string testAuthorityUrl = "https://oidc";

        private ConfigurationManager configurationManager = null;

        [SetUp]
        public void Setup()
        {
            configurationManager = null;
        }

        [Test]
        public void Test_When_Attribute_Is_Null()
        {
            string testMessage = "Attribute is null";

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(null), testMessage);
            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);
            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            ValidateAuthorityUrl(configurationManager, testMessage, false);
        }

        [Test]
        public void Test_When_Attribute_Is_Empty()
        {
            string testMessage = "Attributes are empty";

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(new WebJobsAuthenticationEventsTriggerAttribute()), testMessage);
            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);
            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            Assert.AreEqual("99045fe1-7639-4a75-9d4a-577b6ca3810f", configurationManager.AuthorizedPartyAppId, testMessage);

            ValidateAuthorityUrl(configurationManager, testMessage, false);
        }

        [Test]
        public void Test_When_Attribute_Is_Only_AuthorizedPartyIsConfigured()
        {
            string testMessage = "Only Authorized Party is configured.";

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(new WebJobsAuthenticationEventsTriggerAttribute() { AuthorizedPartyAppId = testAuthorizedPartyId }), testMessage);
            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);
            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            Assert.AreEqual(testAuthorizedPartyId, configurationManager.AuthorizedPartyAppId, testMessage);

            ValidateAuthorityUrl(configurationManager, testMessage, false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_When_Attributes_AuthorizedPartyAppId_Is_Null(string value)
        {
            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AuthorizedPartyAppId = value,
                AudienceAppId = testAudienceAppId,
                AuthorityUrl = testAuthorityUrl
            };

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Config should not throw when initialized.");
            Assert.DoesNotThrow(() => _ = configurationManager.AudienceAppId, "Audience is not null");
            Assert.AreEqual(testAudienceAppId, configurationManager.AudienceAppId, "Audience should match what it was set to.");

            ValidateAuthorityUrl(configurationManager, "AuthorityURl should match what match to what it was set to.");

            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AuthorizedPartyAppId, "Should throw if value of AuthorizedPartyAppId was set. No Default.");
        }

        [Test]
        public void Test_When_Attributes_AuthorizedPartyAppId_Is_NotSet()
        {
            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AudienceAppId = testAudienceAppId,
                AuthorityUrl = testAuthorityUrl
            };

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Config should not throw when initialized.");
            Assert.DoesNotThrow(() => _ = configurationManager.AudienceAppId, "Audience is not null");
            Assert.AreEqual(testAudienceAppId, configurationManager.AudienceAppId, "Audience should match what it was set to.");

            ValidateAuthorityUrl(configurationManager, "AuthorityURl should match what match to what it was set to.");

            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, "Should not throw when AuthorizedPartyAppId is not set.");
            Assert.AreEqual("99045fe1-7639-4a75-9d4a-577b6ca3810f", configurationManager.AuthorizedPartyAppId, "AuthorizedPartyAppId should match default value.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_When_Attributes_AudienceAppId_Is_Null(string value)
        {
            string testMessage = "Audience App ID is null.";

            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AuthorizedPartyAppId = testAuthorizedPartyId,
                AudienceAppId = value,
                AuthorityUrl = testAuthorityUrl
            };
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessage);

            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);

            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            ValidateAuthorityUrl(configurationManager, testMessage);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_When_Attributes_AuthorityUrl_Is_Null(string value)
        {
            string testMessage = "Authority URL is null. Should use default value";

            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AuthorizedPartyAppId = testAuthorizedPartyId,
                AudienceAppId = testAudienceAppId,
                AuthorityUrl = value
            };
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessage);

            Assert.DoesNotThrow(() => _ = configurationManager.AudienceAppId, testMessage);
            Assert.AreEqual(testAudienceAppId, configurationManager.AudienceAppId, testMessage);

            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            Assert.AreEqual(testAuthorizedPartyId, configurationManager.AuthorizedPartyAppId, testMessage);

            ValidateAuthorityUrl(configurationManager, testMessage, false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_When_Attributes_AudienceAppId_Is_Null_And_Authority_Is_Null(string value)
        {
            string testMessage = "AudienceAppId and AuthorityUrl is null.";

            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AuthorizedPartyAppId = testAuthorizedPartyId,
                AudienceAppId = value,
                AuthorityUrl = value
            };

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessage);
            Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);

            Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);
            ValidateAuthorityUrl(configurationManager, testMessage, false);
        }

        [Test]
        public void Test_Success_Custom()
        {
            string testMessage = "Test when all attributes are set. Result should be custom OIDC Config.";

            var attribute = new WebJobsAuthenticationEventsTriggerAttribute
            {
                AuthorizedPartyAppId = testAuthorizedPartyId,
                AudienceAppId = testAudienceAppId,
                AuthorityUrl = testAuthorityUrl
            };

            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessage);
            ValidateAudienceAppId(configurationManager, testMessage);
            ValidateAuthorizedPartyAppId(configurationManager, testMessage);
            ValidateAuthorityUrl(configurationManager, testMessage);
        }

        private void ValidateAudienceAppId(ConfigurationManager configurationManager, string testMessage, bool isSuccess = true)
        {
            if (isSuccess)
            {
                Assert.DoesNotThrow(() => _ = configurationManager.AudienceAppId, testMessage);
                Assert.AreEqual(testAudienceAppId, configurationManager.AudienceAppId, testMessage);
            }
            else
            {
                Assert.Throws<MissingFieldException>(() => _ = configurationManager.AudienceAppId, testMessage);
            }
        }

        private void ValidateAuthorizedPartyAppId(ConfigurationManager configurationManager, string testMessage, bool isSuccess = true)
        {
            if (isSuccess)
            {
                Assert.DoesNotThrow(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
                Assert.AreEqual(testAuthorizedPartyId, configurationManager.AuthorizedPartyAppId, testMessage);
            }
            else
            {
                Assert.Throws<MissingFieldException>(() => _ = configurationManager.AuthorizedPartyAppId, testMessage);
            }
        }

        private void ValidateAuthorityUrl(ConfigurationManager configurationManager, string testMessage, bool isSuccess = true)
        {
            if (isSuccess)
            {
                Assert.DoesNotThrow(() => _ = configurationManager.AuthorityUrl, testMessage);
                Assert.AreEqual(testAuthorityUrl, configurationManager.AuthorityUrl, testMessage);

                string odicUrlV1 = configurationManager.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0);
                string odicUrlV2 = configurationManager.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0);

                Assert.AreEqual($"{testAuthorityUrl}/.well-known/openid-configuration", odicUrlV1, testMessage);
                Assert.AreEqual($"{testAuthorityUrl}/v2.0/.well-known/openid-configuration", odicUrlV2, testMessage);
            }
            else
            {
                Assert.Throws<MissingFieldException>(() => _ = configurationManager.AuthorityUrl, testMessage);
                Assert.Throws<MissingFieldException>(() => _ = configurationManager.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0), testMessage);
                Assert.Throws<MissingFieldException>(() => _ = configurationManager.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0), testMessage);
            }
        }
    }
}
