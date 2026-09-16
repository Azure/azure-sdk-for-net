// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

// Assembly-wide (global-namespace) setup fixture: NUnit runs this before any test in the
// assembly and after all tests complete.
//
// Every default-configured Responses host resolves its durable state directory from
// AGENTSERVER_STATE_ROOT (falling back to ~/.agentserver). Since the Core resilient-task
// subsystem is composed for EVERY local host, each test host runs a cold-start recovery scan
// over that directory. Without isolation, all tests would read and write the developer's real
// ~/.agentserver, which (a) pollutes it with thousands of throwaway envelope/task files across
// runs and (b) slows every host start as the scan re-enumerates the ever-growing shared tree.
//
// Pinning the state root to a unique per-run temp directory keeps the suite hermetic: each
// `dotnet test` invocation starts from an empty state tree and cleans it up on completion. Tests
// that need cross-lifetime persistence (crash-recovery e2e) wire their own explicit provider/task
// paths via DI and do not depend on this env var, so they are unaffected.
[SetUpFixture]
public sealed class TestStateRootFixture
{
    private const string StateRootEnvVar = "AGENTSERVER_STATE_ROOT";

    private string? _createdRoot;

    [OneTimeSetUp]
    public void SetUpStateRoot()
    {
        // Respect an explicit external override (e.g. a developer debugging against a fixed
        // directory); otherwise create a fresh, unique per-run temp root.
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(StateRootEnvVar)))
        {
            return;
        }

        _createdRoot = Path.Combine(
            Path.GetTempPath(),
            "agentserver-responses-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_createdRoot);
        Environment.SetEnvironmentVariable(StateRootEnvVar, _createdRoot);
    }

    [OneTimeTearDown]
    public void TearDownStateRoot()
    {
        if (_createdRoot is null)
        {
            return;
        }

        Environment.SetEnvironmentVariable(StateRootEnvVar, null);

        try
        {
            if (Directory.Exists(_createdRoot))
            {
                Directory.Delete(_createdRoot, recursive: true);
            }
        }
        catch (IOException)
        {
            // Best-effort cleanup; a leftover temp directory is harmless.
        }
        catch (UnauthorizedAccessException)
        {
            // Best-effort cleanup.
        }
    }
}
