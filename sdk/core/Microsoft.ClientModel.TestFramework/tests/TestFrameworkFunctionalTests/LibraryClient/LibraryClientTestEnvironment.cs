// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class LibraryClientTestEnvironment : TestEnvironment
{
    static LibraryClientTestEnvironment()
    {
        DevCertPath = Path.Combine(
                RepositoryRoot,
                "eng",
                "common",
                "testproxy",
                "dotnet-devcert.pfx");
    }

    // For our fake client, we don't need real API keys
    // but we'll define one for consistency with the pattern
    public string FakeApiKey => GetRecordedVariable("FAKE-API-KEY", options => options.IsSecret());

    public override Dictionary<string, string> ParseEnvironmentFile() => new()
    {
        { "FAKE-API-KEY", Environment.GetEnvironmentVariable("FAKE_API_KEY") ?? "fake-test-key" }
    };

    public override Task WaitForEnvironmentAsync()
    {
        return Task.CompletedTask;
    }
}
