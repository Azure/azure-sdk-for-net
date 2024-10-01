// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Identity;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Mocks;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests.Utils;

/// <summary>
/// Represents an Azure test environment.
/// </summary>
public class AzureTestEnvironment
{
    private readonly RecordedTestMode _mode;
    private readonly string _optionPrefix;
    private TokenCredential? _credential;

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="mode">The recorded test mode to use.</param>
    public AzureTestEnvironment(RecordedTestMode mode)
    {
        _mode = mode;

        /**
         * We want to be able to to find "root" folders:
         * - The root of the Git repo on disk
         * - The root folder of the source code (eng/sdk)
         * These two are usually the same. In external repos, they may however be a little different.
         * 
         * To search for these folders, we use a simple method where we search up from these starting folders:
         * - Check the "SourcePath" assembly metadata attribute value. All projects in the Azure C# repo automatically have this attribute
         *   added as part of the build "magic" (see {repo_root}\Directory.Build.Targets)
         * - Where the executing assembly is running from
         * Until we find a parent folder that contains a specific subfolder(s).
         */
        DirectoryInfo?[] startingPoints =
        [
            AssemblyHelper.GetAssemblySourceDir<AzureTestEnvironment>(),
            new FileInfo(Assembly.GetExecutingAssembly().Location).Directory,
        ];

        RepoRoot = FindFirstParentWithSubfolders(startingPoints, ".git")
            ?? throw new InvalidOperationException("Could not determine the GIT root folder for this repository");

        string sourceRoot = (FindFirstParentWithSubfolders(startingPoints, "eng", "sdk") ?? RepoRoot)
            .FullName;

        DotNetExe = AssemblyHelper.GetDotnetExecutable()
            ?? throw new InvalidOperationException(
                "Could not determine the dotnet executable to use. Do you have .Net installed or have your paths correctly configured?");

        TestProxyDll = new FileInfo(
            AssemblyHelper.GetAssemblyMetadata<TestRecording>("TestProxyPath")
            ?? throw new InvalidOperationException("Could not determine the path to the recording test proxy DLL"));

        TestProxyHttpsCert = new FileInfo(Path.Combine(
            sourceRoot,
            "eng",
            "common",
            "testproxy",
            "dotnet-devcert.pfx"));
        if (!TestProxyHttpsCert.Exists)
        {
            throw new InvalidOperationException("Could not find test proxy HTTPS root certificate to use.");
        }

        TestProxyHttpsCertPassword = "password";

        string? serviceName = null;
        DirectoryInfo? sourceDir = GetType().Assembly.GetAssemblySourceDir();
        if (sourceDir != null)
        {
            string relativePath = PathHelpers.GetRelativePath(
                Path.Combine(sourceRoot, "sdk"),
                sourceDir.FullName);
            serviceName = relativePath
                .Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault()!;
        }

        _optionPrefix = serviceName?.ToUpperInvariant() + "_";
    }

    /// <summary>
    /// Gets the root Git folder.
    /// </summary>
    public DirectoryInfo RepoRoot { get; }

    /// <summary>
    /// Gets the path to the dotnet executable. This will be used in combination with <see cref="TestProxyDll"/> to start the
    /// recording test proxy service.
    /// </summary>
    public FileInfo DotNetExe { get; }

    /// <summary>
    /// The path to test proxy DLL that will be used when starting the recording test proxy service.
    /// </summary>
    public FileInfo TestProxyDll { get; }

    /// <summary>
    /// Gets the HTTPS certificate file to use as the signing certificate for HTTPS connections to the test proxy.
    /// </summary>
    public FileInfo TestProxyHttpsCert { get; }

    /// <summary>
    /// Gets the password for <see cref="TestProxyHttpsCert"/>.
    /// </summary>
    public string TestProxyHttpsCertPassword { get; }

    /// <summary>
    /// Gets the token credential to use during testing. This will change depending on the record mode.
    /// </summary>
    public TokenCredential Credential => _credential ??= GetCredential();

