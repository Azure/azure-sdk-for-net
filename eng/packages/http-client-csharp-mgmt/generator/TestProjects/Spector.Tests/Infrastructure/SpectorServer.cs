// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

namespace TestProjects.Spector.Tests
{
    public class SpectorServer : TestServerBase
    {
        private readonly ScenarioConfiguration _configuration;

        public SpectorServer() : this(ScenarioConfiguration.Create())
        {
        }

        private SpectorServer(ScenarioConfiguration configuration)
            : base(GetProcessPath(), $"serve {configuration.ScenariosPath} --port 0 --coverageFile {GetCoverageFilePath()}", configuration.Dispose)
        {
            _configuration = configuration;
        }

        internal static string GetProcessPath()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@typespec", "spector", "dist", "src", "cli", "cli.js");
        }

        internal static string GetAzureSpecDirectory()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@azure-tools", "azure-http-specs");
        }

        internal static string GetCoverageFilePath()
        {
            return Path.Combine(GetCoverageDirectory(), "tsp-spector-coverage-azure.json");
        }

        protected override void Stop(Process process)
        {
            try
            {
                Process.Start(new ProcessStartInfo("node", $"{GetProcessPath()} server stop --port {Port}"));
                process.WaitForExit();
            }
            finally
            {
                _configuration.Dispose();
            }
        }

        private sealed class ScenarioConfiguration : IDisposable
        {
            private readonly string _scenariosRoot;
            private bool _disposed;

            private ScenarioConfiguration(string scenariosRoot)
            {
                _scenariosRoot = scenariosRoot;
                ScenariosPath = Path.Combine(scenariosRoot, "specs");
                AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            }

            public string ScenariosPath { get; }

            public static ScenarioConfiguration Create()
            {
                var scenariosRoot = Path.Combine(GetCoverageDirectory(), $"resource-manager-scenarios-{Guid.NewGuid():N}");
                try
                {
                    var scenariosPath = Path.Combine(scenariosRoot, "specs");
                    var sourceDistPath = Path.Combine(GetAzureSpecDirectory(), "dist", "specs", "azure", "resource-manager");
                    var targetDistPath = Path.Combine(scenariosRoot, "dist", "specs", "azure", "resource-manager");

                    Directory.CreateDirectory(scenariosPath);
                    File.Copy(
                        Path.Combine(GetAzureSpecDirectory(), "package.json"),
                        Path.Combine(scenariosRoot, "package.json"));
                    CopyDirectory(sourceDistPath, targetDistPath);
                    return new ScenarioConfiguration(scenariosRoot);
                }
                catch
                {
                    if (Directory.Exists(scenariosRoot))
                    {
                        Directory.Delete(scenariosRoot, recursive: true);
                    }
                    throw;
                }
            }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }

                AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
                if (Directory.Exists(_scenariosRoot))
                {
                    Directory.Delete(_scenariosRoot, recursive: true);
                }
                _disposed = true;
            }

            private static void CopyDirectory(string sourceDirectory, string targetDirectory)
            {
                Directory.CreateDirectory(targetDirectory);

                foreach (var sourceFile in Directory.GetFiles(sourceDirectory))
                {
                    File.Copy(sourceFile, Path.Combine(targetDirectory, Path.GetFileName(sourceFile)));
                }

                foreach (var sourceSubDirectory in Directory.GetDirectories(sourceDirectory))
                {
                    CopyDirectory(sourceSubDirectory, Path.Combine(targetDirectory, Path.GetFileName(sourceSubDirectory)));
                }
            }

            private void OnProcessExit(object? sender, EventArgs e)
            {
                Dispose();
            }
        }
    }
}
