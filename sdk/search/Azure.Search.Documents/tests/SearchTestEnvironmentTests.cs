// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchTestEnvironmentTests
    {
        private static Dictionary<string, string> CreateConfiguration() => new Dictionary<string, string>
        {
            ["SEARCH_SERVICE_NAME"] = "test-search",
            ["SEARCH_STORAGE_NAME"] = "teststorage",
            ["SEARCH_STORAGE_RESOURCE_ID"] = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/teststorage",
            ["SEARCH_KEYVAULT_URL"] = "https://test-vault.vault.azure.net/",
        };

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("false", false)]
        [TestCase("1", false)]
        [TestCase("yes", false)]
        [TestCase("true", true)]
        [TestCase("TRUE", true)]
        public void DoubleEncryptedIndexRequiresExplicitOptIn(string value, bool expected)
        {
            Assert.AreEqual(expected, SearchTestEnvironment.IsDoubleEncryptedIndexEnabled(value));
        }

        [Test]
        public void DoubleEncryptedIndexAcceptsCompleteConfiguration()
        {
            Dictionary<string, string> configuration = CreateConfiguration();
            Assert.DoesNotThrow(() => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(
                name => configuration.TryGetValue(name, out string value) ? value : null));
        }

        [TestCase("SEARCH_SERVICE_NAME")]
        [TestCase("SEARCH_STORAGE_NAME")]
        [TestCase("SEARCH_STORAGE_RESOURCE_ID")]
        [TestCase("SEARCH_KEYVAULT_URL")]
        public void DoubleEncryptedIndexReportsMissingConfiguration(string name)
        {
            Dictionary<string, string> configuration = CreateConfiguration();
            configuration.Remove(name);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(
                    key => configuration.TryGetValue(key, out string value) ? value : null));
            StringAssert.Contains($"Missing SEARCH_{name}.", exception.Message);
            StringAssert.Contains("Set-RecordingEnvironment.ps1", exception.Message);
            StringAssert.Contains("No test resources have been created.", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void DoubleEncryptedIndexReportsAllMissingConfiguration(string value)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(_ => value));
            foreach (string name in CreateConfiguration().Keys)
            {
                StringAssert.Contains($"Missing SEARCH_{name}.", exception.Message);
            }
        }

        [TestCase("SEARCH_KEYVAULT_URL", "not-a-url", "absolute HTTPS vault URL")]
        [TestCase("SEARCH_KEYVAULT_URL", "http://test-vault.vault.azure.net/", "absolute HTTPS vault URL")]
        [TestCase("SEARCH_STORAGE_RESOURCE_ID", "teststorage", "full ARM resource ID")]
        [TestCase("SEARCH_STORAGE_RESOURCE_ID", "/subscriptions/sub/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/otherstorage", "must identify SEARCH_SEARCH_STORAGE_NAME")]
        public void DoubleEncryptedIndexReportsInvalidConfiguration(string name, string value, string message)
        {
            Dictionary<string, string> configuration = CreateConfiguration();
            configuration[name] = value;

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(key => configuration[key]));
            StringAssert.Contains(message, exception.Message);
            StringAssert.DoesNotContain(value, exception.Message);
        }
    }
}
