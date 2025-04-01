// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TestProjects.Spector.Tests
{
    public class SpectorServer : TestServerBase
    {
        public SpectorServer() : base(GetProcessPath(), $"serve {string.Join(" ", GetScenariosPaths())} --port 0 --coverageFile {GetCoverageFilePath()}")
        {
        }

        internal static string GetProcessPath()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@typespec", "spector", "dist", "src", "cli", "cli.js");
        }

        internal static string GetSpecDirectory()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@typespec", "http-specs");
        }

        internal static string GetAzureSpecDirectory()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@azure-tools", "azure-http-specs");
        }

        internal static IEnumerable<string> GetScenariosPaths()
        {
            yield return Path.Combine(GetSpecDirectory(), "specs");
            yield return Path.Combine(GetAzureSpecDirectory(), "specs");
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
    }
}