    /// <summary>
    /// Gets the default record mode to use for the test. This will attempt to read from the test context, or environment variables.
    /// </summary>
    public static RecordedTestMode DefaultRecordMode
    {
        get
        {
            string? modeString = TestContext.Parameters["TestMode"]
                ?? Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

            if (Enum.TryParse(modeString, true, out RecordedTestMode mode))
            {
                return mode;
            }

            return RecordedTestMode.Playback;
        }
    }

    /// <summary>
    /// Gets whether or not we should automatically record tests.
    /// </summary>
    public static bool DefaultAutomaticRecordEnabled
    {
        get
        {
            string? enabledString = TestContext.Parameters["DisableAutoRecording"]
                ?? Environment.GetEnvironmentVariable("AZURE_DISABLE_AUTO_RECORDING");

            if (bool.TryParse(enabledString, out bool enabled))
            {
                return !enabled;
            }

            return true;
        }
    }

    /// <summary>
    /// Gets an optional value from environment variables.
    /// </summary>
    /// <param name="name">The name of the value to retrieve.</param>
    /// <returns>The value, or null if it did not exist.</returns>
    public string? GetOptionalVariable(string name)
    {
        return new[]
            {
                _optionPrefix + name,
                name,
                "AZURE_" + name
            }
            .Select(Environment.GetEnvironmentVariable)
            .FirstOrDefault(value => !string.IsNullOrWhiteSpace(value));
    }

    /// <summary>
    /// Gets a value from environment variables, or throws an exception if it does not exist.
    /// </summary>
    /// <param name="name">The name of the value to retrieve.</param>
    /// <returns>The value.</returns>
    /// <exception cref="InvalidOperationException">If the value did not exist.</exception>
    public string GetVariable(string name)
    {
        string? optionalVariable = GetOptionalVariable(name);
        return optionalVariable
            ?? throw new InvalidOperationException($"Could not find required environment variable '{_optionPrefix + name }' or '{name}'.");
    }

    private static DirectoryInfo? FindFirstParentWithSubfolders(IEnumerable<DirectoryInfo?> startingDirs, params string[] subFolders)
        => startingDirs
            .Select(d => FindParentWithSubfolders(d, subFolders))
            .FirstOrDefault(d => d != null);

    private static DirectoryInfo? FindParentWithSubfolders(DirectoryInfo? start, params string[] subFolders)
    {
        if (subFolders == null || subFolders.Length == 0)
        {
            return null;
        }

        for (DirectoryInfo? current = start; current != null; current = current.Parent)
        {
            if (!current.Exists)
            {
                return null;
            }
            else if (subFolders.All(sub => current.EnumerateDirectories(sub).Any()))
            {
                return current;
            }
        }

        return null;
    }

    private TokenCredential GetCredential()
    {
        if (_mode == RecordedTestMode.Playback)
        {
            return new MockTokenCredential();
        }

        // I'm not sure exactly what the possible combinations to use here are, so I've essentially copied the logic
        // TestEnvironment.cs in Azure.Core.TestFramework (though it is a little simplified here)
        string? clientSecret = GetOptionalVariable("CLIENT_SECRET");
        string? systemAccessToken = GetOptionalVariable("SYSTEM_ACCESSTOKEN");

        if (!string.IsNullOrWhiteSpace(clientSecret))
        {
            return new ClientSecretCredential(
                GetVariable("TENANT_ID"),
                GetVariable("CLIENT_ID"),
                clientSecret);
        }
        else if (!string.IsNullOrWhiteSpace(systemAccessToken))
        {
            return new AzurePipelinesCredential(
                GetVariable("AZURESUBSCRIPTION_TENANT_ID"),
                GetVariable("AZURESUBSCRIPTION_CLIENT_ID"),
                GetVariable("AZURESUBSCRIPTION_SERVICE_CONNECTION_ID"),
                systemAccessToken,
                new AzurePipelinesCredentialOptions { AuthorityHost = new Uri(GetVariable("AZURE_AUTHORITY_HOST")) });
        }
        else
        {
            return new DefaultAzureCredential(
                new DefaultAzureCredentialOptions() { ExcludeManagedIdentityCredential = true });
        }
    }
}
