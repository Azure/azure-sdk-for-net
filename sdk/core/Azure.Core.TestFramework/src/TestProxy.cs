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
                    ["Logging__LogLevel__Microsoft"] = "Information"
                }
            };

            if (!TestEnvironment.GlobalIsRunningInCI)
            {
                ImportDevCertIfNeeded();
            }

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
                throw new InvalidOperationException("Failed to start the test proxy.");
            }

            // we need to use https when talking to test proxy admin endpoint so that we can establish the connection before any
            // test related traffic happens which would send a Connection header for the first request. This can be switched to HTTP
            // once https://github.com/Azure/azure-sdk-tools/issues/2303 is fixed
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate.Issuer == DevCertIssuer
            };
            var options = new TestProxyClientOptions
            {
                Transport = new HttpClientTransport(handler)
            };
            Client = new TestProxyRestClient(
                new ClientDiagnostics(options),
                HttpPipelineBuilder.Build(options),
                new Uri($"https://{IpAddress}:{_proxyPortHttps}"));

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
            return new TestProxy(typeof(TestProxy)
                .Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .Single(a => a.Key == "TestProxyPath")
                .Value);
        }

        public void Stop()
        {
            _testProxyProcess?.Kill();
        }

        private static void ImportDevCertIfNeeded()
        {
            ProcessStartInfo checkCertProcessInfo = new ProcessStartInfo(
                s_dotNetExe,
                "dev-certs https --check --verbose")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process checkCertProcess = Process.Start(checkCertProcessInfo);
            string output = checkCertProcess.StandardOutput.ReadToEnd();
            if (!output.Contains("A valid certificate was found.") &&
                // .NET 6.0 SDK has a different output
                !output.Contains("CN=localhost"))
            {
                TestContext.Progress.WriteLine("Importing certificate...");
                checkCertProcess.WaitForExit();
                var certPath = Path.Combine(TestEnvironment.RepositoryRoot, "eng", "common", "testproxy", "dotnet-devcert.pfx");
                ProcessStartInfo processInfo = new ProcessStartInfo(
                    s_dotNetExe,
                    $"dev-certs https --clean --import {certPath} --password=\"password\"")
                {
                    UseShellExecute = false
                };
                Process.Start(processInfo).WaitForExit();
                processInfo = new ProcessStartInfo(
                    s_dotNetExe,
                    $"dev-certs https --trust")
                {
                    UseShellExecute = false
                };
                Process.Start(processInfo).WaitForExit();
            }
            else
            {
                checkCertProcess.WaitForExit();
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