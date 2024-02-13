using System;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class ConfigurationManagerTests
    {
        private const string audienceAppId = "audienceAppId";
        private const string tenantId = "tenantId";
        private const string oidcHost = "oidc";
        private const string issuerv1 = "issuerv1";
        private const string issuerv2 = "issuerv2";

        [Test]
        public void Test_When_Attribute_Is_Null()
        {
            Assert.Throws<MissingFieldException>(() => new ConfigurationManager(null), "Test when attribute is null");
        }

        [Test]
        public void Test_When_Attributes_TenantId_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = null,
                AudienceAppId = audienceAppId,
                TokenIssuerV1 = issuerv1,
                TokenIssuerV2 = issuerv2,
                OpenIdConnectionHost = oidcHost
            };
            Assert.Throws<MissingFieldException>(() => new ConfigurationManager(attribute), "Test when attribute's tenantId is null");
        }

        [Test]
        public void Test_When_Attributes_AudienceAppId_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = null,
                TokenIssuerV1 = issuerv1,
                TokenIssuerV2 = issuerv2,
                OpenIdConnectionHost = oidcHost
            };
            Assert.Throws<MissingFieldException>(() => new ConfigurationManager(attribute), "Test when attribute's audienceAppId is null");
        }

        [Test]
        public void Test_When_Attributes_TokenIssuerV1_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                TokenIssuerV1 = null,
                TokenIssuerV2 = issuerv2,
                OpenIdConnectionHost = oidcHost
            };
            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Test when attribute's TokenIssuerV1 is null");
            Assert.IsNotNull(configurationManager, "Test when attribute's TokenIssuerV1 is null");
            Assert.IsTrue(configurationManager.ConfiguredService.IsDefault, "When full configuration not provided, default service should be set");
        }

        [Test]
        public void Test_When_Attributes_TokenIssuerV2_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                TokenIssuerV1 = issuerv1,
                TokenIssuerV2 = null,
                OpenIdConnectionHost = oidcHost
            };
            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Test when attribute's TokenIssuerV2 is null");
            Assert.IsNotNull(configurationManager, "Test when attribute's TokenIssuerV2 is null");
            Assert.IsTrue(configurationManager.ConfiguredService.IsDefault, "When full configuration not provided, default service should be set");
        }

        [Test]
        public void Test_When_Attributes_OpenIdConnectionHost_Is_Null()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                TokenIssuerV1 = issuerv1,
                TokenIssuerV2 = issuerv2,
                OpenIdConnectionHost = null
            };
            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsNotNull(configurationManager, "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsTrue(configurationManager.ConfiguredService.IsDefault, "When full configuration not provided, default service should be set");
        }

        [Test]
        public void Test_Success_Custom()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId,
                TokenIssuerV1 = issuerv1,
                TokenIssuerV2 = issuerv2,
                OpenIdConnectionHost = oidcHost
            };
            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsNotNull(configurationManager, "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsFalse(configurationManager.ConfiguredService.IsDefault, "When full configuration not provided, default service should be set");

            Assert.AreEqual(tenantId, configurationManager.ConfiguredService.TenantId, "TenantId should be set to the custom");
            Assert.AreEqual(audienceAppId, configurationManager.ConfiguredService.ApplicationId, "AudienceAppId should be set to the custom");
            Assert.AreEqual(oidcHost, configurationManager.ConfiguredService.OIDCMetadataUrl, "OIDCMetadataUrl should be set to the custom");
            Assert.AreEqual(issuerv1, configurationManager.ConfiguredService.TokenIssuerV1, "TokenIssuerV1 should be set to the custom");
            Assert.AreEqual(issuerv2, configurationManager.ConfiguredService.TokenIssuerV2, "TokenIssuerV2 should be set to the custom");
        }

        [Test]
        public void Test_Success_Ests()
        {
            var attribute = new AuthenticationEventsTriggerAttribute
            {
                TenantId = tenantId,
                AudienceAppId = audienceAppId
            };
            ConfigurationManager configurationManager = null;
            Assert.DoesNotThrow(() => configurationManager = new ConfigurationManager(attribute), "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsNotNull(configurationManager, "Test when attribute's OIDCMetadataUrl is null");
            Assert.IsTrue(configurationManager.ConfiguredService.IsDefault, "When full configuration not provided, default service should be set");
        }
    }
}
