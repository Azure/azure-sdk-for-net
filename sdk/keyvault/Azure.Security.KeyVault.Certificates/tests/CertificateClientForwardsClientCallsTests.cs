// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Pin the [ForwardsClientCalls] decoration on every CertificateClient method
    // that returns a Pageable<T>/AsyncPageable<T> by delegating directly to the
    // generated KeyVaultCertificatesClient (no per-method DiagnosticScope of its
    // own). Azure.Core.TestFramework's DiagnosticScopeValidatingInterceptor
    // enforces this contract at runtime when the test uses InstrumentClient;
    // this reflection-based test catches drift in pure unit-test mode where the
    // interceptor isn't in play (and is independent of which test mode runs).
    //
    // Start*Operation methods are intentionally NOT in scope: those wrap the
    // generated call in a CertificateClient-owned DiagnosticScope (mirroring
    // SecretClient.StartRecoverDeletedSecret in PR #59972) and therefore do
    // not need - and must not declare - [ForwardsClientCalls].
    public class CertificateClientForwardsClientCallsTests
    {
        // Methods whose body is essentially `return Map(_generated.XYZ(...))`
        // and consequently rely on the generated client's own scope.
        private static readonly string[] ExpectedForwardingMethods = new[]
        {
            nameof(CertificateClient.GetPropertiesOfCertificates),
            nameof(CertificateClient.GetPropertiesOfCertificatesAsync),
            nameof(CertificateClient.GetPropertiesOfCertificateVersions),
            nameof(CertificateClient.GetPropertiesOfCertificateVersionsAsync),
            nameof(CertificateClient.GetDeletedCertificates),
            nameof(CertificateClient.GetDeletedCertificatesAsync),
            nameof(CertificateClient.GetPropertiesOfIssuers),
            nameof(CertificateClient.GetPropertiesOfIssuersAsync),
        };

        [Test]
        public void AllPageableMethods_AreDecoratedWithForwardsClientCalls()
        {
            MethodInfo[] methods = typeof(CertificateClient).GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            var missing = new List<string>();
            foreach (string name in ExpectedForwardingMethods)
            {
                MethodInfo m = methods.SingleOrDefault(x => x.Name == name);
                if (m == null)
                {
                    missing.Add($"{name} (method not found on CertificateClient)");
                    continue;
                }

                if (m.GetCustomAttribute<ForwardsClientCallsAttribute>() == null)
                {
                    missing.Add(name);
                }
            }

            Assert.IsEmpty(
                missing,
                "These CertificateClient methods delegate to the generated client without a per-method DiagnosticScope " +
                "and so must be decorated with [ForwardsClientCalls] to satisfy Azure.Core.TestFramework's " +
                "DiagnosticScopeValidatingInterceptor: " + string.Join(", ", missing));
        }

        [Test]
        public void EveryPageableReturningMethod_IsCoveredByExpectedList()
        {
            // Defense-in-depth: if someone adds a new public Pageable/AsyncPageable
            // method to CertificateClient, force them to add it to ExpectedForwardingMethods
            // (or explicitly opt it out by giving it a per-method DiagnosticScope).
            MethodInfo[] methods = typeof(CertificateClient).GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            string[] pageableReturning = methods
                .Where(m => IsPageableLike(m.ReturnType))
                .Select(m => m.Name)
                .Distinct()
                .ToArray();

            var notCovered = pageableReturning.Except(ExpectedForwardingMethods).ToArray();
            Assert.IsEmpty(
                notCovered,
                "New Pageable/AsyncPageable-returning methods detected on CertificateClient. " +
                "Add them to CertificateClientForwardsClientCallsTests.ExpectedForwardingMethods " +
                "(and decorate them with [ForwardsClientCalls]) or give them their own DiagnosticScope: " +
                string.Join(", ", notCovered));
        }

        private static bool IsPageableLike(Type t)
        {
            if (t == null || !t.IsGenericType)
            {
                return false;
            }

            Type def = t.GetGenericTypeDefinition();
            return def == typeof(Pageable<>) || def == typeof(AsyncPageable<>);
        }
    }
}
