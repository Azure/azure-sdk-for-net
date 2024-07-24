// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// A test environment that supports recording.
/// </summary>
public class RecordedTestEnvironment : TestEnvironment
{
    /// <summary>
    /// Creates a new instance
    /// </summary>
    public RecordedTestEnvironment()
    {
        (DevCertPath, DevCertPassword) = FindDevCertPathAndPassword();
        GlobalMode = GetGlobalTestMode();
    }

    public FileInfo DevCertPath { get; }

    public string DevCertPassword { get; }

    public RecordedTestMode GlobalMode { get; }

    protected virtual (FileInfo, string) FindDevCertPathAndPassword()
    {
        FileInfo devCert = new FileInfo(
            Path.Combine(
                RepositoryRoot.FullName,
                "eng",
                "common",
                "testproxy",
                "dotnet-devcert.pfx"));

        if (!devCert.Exists)
        {
            throw new InvalidOperationException("Could not find the DEV HTTPS cert to use for the test proxy");
        }

        // The password for now is "password"
        return (devCert, "password");
    }

    protected virtual RecordedTestMode GetGlobalTestMode()
    {
        string? modeString = TestContext.Parameters["TestMode"]
            ?? Environment.GetEnvironmentVariable("SCM_TEST_MODE")
            ?? Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

        if (Enum.TryParse(modeString, true, out RecordedTestMode mode))
        {
            return mode;
        }

        return RecordedTestMode.Playback;
    }
}
