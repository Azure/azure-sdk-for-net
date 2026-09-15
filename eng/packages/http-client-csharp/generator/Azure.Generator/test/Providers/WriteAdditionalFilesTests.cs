// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public void GetReadmeContentPromptsForServiceDescription()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetReadmeContent("Azure.Test.Package");

            Assert.That(content, Does.Contain("TODO: Replace this paragraph before publishing Azure.Test.Package."));
            Assert.That(content, Does.Contain("Introduce the Azure service"));
            Assert.That(content, Does.Contain("main scenarios"));
            Assert.That(content, Does.Contain("link to the service documentation"));
            Assert.That(content, Does.Not.Contain("rich experience"));
        }

        [Test]
        public void GetSourceProjectFileContentPromptsForServiceDescription()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            var project = XDocument.Parse(scaffolding.TestGetSourceProjectFileContent());
            string? description = project.Root?.Element("PropertyGroup")?.Element("Description")?.Value;

            Assert.That(description, Does.Contain($"TODO: Replace this text before publishing {AzureClientGenerator.Instance.Configuration.PackageName}."));
            Assert.That(description, Does.Contain("Describe the Azure service"));
            Assert.That(description, Does.Contain("main scenarios"));
            Assert.That(description, Does.Not.Contain("rich experience"));
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
        public void GetDirectoryBuildPropsContentContainsMSBuildImport()
        {
            var scaffolding = new TestableNewAzureProjectScaffolding();
            string content = scaffolding.TestGetDirectoryBuildPropsContent();
            Assert.IsTrue(content.Contains("GetDirectoryNameOfFileAbove"));
            Assert.IsTrue(content.Contains("Directory.Build.props"));
            Assert.IsTrue(content.Contains("<Project"));
        }

        [Test]
        public async Task WriteAdditionalFilesSkipsNonSdkDirectory()
        {
            // The test output directory is under eng/, not sdk/, so files should NOT be created
            string outputDir = AzureClientGenerator.Instance.Configuration.OutputDirectory;
            string readmePath = Path.Combine(outputDir, "README.md");
            string changelogPath = Path.Combine(outputDir, "CHANGELOG.md");
            string propsPath = Path.Combine(outputDir, "Directory.Build.props");

            try
            {
                // Clean any pre-existing files
                if (File.Exists(readmePath)) File.Delete(readmePath);
                if (File.Exists(changelogPath)) File.Delete(changelogPath);
                if (File.Exists(propsPath)) File.Delete(propsPath);

                var scaffolding = new TestableNewAzureProjectScaffolding();
                await scaffolding.TestWriteAdditionalFiles();

                // Files should NOT be created since output is not under sdk/
                Assert.IsFalse(File.Exists(readmePath));
                Assert.IsFalse(File.Exists(changelogPath));
                Assert.IsFalse(File.Exists(propsPath));
            }
            finally
            {
                if (File.Exists(readmePath)) File.Delete(readmePath);
                if (File.Exists(changelogPath)) File.Delete(changelogPath);
                if (File.Exists(propsPath)) File.Delete(propsPath);
            }
        }

        /// <summary>
        /// Testable wrapper that exposes protected virtual methods for testing.
        /// </summary>
        private class TestableNewAzureProjectScaffolding : NewAzureProjectScaffolding
        {
            public string TestGetSourceProjectFileContent() => GetSourceProjectFileContent();
            public string TestGetReadmeContent(string packageName) => GetReadmeContent(packageName);
            public string TestGetChangelogContent(string packageName) => GetChangelogContent(packageName);
            public string TestGetDirectoryBuildPropsContent() => GetDirectoryBuildPropsContent("TestPackage");
            public Task TestWriteAdditionalFiles() => WriteAdditionalFiles();
        }
    }
}
