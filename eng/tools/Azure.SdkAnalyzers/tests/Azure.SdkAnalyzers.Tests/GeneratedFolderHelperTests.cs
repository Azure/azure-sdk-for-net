// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    public class GeneratedFolderHelperTests
    {
        [Test]
        public void GetGeneratedFolderInfo_NotInGeneratedFolder_ReturnsFalse()
        {
            string filePath = @"C:\sdk\keyvault\Azure.Security.KeyVault.Secrets\src\Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.False);
        }

        [Test]
        public void GetGeneratedFolderInfo_DirectlyInGeneratedFolder_ReturnsCustomOnly()
        {
            string filePath = @"C:\sdk\keyvault\Azure.Security.KeyVault.Secrets\src\Generated\Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_InGeneratedModelsFolder_ReturnsCustomModels()
        {
            string filePath = @"C:\sdk\keyvault\Azure.Security.KeyVault.Secrets\src\Generated\Models\Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_InDeepNestedFolder_ReturnsFullCustomPath()
        {
            string filePath = @"C:\sdk\keyvault\Azure.Security.KeyVault.Secrets\src\Generated\Models\Requests\Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models", "Requests" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_WithForwardSlashes_ReturnsCorrectFolders()
        {
            string filePath = @"C:/sdk/keyvault/Azure.Security.KeyVault.Secrets/src/Generated/Models/Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_DoesNotIncludeFileName()
        {
            string filePath = @"C:\sdk\keyvault\Azure.Security.KeyVault.Secrets\src\Generated\Models\MyClass.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            Assert.That(result.CustomFolders.Any(f => f.EndsWith(".cs")), Is.False, "Folders should not include the filename");
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_RelativePath_DirectlyInGenerated()
        {
            string filePath = "Generated/Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_RelativePath_WithModelsFolder()
        {
            string filePath = "Generated/Models/Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_RelativePath_WithSrcPrefix()
        {
            string filePath = "src/Generated/Models/Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_RelativePath_DeepNesting()
        {
            string filePath = "src/Generated/Models/Requests/Internal/Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models", "Requests", "Internal" }, result.CustomFolders);
        }

        [Test]
        public void GetGeneratedFolderInfo_RelativePath_WithBackslashes()
        {
            string filePath = @"src\Generated\Models\Foo.cs";

            GeneratedFolderInfo result = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            Assert.That(result.IsInGeneratedFolder, Is.True);
            CollectionAssert.AreEqual(new[] { "Custom", "Models" }, result.CustomFolders);
        }
    }
}
