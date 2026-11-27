// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.Generator.MgmtTypeSpec.Tests.Mocking;
using NUnit.Framework;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    /// <summary>Tests the generated public surface for provider polling operations.</summary>
    public class PollingSurfaceTests
    {
        /// <summary>Polling operations are hidden while ordinary provider operations remain public.</summary>
        [Test]
        public void ProviderPollingOperationsAreNotPublicExtensions()
        {
            Type[] surfaces =
            {
                typeof(AzureGeneratorMgmtTypeSpecTestsExtensions),
                typeof(MockableAzureGeneratorMgmtTypeSpecTestsTenantResource),
                typeof(MockableAzureGeneratorMgmtTypeSpecTestsSubscriptionResource)
            };
            string[] pollingNames =
            {
                "GetSubscriptionPollingStatus", "GetSubscriptionPollingStatusAsync",
                "GetTenantPollingStatus", "GetTenantPollingStatusAsync",
                "GetSubscriptionPollingResult", "GetSubscriptionPollingResultAsync"
            };

            foreach (var surface in surfaces)
            {
                var methods = surface.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var name in pollingNames)
                {
                    Assert.That(methods.Any(method => method.Name == name), Is.False, $"{surface.Name}.{name}");
                }
            }

            foreach (var surface in new[] { typeof(AzureGeneratorMgmtTypeSpecTestsExtensions), typeof(MockableAzureGeneratorMgmtTypeSpecTestsTenantResource) })
            {
                var methods = surface.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                Assert.That(methods.Any(method => method.Name == "GetPollingDetails"), Is.True, surface.Name);
                Assert.That(methods.Any(method => method.Name == "GetPollingDetailsAsync"), Is.True, surface.Name);
            }
        }
    }
}
