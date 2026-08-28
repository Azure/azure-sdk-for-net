// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>Runs the shared store-conformance suite against <see cref="LocalTaskStore"/>.</summary>
[TestFixture]
public sealed class LocalTaskStoreConformanceTests : TaskStoreConformanceTestsBase
{
    private string _tempDir = string.Empty;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "agentserver-tasks-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, recursive: true);
            }
        }
        catch (IOException)
        {
            // Best-effort cleanup.
        }
    }

    /// <inheritdoc/>
    private protected override ITaskStore CreateStore() => new LocalTaskStore(_tempDir);
}
