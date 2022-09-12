// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DefaultAzureCredentialOptionsTests
    {
        public static IEnumerable<string> IdTestValues()
        {
            yield return Guid.NewGuid().ToString();
            yield return String.Empty;
            yield return null;
        }

        [Test]
        [TestCaseSource(nameof(IdTestValues))]
        public void ValidateAzureTenantIdEnvVarDefaultHonored(string envVarValue)
        {
            var expValue = string.IsNullOrEmpty(envVarValue) ? null : envVarValue;

            using (new TestEnvVar("AZURE_TENANT_ID", envVarValue))
            {
                var options = new DefaultAzureCredentialOptions();

                Assert.AreEqual(options.TenantId, expValue);
                Assert.AreEqual(options.InteractiveBrowserTenantId, expValue);
                Assert.AreEqual(options.SharedTokenCacheTenantId, expValue);
                Assert.AreEqual(options.VisualStudioTenantId, expValue);
                Assert.AreEqual(options.VisualStudioCodeTenantId, expValue);
            }
        }

        [Test]
        [TestCaseSource(nameof(IdTestValues))]
        public void ValidateAzureUsernameEnvVarDefaultHonored(string envVarValue)
        {
            var expValue = string.IsNullOrEmpty(envVarValue) ? null : envVarValue;

            using (new TestEnvVar("AZURE_USERNAME", envVarValue))
            {
                var options = new DefaultAzureCredentialOptions();

                Assert.AreEqual(options.SharedTokenCacheUsername, expValue);
            }
        }

        [Test]
        [TestCaseSource(nameof(IdTestValues))]
        public void ValidateAzureClientIdEnvVarDefaultHonored(string envVarValue)
        {
            var expValue = string.IsNullOrEmpty(envVarValue) ? null : envVarValue;

            using (new TestEnvVar("AZURE_CLIENT_ID", envVarValue))
            {
                var options = new DefaultAzureCredentialOptions();

                Assert.AreEqual(options.ManagedIdentityClientId, expValue);
            }
        }

        public static IEnumerable<string> IdListTestValues()
        {
            yield return Guid.NewGuid().ToString();
            yield return "*";
            yield return $"{Guid.NewGuid().ToString()};{Guid.NewGuid().ToString()};{Guid.NewGuid().ToString()}";
            yield return String.Empty;
            yield return null;
        }
        [Test]
        [TestCaseSource(nameof(IdTestValues))]
        public void ValidateAzureAdditionallyAllowedTenantsEnvVarDefaultHonored(string envVarValue)
        {
            var expValue = string.IsNullOrEmpty(envVarValue) ? Array.Empty<string>() : envVarValue.Split(';');

            using (new TestEnvVar("AZURE_ADDITIONALLY_ALLOWED_TENANTS", envVarValue))
            {
                var options = new DefaultAzureCredentialOptions();

                CollectionAssert.AreEqual(expValue, options.AdditionallyAllowedTenants);
            }
        }
    }
}
