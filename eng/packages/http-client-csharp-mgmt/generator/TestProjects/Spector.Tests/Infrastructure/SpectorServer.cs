// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

namespace TestProjects.Spector.Tests
{
    public class SpectorServer : TestServerBase
    {
        private readonly string _scenariosRoot;

        public SpectorServer() : this(CreateResourceManagerScenariosPath())
        {
        }

        private SpectorServer(string scenariosPath) : base(GetProcessPath(), $"serve {scenariosPath} --port 0 --coverageFile {GetCoverageFilePath()}")
        {
            _scenariosRoot = Path.GetDirectoryName(scenariosPath)!;
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
                Directory.Delete(_scenariosRoot, recursive: true);
            }
        }

        private static string CreateResourceManagerScenariosPath()
        {
            var scenariosRoot = Path.Combine(GetCoverageDirectory(), $"resource-manager-scenarios-{Environment.ProcessId}");
            var scenariosPath = Path.Combine(scenariosRoot, "specs");
            var sourceDistPath = Path.Combine(GetAzureSpecDirectory(), "dist", "specs", "azure", "resource-manager");
            var targetDistPath = Path.Combine(scenariosRoot, "dist", "specs", "azure", "resource-manager");

            Directory.CreateDirectory(scenariosPath);
            File.Copy(
                Path.Combine(GetAzureSpecDirectory(), "package.json"),
                Path.Combine(scenariosRoot, "package.json"),
                overwrite: true);
            CopyDirectory(sourceDistPath, targetDistPath);
            return scenariosPath;
        }

        private static void CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            Directory.CreateDirectory(targetDirectory);

            foreach (var sourceFile in Directory.GetFiles(sourceDirectory))
            {
                File.Copy(sourceFile, Path.Combine(targetDirectory, Path.GetFileName(sourceFile)), overwrite: true);
            }

            foreach (var sourceSubDirectory in Directory.GetDirectories(sourceDirectory))
            {
                CopyDirectory(sourceSubDirectory, Path.Combine(targetDirectory, Path.GetFileName(sourceSubDirectory)));
            }
        }
    }
}
