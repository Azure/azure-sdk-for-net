// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            yield return "46A32CE9-7466-43E6-8704-B98F83725592";
            yield return "*";
            yield return "C9280049-5395-42BA-BBCB-7F06676595A5;4BB289FC-2FE5-46BD-ADD7-EF71120A3BDC;7256A98E-BA8C-4E31-980E-AE2E7566FE9E";
            yield return String.Empty;
            yield return null;
        }
        [Test]
        [TestCaseSource(nameof(IdListTestValues))]
        public void ValidateAzureAdditionallyAllowedTenantsEnvVarDefaultHonored(string envVarValue)
        {
            var expValue = string.IsNullOrEmpty(envVarValue) ? Array.Empty<string>() : envVarValue.Split(';');

            using (new TestEnvVar("AZURE_ADDITIONALLY_ALLOWED_TENANTS", envVarValue))
            {
                var options = new DefaultAzureCredentialOptions();

                CollectionAssert.AreEqual(expValue, options.AdditionallyAllowedTenants);
            }
        }

        [Test]
        public void DeprecatedTenantIdPropertiesCannotMismatch()
        {
            var options = new DefaultAzureCredentialOptions();
            options.TenantId = "1";
            Assert.Throws<InvalidOperationException>(() => options.InteractiveBrowserTenantId = "2");
            Assert.Throws<InvalidOperationException>(() => options.SharedTokenCacheTenantId = "2");
            Assert.Throws<InvalidOperationException>(() => options.VisualStudioTenantId = "2");
            Assert.Throws<InvalidOperationException>(() => options.VisualStudioCodeTenantId = "2");
        }

        [Test]
        public void TenantIdCanBeSetTwice()
        {
            var options = new DefaultAzureCredentialOptions();
            options.TenantId = "1";
            options.TenantId = "2";
        }

        [Test]
        public void ValidateShallowCloneCopiesAllProperties([Values] bool useTenantId)
        {
            Random rand = new Random();

            var orig = new DefaultAzureCredentialOptions();

            foreach (var propInfo in EnumerateDefaultAzureCredentialOptionsProperties(useTenantId, !useTenantId))
            {
                if (propInfo.PropertyType == typeof(string))
                {
                    propInfo.SetValue(orig, Guid.NewGuid().ToString());
                }
                else if (propInfo.PropertyType == typeof(bool))
                {
                    propInfo.SetValue(orig, rand.NextDouble() > .5);
                }
                else if (propInfo.PropertyType == typeof(TimeSpan?))
                {
                    propInfo.SetValue(orig, TimeSpan.FromHours(rand.NextDouble() + .02));
                }
                else if (propInfo.PropertyType == typeof(Uri))
                {
                    propInfo.SetValue(orig, AzureAuthorityHosts.AzureChina);
                }
                else if (propInfo.PropertyType == typeof(ResourceIdentifier))
                {
                    propInfo.SetValue(orig, new ResourceIdentifier($"{Guid.NewGuid()}/{Guid.NewGuid()}/{Guid.NewGuid()}"));
                }
                else if (propInfo.PropertyType == typeof(IList<string>))
                {
                    IList<string> list = propInfo.GetValue(orig) as IList<string>;
                    list.Add(Guid.NewGuid().ToString());
                    list.Add(Guid.NewGuid().ToString());
                }
                else
                {
                    Assert.Fail($"test doesn't support property type {propInfo.PropertyType} for property {propInfo.Name}");
                }
            }

            var clone = orig.Clone<DefaultAzureCredentialOptions>();

            foreach (var propInfo in EnumerateDefaultAzureCredentialOptionsProperties(useTenantId, !useTenantId))
            {
                if (propInfo.PropertyType == typeof(IList<string>))
                {
                    CollectionAssert.AreEqual((IList<string>)propInfo.GetValue(orig), (IList<string>)propInfo.GetValue(clone), $"Cloned {propInfo.Name} does not match original");
                }
                else
                {
                    Assert.AreEqual(propInfo.GetValue(orig), propInfo.GetValue(clone), $"Cloned {propInfo.Name} does not match original");
                }
            }
        }

        private IEnumerable<PropertyInfo> EnumerateDefaultAzureCredentialOptionsProperties(bool includeTenantId, bool includeAltTenantIds)
        {
            foreach (var propInfo in typeof(DefaultAzureCredentialOptions).GetProperties())
            {
                // shallow clone only clones properties from Azure.Identity so we exclude base properties
                if (propInfo.DeclaringType == typeof(DefaultAzureCredentialOptions) || propInfo.DeclaringType == typeof(TokenCredentialOptions))
                {
                    switch (propInfo.Name)
                    {
                        // diagnostics is also ignored by shallow clone
                        case "Diagnostics":
                            break;
                        case "TenantId":
                            if (includeTenantId)
                            {
                                yield return propInfo;
                            }
                            break;
                        case "InteractiveBrowserTenantId":
                        case "SharedTokenCacheTenantId":
                        case "VisualStudioTenantId":
                        case "VisualStudioCodeTenantId":
                            if (includeAltTenantIds)
                            {
                                yield return propInfo;
                            }
                            break;
                        default:
                            yield return propInfo;
                            break;
                    }
                }
            }
        }
    }
}
