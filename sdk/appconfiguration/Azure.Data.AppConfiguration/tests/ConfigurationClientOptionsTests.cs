// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationClientOptionsTests
    {
        // This test validates that the client options always uses the supplied token audience
        // when it is provided via the options.
        [TestCaseSource(nameof(GetDefaultScopeWithSuppliedValueTestCases))]
        public void TestGetDefaultScope_WithSuppliedValue(
            AppConfigurationAudience? configurationAudience,
            string url,
            string expectedScope)
        {
            var options = new ConfigurationClientOptions
            {
                Audience = configurationAudience
            };

            var defaultScope = options.GetDefaultScope(new Uri(url));
            Assert.That(defaultScope, Is.EqualTo(expectedScope));
        }

        // This test validates that the token audience and scope is correctly parsed from the URL
        [TestCaseSource(nameof(GetDefaultScopeTestCases))]
        public void TestGetDefaultScope(string url, string expectedScope)
        {
            var defaultScope = new ConfigurationClientOptions().GetDefaultScope(new Uri(url));
            Assert.That(defaultScope, Is.EqualTo(expectedScope));
        }

        public static IEnumerable<TestCaseData> GetDefaultScopeWithSuppliedValueTestCases
        {
            get
            {
                yield return new TestCaseData(AppConfigurationAudience.AzurePublicCloud, "https://locaLhost.azconfiG.com", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(AppConfigurationAudience.AzurePublicCloud, "https://locaLhost.azconfiG.com/", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(AppConfigurationAudience.AzureChina, "https://other.AZconfig.cn", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData(AppConfigurationAudience.AzureChina, "https://other.AZconfig.cn/", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData(AppConfigurationAudience.AzureGovernment, "https://gov-localhost-2353453.azconfig.us", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData(AppConfigurationAudience.AzureGovernment, "https://gov-localhost-2353453.azconfig.us/", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData(null, "https://localhost.azconfig.com", "https://azconfig.com/.default");
                yield return new TestCaseData(null, "https://localhost.azconfig.com/", "https://azconfig.com/.default");
                yield return new TestCaseData(new AppConfigurationAudience("my.custom.audience"), "http://other.my.custom.audience", "my.custom.audience/.default");
                yield return new TestCaseData(new AppConfigurationAudience("my.custom.audience"), "http://other.my.custom.audience/", "my.custom.audience/.default");
            }
        }

        public static IEnumerable<TestCaseData> GetDefaultScopeTestCases
        {
            get
            {
                // public cloud
                yield return new TestCaseData("http://locaLhost.azconfiG.io", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://locaLhost.azconfiG.io/", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://locaLhost.azconfiG.io//", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.azconfig.io", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.com", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.com/", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                // staging is an explicitly recognized host
                yield return new TestCaseData("https://contoso.appconfig-staging.azure.com", "https://appconfig-staging.azure.com/.default");
                yield return new TestCaseData("https://contoso.appconfig-staging.azure.com/", "https://appconfig-staging.azure.com/.default");
                yield return new TestCaseData("https://appconfig-staging.azure.com", "https://appconfig-staging.azure.com/.default");
                // derived audience for hosts that do not match a well-known cloud, anchored on the exact appconfig/azconfig marker
                yield return new TestCaseData("https://contoso.appconfig.sovereign.cloud", "https://appconfig.sovereign.cloud/.default");
                // derived audience is anchored on the appconfig/azconfig marker, so any leading labels (such as the store name) are ignored
                yield return new TestCaseData("https://contoso.eastus.appconfig.sovereign.cloud", "https://appconfig.sovereign.cloud/.default");
                // hyphenated labels other than the recognized staging host are not treated as a marker, so they fall back to the public cloud audience
                yield return new TestCaseData("https://contoso.appconfig-test.azure.com", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                // hosts without an appconfig/azconfig marker fall back to the public cloud audience
                yield return new TestCaseData("http://other.my.custom.audience", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                // well-known cloud suffixes only match on a DNS label boundary, so look-alike hosts are not misclassified
                yield return new TestCaseData("https://myazconfig.io", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.fooappconfig.azure.us", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                // china cloud
                yield return new TestCaseData("http://other-23232.AZconfig.azure.cn", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.azconfig.azure.cn", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://other.APPconfig.azure.cn", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn/", $"{AppConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn//", $"{AppConfigurationAudience.AzureChina}/.default");
                // us gov cloud
                yield return new TestCaseData("http://other-23232.AZconfig.azure.us", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.azconfig.azure.us", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://other.APPconfig.azure.us", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us/", $"{AppConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us//", $"{AppConfigurationAudience.AzureGovernment}/.default");
            }
        }
    }
}
