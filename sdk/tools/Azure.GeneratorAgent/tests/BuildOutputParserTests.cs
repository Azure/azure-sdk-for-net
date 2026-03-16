// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class BuildOutputParserTests
{
    [Test]
    public void Parse_EmptyInput_ReturnsEmptyList()
    {
        var result = BuildOutputParser.Parse(string.Empty);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Parse_NullInput_ReturnsEmptyList()
    {
        var result = BuildOutputParser.Parse(null!);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Parse_WhitespaceInput_ReturnsEmptyList()
    {
        var result = BuildOutputParser.Parse("   \n   ");
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Parse_StandardError_ExtractsAllFields()
    {
        var output = @"C:\src\MyFile.cs(10,5): error CS0246: The type or namespace name 'HttpPipeline' could not be found";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].FilePath, Is.EqualTo(@"C:\src\MyFile.cs"));
            Assert.That(result[0].Line, Is.EqualTo(10));
            Assert.That(result[0].Column, Is.EqualTo(5));
            Assert.That(result[0].Code, Is.EqualTo("CS0246"));
            Assert.That(result[0].Message, Is.EqualTo("The type or namespace name 'HttpPipeline' could not be found"));
            Assert.That(result[0].Severity, Is.EqualTo("error"));
            Assert.That(result[0].IsGenerated, Is.False);
        });
    }

    [Test]
    public void Parse_GeneratedFilePath_SetsIsGenerated()
    {
        var output = @"C:\src\Generated\Model.cs(5,1): error CS1061: 'Foo' does not contain a definition for '_pipeline'";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].IsGenerated, Is.True);
    }

    [Test]
    public void Parse_WarningLine_ParsedCorrectly()
    {
        var output = @"C:\src\Client.cs(20,10): warning CS8600: Converting null literal or possible null value to non-nullable type";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Severity, Is.EqualTo("warning"));
        Assert.That(result[0].Code, Is.EqualTo("CS8600"));
    }

    [Test]
    public void Parse_MultipleErrors_ParsesAll()
    {
        var output = """
            C:\src\A.cs(1,1): error CS0246: The type or namespace name 'Foo' could not be found
            C:\src\B.cs(2,3): error CS1061: 'Bar' does not contain a definition for '_pipeline'
            C:\src\C.cs(3,5): warning CS8625: Cannot convert null literal to non-nullable reference type
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(3));
    }

    [Test]
    public void Parse_DuplicateErrors_Deduplicated()
    {
        var output = """
            C:\src\A.cs(1,1): error CS0246: The type or namespace name 'Foo' could not be found
            C:\src\A.cs(1,1): error CS0246: The type or namespace name 'Foo' could not be found
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
    }

    [Test]
    public void Parse_LineWithoutColumn_Parsed()
    {
        var output = @"C:\src\MyFile.cs(15): error CS0103: The name '_endpoint' does not exist in the current context";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Line, Is.EqualTo(15));
            Assert.That(result[0].Column, Is.EqualTo(0));
            Assert.That(result[0].Code, Is.EqualTo("CS0103"));
        });
    }

    [Test]
    public void IsSuccess_SuccessfulBuild_ReturnsTrue()
    {
        var output = """
            Build succeeded.
                0 Warning(s)
                0 Error(s)
            """;
        Assert.That(BuildOutputParser.IsSuccess(output), Is.True);
    }

    [Test]
    public void IsSuccess_FailedBuild_ReturnsFalse()
    {
        var output = """
            C:\src\A.cs(1,1): error CS0246: something
            Build FAILED.
            """;
        Assert.That(BuildOutputParser.IsSuccess(output), Is.False);
    }

    [Test]
    public void IsSuccess_EmptyOutput_ReturnsFalse()
    {
        Assert.That(BuildOutputParser.IsSuccess(string.Empty), Is.False);
    }

    [Test]
    public void Parse_UnixStyleGeneratedPath_SetsIsGenerated()
    {
        var output = "/home/user/src/Generated/Model.cs(5,1): error CS1061: something";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].IsGenerated, Is.True);
    }
}
