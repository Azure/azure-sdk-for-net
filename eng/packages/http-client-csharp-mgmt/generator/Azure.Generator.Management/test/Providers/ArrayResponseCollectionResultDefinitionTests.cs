// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.IO;

namespace Azure.Generator.Management.Tests.Providers
{
    /// <summary>
    /// Integration tests for ArrayResponseCollectionResultDefinition.
    /// These tests verify that the generated code uses the correct request method names.
    /// </summary>
    internal class ArrayResponseCollectionResultDefinitionTests
    {
        private static string TestProjectRoot
        {
            get
            {
                // When running from test bin folder, need to navigate back to the eng/packages folder
                var testAssemblyPath = Path.GetDirectoryName(typeof(ArrayResponseCollectionResultDefinitionTests).Assembly.Location)!;
                // Navigate from artifacts/bin/Azure.Generator.Mgmt.Tests/Debug/net10.0/ back to repo root
                var currentPath = testAssemblyPath;
                while (!string.IsNullOrEmpty(currentPath) && Path.GetFileName(currentPath) != "azure-sdk-for-net")
                {
                    currentPath = Path.GetDirectoryName(currentPath);
                }

                if (string.IsNullOrEmpty(currentPath))
                {
                    // Fallback: assume we're in the standard structure
                    currentPath = Path.GetFullPath(Path.Combine(testAssemblyPath, "..", "..", "..", "..", "..", "..", "..", ".."));
                }

                return Path.Combine(currentPath, "eng", "packages", "http-client-csharp-mgmt", "generator", "TestProjects", "Local", "Mgmt-TypeSpec");
            }
        }

        private const string GeneratedCollectionResultsPath = "src/Generated/CollectionResults";

        /// <summary>
        /// Test that the generated GetNextResponse method calls the correct Create*Request method
        /// based on the original convenience method name, not a potentially customized method name.
        ///
        /// This test verifies the fix for the issue where baseName was derived from _methodName
        /// instead of the original convenience method name from the REST client.
        /// </summary>
        [TestCase("FooResourceGetDependenciesCollectionResultOfT.cs", "CreateGetDependenciesRequest")]
        [TestCase("FooResourceGetDependenciesAsyncCollectionResultOfT.cs", "CreateGetDependenciesRequest")]
        public void Verify_GeneratedCollectionResult_UsesOriginalConvenienceMethodName(string fileName, string expectedRequestMethod)
        {
            // Arrange
            var filePath = Path.Combine(TestProjectRoot, GeneratedCollectionResultsPath, fileName);
            var fullPath = Path.GetFullPath(filePath);

            // Assert file exists
            Assert.That(File.Exists(fullPath), Is.True,
                $"Generated file should exist at: {fullPath}");

            // Act
            var content = File.ReadAllText(fullPath);

            // Assert
            // Verify the file contains the correct Create*Request method call
            Assert.That(content, Does.Contain(expectedRequestMethod),
                $"Generated code should call {expectedRequestMethod} based on the original convenience method name. " +
                $"This ensures the fix works: baseName should use the original convenience method name from REST client, " +
                $"not a potentially customized _methodName parameter.");

            // Additional verification: ensure it's called with proper syntax
            Assert.That(content, Does.Contain($"_client.{expectedRequestMethod}("),
                $"Generated code should call _client.{expectedRequestMethod}(...) with proper syntax");
        }

        /// <summary>
        /// Test that async methods don't add an additional "Async" suffix to the request method name.
        /// The async convenience method (e.g., "GetDependenciesAsync") should still call
        /// "CreateGetDependenciesRequest", not "CreateGetDependenciesAsyncRequest".
        /// </summary>
        [TestCase]
        public void Verify_AsyncMethod_DoesNotAddAsyncSuffixToRequestMethod()
        {
            // Arrange
            var filePath = Path.Combine(TestProjectRoot, GeneratedCollectionResultsPath,
                "FooResourceGetDependenciesAsyncCollectionResultOfT.cs");
            var fullPath = Path.GetFullPath(filePath);

            Assert.That(File.Exists(fullPath), Is.True, $"Generated file should exist at: {fullPath}");

            // Act
            var content = File.ReadAllText(fullPath);

            // Assert
            // Should call CreateGetDependenciesRequest (without Async)
            Assert.That(content, Does.Contain("CreateGetDependenciesRequest"),
                "Async collection result should call CreateGetDependenciesRequest (without Async suffix)");

            // Should NOT call CreateGetDependenciesAsyncRequest
            Assert.That(content, Does.Not.Contain("CreateGetDependenciesAsyncRequest"),
                "Async collection result should NOT call CreateGetDependenciesAsyncRequest. " +
                "The fix ensures the 'Async' suffix is properly stripped from the convenience method name.");
        }

        /// <summary>
        /// Test that the generated code has the correct structure with HttpMessage, DiagnosticScope, etc.
        /// </summary>
        [TestCase("FooResourceGetDependenciesCollectionResultOfT.cs")]
        public void Verify_GeneratedCode_HasCorrectStructure(string fileName)
        {
            // Arrange
            var filePath = Path.Combine(TestProjectRoot, GeneratedCollectionResultsPath, fileName);
            var fullPath = Path.GetFullPath(filePath);

            Assert.That(File.Exists(fullPath), Is.True, $"Generated file should exist at: {fullPath}");

            // Act
            var content = File.ReadAllText(fullPath);

            // Assert - verify key elements of the GetNextResponse method
            Assert.That(content, Does.Contain("HttpMessage message"),
                "Generated code should declare HttpMessage variable");

            Assert.That(content, Does.Contain("DiagnosticScope scope"),
                "Generated code should declare and use DiagnosticScope");

            Assert.That(content, Does.Contain("Pipeline.ProcessMessage"),
                "Generated code should call Pipeline.ProcessMessage");

            Assert.That(content, Does.Contain("scope.Start()"),
                "Generated code should call scope.Start()");

            Assert.That(content, Does.Contain("scope.Failed("),
                "Generated code should call scope.Failed() in catch block");
        }
    }
}
