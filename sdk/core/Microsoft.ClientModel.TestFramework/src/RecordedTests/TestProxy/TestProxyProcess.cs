// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.TestProxy;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Encapsulates a process running an instance of the Test Proxy as well as providing access to the Test Proxy administration actions.
/// <seealso href="https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy"/>
/// </summary>
public class TestProxyProcess
{
    private static readonly string s_dotNetExe;
    private readonly int? _proxyPortHttp;
    private readonly int? _proxyPortHttps;
    private readonly Process? _testProxyProcess;
    private readonly StringBuilder _errorBuffer = new();
    private static readonly object _lock = new();
    private static TestProxyProcess? _shared;
    private readonly StringBuilder _output = new();
    private static readonly bool s_enableDebugProxyLogging;

    internal virtual TestProxyAdminClient AdminClient { get; }
    internal virtual TestProxyClient ProxyClient { get; }

    /// <summary>
    /// The IP address used for the test proxy. Uses 127.0.0.1 instead of localhost to avoid SSL callback slowness.
    /// </summary>
    // for some reason using localhost instead of the ip address causes slowness when combined with SSL callback being specified
    public const string IpAddress = "127.0.0.1";

    /// <summary>
    /// Gets the HTTP port used by the test proxy.
    /// </summary>
    public int? ProxyPortHttp => _proxyPortHttp;

    /// <summary>
    /// Gets the HTTPS port used by the test proxy.
    /// </summary>
    public int? ProxyPortHttps => _proxyPortHttps;

    /// <summary>
    /// Initializes static members of the <see cref="TestProxyProcess"/> class.
    /// Locates the .NET executable and configures debug logging settings.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the .NET installation directory is not found.</exception>
    static TestProxyProcess()
    {
        string? installDir = Environment.GetEnvironmentVariable("DOTNET_INSTALL_DIR");
        var dotNetExeName = "dotnet" + (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".exe" : "");
        if (!HasDotNetExe(installDir))
        {
            installDir = Environment.GetEnvironmentVariable("PATH")?.Split(Path.PathSeparator).FirstOrDefault(HasDotNetExe);
        }

        if (installDir == null)
        {
            throw new InvalidOperationException("DOTNET install directory was not found");
        }

        s_dotNetExe = Path.Combine(installDir, dotNetExeName);

        bool HasDotNetExe(string? dotnetDir) => dotnetDir != null && File.Exists(Path.Combine(dotnetDir, dotNetExeName));
        s_enableDebugProxyLogging = TestEnvironment.EnableTestProxyDebugLogs;
    }

