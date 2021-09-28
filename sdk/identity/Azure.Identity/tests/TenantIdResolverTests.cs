// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
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
            yield return new object[] {TenantId, Context_Hint, false, Context_Hint.TenantId, new[] {string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndUsedEventMessage, TenantId, Context_Hint.TenantId)}};
            yield return new object[] {TenantId, Context_NoHint, false, TenantId, new string[] { }};
            yield return new object[] {TenantId, Context_Hint, true, TenantId, new[] {string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, TenantId, Context_Hint.TenantId)}};
            yield return new object[] {TenantId, Context_NoHint, true, TenantId, new string[] { }};
            yield return new object[] {Constants.AdfsTenantId, Context_Hint, false, Constants.AdfsTenantId, new[] {string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, Constants.AdfsTenantId, Context_Hint.TenantId)}};
            yield return new object[] {Constants.AdfsTenantId, Context_NoHint, false, Constants.AdfsTenantId, new string[] { }};
            yield return new object[] {Constants.AdfsTenantId, Context_Hint, true, Constants.AdfsTenantId, new[] {string.Format(AzureIdentityEventSource.TenantIdDiscoveredAndNotUsedEventMessage, Constants.AdfsTenantId, Context_Hint.TenantId)}};
            yield return new object[] {Constants.AdfsTenantId, Context_NoHint, true, Constants.AdfsTenantId, new string[] { }};
            yield return new object[] {null, Context_Hint, false, Context_Hint.TenantId, new string[] { }};
            yield return new object[] {null, Context_NoHint, false, null, new string[] { }};
            yield return new object[] {null, Context_Hint, true, null, new string[] { }};
            yield return new object[] {null, Context_NoHint, true, null, new string[] { }};
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

                result = TenantIdResolver.Resolve(tenantId, context);
                Assert.AreEqual(expectedresult, result);
                Assert.AreEqual(expectedEvents, messages);
            }
            finally
            {
                env?.Dispose();
            }
        }
    }
}
