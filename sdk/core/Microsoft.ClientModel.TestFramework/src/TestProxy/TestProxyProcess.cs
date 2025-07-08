// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Encapsulates a process running an instance of the Test Proxy as well as providing access to the Test Proxy administration actions
/// via the TestProxyRestClient.
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
                string outputLine = _testProxyProcess.StandardOutput.ReadLine();
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
        Client = new TestProxyRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), new Uri($"http://{IpAddress}:{_proxyPortHttp}"));

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
}