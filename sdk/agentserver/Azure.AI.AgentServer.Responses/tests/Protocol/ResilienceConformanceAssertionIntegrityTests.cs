// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Assertion-integrity guard (T007). The resilience work must not weaken the existing
/// spec-conformance and protocol test suites to fit new implementation behavior. These meta-tests
/// lock the pre-change baseline: they fail if protocol/conformance tests are deleted, silently
/// disabled (<c>[Ignore]</c>/<c>[Explicit]</c>), or excluded from CI via non-Live categories.
/// <para>
/// If you intentionally add protocol tests, RAISE <see cref="ProtocolTestMethodBaseline"/> to the
/// new floor. If you intentionally remove or disable a protocol test, that is a spec regression and
/// must be justified — do not lower the baseline to make this guard pass.
/// </para>
/// </summary>
[NonParallelizable]
public sealed class ResilienceConformanceAssertionIntegrityTests
{
    /// <summary>
    /// The minimum number of executable test methods that must exist in the
    /// <c>...Tests.Protocol</c> namespace. Captured as the pre-resilience-work baseline
    /// (protocol/conformance suite). Deleting or disabling protocol tests drops the count below this
    /// floor and fails the guard.
    /// </summary>
    private const int ProtocolTestMethodBaseline = 430;

    private const string ProtocolNamespace = "Azure.AI.AgentServer.Responses.Tests.Protocol";

    /// <summary>
    /// Namespaces where <c>[Explicit]</c> is legitimately allowed: compile-only snippet harnesses
    /// (require a running server) and live-sample e2e (require credentials). Conformance/protocol
    /// tests are NOT in this list — they must always run in CI.
    /// </summary>
    private static readonly string[] ExplicitAllowedNamespaceFragments =
    {
        ".Tests.Snippets",
        ".Tests.Samples",
        ".Live",
    };

    private static IEnumerable<MethodInfo> AllTestMethods()
    {
        var asm = typeof(ResilienceConformanceAssertionIntegrityTests).Assembly;
        foreach (var type in asm.GetTypes())
        {
            if (!type.IsClass || type.IsAbstract && !type.IsSealed)
            {
                // Skip pure abstract bases; sealed static helpers have no test methods anyway.
            }

            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (IsTestMethod(method))
                {
                    yield return method;
                }
            }
        }
    }

    private static bool IsTestMethod(MethodInfo method)
        => method.GetCustomAttributes(inherit: true)
            .Any(a =>
            {
                var n = a.GetType().Name;
                return n is "TestAttribute" or "TestCaseAttribute" or "TestCaseSourceAttribute" or "TheoryAttribute";
            });

    private static bool HasAttribute(MethodInfo method, string attributeName)
        => method.GetCustomAttributes(inherit: true).Any(a => a.GetType().Name == attributeName)
           || (method.DeclaringType?.GetCustomAttributes(inherit: true).Any(a => a.GetType().Name == attributeName) ?? false);

    [Test]
    public void ProtocolSuite_MeetsOrExceeds_BaselineTestCount()
    {
        var count = AllTestMethods()
            .Count(m => m.DeclaringType?.Namespace?.StartsWith(ProtocolNamespace, System.StringComparison.Ordinal) == true);

        Assert.That(count, Is.GreaterThanOrEqualTo(ProtocolTestMethodBaseline),
            $"Protocol/conformance test count ({count}) fell below the locked baseline " +
            $"({ProtocolTestMethodBaseline}). Protocol tests must not be deleted or disabled to fit " +
            "new implementation behavior. If this drop is intentional and correct, it is a spec " +
            "regression that requires explicit justification — do not lower the baseline to pass.");
    }

    [Test]
    public void ProtocolAndE2ETests_AreNotSilentlyDisabled()
    {
        var offenders = new List<string>();
        foreach (var method in AllTestMethods())
        {
            var ns = method.DeclaringType?.Namespace ?? string.Empty;
            var isProtocol = ns.StartsWith(ProtocolNamespace, System.StringComparison.Ordinal);
            var isE2E = ns.Contains(".Tests.E2E", System.StringComparison.Ordinal);
            if (!isProtocol && !isE2E)
            {
                continue;
            }

            if (HasAttribute(method, "IgnoreAttribute"))
            {
                offenders.Add($"[Ignore] on {method.DeclaringType!.FullName}.{method.Name}");
            }

            var explicitAllowed = ExplicitAllowedNamespaceFragments
                .Any(fragment => ns.Contains(fragment, System.StringComparison.Ordinal));
            if (!explicitAllowed && HasAttribute(method, "ExplicitAttribute"))
            {
                offenders.Add($"[Explicit] on {method.DeclaringType!.FullName}.{method.Name}");
            }
        }

        Assert.That(offenders, Is.Empty,
            "Protocol/conformance/e2e tests must not be silently disabled via [Ignore]/[Explicit]:\n  "
            + string.Join("\n  ", offenders));
    }

    [Test]
    public void ProtocolTests_AreNotExcludedFromCi_ViaLiveCategory()
    {
        // Protocol/conformance tests run in CI (TestCategory!=Live). Tagging one Live would silently
        // remove it from the default CI run — a covert weakening. Guard against it.
        var offenders = AllTestMethods()
            .Where(m => m.DeclaringType?.Namespace?.StartsWith(ProtocolNamespace, System.StringComparison.Ordinal) == true)
            .Where(m => m.GetCustomAttributes(inherit: true)
                .Any(a => a.GetType().Name == "CategoryAttribute"
                          && string.Equals(
                              a.GetType().GetProperty("Name")?.GetValue(a) as string,
                              "Live", System.StringComparison.OrdinalIgnoreCase)))
            .Select(m => $"{m.DeclaringType!.FullName}.{m.Name}")
            .ToList();

        Assert.That(offenders, Is.Empty,
            "Protocol/conformance tests must not be tagged [Category(\"Live\")] (that excludes them "
            + "from the default CI run):\n  " + string.Join("\n  ", offenders));
    }
}
