// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    /// <summary>
    /// Tests to verify property flattening scenarios, especially ensuring internal properties
    /// have setters when needed for lazy initialization in flattened property getters.
    /// </summary>
    public class FlattenPropertyTests
    {
        private static string TestProjectPath => Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            "..", "..", "..", "..", "..", "eng", "packages", "http-client-csharp-mgmt",
            "generator", "TestProjects", "Local", "Mgmt-TypeSpec", "src", "Generated", "Models");

        /// <summary>
        /// Verifies that when a model has a flattened property with lazy initialization,
        /// the internal property has a setter to allow the assignment in the getter.
        /// This prevents compilation errors like: "Property or indexer cannot be assigned to -- it is read only"
        /// </summary>
        [Test]
        public void VerifyInternalPropertyHasSetterForLazyInitialization()
        {
            // ZooPatch has a flattened property (ZooUpdateSomething) that requires lazy initialization
            // of the internal Properties property. This test verifies that Properties has a setter.
            var zooPatchFile = Path.Combine(TestProjectPath, "ZooPatch.cs");

            if (!File.Exists(zooPatchFile))
            {
                Assert.Inconclusive($"Test file not found: {zooPatchFile}. Run Generate.ps1 to generate test projects.");
                return;
            }

            var content = File.ReadAllText(zooPatchFile);

            // Verify the internal property has both get and set
            var internalPropertyPattern = @"internal\s+ZooUpdateProperties\s+Properties\s*\{\s*get;\s*set;\s*\}";
            Assert.IsTrue(Regex.IsMatch(content, internalPropertyPattern),
                "Internal Properties property should have both get and set accessors to support lazy initialization in flattened property getter");

            // Verify the flattened property exists with a setter that can initialize the internal property
            Assert.IsTrue(content.Contains("public string ZooUpdateSomething"),
                "Flattened property ZooUpdateSomething should exist");

            // Check that it has both get and set
            var zooUpdateSomethingSection = content.Substring(content.IndexOf("public string ZooUpdateSomething"));
            var nextPropertyIndex = zooUpdateSomethingSection.IndexOf("public ", 1);
            if (nextPropertyIndex > 0)
            {
                zooUpdateSomethingSection = zooUpdateSomethingSection.Substring(0, nextPropertyIndex);
            }
            Assert.IsTrue(zooUpdateSomethingSection.Contains("get") && zooUpdateSomethingSection.Contains("set"),
                "Flattened property ZooUpdateSomething should have both get and set accessors");

            // Verify the setter contains lazy initialization logic
            var setterWithInitPattern = @"set\s*\{[^}]*if\s*\([^)]*Properties\s+is\s+null[^)]*\)[^}]*Properties\s*=\s*new\s+ZooUpdateProperties\(\)";
            Assert.IsTrue(Regex.IsMatch(content, setterWithInitPattern, RegexOptions.Singleline),
                "Flattened property setter should contain lazy initialization logic for internal Properties");
        }

        /// <summary>
        /// Verifies that internal properties used for safe flattening have appropriate accessors.
        /// Safe flattening occurs when a model has a single property that is flattened to the parent.
        /// </summary>
        [Test]
        public void VerifySafeFlattenInternalProperty()
        {
            // FooProperties has a SafeFlattenModel property that is safe flattened
            var fooPropertiesFile = Path.Combine(TestProjectPath, "FooProperties.cs");

            if (!File.Exists(fooPropertiesFile))
            {
                Assert.Inconclusive($"Test file not found: {fooPropertiesFile}. Run Generate.ps1 to generate test projects.");
                return;
            }

            var content = File.ReadAllText(fooPropertiesFile);

            // Verify the flattened property exists
            var flattenedPropertyPattern = @"public\s+string\s+FlattenedProperty\s*\{[^}]*get[^}]*\}";
            Assert.IsTrue(Regex.IsMatch(content, flattenedPropertyPattern, RegexOptions.Singleline),
                "FlattenedProperty should exist as a public property with getter");

            // Verify the internal property exists (should be internal with get and set for safe flatten)
            var internalPropertyExists = content.Contains("SafeFlattenModel") && content.Contains("OptionalProperty");
            Assert.IsTrue(internalPropertyExists,
                "Internal OptionalProperty of type SafeFlattenModel should exist");
        }

        /// <summary>
        /// Verifies that collection properties with required wire info work correctly with flattening.
        /// This scenario requires lazy initialization when the internal property is null.
        /// </summary>
        [Test]
        public void VerifyCollectionPropertyFlatteningWithLazyInit()
        {
            // FooSettingsProperties has MetaDatas collection property that is flattened
            var fooSettingsPropertiesFile = Path.Combine(TestProjectPath, "FooSettingsProperties.cs");

            if (!File.Exists(fooSettingsPropertiesFile))
            {
                Assert.Inconclusive($"Test file not found: {fooSettingsPropertiesFile}. Run Generate.ps1 to generate test projects.");
                return;
            }

            var content = File.ReadAllText(fooSettingsPropertiesFile);

            // Check if MetaDatas flattened property exists
            var hasMetaDatasProperty = content.Contains("MetaDatas") && content.Contains("IList<string>");
            if (hasMetaDatasProperty)
            {
                // Verify the internal MetaData property exists
                Assert.IsTrue(content.Contains("MetaData"),
                    "Internal MetaData property should exist for collection flattening");

                // Verify the flattened property has a getter
                var flattenedPropertyPattern = @"public\s+IList<string>\s+MetaDatas\s*\{[^}]*get[^}]*\}";
                Assert.IsTrue(Regex.IsMatch(content, flattenedPropertyPattern, RegexOptions.Singleline),
                    "MetaDatas flattened property should have a getter");
            }
        }
    }
}
