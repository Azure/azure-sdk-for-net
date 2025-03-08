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
            ConfigurationAudience? configurationAudience,
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
                yield return new TestCaseData(ConfigurationAudience.AzurePublicCloud, "https://locaLhost.azconfiG.com", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(ConfigurationAudience.AzurePublicCloud, "https://locaLhost.azconfiG.com/", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(ConfigurationAudience.AzureChina, "https://other.AZconfig.cn", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData(ConfigurationAudience.AzureChina, "https://other.AZconfig.cn/", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData(ConfigurationAudience.AzureGovernment, "https://gov-localhost-2353453.azconfig.us", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData(ConfigurationAudience.AzureGovernment, "https://gov-localhost-2353453.azconfig.us/", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData(null, "https://localhost.azconfig.com", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(null, "https://localhost.azconfig.com/", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData(new ConfigurationAudience("my.custom.audience"), "http://other.my.custom.audience", "my.custom.audience/.default");
                yield return new TestCaseData(new ConfigurationAudience("my.custom.audience"), "http://other.my.custom.audience/", "my.custom.audience/.default");
            }
        }

        public static IEnumerable<TestCaseData> GetDefaultScopeTestCases
        {
            get
            {
                // public cloud
                yield return new TestCaseData("http://locaLhost.azconfiG.io", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://locaLhost.azconfiG.io/", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://locaLhost.azconfiG.io//", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.azconfig.io", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.com", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.com/", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                yield return new TestCaseData("http://other.my.custom.audience", $"{ConfigurationAudience.AzurePublicCloud}/.default");
                // china cloud
                yield return new TestCaseData("http://other-23232.AZconfig.azure.cn", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.azconfig.azure.cn", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://other.APPconfig.azure.cn", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn/", $"{ConfigurationAudience.AzureChina}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.cn//", $"{ConfigurationAudience.AzureChina}/.default");
                // us gov cloud
                yield return new TestCaseData("http://other-23232.AZconfig.azure.us", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.azconfig.azure.us", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://other.APPconfig.azure.us", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us/", $"{ConfigurationAudience.AzureGovernment}/.default");
                yield return new TestCaseData("https://contoso.appconfig.azure.us//", $"{ConfigurationAudience.AzureGovernment}/.default");
            }
        }
    }
}
