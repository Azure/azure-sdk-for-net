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
            Assert.AreEqual(expectedScope, defaultScope);
        }

        // This test validates that the token audience and scope is correctly parsed from the URL
        [TestCaseSource(nameof(GetDefaultScopeTestCases))]
        public void TestGetDefaultScope(string url, string expectedScope)
        {
            var defaultScope = new ConfigurationClientOptions().GetDefaultScope(new Uri(url));
            Assert.AreEqual(expectedScope, defaultScope);
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
                yield return new TestCaseData(null, "https://localhost.azconfig.com", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(null, "https://localhost.azconfig.com/", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
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
                yield return new TestCaseData("http://other.my.custom.audience", $"{AppConfigurationAudience.AzurePublicCloud}/.default");
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
