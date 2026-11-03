// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class NewProvisioningProjectScaffoldingTests
    {
        private const string PackageName = "Azure.Provisioning.Tests";
        private string _root = null!;

        [SetUp]
        public void SetUp()
        {
            _root = Path.Combine(Path.GetTempPath(), $"provisioning-scaffolding-{Guid.NewGuid():N}");
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_root))
            {
                Directory.Delete(_root, recursive: true);
            }
        }

        [Test]
        public void FactorySelectsProvisioningScaffolding()
        {
            var generator = ProvisioningMockHelpers.LoadMockPlugin();
            Assert.That(generator.Object.TypeFactory.CreateNewProjectScaffolding(),
                Is.TypeOf<NewProvisioningProjectScaffolding>());
        }

        [Test]
        public void SourceProjectUsesProvisioningMetadataAndDependencies()
        {
            LoadGenerator("sdk");
            var project = new TestableScaffolding().SourceProject();
            var properties = project.Root!.Element("PropertyGroup")!;

            Assert.Multiple(() =>
            {
                Assert.That(properties.Element("Description")?.Value,
                    Is.EqualTo($"{PackageName} simplifies declarative resource provisioning in .NET."));
                Assert.That(properties.Element("Version")?.Value, Is.EqualTo("1.0.0-beta.1"));
                Assert.That(properties.Element("AssemblyTitle")?.Value, Is.EqualTo($"SDK Code Generation {PackageName}"));
                Assert.That(properties.Element("PackageTags")?.Value, Is.EqualTo(PackageName));
                Assert.That(properties.Element("GenerateDocumentationFile")?.Value, Is.EqualTo("true"));
                Assert.That(project.Descendants("PackageReference").Select(p => p.Attribute("Include")?.Value),
                    Is.EquivalentTo(new[] { "Azure.Provisioning" }));
                Assert.That(project.Descendants("Compile").Select(p => p.Attribute("Include")?.Value),
                    Is.EquivalentTo(new[] { "$(AzureCoreSharedSources)ExperimentalAttribute.cs" }));
            });
        }

        [TestCase("sdk")]
        [TestCase("eng")]
        public void TestProjectReferencesProvisioningInfrastructure(string directory)
        {
            string outputDir = LoadGenerator(directory);
            var project = new TestableScaffolding().TestProject();
            var references = project.Descendants("ProjectReference")
                .Select(p => p.Attribute("Include")!.Value)
                .Where(p => p.StartsWith("$(MSBuildThisFileDirectory)", StringComparison.Ordinal))
                .Select(p => ResolveTestPath(outputDir, p));
            Assert.Multiple(() =>
            {
                Assert.That(references, Is.EquivalentTo(new[]
                {
                    Path.Combine(_root, "sdk", "provisioning", "Azure.Provisioning", "src", "Azure.Provisioning.csproj"),
                    Path.Combine(_root, "sdk", "provisioning", "Azure.Provisioning.Deployment", "src", "Azure.Provisioning.Deployment.csproj")
                }));
                Assert.That(ResolveTestPath(outputDir, project.Descendants("Compile").Single().Attribute("Include")!.Value),
                    Is.EqualTo(Path.Combine(_root, "common", "ProvisioningTestShared", "*.cs")));
                Assert.That(project.Descendants("ProjectReference").Any(p => p.Attribute("Include")?.Value == $@"..\src\{PackageName}.csproj"), Is.True);
                Assert.That(project.Descendants("ProjectReference")
                    .Single(p => p.Attribute("Include")?.Value == "$(AzureCoreTestFramework)")
                    .Attribute("Condition")?.Value, Is.EqualTo("'$(IsMgmtLibrary)' != 'true'"));
                Assert.That(project.Descendants("PackageReference").Select(p => p.Attribute("Include")?.Value),
                    Is.EquivalentTo(new[] { "NUnit", "NUnit3TestAdapter", "Microsoft.NET.Test.Sdk", "Moq" }));
                Assert.That(project.Descendants("PackageReference").First().Parent!.Attribute("Condition")?.Value,
                    Is.EqualTo("'$(IsMgmtLibrary)' != 'true' and '$(IsStorageTest)' != 'true'"));
            });
        }

        [Test]
        public async Task SdkScaffoldingCreatesProvisioningFiles()
        {
            string outputDir = LoadGenerator("sdk");
            var scaffolding = new TestableScaffolding();
            await scaffolding.WriteFilesAsync();

            string readme = File.ReadAllText(Path.Combine(outputDir, "README.md"));
            string changelog = File.ReadAllText(Path.Combine(outputDir, "CHANGELOG.md"));
            var props = XDocument.Load(Path.Combine(outputDir, "Directory.Build.props"));
            XNamespace ns = props.Root!.Name.Namespace;
            var solution = scaffolding.Solution();

            Assert.Multiple(() =>
            {
                Assert.That(readme, Does.Contain(PackageName).And.Contain("BicepValue<T>").And.Contain("## Examples"));
                Assert.That(readme, Does.Not.Contain("{packageName}").And.Not.Contain("management client"));
                Assert.That(changelog, Does.Contain("## 1.0.0-beta.1 (Unreleased)"));
                Assert.That(props.Descendants(ns + "IsMgmtLibrary").Single().Value, Is.EqualTo("true"));
                Assert.That(props.Descendants(ns + "Nullable").Single().Value, Is.EqualTo("enable"));
                Assert.That(props.Descendants(ns + "Import").Single().Attribute("Project")?.Value, Does.Contain("GetDirectoryNameOfFileAbove"));
                Assert.That(File.ReadAllText(Path.Combine(outputDir, "tests", $"{PackageName}.Tests.csproj")),
                    Is.EqualTo(scaffolding.TestProjectContent()));
                Assert.That(solution.Descendants("Project").Select(p => p.Attribute("Path")?.Value),
                    Is.EquivalentTo(new[] { $"src/{PackageName}.csproj", $"tests/{PackageName}.Tests.csproj" }));
            });
        }

        [Test]
        public async Task ExistingFilesArePreserved()
        {
            string outputDir = LoadGenerator("sdk");
            string[] paths = ["README.md", "CHANGELOG.md", "Directory.Build.props", $"tests/{PackageName}.Tests.csproj"];
            Directory.CreateDirectory(Path.Combine(outputDir, "tests"));
            foreach (string path in paths)
            {
                File.WriteAllText(Path.Combine(outputDir, path), "customized content");
            }

            await new TestableScaffolding().WriteFilesAsync();

            foreach (string path in paths)
            {
                Assert.That(File.ReadAllText(Path.Combine(outputDir, path)), Is.EqualTo("customized content"), path);
            }
        }

        [Test]
        public async Task AdditionalFilesAreNotCreatedOutsideSdk()
        {
            string outputDir = LoadGenerator("eng");
            await new TestableScaffolding().WriteFilesAsync();

            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(Path.Combine(outputDir, "README.md")), Is.False);
                Assert.That(File.Exists(Path.Combine(outputDir, "CHANGELOG.md")), Is.False);
                Assert.That(File.Exists(Path.Combine(outputDir, "Directory.Build.props")), Is.False);
                Assert.That(Directory.Exists(Path.Combine(outputDir, "tests")), Is.False);
            });
        }

        private string LoadGenerator(string directory)
        {
            string outputDir = directory == "sdk"
                ? Path.Combine(_root, "sdk", "service", PackageName)
                : Path.Combine(_root, "eng", "packages", "generator", "TestProjects", "Local", PackageName);
            Directory.CreateDirectory(outputDir);
            var generator = ProvisioningMockHelpers.LoadMockPlugin();
            typeof(Configuration).GetField("<OutputDirectory>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(generator.Object.Configuration, outputDir);
            return outputDir;
        }

        private static string ResolveTestPath(string outputDir, string path)
            => Path.GetFullPath(Path.Combine(outputDir, "tests", path.Replace("$(MSBuildThisFileDirectory)", "", StringComparison.Ordinal)));

        private class TestableScaffolding : NewProvisioningProjectScaffolding
        {
            public XDocument SourceProject() => XDocument.Parse(GetSourceProjectFileContent());
            public XDocument TestProject() => XDocument.Parse(GetTestProjectFileContent());
            public XDocument Solution() => XDocument.Parse(GetSolutionFileContent());
            public string TestProjectContent() => GetTestProjectFileContent();
            public Task WriteFilesAsync() => WriteAdditionalFiles();
        }
    }
}
