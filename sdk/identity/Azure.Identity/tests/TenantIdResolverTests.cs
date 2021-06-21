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
        private static TokenRequestContext Context_Hint = new(Array.Empty<string>(), tenantId: "hint");
        private static TokenRequestContext Context_NoHint = new(Array.Empty<string>());

        public static IEnumerable<object[]> ResolveInputs()
        {
            yield return new object[] { TenantId, Context_Hint, true, Context_Hint.TenantId };
            yield return new object[] { TenantId, Context_NoHint, true, TenantId };
            yield return new object[] { TenantId, Context_Hint, false, TenantIdResolver.tenantIdMismatch };
            yield return new object[] { TenantId, Context_NoHint, false, TenantId };
            yield return new object[] { null, Context_Hint, true, Context_Hint.TenantId };
            yield return new object[] { null, Context_NoHint, true, null };
            yield return new object[] { null, Context_Hint, false, TenantIdResolver.tenantIdMismatch };
            yield return new object[] { null, Context_NoHint, false, null };
        }

        [Test]
        [TestCaseSource(nameof(ResolveInputs))]
        public void Resolve(string tenantId, TokenRequestContext context, bool allowMultiTenantAuth, string expectedresult)
        {
            object result = null;
            try
            {
                result = TenantIdResolver.Resolve(tenantId, context, allowMultiTenantAuth);
            }
            catch (AuthenticationFailedException ex)
            {
                result = ex.Message;
            }
            finally
            {
                Assert.AreEqual(expectedresult, result);
            }
        }
    }
}
