// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.TestProxy;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Encapsulates a process running an instance of the Test Proxy as well as providing access to the Test Proxy administration actions
/// via the TestProxyRestClient.
/// <seealso href="https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy"/>
/// </summary>
internal class TestProxyProcess
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

    /// <summary>
    /// TODO.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    static TestProxyProcess()
    {
        string? installDir = Environment.GetEnvironmentVariable("DOTNET_INSTALL_DIR") ?? string.Empty;
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

        bool HasDotNetExe(string dotnetDir) => dotnetDir != null && File.Exists(Path.Combine(dotnetDir, dotNetExeName));
        s_enableDebugProxyLogging = false; // TODO - TestEnvironment.EnableTestProxyDebugLogs;
    }

    private TestProxyProcess(string proxyPath, bool debugMode = false)
    {
        bool.TryParse(Environment.GetEnvironmentVariable("PROXY_DEBUG_MODE"), out bool environmentDebugMode);

        debugMode |= environmentDebugMode;

        ProcessStartInfo testProxyProcessInfo = new ProcessStartInfo(
            s_dotNetExe,
            $"\"{proxyPath}\" start -u --storage-location=\"{TestEnvironment.RepositoryRoot}\"")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            EnvironmentVariables =
                {
                    ["ASPNETCORE_URLS"] = $"http://{IpAddress}:0;https://{IpAddress}:0",
                    ["Logging__LogLevel__Azure.Sdk.Tools.TestProxy"] = s_enableDebugProxyLogging ? "Debug" : "Error",
                    ["Logging__LogLevel__Default"] = "Error",
                    ["Logging__LogLevel__Microsoft.AspNetCore"] = s_enableDebugProxyLogging ? "Information" : "Error",
                    ["Logging__LogLevel__Microsoft.Hosting.Lifetime"] = "Information",
                    ["ASPNETCORE_Kestrel__Certificates__Default__Path"] = TestEnvironment.DevCertPath,
                    ["ASPNETCORE_Kestrel__Certificates__Default__Password"] = TestEnvironment.DevCertPassword
                }
        };

        _testProxyProcess = Process.Start(testProxyProcessInfo);

        ProcessTracker.Add(_testProxyProcess!); // TODO
        _ = Task.Run(
            () =>
            {
                while (!_testProxyProcess?.HasExited ?? false && (!_testProxyProcess?.StandardError.EndOfStream ?? false))
                {
                    var error = _testProxyProcess!.StandardError.ReadLine();
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
                string outputLine = _testProxyProcess!.StandardOutput.ReadLine()!; // TODO
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
            CheckForErrors();
            // if no errors, fallback to this exception
            throw new InvalidOperationException("Failed to start the test proxy. One or both of the ports was not populated." + Environment.NewLine +
                                                $"http: {_proxyPortHttp}" + Environment.NewLine +
                                                $"https: {_proxyPortHttps}");
        }

        var options = new TestProxyClientOptions();
        Client = new TestProxyClient(ClientPipeline.Create(), new Uri($"http://{IpAddress}:{_proxyPortHttp}"));

        _ = Task.Run(
            () =>
            {
                while (!_testProxyProcess!.HasExited && !_testProxyProcess.StandardOutput.EndOfStream) // TODO
                {
                    lock (_output)
                    {
                        _output.AppendLine(_testProxyProcess.StandardOutput.ReadLine());
                    }
                }
            });
    }

    internal TestProxyClient Client { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public const string IpAddress = "127.0.0.1"; // using localhost instead of the ip address causes slowness when combined with SSL callback being specified

    /// <summary>
    /// TODO.
    /// </summary>
    public const string TestProxyProcessLocation = "";

    /// <summary>
    /// Gets the HTTP port used by the proxy.
    /// </summary>
    public int? ProxyPortHttp => _proxyPortHttp;

    /// <summary>
    /// Gets the HTTPS port used by the proxy.
    /// </summary>
    public int? ProxyPortHttps => _proxyPortHttps;

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
                shared = new TestProxyProcess(typeof(TestProxyProcess)
                    .Assembly
                    .GetCustomAttributes<AssemblyMetadataAttribute>()
                    .Single(a => a.Key == "TestProxyPath")
                    .Value!, // TODO- nullable
                    debugMode);

                AppDomain.CurrentDomain.DomainUnload += (_, _) =>
                {
                    shared._testProxyProcess?.Kill();
                };

                _shared = shared;
            }

            return shared;
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    public async Task CheckProxyOutputAsync()
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

        CheckForErrors();
    }

    private static bool TryParsePort(string output, string scheme, out int? port)
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

    private void CheckForErrors()
    {
        if (_errorBuffer.Length > 0)
        {
            var error = _errorBuffer.ToString();
            _errorBuffer.Clear();
            throw new InvalidOperationException($"An error occurred in the test proxy: {error}");
        }
    }
}