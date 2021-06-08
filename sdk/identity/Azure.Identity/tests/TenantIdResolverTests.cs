// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TenantIdResolverTests
    {
        private const string TenantId = "clientTenant";
        private static TokenRequestContext Context_Hint = new(Array.Empty<string>(), tenantId: "hint" );
        private static TokenRequestContext Context_NoHint = new(Array.Empty<string>());
        private static TokenCredentialOptions Options_True = new() { PreferClientConfiguredTenantId = true };
        private static TokenCredentialOptions Options_False = new() { PreferClientConfiguredTenantId = false };

        public static IEnumerable<object[]> ResolveInputs()
        {
            yield return new object[] { TenantId, Context_Hint, Options_True, TenantId };
            yield return new object[] { TenantId, Context_NoHint, Options_True, TenantId };
            yield return new object[] { TenantId, Context_Hint, Options_False, Context_Hint.TenantId };
            yield return new object[] { TenantId, Context_Hint, Options_False, Context_Hint.TenantId };
            yield return new object[] { null, Context_Hint, Options_True, Context_Hint.TenantId };
            yield return new object[] { null, Context_NoHint, Options_True, null };
            yield return new object[] { null, Context_Hint, Options_False, Context_Hint.TenantId };
            yield return new object[] { null, Context_NoHint, Options_False, null };
        }

        [Test]
        [TestCaseSource(nameof(ResolveInputs))]
        public void Resolve(string tenantId, TokenRequestContext context, TokenCredentialOptions options, string expectedTenantId)
        {
            var result = TenantIdResolver.Resolve(tenantId, context, options);

            Assert.AreEqual(expectedTenantId, result);
        }
    }
}
