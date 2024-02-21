using System;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class ConfigurationManagerTests
    {
        private const string audienceAppId = "testAudienceAppId";
        private const string tenantId = "testTenantId";
        private const string authorityUrl = "oidc";

        [Test]
        public void Test_When_Attribute_Is_Null()
        {
            Assert.Throws<MissingFieldException>(() => new ConfigurationManager(null), "Test when attribute is null");
        }

        [Test]
        public void Test_When_Attributes_AudienceAppId_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = null, // AudienceAppId is required when authority is provided.
                AuthorityUrl = authorityUrl
            };
            Assert.Throws<MissingFieldException>(() => new ConfigurationManager(attribute), "Test when attribute's audienceAppId is null");
        }

        [Test]
        public void Test_When_Attributes_AudienceAppId_Is_Null_And_Authority_Is_Null()
        {
            string testMessageString = "Test when attribute's Tenant ID is not null but other properties are. Result should be Azure Active Directory OIDC Config.";

            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = null, // AudienceAppId is required when authority is provided.
                AuthorityUrl = null // this will force it to be ESTS
            };

            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessageString);
            Assert.IsNotNull(configurationManager.ConfiguredService, testMessageString);
            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0),
                actual: $"https://login.microsoftonline.com/common/{tenantId}/.well-known/openid-configuration",
                message: testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0),
                actual: $"https://login.microsoftonline.com/common/{tenantId}/v2.0/.well-known/openid-configuration",
                message: testMessageString);
        }

        [Test]
        public void Test_When_Attributes_OidcMetadataUrl_Is_Null()
        {
            string testMessageString = "Test when authority url is null. Result should be Azure Active Directory OIDC Config.";

            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                AuthorityUrl = null
            };

            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessageString);
            Assert.IsNotNull(configurationManager.ConfiguredService, testMessageString);
            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0),
                actual: $"https://login.microsoftonline.com/common/{tenantId}/.well-known/openid-configuration",
                message: testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0),
                actual: $"https://login.microsoftonline.com/common/{tenantId}/v2.0/.well-known/openid-configuration",
                message: testMessageString);
        }

        [Test]
        public void Test_When_Attributes_TenantId_Is_Null()
        {
            string testMessageString = "Test when attribute's Tenant ID is null. Result should be cusomt OIDC Config.";

            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = null,
                AudienceAppId = audienceAppId,
                AuthorityUrl = authorityUrl
            };

            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessageString);
            Assert.IsNotNull(configurationManager.ConfiguredService, testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0),
                actual: $"{authorityUrl}/.well-known/openid-configuration",
                message: testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0),
                actual: $"{authorityUrl}/v2.0/.well-known/openid-configuration",
                message: testMessageString);
        }

        [Test]
        public void Test_Success_Custom()
        {
            string testMessageString = "Test when all attributes are set. Result should be custom OIDC Config.";

            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                AuthorityUrl = authorityUrl
            };

            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), testMessageString);
            Assert.IsNotNull(configurationManager.ConfiguredService, testMessageString);

            Assert.AreEqual(audienceAppId, configurationManager.ConfiguredService.ApplicationId, testMessageString);
            Assert.AreEqual(authorityUrl, configurationManager.ConfiguredService.Authority, testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V1_0),
                actual: $"{authorityUrl}/.well-known/openid-configuration",
                message: testMessageString);

            Assert.AreEqual(
                expected: configurationManager.ConfiguredService.GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions.V2_0),
                actual: $"{authorityUrl}/v2.0/.well-known/openid-configuration",
                message: testMessageString);
        }
    }
}
