// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class GeneratedPathGuardTests
{
    [TestCase(@"C:\repo\sdk\ai\src\Generated\Models\MyModel.cs", true)]
    [TestCase(@"C:\repo\sdk\ai\src\Generated\MyClient.cs", true)]
    [TestCase(@"C:\repo\sdk\ai\src\Generated\Internal\Helper.cs", true)]
    [TestCase(@"C:\repo\sdk\ai\Generated\Models\MyModel.cs", true)]
    [TestCase(@"C:\repo\sdk\ai\src\Custom\MyClient.cs", false)]
    [TestCase(@"C:\repo\sdk\ai\src\MyClient.cs", false)]
    [TestCase(@"C:\repo\sdk\ai\tests\PersistentAgentsTests.cs", false)]
    public void IsInGeneratedDirectory_ClassifiesCorrectly(string path, bool expected)
    {
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(path), Is.EqualTo(expected));
    }

    [Test]
    public void IsInGeneratedDirectory_CaseInsensitive()
    {
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\GENERATED\Model.cs"), Is.True);
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\generated\Model.cs"), Is.True);
    }

    [Test]
    public void IsInGeneratedDirectory_NoFalsePositiveOnPartialName()
    {
        // "MyGenerated" should NOT match — only exact "Generated" segment
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\MyGenerated\Model.cs"), Is.False);
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\GeneratedCode\Model.cs"), Is.False);
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\PreGenerated\Model.cs"), Is.False);
    }

    [Test]
    public void IsInGeneratedDirectory_FileNamedGenerated_NotBlocked()
    {
        // A file *named* "Generated.cs" in a non-Generated directory is fine
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory(@"C:\repo\src\Custom\Generated.cs"), Is.False);
    }

    [Test]
    public void IsInGeneratedDirectory_HandlesForwardSlashes()
    {
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory("C:/repo/src/Generated/Model.cs"), Is.True);
        Assert.That(GeneratedPathGuard.IsInGeneratedDirectory("C:/repo/src/Custom/Model.cs"), Is.False);
    }

    [Test]
    public void ValidateNotGenerated_ReturnsNull_ForNonGeneratedPath()
    {
        var result = GeneratedPathGuard.ValidateNotGenerated(@"C:\repo\src\Custom\MyClient.cs");
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ValidateNotGenerated_ReturnsError_ForGeneratedPath()
    {
        var result = GeneratedPathGuard.ValidateNotGenerated(@"C:\repo\src\Generated\Model.cs");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("Refusing to modify"));
        Assert.That(result, Does.Contain("Generated/"));
    }
}
