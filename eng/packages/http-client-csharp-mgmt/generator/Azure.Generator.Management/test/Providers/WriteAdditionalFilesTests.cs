// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Tests.TestHelpers;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Tests.Providers
{
    public class WriteAdditionalFilesTests
    {
        [SetUp]
        public void SetUp()
        {
            ManagementMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void GetReadmeContentContainsPackageName()
        {
            var scaffolding = new TestableNewManagementProjectScaffolding();
            string content = scaffolding.TestGetReadmeContent("Azure.ResourceManager.Test");
            Assert.IsTrue(content.Contains("Azure.ResourceManager.Test"));
            Assert.IsTrue(content.Contains("management client library for .NET"));
            Assert.IsTrue(content.Contains("Getting started"));
            Assert.IsTrue(content.Contains("Install the package"));
            Assert.IsTrue(content.Contains("Authenticate the Client"));
            Assert.IsTrue(content.Contains("mgmt_quickstart.md"));
        }

        [Test]
        public void GetChangelogContentContainsReleaseHistory()
        {
            var scaffolding = new TestableNewManagementProjectScaffolding();
            string content = scaffolding.TestGetChangelogContent("Azure.ResourceManager.Test");
            Assert.IsTrue(content.Contains("# Release History"));
            Assert.IsTrue(content.Contains("## 1.0.0-beta.1 (Unreleased)"));
            Assert.IsTrue(content.Contains("### Features Added"));
        }

        [Test]
        public void GetDirectoryBuildPropsContentContainsMSBuildImport()
        {
            var scaffolding = new TestableNewManagementProjectScaffolding();
            string content = scaffolding.TestGetDirectoryBuildPropsContent();
            Assert.IsTrue(content.Contains("GetDirectoryNameOfFileAbove"));
            Assert.IsTrue(content.Contains("Directory.Build.props"));
            Assert.IsTrue(content.Contains("<Project"));
        }

        [Test]
        public void GetTestProjectContentContainsProjectReference()
        {
            var scaffolding = new TestableNewManagementProjectScaffolding();
            string content = scaffolding.TestGetTestProjectContent("Azure.ResourceManager.Test");
            Assert.IsTrue(content.Contains(@"<ProjectReference Include=""..\src\Azure.ResourceManager.Test.csproj"" />"));
            Assert.IsTrue(content.Contains("<Project Sdk=\"Microsoft.NET.Sdk\">"));
        }

        [Test]
        public void GetSolutionFileContentIncludesTestProject()
        {
            var scaffolding = new TestableNewManagementProjectScaffolding();
            string originalOutputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;
            string packageName = ManagementClientGenerator.Instance.Configuration.PackageName;

            try
            {
                SetOutputDirectory(@"C:\repo\sdk\test\" + packageName);

                string content = scaffolding.TestGetSolutionFileContent();
                Assert.IsTrue(content.Contains($@"<Project Path=""src/{packageName}.csproj"" />"));
                Assert.IsTrue(content.Contains($@"<Project Path=""tests/{packageName}.Tests.csproj"" />"));
            }
            finally
            {
                SetOutputDirectory(originalOutputDir);
            }
        }

        [Test]
        public async Task WriteAdditionalFilesSkipsNonSdkDirectory()
        {
            // The test output directory is under eng/, not sdk/, so files should NOT be created
            string outputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;
            string readmePath = Path.Combine(outputDir, "README.md");
            string changelogPath = Path.Combine(outputDir, "CHANGELOG.md");
            string propsPath = Path.Combine(outputDir, "Directory.Build.props");
            string testCsprojPath = Path.Combine(outputDir, "tests", "Samples.Tests.csproj");

            try
            {
                // Clean any pre-existing files
                if (File.Exists(readmePath)) File.Delete(readmePath);
                if (File.Exists(changelogPath)) File.Delete(changelogPath);
                if (File.Exists(propsPath)) File.Delete(propsPath);
                if (File.Exists(testCsprojPath)) File.Delete(testCsprojPath);

                var scaffolding = new TestableNewManagementProjectScaffolding();
                await scaffolding.TestWriteAdditionalFiles();

                // Files should NOT be created since output is not under sdk/
                Assert.IsFalse(File.Exists(readmePath));
                Assert.IsFalse(File.Exists(changelogPath));
                Assert.IsFalse(File.Exists(propsPath));
                Assert.IsFalse(File.Exists(testCsprojPath));
            }
            finally
            {
                if (File.Exists(readmePath)) File.Delete(readmePath);
                if (File.Exists(changelogPath)) File.Delete(changelogPath);
                if (File.Exists(propsPath)) File.Delete(propsPath);
                if (File.Exists(testCsprojPath)) File.Delete(testCsprojPath);
            }
        }

        /// <summary>
        /// Testable wrapper that exposes protected virtual methods for testing.
        /// </summary>
        private class TestableNewManagementProjectScaffolding : NewManagementProjectScaffolding
        {
            public string TestGetReadmeContent(string packageName) => GetReadmeContent(packageName);
            public string TestGetChangelogContent(string packageName) => GetChangelogContent(packageName);
            public string TestGetDirectoryBuildPropsContent() => GetDirectoryBuildPropsContent("TestPackage");
            public string TestGetTestProjectContent(string packageName) => GetTestProjectContent(packageName);
            public string TestGetSolutionFileContent() => GetSolutionFileContent();
            public Task TestWriteAdditionalFiles() => WriteAdditionalFiles();
        }

        private static void SetOutputDirectory(string outputDirectory)
        {
            object configuration = ManagementClientGenerator.Instance.Configuration;
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            PropertyInfo? property = configuration.GetType().GetProperty("OutputDirectory", Flags);
            if (property?.CanWrite == true)
            {
                property.SetValue(configuration, outputDirectory);
                return;
            }

            FieldInfo? field = configuration.GetType().GetField("<OutputDirectory>k__BackingField", Flags)
                ?? configuration.GetType().GetField("_outputDirectory", Flags);

            Assert.IsNotNull(field, "Unable to set Configuration.OutputDirectory for test.");
            field!.SetValue(configuration, outputDirectory);
        }
    }
}
