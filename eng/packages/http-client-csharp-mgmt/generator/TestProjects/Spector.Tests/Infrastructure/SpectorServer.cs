// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TestProjects.Spector.Tests
{
    public class SpectorServer : TestServerBase
    {
        private static readonly Lazy<string> s_resourceManagerScenariosPath = new(CreateResourceManagerScenariosPath);

        public SpectorServer() : base(GetProcessPath(), $"serve {string.Join(" ", GetScenariosPaths())} --port 0 --coverageFile {GetCoverageFilePath()}")
        {
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

        internal static IEnumerable<string> GetScenariosPaths()
        {
            yield return s_resourceManagerScenariosPath.Value;
        }

        internal static string GetCoverageFilePath()
        {
            return Path.Combine(GetCoverageDirectory(), "tsp-spector-coverage-azure.json");
        }

        protected override void Stop(Process process)
        {
            Process.Start(new ProcessStartInfo("node", $"{GetProcessPath()} server stop --port {Port}"));
            process.WaitForExit();
        }

        private static string CreateResourceManagerScenariosPath()
        {
            var scenariosPath = Path.Combine(GetCoverageDirectory(), $"resource-manager-scenarios-{Environment.ProcessId}", "specs");
            var sourceDistPath = Path.Combine(GetAzureSpecDirectory(), "dist", "specs", "azure", "resource-manager");
            var targetDistPath = Path.Combine(Path.GetDirectoryName(scenariosPath)!, "dist", "specs", "azure", "resource-manager");

            Directory.CreateDirectory(scenariosPath);
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
