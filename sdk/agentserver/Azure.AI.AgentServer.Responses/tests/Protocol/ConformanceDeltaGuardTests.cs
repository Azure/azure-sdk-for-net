// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Conformance-delta guard (T081, FR-086). This is the CI-facing companion to
/// <see cref="ResilienceConformanceAssertionIntegrityTests"/> (T007). Where T007 locks the number of
/// executable protocol/conformance test <em>methods</em> (guarding against deletion/disabling of
/// whole tests), this guard operates one level finer: it partitions the conformance/e2e test SOURCE
/// into <b>pre-existing</b> tests versus <b>newly-added resilience</b> tests and locks the
/// <em>assertion density</em> of the pre-existing set — catching a covert weakening where a
/// pre-existing test keeps its method signature but has its assertions gutted (something a
/// method-count baseline cannot see).
/// <para>
/// It also emits a delta report to the test output so a reviewer sees, separately, which files are
/// pre-existing conformance tests and which were added for the resilience work.
/// </para>
/// <para>
/// If you intentionally refactor a pre-existing conformance test in a way that legitimately lowers
/// its assertion count, add its file name to <see cref="WeakeningWhitelist"/> WITH justification —
/// do not lower <see cref="PreExistingAssertionFloor"/> to make this pass.
/// </para>
/// </summary>
[NonParallelizable]
public sealed class ConformanceDeltaGuardTests
{
    /// <summary>
    /// Minimum total number of assertion statements (<c>Assert.</c> / <c>.Should(</c>) that must
    /// remain across the pre-existing (non-resilience) protocol conformance suite. Captured as the
    /// pre-resilience-work floor with a small margin. Gutting assertions out of pre-existing tests
    /// drops the count below this floor and fails the guard.
    /// </summary>
    private const int PreExistingAssertionFloor = 1000;

    /// <summary>
    /// Pre-existing conformance files that may legitimately have a reduced assertion count (with
    /// justification). Empty by design — no pre-existing conformance test was weakened by the
    /// resilience work.
    /// </summary>
    private static readonly IReadOnlyList<string> WeakeningWhitelist = Array.Empty<string>();

    /// <summary>
    /// File-name markers that identify a test file as ADDED (or heavily extended) for the resilience
    /// feature. Files matching any marker are excluded from the "pre-existing" assertion floor and
    /// reported in the delta report as resilience-added.
    /// </summary>
    private static readonly string[] ResilienceFileMarkers =
    {
        "Recovery", "Resilien", "Checkpoint", "ChainIdentity", "ChainMetadata", "ExitForRecovery",
        "Steer", "InternalMetadata", "PersistenceFailure", "ProviderIntegration", "CancelConsistency",
        "StreamingRecovery", "HandlerDrivenPersistence", "ConformanceDelta", "Row", "Reconnect",
        "ContractCoverage", "SampleParity", "CrashRecovery", "DropPrecondition",
    };

    private static string TestsRoot([CallerFilePath] string thisFile = "")
    {
        // thisFile = <...>/tests/Protocol/ConformanceDeltaGuardTests.cs
        var protocolDir = Path.GetDirectoryName(thisFile)!;
        return Path.GetDirectoryName(protocolDir)!; // the 'tests' directory
    }

    private static bool IsResilienceFile(string fileName)
        => ResilienceFileMarkers.Any(m => fileName.Contains(m, StringComparison.OrdinalIgnoreCase));

    private static int CountAssertions(string path)
    {
        int count = 0;
        foreach (var line in File.ReadAllLines(path))
        {
            int idx = 0;
            while ((idx = line.IndexOf("Assert.", idx, StringComparison.Ordinal)) >= 0)
            {
                count++;
                idx += "Assert.".Length;
            }

            idx = 0;
            while ((idx = line.IndexOf(".Should(", idx, StringComparison.Ordinal)) >= 0)
            {
                count++;
                idx += ".Should(".Length;
            }
        }

        return count;
    }

    private static IEnumerable<string> ConformanceSourceFiles()
    {
        var testsRoot = TestsRoot();
        var protocolDir = Path.Combine(testsRoot, "Protocol");
        var e2eDir = Path.Combine(testsRoot, "e2e");

        var files = new List<string>();
        if (Directory.Exists(protocolDir))
        {
            files.AddRange(Directory.GetFiles(protocolDir, "*.cs", SearchOption.AllDirectories));
        }

        if (Directory.Exists(e2eDir))
        {
            files.AddRange(Directory.GetFiles(e2eDir, "*.cs", SearchOption.AllDirectories));
        }

        return files;
    }

    [Test]
    public void PreExistingConformanceSuite_AssertionDensity_MeetsFloor()
    {
        var files = ConformanceSourceFiles().ToList();
        Assert.That(files, Is.Not.Empty, "no conformance source files were discovered");

        int preExistingAssertions = 0;
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            if (IsResilienceFile(name) || WeakeningWhitelist.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            preExistingAssertions += CountAssertions(file);
        }

        Assert.That(preExistingAssertions, Is.GreaterThanOrEqualTo(PreExistingAssertionFloor),
            $"Pre-existing conformance assertion count ({preExistingAssertions}) fell below the locked "
            + $"floor ({PreExistingAssertionFloor}). The resilience work must not weaken pre-existing "
            + "conformance tests by removing assertions. If a reduction is intentional and correct, "
            + "add the file to WeakeningWhitelist with justification — do not lower the floor.");
    }

    [Test]
    public void ConformanceDelta_ReportsPreExistingVsResilienceAdded()
    {
        var files = ConformanceSourceFiles().OrderBy(Path.GetFileName).ToList();

        var preExisting = new List<string>();
        var resilienceAdded = new List<string>();
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            var asserts = CountAssertions(file);
            var entry = $"{name} ({asserts} assertions)";
            if (IsResilienceFile(name))
            {
                resilienceAdded.Add(entry);
            }
            else
            {
                preExisting.Add(entry);
            }
        }

        // Emit the partitioned delta report so CI/reviewers see modifications to pre-existing
        // conformance tests SEPARATELY from newly-added resilience tests.
        TestContext.WriteLine("=== Conformance delta report ===");
        TestContext.WriteLine($"Pre-existing conformance/e2e files ({preExisting.Count}):");
        foreach (var e in preExisting)
        {
            TestContext.WriteLine($"  [pre-existing] {e}");
        }

        TestContext.WriteLine($"Resilience-added conformance/e2e files ({resilienceAdded.Count}):");
        foreach (var e in resilienceAdded)
        {
            TestContext.WriteLine($"  [resilience]   {e}");
        }

        // Sanity: both partitions are non-empty (the resilience work added tests, and the
        // pre-existing suite still exists and was not wholesale replaced).
        Assert.That(preExisting, Is.Not.Empty, "the pre-existing conformance suite must still exist");
        Assert.That(resilienceAdded, Is.Not.Empty, "resilience tests must be present and partitioned");
    }
}