    // For mocking
    internal TestProxyProcess()
    {
        AdminClient = default!;
        ProxyClient = default!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestProxyProcess"/> class.
    /// </summary>
    /// <param name="proxyPath">The path to the test proxy executable.</param>
    /// <param name="debugMode">If true, uses predefined ports 5000 and 5001 for debugging.</param>
    private TestProxyProcess(string? proxyPath, bool debugMode = false)
    {
        bool.TryParse(Environment.GetEnvironmentVariable("PROXY_DEBUG_MODE"), out bool environmentDebugMode);

        debugMode |= environmentDebugMode;

        ProcessStartInfo testProxyProcessInfo;

        if (proxyPath is not null)
        {
            testProxyProcessInfo = new ProcessStartInfo(
                s_dotNetExe,
                $"\"{proxyPath}\" start -u --storage-location=\"{TestEnvironment.RepositoryRoot}\"");
        }
        else
        {
            TryRestoreLocalTools();

            testProxyProcessInfo = new ProcessStartInfo(
                s_dotNetExe,
                $"test-proxy start -u --storage-location=\"{TestEnvironment.RepositoryRoot}\"");
        }

        testProxyProcessInfo.UseShellExecute = false;
        testProxyProcessInfo.RedirectStandardOutput = true;
        testProxyProcessInfo.RedirectStandardError = true;

        // Set environment variables
        testProxyProcessInfo.EnvironmentVariables["ASPNETCORE_URLS"] = $"http://{IpAddress}:0;https://{IpAddress}:0";
        testProxyProcessInfo.EnvironmentVariables["Logging__LogLevel__Azure.Sdk.Tools.TestProxy"] = s_enableDebugProxyLogging ? "Debug" : "Error";
        testProxyProcessInfo.EnvironmentVariables["Logging__LogLevel__Default"] = "Error";
        testProxyProcessInfo.EnvironmentVariables["Logging__LogLevel__Microsoft.AspNetCore"] = s_enableDebugProxyLogging ? "Information" : "Error";
        testProxyProcessInfo.EnvironmentVariables["Logging__LogLevel__Microsoft.Hosting.Lifetime"] = "Information";
        testProxyProcessInfo.EnvironmentVariables["ASPNETCORE_Kestrel__Certificates__Default__Path"] = TestEnvironment.DevCertPath;
        testProxyProcessInfo.EnvironmentVariables["ASPNETCORE_Kestrel__Certificates__Default__Password"] = TestEnvironment.DevCertPassword;

        _testProxyProcess = Process.Start(testProxyProcessInfo);

        if (_testProxyProcess == null)
        {
            throw new InvalidOperationException("Failed to start the test proxy process.");
        }

        ProcessTracker.Add(_testProxyProcess);
        _ = Task.Run(
            () =>
            {
                while (!_testProxyProcess.HasExited && !_testProxyProcess.StandardError.EndOfStream)
                {
                    var error = _testProxyProcess.StandardError.ReadLine();
                    // output to console in case another error in the test causes the exception to not be propagated
                    TestContext.Progress.WriteLine(error);
                    _errorBuffer.AppendLine(error);
                }
            });
        if (debugMode)
        {
            _proxyPortHttp = 5000;
            _proxyPortHttps = 5001;
        }
        else
        {
            int lines = 0;
            while ((_proxyPortHttp == null || _proxyPortHttps == null) && lines++ < 50)
            {
                string? outputLine = _testProxyProcess.StandardOutput.ReadLine();
                // useful for debugging
                TestContext.Progress.WriteLine(outputLine);

                if (ProxyPortHttp == null && TryParsePort(outputLine, "http", out _proxyPortHttp))
                {
                    continue;
                }

                if (_proxyPortHttps == null && TryParsePort(outputLine, "https", out _proxyPortHttps))
                {
                    continue;
                }
            }
        }

        if (_proxyPortHttp == null || _proxyPortHttps == null)
        {
            if (_errorBuffer.Length > 0)
            {
                var error = _errorBuffer.ToString();
                _errorBuffer.Clear();
                throw new InvalidOperationException($"An error occurred in the test proxy: {error}");
            }

            // if no errors, fallback to this exception
            throw new InvalidOperationException("Failed to start the test proxy. One or both of the ports was not populated." + Environment.NewLine +
                                                $"http: {_proxyPortHttp}" + Environment.NewLine +
                                                $"https: {_proxyPortHttps}");
        }

        var options = new TestProxyClientOptions();
        ProxyClient = new TestProxyClient(new Uri($"http://{IpAddress}:{_proxyPortHttp}"), options);
        AdminClient = ProxyClient.GetTestProxyAdminClient();

        _ = Task.Run(
            () =>
            {
                while (!_testProxyProcess.HasExited && !_testProxyProcess.StandardOutput.EndOfStream)
                {
                    lock (_output)
                    {
                        _output.AppendLine(_testProxyProcess.StandardOutput.ReadLine());
                    }
                }
            });
    }

    private static bool TryParsePort(string? output, string scheme, out int? port)
    {
        if (output == null)
        {
            TestContext.Progress.WriteLine("output was null");
            port = null;
            return false;
        }
        string nowListeningOn = "Now listening on: ";
        int nowListeningOnLength = nowListeningOn.Length;
        var index = output.IndexOf($"{nowListeningOn}{scheme}:", StringComparison.CurrentCultureIgnoreCase);
        if (index > -1)
        {
            var start = index + nowListeningOnLength;
            var uri = output.Substring(start, output.Length - start).Trim();
            port = new Uri(uri).Port;
            return true;
        }

        port = null;
        return false;
    }

    private static void TryRestoreLocalTools()
    {
        try
        {
            var currentDir = Directory.GetCurrentDirectory();
            while (currentDir != null)
            {
                var toolsJsonPath = Path.Combine(currentDir, ".config", "dotnet-tools.json");
                if (File.Exists(toolsJsonPath))
                {
                    // Found a tools manifest, try to restore
                    var processInfo = new ProcessStartInfo
                    {
                        FileName = s_dotNetExe,
                        Arguments = "tool restore",
                        WorkingDirectory = currentDir,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };

                    using var process = Process.Start(processInfo);
                    if (process != null)
                    {
                        process.WaitForExit(30000);
                    }
                    break;
                }

                var parentDir = Directory.GetParent(currentDir);
                currentDir = parentDir?.FullName;
            }
        }
        catch
        {
            // If restore fails, silently continue - the dotnet test-proxy command will handle it
        }
    }

    /// <summary>
    /// Starts the test proxy
    /// </summary>
    /// <param name="debugMode">If true, the proxy will be configured to look for port 5000 and 5001, which is the default used when running the proxy locally in debug mode.</param>
    /// <returns>The started TestProxy instance.</returns>
    public static TestProxyProcess Start(bool debugMode = false)
    {
        if (_shared != null)
        {
            return _shared;
        }

        lock (_lock)
        {
            var shared = _shared;
            if (shared == null)
            {
                var proxyPath = GetTestProxyPath();
                shared = new TestProxyProcess(proxyPath, debugMode);

                AppDomain.CurrentDomain.DomainUnload += (_, _) =>
                {
                    shared._testProxyProcess?.Kill();
                };

                _shared = shared;
            }

            return shared;
        }
    }

    private static string? GetTestProxyPath()
    {
        // Look for environment variable override
        var envPath = Environment.GetEnvironmentVariable("TEST_PROXY_PATH");
        if (!string.IsNullOrEmpty(envPath))
        {
            return envPath;
        }

        return null;
    }

    /// <summary>
    /// Checks the test proxy output for any logged information and errors.
    /// If debug logging is enabled, outputs the collected logs and clears the buffer.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task CheckProxyOutputAsync()
    {
        if (s_enableDebugProxyLogging)
        {
            // add a small delay to allow the log output for the just finished test to be collected into the _output StringBuilder
            await Task.Delay(20).ConfigureAwait(false);

            // lock to avoid any race conditions caused by appending to the StringBuilder while calling ToString
            lock (_output)
            {
                TestContext.Out.WriteLine(_output.ToString());
                _output.Clear();
            }
        }

        if (_errorBuffer.Length > 0)
        {
            var error = _errorBuffer.ToString();
            _errorBuffer.Clear();
            throw new InvalidOperationException($"An error occurred in the test proxy: {error}");
        }
    }
}
