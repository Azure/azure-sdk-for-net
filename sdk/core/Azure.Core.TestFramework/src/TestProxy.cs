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
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Encapsulates a process running an instance of the Test Proxy as well as providing access to the Test Proxy administration actions
    /// via the TestProxyRestClient.
    /// <seealso href="https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy"/>
    /// </summary>
    public class TestProxy
    {
        private static readonly string s_dotNetExe;

        public const string DevCertIssuer = "CN=localhost";

        public const string IpAddress = "127.0.0.1";

        public int? ProxyPortHttp => _proxyPortHttp;

        public int? ProxyPortHttps => _proxyPortHttps;

        private readonly int? _proxyPortHttp;
        private readonly int? _proxyPortHttps;
        private readonly Process _testProxyProcess;
        internal TestProxyRestClient Client { get; }
        private readonly StringBuilder _errorBuffer = new();
        private static readonly object _lock = new();
        private static TestProxy _shared;

        static TestProxy()
        {
            string installDir = Environment.GetEnvironmentVariable("DOTNET_INSTALL_DIR");
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
        }

        private TestProxy(string proxyPath)
        {
            ProcessStartInfo testProxyProcessInfo = new ProcessStartInfo(
                s_dotNetExe,
                proxyPath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                EnvironmentVariables =
                {
                    ["ASPNETCORE_URLS"] = $"http://{IpAddress}:0;https://{IpAddress}:0",
                    ["Logging__LogLevel__Default"] = "Error",
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

            if (_proxyPortHttp == null || _proxyPortHttps == null)
            {
                CheckForErrors();
                // if no errors, fallback to this exception
                throw new InvalidOperationException("Failed to start the test proxy. One or both of the ports was not populated." + Environment.NewLine +
                                                    $"http: {_proxyPortHttp}" + Environment.NewLine +
                                                    $"https: {_proxyPortHttps}");
            }

            var options = new TestProxyClientOptions();
            Client = new TestProxyRestClient(
                new ClientDiagnostics(new TestProxyClientOptions()),
                HttpPipelineBuilder.Build(options),
                new Uri($"http://{IpAddress}:{_proxyPortHttp}"));

            // For some reason draining the standard output stream is necessary to keep the test-proxy process healthy. Otherwise requests
            // start timing out. This only seems to happen when not specifying a port.
            _ = Task.Run(
                () =>
                {
                    while (!_testProxyProcess.HasExited && !_testProxyProcess.StandardOutput.EndOfStream)
                    {
                        _testProxyProcess.StandardOutput.ReadLine();
                    }
                });
        }

        public static TestProxy Start()
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
                    shared = new TestProxy(typeof(TestProxy)
                        .Assembly
                        .GetCustomAttributes<AssemblyMetadataAttribute>()
                        .Single(a => a.Key == "TestProxyPath")
                        .Value);

                    AppDomain.CurrentDomain.DomainUnload += (_, _) =>
                    {
                        shared._testProxyProcess?.Kill();
                    };

                    _shared = shared;
                }

                return shared;
            }
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

        public void CheckForErrors()
        {
            if (_errorBuffer.Length > 0)
            {
                var error = _errorBuffer.ToString();
                _errorBuffer.Clear();
                throw new InvalidOperationException($"An error occurred in the test proxy: {error}");
            }
        }
    }
}
