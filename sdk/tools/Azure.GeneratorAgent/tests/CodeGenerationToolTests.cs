// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class CodeGenerationToolTests
{
    [Test]
    public void BuildArguments_NoLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments(null);

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_EmptyLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments("");

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_WhitespaceLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments("   ");

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_WithLocalSpecs_IncludesLocalSpecRepo()
    {
        var specsPath = Path.Combine(Path.GetTempPath(), "azure-rest-api-specs");

        var args = CodeGenerationTool.BuildArguments(specsPath);

        Assert.Multiple(() =>
        {
            Assert.That(args, Does.StartWith("build /t:generateCode"));
            Assert.That(args, Does.Contain("/p:LocalSpecRepo="));
            Assert.That(args, Does.Contain("azure-rest-api-specs"));
        });
    }

    [Test]
    public void BuildArguments_WithLocalSpecs_NormalizesPath()
    {
        var specsPath = Path.Combine(Path.GetTempPath(), "specs", "..", "azure-rest-api-specs");

        var args = CodeGenerationTool.BuildArguments(specsPath);

        // Path should be normalized (no ".." segments)
        Assert.That(args, Does.Not.Contain(".."));
        Assert.That(args, Does.Contain("/p:LocalSpecRepo="));
    }
}
