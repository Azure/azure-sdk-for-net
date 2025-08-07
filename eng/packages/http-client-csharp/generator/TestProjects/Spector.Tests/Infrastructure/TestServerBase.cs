// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests
{
    public class TestServerBase : IDisposable
    {
        private static Lazy<BuildPropertiesAttribute> _buildProperties = new(() => (BuildPropertiesAttribute)typeof(TestServerBase).Assembly.GetCustomAttributes(typeof(BuildPropertiesAttribute), false)[0]);

        private readonly Process? _process;
        public HttpClient Client { get; }
        public Uri Host { get; }
        public string Port { get; }

        public TestServerBase(string processPath, string processArguments)
        {
            var portPhrase = "Started server on ";

            var processStartInfo = new ProcessStartInfo("node", $"{processPath} {processArguments}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            _process = Process.Start(processStartInfo);
            if (_process == null)
            {
                throw new InvalidOperationException($"Unable to start process {processStartInfo.FileName} {processStartInfo.Arguments}");
            }
            ProcessTracker.Add(_process);
            Debug.Assert(_process != null);
            while (!_process.HasExited)
            {
                var s = _process.StandardOutput.ReadLine();
                var indexOfPort = s?.IndexOf(portPhrase);
                if (indexOfPort > 0)
                {   
                    Port = s!.Substring(indexOfPort.Value + portPhrase.Length).Trim();
                    Host = new Uri($"http://localhost:{Port}");
                    Client = new HttpClient
                    {
                        BaseAddress = Host
                    };
                    _ = Task.Run(ReadOutput);
                    return;
                }
            }

            if (Client == null || Host == null || Port == null)
            {
                throw new InvalidOperationException($"Unable to detect server port {_process.StandardOutput.ReadToEnd()} {_process.StandardError.ReadToEnd()}");
            }
        }

        protected static string GetCoverageDirectory()
        {
            return Path.Combine(_buildProperties.Value.ArtifactsDirectory, "coverage");
        }

        protected static string GetRepoRootDirectory()
        {
            return _buildProperties.Value.RepoRoot;
        }

        protected static string GetNodeModulesDirectory()
        {
            var repoRoot = _buildProperties.Value.RepoRoot;
            var nodeModulesDirectory = Path.Combine(repoRoot, "eng", "packages", "http-client-csharp", "node_modules");
            if (Directory.Exists(nodeModulesDirectory))
            {
                return nodeModulesDirectory;
            }

            throw new InvalidOperationException($"Cannot find 'node_modules' in parent directories of {typeof(SpectorServer).Assembly.Location}.");
        }

        private void ReadOutput()
        {
            while (_process is not null && !_process.HasExited && !_process.StandardOutput.EndOfStream)
            {
                _process.StandardOutput.ReadToEnd();
                _process.StandardError.ReadToEnd();
            }
        }

        protected virtual void Stop(Process process)
        {
            process.Kill(true);
        }

        public void Dispose()
        {
            if (_process is not null)
                Stop(_process);

            _process?.Dispose();
            Client?.Dispose();
        }
    }
}
