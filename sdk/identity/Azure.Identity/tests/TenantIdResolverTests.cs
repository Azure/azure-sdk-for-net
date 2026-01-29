// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.Identity.Tests.CredentialTestBase<Azure.Identity.TokenCredentialOptions>;

namespace Azure.Identity.Tests
{
    public class TenantIdResolverTests
    {
        private const string TenantId = "clientTenant";
        private static TokenRequestContext Context_Hint = new(Array.Empty<string>(), tenantId: "hint");
        private static TokenRequestContext Context_NoHint = new(Array.Empty<string>());

        public static IEnumerable<object[]> ResolveInputs()
        {
            yield return new object[] { TenantId, Context_Hint, false, Context_Hint.TenantId, new[] { string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndUsedEventMessage, TenantId, Context_Hint.TenantId) } };
            yield return new object[] { TenantId, Context_NoHint, false, TenantId, new string[] { } };
            yield return new object[] { TenantId, Context_Hint, true, TenantId, new[] { string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, TenantId, Context_Hint.TenantId) } };
            yield return new object[] { TenantId, Context_NoHint, true, TenantId, new string[] { } };
            yield return new object[] { Constants.AdfsTenantId, Context_Hint, false, Constants.AdfsTenantId, new[] { string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, Constants.AdfsTenantId, Context_Hint.TenantId) } };
            yield return new object[] { Constants.AdfsTenantId, Context_NoHint, false, Constants.AdfsTenantId, new string[] { } };
            yield return new object[] { Constants.AdfsTenantId, Context_Hint, true, Constants.AdfsTenantId, new[] { string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, Constants.AdfsTenantId, Context_Hint.TenantId) } };
            yield return new object[] { Constants.AdfsTenantId, Context_NoHint, true, Constants.AdfsTenantId, new string[] { } };
            yield return new object[] { null, Context_Hint, false, Context_Hint.TenantId, new string[] { } };
            yield return new object[] { null, Context_NoHint, false, null, new string[] { } };
            yield return new object[] { null, Context_Hint, true, null, new string[] { } };
            yield return new object[] { null, Context_NoHint, true, null, new string[] { } };
        }

        [Test]
        [TestCaseSource(nameof(ResolveInputs))]
        public void Resolve(string tenantId, TokenRequestContext context, bool? disableMultiTenantAuth,
            string expectedresult, string[] expectedEvents)
        {
            string result = null;
            TestEnvVar env = null;
            List<string> messages = new();

            using AzureEventSourceListener listener = new(
                (args, _) =>
                {
                    if (args.EventName.StartsWith("TenantIdDiscovered"))
                    {
                        messages.Add(string.Format(args.Message, args.GetProperty<string>("explicitTenantId"),
                            args.GetProperty<string>("contextTenantId")));
                    }
                },
                EventLevel.Informational);

            try
            {
                if (disableMultiTenantAuth.HasValue)
                {
                    env = new TestEnvVar(IdentityCompatSwitches.DisableMultiTenantAuthEnvVar,
                        disableMultiTenantAuth.Value.ToString());
                }

                result = TenantIdResolverBase.Default.Resolve(tenantId, context, TenantIdResolverBase.AllTenants);
                Assert.That(result, Is.EqualTo(expectedresult));
                Assert.That(messages, Is.EqualTo(expectedEvents));
            }
            finally
            {
                env?.Dispose();
            }
        }

        public static IEnumerable<AllowedTenantsTestParameters> GetAllowedTenantsTestCases()
        {
            return CredentialTestBase<TokenCredentialOptions>.GetAllowedTenantsTestCases();
        }

        [TestCaseSource(nameof(GetAllowedTenantsTestCases))]
        public void VerifyAllowedTenantEnforcement(AllowedTenantsTestParameters parameters)
        {
            var additionallyAllowedTenants = TenantIdResolverBase.Default.ResolveAddionallyAllowedTenantIds(parameters.AdditionallyAllowedTenants);

            AssertAllowedTenantIdsEnforcedAsync(parameters.TenantId, parameters.TokenRequestContext, additionallyAllowedTenants);
        }

        public static void AssertAllowedTenantIdsEnforcedAsync(string tenantId, TokenRequestContext tokenRequestContext, string[] additionallyAllowedTenants)
        {
            bool expAllowed = tenantId == null
                || tokenRequestContext.TenantId == null
                || tenantId == tokenRequestContext.TenantId
                || additionallyAllowedTenants.Contains(tokenRequestContext.TenantId)
                || additionallyAllowedTenants.Contains("*");

            if (expAllowed)
            {
                var resolvedTenantId = TenantIdResolverBase.Default.Resolve(tenantId, tokenRequestContext, additionallyAllowedTenants);

                Assert.That(resolvedTenantId, Is.EqualTo(tokenRequestContext.TenantId ?? tenantId));
            }
            else
            {
                var ex = Assert.Throws<AuthenticationFailedException>(() => TenantIdResolverBase.Default.Resolve(tenantId, tokenRequestContext, additionallyAllowedTenants));

                Assert.That(ex.Message, Does.Contain($"The current credential is not configured to acquire tokens for tenant {tokenRequestContext.TenantId}"));
            }
        }

        [Test]
        public void ResolveWithCaseInsensitiveTenantIdComparison()
        {
            const string upperCaseTenantId = "CLIENT-TENANT";
            const string lowerCaseTenantId = "client-tenant";
            const string mixedCaseTenantId = "Client-Tenant";

            var contextWithUpperCase = new TokenRequestContext(Array.Empty<string>(), tenantId: upperCaseTenantId);
            var contextWithLowerCase = new TokenRequestContext(Array.Empty<string>(), tenantId: lowerCaseTenantId);
            var contextWithMixedCase = new TokenRequestContext(Array.Empty<string>(), tenantId: mixedCaseTenantId);

            // Test that different case variations of the same tenant ID are considered equal
            var result1 = TenantIdResolverBase.Default.Resolve(lowerCaseTenantId, contextWithUpperCase, TenantIdResolverBase.AllTenants);
            var result2 = TenantIdResolverBase.Default.Resolve(upperCaseTenantId, contextWithLowerCase, TenantIdResolverBase.AllTenants);
            var result3 = TenantIdResolverBase.Default.Resolve(mixedCaseTenantId, contextWithLowerCase, TenantIdResolverBase.AllTenants);

            // All should resolve to the context tenant ID as that takes precedence
            Assert.That(result1, Is.EqualTo(upperCaseTenantId));
            Assert.That(result2, Is.EqualTo(lowerCaseTenantId));
            Assert.That(result3, Is.EqualTo(lowerCaseTenantId));
        }

        [Test]
        public void ResolveWithCaseInsensitiveAdfsTenantId()
        {
            const string upperCaseAdfs = "ADFS";
            const string mixedCaseAdfs = "Adfs";
            const string lowerCaseAdfs = "adfs";

            var contextWithHint = new TokenRequestContext(Array.Empty<string>(), tenantId: "some-hint");

            // Test that different case variations of ADFS are all recognized
            var result1 = TenantIdResolverBase.Default.Resolve(upperCaseAdfs, contextWithHint, TenantIdResolverBase.AllTenants);
            var result2 = TenantIdResolverBase.Default.Resolve(mixedCaseAdfs, contextWithHint, TenantIdResolverBase.AllTenants);
            var result3 = TenantIdResolverBase.Default.Resolve(lowerCaseAdfs, contextWithHint, TenantIdResolverBase.AllTenants);

            // For ADFS, the explicit tenant ID should be returned regardless of case
            Assert.That(result1, Is.EqualTo(upperCaseAdfs));
            Assert.That(result2, Is.EqualTo(mixedCaseAdfs));
            Assert.That(result3, Is.EqualTo(lowerCaseAdfs));
        }

        [Test]
        public void ResolveWithCaseInsensitiveComparisonForAllowedTenants()
        {
            const string explicitTenantId = "explicit-tenant";
            const string upperCaseContextTenant = "CONTEXT-TENANT";
            const string lowerCaseContextTenant = "context-tenant";

            var contextWithUpperCase = new TokenRequestContext(Array.Empty<string>(), tenantId: upperCaseContextTenant);
            var additionallyAllowedTenants = new[] { lowerCaseContextTenant };

            // The context tenant ID (uppercase) should be allowed because it matches
            // the additionally allowed tenant (lowercase) in a case-insensitive manner
            var result = TenantIdResolverBase.Default.Resolve(explicitTenantId, contextWithUpperCase, additionallyAllowedTenants);

            Assert.That(result, Is.EqualTo(upperCaseContextTenant));
        }
    }
}
