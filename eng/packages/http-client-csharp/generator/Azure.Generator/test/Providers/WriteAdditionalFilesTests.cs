// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Generator.Tests.Providers
{
    public class WriteAdditionalFilesTests
    {
        [SetUp]
        public void SetUp()
        {
            MockHelpers.LoadMockGenerator();
        }

        [Test]
        public void GetCiFileNameReturnsCiYml()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            Assert.AreEqual("ci.yml", scaffolding.TestGetCiFileName());
        }

        [Test]
        public void GetReadmeContentContainsPackageName()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetReadmeContent("Azure.Test.Package");
            Assert.IsTrue(content.Contains("Azure.Test.Package"));
            Assert.IsTrue(content.Contains("client library for .NET"));
            Assert.IsTrue(content.Contains("Getting started"));
            Assert.IsTrue(content.Contains("Install the package"));
        }

        [Test]
        public void GetReadmeContentUsesCorrectGrammar()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetReadmeContent("Azure.Test.Package");
            Assert.IsTrue(content.Contains("a [Microsoft Azure subscription]"));
            Assert.IsFalse(content.Contains("an [Microsoft Azure subscription]"));
        }

        [Test]
        public void GetChangelogContentContainsReleaseHistory()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetChangelogContent("Azure.Test.Package");
            Assert.IsTrue(content.Contains("# Release History"));
            Assert.IsTrue(content.Contains("## 1.0.0-beta.1 (Unreleased)"));
            Assert.IsTrue(content.Contains("### Features Added"));
        }

        [Test]
        public void GetCiYamlContentContainsPackageInfo()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetCiYamlContent("Azure.Test.Package", "testservice");
            Assert.IsTrue(content.Contains("Azure.Test.Package"));
            Assert.IsTrue(content.Contains("AzureTestPackage"));
            Assert.IsTrue(content.Contains("testservice"));
            Assert.IsTrue(content.Contains("SDKType: client"));
            Assert.IsTrue(content.Contains("trigger:"));
        }

        [Test]
        public void GetDirectoryBuildPropsContentContainsMSBuildImport()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetDirectoryBuildPropsContent();
            Assert.IsTrue(content.Contains("GetDirectoryNameOfFileAbove"));
            Assert.IsTrue(content.Contains("Directory.Build.props"));
            Assert.IsTrue(content.Contains("<Project"));
        }

        [Test]
        public void GetCiYamlContentSafeNameRemovesDots()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetCiYamlContent("Azure.Storage.Blobs", "storage");
            Assert.IsTrue(content.Contains("safeName: AzureStorageBlobs"));
        }

        [Test]
        public async Task WriteAdditionalFilesCreatesExpectedFiles()
        {
            string outputDir = AzureClientGenerator.Instance.Configuration.OutputDirectory;
            string[] filesToClean = [
                Path.Combine(outputDir, "README.md"),
                Path.Combine(outputDir, "CHANGELOG.md"),
                Path.Combine(outputDir, "Directory.Build.props")
            ];
            // Also clean ci.yml from parent directory
            string? parentDir = Path.GetDirectoryName(outputDir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            string? ciFile = parentDir != null ? Path.Combine(parentDir, "ci.yml") : null;

            try
            {
                // Clean any pre-existing files
                foreach (var f in filesToClean) if (File.Exists(f)) File.Delete(f);
                if (ciFile != null && File.Exists(ciFile)) File.Delete(ciFile);

                var scaffolding = new TestableNewAzureProjectScaffolding();
                await scaffolding.TestWriteAdditionalFiles();

                Assert.IsTrue(File.Exists(Path.Combine(outputDir, "README.md")));
                Assert.IsTrue(File.Exists(Path.Combine(outputDir, "CHANGELOG.md")));
                Assert.IsTrue(File.Exists(Path.Combine(outputDir, "Directory.Build.props")));

                // ci.yml should be in the parent directory
                if (ciFile != null)
                {
                    Assert.IsTrue(File.Exists(ciFile));
                }
            }
            finally
            {
                foreach (var f in filesToClean) if (File.Exists(f)) File.Delete(f);
                if (ciFile != null && File.Exists(ciFile)) File.Delete(ciFile);
            }
        }

        [Test]
        public async Task WriteAdditionalFilesDoesNotOverwriteExisting()
        {
            string outputDir = AzureClientGenerator.Instance.Configuration.OutputDirectory;
            string readmePath = Path.Combine(outputDir, "README.md");
            string? existingContent = null;

            try
            {
                existingContent = "# My Custom README";
                File.WriteAllText(readmePath, existingContent);

                var scaffolding = new TestableNewAzureProjectScaffolding();
                await scaffolding.TestWriteAdditionalFiles();

                Assert.AreEqual(existingContent, File.ReadAllText(readmePath));
            }
            finally
            {
                if (File.Exists(readmePath)) File.Delete(readmePath);
                // Clean other files too
                string changelogPath = Path.Combine(outputDir, "CHANGELOG.md");
                string propsPath = Path.Combine(outputDir, "Directory.Build.props");
                if (File.Exists(changelogPath)) File.Delete(changelogPath);
                if (File.Exists(propsPath)) File.Delete(propsPath);
                string? parentDir = Path.GetDirectoryName(outputDir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                string? ciFile = parentDir != null ? Path.Combine(parentDir, "ci.yml") : null;
                if (ciFile != null && File.Exists(ciFile)) File.Delete(ciFile);
            }
        }

        /// <summary>
        /// Testable wrapper that exposes protected virtual methods for testing.
        /// </summary>
        private class TestableNewAzureProjectScaffolding : NewAzureProjectScaffolding
        {
            public string TestGetCiFileName() => GetCiFileName();
            public string TestGetReadmeContent(string packageName) => GetReadmeContent(packageName);
            public string TestGetChangelogContent(string packageName) => GetChangelogContent(packageName);
            public string TestGetCiYamlContent(string packageName, string serviceDirectoryName) => GetCiYamlContent(packageName, serviceDirectoryName);
            public string TestGetDirectoryBuildPropsContent() => GetDirectoryBuildPropsContent("TestPackage");
            public Task TestWriteAdditionalFiles() => WriteAdditionalFiles();
        }
    }
}
