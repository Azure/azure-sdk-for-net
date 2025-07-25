// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using NUnit.Framework;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Concurrent;
using System.ClientModel;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
///   Represents the ambient environment in which the test suite is
///   being run.
/// </summary>
public abstract class TestEnvironment
{
    private static readonly Dictionary<Type, Task> s_environmentStateCache = new();
    private AuthenticationTokenProvider? _credential;
    private TestRecording? _recording;
    private Dictionary<string, string>? _environmentFile;
    private static readonly HashSet<Type> s_bootstrappingAttemptedTypes = new();
    private static readonly object s_syncLock = new();
    private Exception? _bootstrappingException;
    private readonly Type _type;
    // TODO - private readonly ClientDiagnostics _clientDiagnostics;

    /// <summary>
    /// TODO.
    /// </summary>
    public static string? RepositoryRoot { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public static string? DevCertPath { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public string? PathToTestResourceBootstrappingScript { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public const string DevCertPassword = "password";

    /// <summary>
    /// TODO.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    protected TestEnvironment()
    {
        if (RepositoryRoot == null)
        {
            throw new InvalidOperationException("Repository root is not set");
        }

        if (DevCertPath == null)
        {
            throw new InvalidOperationException("Dev cert path is not set.");
        }

        _type = GetType();
        // TODO - _clientDiagnostics = new ClientDiagnostics(ClientOptions.Default);

        _environmentFile = ParseEnvironmentFile();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    static TestEnvironment()
    {
        var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
        string? repositoryRoot = null;

        // Strategy 1: Look for common repository root indicators
        while (directoryInfo != null)
        {
            // Check for common repository root files/folders
            if (File.Exists(Path.Combine(directoryInfo.FullName, ".git", "config")) ||
                Directory.Exists(Path.Combine(directoryInfo.FullName, ".git")) ||
                File.Exists(Path.Combine(directoryInfo.FullName, "Directory.Build.props")) ||
                File.Exists(Path.Combine(directoryInfo.FullName, "Directory.Build.targets")) ||
                File.Exists(Path.Combine(directoryInfo.FullName, "global.json")) ||
                directoryInfo.Name == "artifacts")  // Keep existing Azure SDK logic
            {
                repositoryRoot = directoryInfo.Name == "artifacts" ? directoryInfo.Parent?.FullName : directoryInfo.FullName;
                break;
            }

            directoryInfo = directoryInfo.Parent;
        }

        // Strategy 2: Fallback to a reasonable default if no indicators found
        if (repositoryRoot == null)
        {
            // Go up a few levels from the assembly location as a reasonable guess
            directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            for (int i = 0; i < 4 && directoryInfo?.Parent != null; i++)
            {
                directoryInfo = directoryInfo.Parent;
            }
            repositoryRoot = directoryInfo?.FullName;
        }

        if (repositoryRoot is null)
        {
            throw new InvalidOperationException("Repository root was not found");
        }

        RepositoryRoot ??= repositoryRoot;

        // Make DevCertPath more flexible too
        DevCertPath ??= Path.Combine(
            RepositoryRoot,
            "eng",
            "common",
            "testproxy",
            "dotnet-devcert.pfx");
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public RecordedTestMode? Mode { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    /// <summary>
    /// TODO.
    /// </summary>
    public virtual AuthenticationTokenProvider Credential
    {
        get
        {
            if (_credential != null)
            {
                return _credential;
            }

            if (Mode == RecordedTestMode.Playback)
            {
                _credential = new MockCredential();
            }
            else
            {
                throw new InvalidOperationException("This getter must be overridden in Live/Record mode");
            }

            return _credential;
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public abstract Dictionary<string, string> ParseEnvironmentFile();

    /// <summary>
    /// Waits until environment becomes ready to use.
    /// </summary>
    /// <returns>A task.</returns>
    public abstract Task WaitForEnvironmentAsync();

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// </summary>
    protected string? GetRecordedOptionalVariable(string name)
    {
        return GetRecordedOptionalVariable(name, _ => { });
    }

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// </summary>
    protected string? GetRecordedOptionalVariable(string name, Action<RecordedVariableOptions>? options)
    {
        if (Mode == RecordedTestMode.Playback)
        {
            return GetRecordedValue(name);
        }

        string? value = GetOptionalVariable(name);

        if (Mode is null or RecordedTestMode.Live)
        {
            return value;
        }

        if (_recording == null)
        {
            throw new InvalidOperationException("Recorded value should not be set outside the test method invocation");
        }

        // If the value was populated, sanitize before recording it.

        string? sanitizedValue = value;

        if (!string.IsNullOrEmpty(value))
        {
            var optionsInstance = new RecordedVariableOptions();
            options?.Invoke(optionsInstance);
            sanitizedValue = optionsInstance.Apply(sanitizedValue!);
        }

        _recording?.SetVariable(name, sanitizedValue);
        return value;
    }

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// Throws when variable is not found.
    /// </summary>
    protected string GetRecordedVariable(string name)
    {
        return GetRecordedVariable(name, null);
    }

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// Throws when variable is not found.
    /// </summary>
    protected string GetRecordedVariable(string name, Action<RecordedVariableOptions>? options)
    {
        var value = GetRecordedOptionalVariable(name, options);
        if (value == null)
        {
            BootStrapTestResources();
            value = GetRecordedOptionalVariable(name, options);
        }
        EnsureValue(name, value);
        return value!;
    }

    /// <summary>
    /// Returns an environment variable value or null when variable is not found.
    /// </summary>
    protected string? GetOptionalVariable(string name)
    {
        // TODO - add prefix var prefixedName = _prefix + name;

        // Prefixed name overrides non-prefixed
        var value = Environment.GetEnvironmentVariable(name);

        if (value == null)
        {
            _environmentFile?.TryGetValue(name, out value);
        }

        if (value == null)
        {
            value = Environment.GetEnvironmentVariable(name);
        }

        if (value == null)
        {
            value = Environment.GetEnvironmentVariable($"AZURE_{name}");
        }

        if (value == null)
        {
            _environmentFile?.TryGetValue(name, out value);
        }

        return value;
    }

    /// <summary>
    /// Returns an environment variable value.
    /// Throws when variable is not found.
    /// </summary>
    protected string GetVariable(string name)
    {
        var value = GetOptionalVariable(name);
        if (value == null)
        {
            BootStrapTestResources();
            value = GetOptionalVariable(name);
        }
        EnsureValue(name, value);
        return value!;
    }

    private void EnsureValue(string name, string? value)
    {
        if (value == null)
        {
            // TODO - string prefixedName = _prefix + name;
            string message = $"Unable to find environment variable {name} required by test." + Environment.NewLine +
                             "Make sure the test environment was initialized using the eng/common/TestResources/New-TestResources.ps1 script.";
            if (_bootstrappingException != null)
            {
                message += Environment.NewLine + "Resource creation failed during the test run. Make sure PowerShell version 6 or higher is installed.";
                throw new InvalidOperationException(
                    message,
                    _bootstrappingException);
            }

            throw new InvalidOperationException(message);
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="recording"></param>
    public void SetRecording(TestRecording recording)
    {
        _credential = null;
        _recording = recording;
    }

    private string? GetRecordedValue(string name)
    {
        if (_recording == null)
        {
            throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
        }

        return _recording.GetVariable(name, ""); // TODO - determine default value
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetSourcePath(Assembly assembly)
    {
        if (assembly == null)
            throw new ArgumentNullException(nameof(assembly));

        var sourcePathAttribute = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == "SourcePath");
        if (sourcePathAttribute?.Value is string sourcePath && !string.IsNullOrEmpty(sourcePath))
        {
            return sourcePath;
        }

        // Fallback: use assembly location directory
        string? assemblyDir = Path.GetDirectoryName(assembly.Location);
        if (string.IsNullOrEmpty(assemblyDir))
        {
            throw new InvalidOperationException($"Unable to determine the test directory for {assembly}");
        }

        Console.WriteLine($"Using fallback path: {assemblyDir}");
        return assemblyDir;
    }

    /// <summary>
    /// Determines if the current global test mode.
    /// </summary>
    internal static RecordedTestMode GlobalTestMode
    {
        get
        {
            string? modeString = TestContext.Parameters["TestMode"] ?? Environment.GetEnvironmentVariable("CLIENTMODEL_TEST_MODE");

            RecordedTestMode mode = RecordedTestMode.Playback;
            if (!string.IsNullOrEmpty(modeString))
            {
                mode = (RecordedTestMode)Enum.Parse(typeof(RecordedTestMode), modeString, true);
            }

            return mode;
        }
    }

    /// <summary>
    /// Determines if tests that use <see cref="RecordedTestAttribute"/> should try to re-record on failure.
    /// </summary>
    internal static bool GlobalDisableAutoRecording
    {
        get
        {
            string? switchString = TestContext.Parameters["DisableAutoRecording"] ?? Environment.GetEnvironmentVariable("CLIENTMODEL_DISABLE_AUTO_RECORDING");

            bool.TryParse(switchString, out bool disableAutoRecording);

            return disableAutoRecording;
        }
    }

    /// <summary>
    /// Determines whether to enable the test framework to proxy traffic through fiddler.
    /// </summary>
    internal static bool EnableFiddler
    {
        get
        {
            string? switchString = TestContext.Parameters["EnableFiddler"] ??
                                  Environment.GetEnvironmentVariable("CLIENTMODEL_ENABLE_FIDDLER");

            bool.TryParse(switchString, out bool enableFiddler);

            return enableFiddler;
        }
    }

    /// <summary>
    /// Determines if the bootstrapping prompt and automatic resource group expiration extension should be disabled.
    /// </summary>
    internal static bool DisableBootstrapping
    {
        get
        {
            string? switchString = TestContext.Parameters["DisableBootstrapping"] ?? Environment.GetEnvironmentVariable("AZURE_DISABLE_BOOTSTRAPPING");

            bool.TryParse(switchString, out bool disableBootstrapping);

            return disableBootstrapping;
        }
    }

    /// <summary>
    /// Determines whether to enable debug level proxy logging. Errors are logged by default.
    /// </summary>
    internal static bool EnableTestProxyDebugLogs
    {
        get
        {
            string? switchString = TestContext.Parameters[nameof(EnableTestProxyDebugLogs)] ??
                                  Environment.GetEnvironmentVariable("CLIENTMODEL_ENABLE_TEST_PROXY_DEBUG_LOGS");

            bool.TryParse(switchString, out bool enableProxyLogging);

            return enableProxyLogging;
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void BootStrapTestResources()
    {
        lock (s_syncLock)
        {
            if (DisableBootstrapping)
            {
                return;
            }
            if (PathToTestResourceBootstrappingScript is null)
            {
                throw new InvalidOperationException("Attempting to bootstrap test resources, but PathToTestResourceBootstrappingScript is null");
            }
            try
            {
                if (!IsWindows ||
                    s_bootstrappingAttemptedTypes.Contains(_type) ||
                    Mode == RecordedTestMode.Playback)
                {
                    return;
                }

                var processInfo = new ProcessStartInfo(
                @"pwsh.exe",
                PathToTestResourceBootstrappingScript)
                {
                    UseShellExecute = true
                };
                Process? process = null;
                try
                {
                    process = Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    _bootstrappingException = ex;
                }

                if (process != null)
                {
                    process.WaitForExit();
                    ParseEnvironmentFile();
                }
            }
            finally
            {
                s_bootstrappingAttemptedTypes.Add(_type);
            }
        }
    }
}