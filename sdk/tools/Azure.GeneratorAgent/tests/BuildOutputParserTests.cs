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
    public void Parse_UnixStyleGeneratedPath_SetsIsGenerated()
    {
        var output = "/home/user/src/Generated/Model.cs(5,1): error CS1061: something";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].IsGenerated, Is.True);
    }

    // --- AZC error code tests (3-letter codes) ---

    [Test]
    public void Parse_AZC0002_ThreeLetterCode_IsParsed()
    {
        var output = @"C:\src\Client.cs(85,57): error AZC0002: Client method should have an optional CancellationToken";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("AZC0002"));
            Assert.That(result[0].Message, Does.Contain("CancellationToken"));
            Assert.That(result[0].FilePath, Does.Contain("Client.cs"));
            Assert.That(result[0].Line, Is.EqualTo(85));
        });
    }

    [Test]
    public void Parse_AZC0020_ThreeLetterCode_IsParsed()
    {
        var output = @"C:\src\Client.cs(127,141): error AZC0020: Method 'StartTranslation' accepts a CancellationToken but does not propagate it to the RequestContext.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("AZC0020"));
            Assert.That(result[0].Message, Does.Contain("StartTranslation"));
        });
    }

    [Test]
    public void Parse_AZC0014_ThreeLetterCode_IsParsed()
    {
        var output = @"C:\src\Generated\ModelFactory.cs(112,267): error AZC0014: Types from System.Text.Json should not be exposed as part of public API surface.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("AZC0014"));
            Assert.That(result[0].IsGenerated, Is.True);
        });
    }

    [Test]
    public void Parse_MSB3492_ThreeLetterCode_IsParsed()
    {
        var output = @"C:\src\project.csproj(10,5): error MSB3492: Could not write state file 'obj\Debug\project.AssemblyInfoInputs.cache'.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Code, Is.EqualTo("MSB3492"));
    }

    [Test]
    public void Parse_MixedTwoAndThreeLetterCodes_AllParsed()
    {
        var output = """
            C:\src\A.cs(1,1): error CS0246: The type 'Something' could not be found
            C:\src\B.cs(5,10): error AZC0002: Client method should have optional CancellationToken
            C:\src\C.cs(8,3): warning CS8625: Cannot convert null literal
            C:\src\D.cs(10,5): error AZC0020: Method 'Foo' accepts a CancellationToken
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(4));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("CS0246"));
            Assert.That(result[1].Code, Is.EqualTo("AZC0002"));
            Assert.That(result[2].Code, Is.EqualTo("CS8625"));
            Assert.That(result[3].Code, Is.EqualTo("AZC0020"));
        });
    }

    [Test]
    public void Parse_ProjectLevelAZCError_IsParsed()
    {
        var output = "  error AZC0002: Client method should have optional CancellationToken";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Code, Is.EqualTo("AZC0002"));
    }

    // --- ApiCompat error tests ---

    [Test]
    public void Parse_ApiCompat_CannotRemoveAttribute_IsParsed()
    {
        var output = @"C:\Users\user\.nuget\packages\microsoft.dotnet.apicompat\5.0.0-beta.20467.1\build\Microsoft.DotNet.ApiCompat.targets(82,5): error : CannotRemoveAttribute : Attribute 'System.ObsoleteAttribute' exists on 'Azure.SomeService.Models.DeprecatedModel' in the contract but not the implementation. [C:\src\project.csproj::TargetFramework=netstandard2.0]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("CannotRemoveAttribute"));
            Assert.That(result[0].Message, Does.Contain("CannotRemoveAttribute"));
            Assert.That(result[0].Message, Does.Contain("System.ObsoleteAttribute"));
            Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
            Assert.That(result[0].Severity, Is.EqualTo("error"));
            Assert.That(result[0].Line, Is.EqualTo(82));
        });
    }

    [Test]
    public void Parse_ApiCompat_CannotSealType_IsParsed()
    {
        var output = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets(82,5): error : CannotSealType : Type 'Azure.SomeService.Models.SomeBaseModel' is effectively sealed in the implementation but not in the contract. [C:\src\project.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("CannotSealType"));
            Assert.That(result[0].Message, Does.Contain("SomeBaseModel"));
            Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
        });
    }

    [Test]
    public void Parse_ApiCompat_MembersMustExist_IsParsed()
    {
        var output = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets(82,5): error : MembersMustExist : Member 'Azure.SomeService.Models.SomeBaseType..ctor(System.Guid, System.Collections.Generic.IEnumerable<System.String>)' does not exist in the implementation but it does exist in the contract. [C:\src\project.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("MembersMustExist"));
            Assert.That(result[0].Message, Does.Contain("SomeBaseType"));
        });
    }

    [Test]
    public void Parse_ApiCompat_TypesMustExist_IsParsed()
    {
        var output = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets(82,5): error : TypesMustExist : Type 'Azure.SomeService.Models.SomeRemovedModel' does not exist in the implementation but it does exist in the contract. [C:\src\project.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("TypesMustExist"));
            Assert.That(result[0].Message, Does.Contain("SomeRemovedModel"));
        });
    }

    [Test]
    public void Parse_ApiCompat_MultipleErrors_AllParsed()
    {
        var output = """
            C:\nuget\ApiCompat.targets(82,5): error : CannotRemoveAttribute : Attribute 'System.ObsoleteAttribute' exists on 'Foo' in the contract but not the implementation. [C:\src\p.csproj]
            C:\nuget\ApiCompat.targets(82,5): error : CannotSealType : Type 'Bar' is effectively sealed in the implementation. [C:\src\p.csproj]
            C:\nuget\ApiCompat.targets(82,5): error : MembersMustExist : Member 'Bar..ctor()' does not exist in the implementation. [C:\src\p.csproj]
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("CannotRemoveAttribute"));
            Assert.That(result[1].Code, Is.EqualTo("CannotSealType"));
            Assert.That(result[2].Code, Is.EqualTo("MembersMustExist"));
        });
    }

    [Test]
    public void Parse_ApiCompat_MixedWithStandardErrors_AllParsed()
    {
        var output = """
            C:\src\Client.cs(10,5): error CS0246: The type 'Foo' could not be found
            C:\nuget\ApiCompat.targets(82,5): error : CannotSealType : Type 'Bar' is effectively sealed. [C:\src\p.csproj]
            C:\src\Model.cs(20,3): error CS1061: 'Baz' does not contain a definition for '_pipeline'
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("CS0246"));
            Assert.That(result[1].Code, Is.EqualTo("CS1061"));
            Assert.That(result[2].Code, Is.EqualTo("CannotSealType"));
        });
    }

    [Test]
    public void Parse_ApiCompat_UnknownRule_FallsBackToApiCompat()
    {
        var output = @"C:\nuget\ApiCompat.targets(82,5): error : SomeNewRule : Something unexpected happened. [C:\src\p.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Code, Is.EqualTo("ApiCompat"));
    }

    [Test]
    public void Parse_ApiCompat_DuplicateErrors_Deduplicated()
    {
        var output = """
            C:\nuget\ApiCompat.targets(82,5): error : CannotSealType : Type 'Foo' is effectively sealed. [C:\src\p.csproj::TargetFramework=netstandard2.0]
            C:\nuget\ApiCompat.targets(82,5): error : CannotSealType : Type 'Foo' is effectively sealed. [C:\src\p.csproj::TargetFramework=net8.0]
            """;
        var result = BuildOutputParser.Parse(output);

        // Same file, line, code, and message — should be deduplicated
        Assert.That(result, Has.Count.EqualTo(1));
    }

    // --- File-level error tests (no line/col) ---

    [Test]
    public void Parse_NuGetFileLevelError_IsParsed()
    {
        var output = @"C:\src\project.csproj : error NU1100: Unable to resolve 'Some.Package (>= 1.0.0)' for 'net8.0'. [C:\src\project.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].FilePath, Is.EqualTo(@"C:\src\project.csproj"));
            Assert.That(result[0].Code, Is.EqualTo("NU1100"));
            Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
            Assert.That(result[0].Message, Does.Contain("Unable to resolve"));
            Assert.That(result[0].Line, Is.EqualTo(0));
            Assert.That(result[0].Column, Is.EqualTo(0));
            Assert.That(result[0].Severity, Is.EqualTo("error"));
        });
    }

    [Test]
    public void Parse_MSBuildPrefixedError_IsParsed()
    {
        var output = "MSBUILD : error MSB1009: Project file does not exist.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].FilePath, Is.EqualTo("MSBUILD"));
            Assert.That(result[0].Code, Is.EqualTo("MSB1009"));
            Assert.That(result[0].Message, Is.EqualTo("Project file does not exist."));
            Assert.That(result[0].Line, Is.EqualTo(0));
        });
    }

    [Test]
    public void Parse_FileLevelWarning_IsParsed()
    {
        var output = @"C:\src\project.csproj : warning NU1903: Package 'SomePackage 1.0.0' has a known moderate severity vulnerability.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("NU1903"));
            Assert.That(result[0].Severity, Is.EqualTo("warning"));
            Assert.That(result[0].FilePath, Is.EqualTo(@"C:\src\project.csproj"));
        });
    }

    [Test]
    public void Parse_FileLevelDuplicate_Deduplicated()
    {
        var output = """
            C:\src\project.csproj : error NU1100: Unable to resolve 'Pkg' for 'net8.0'. [C:\src\project.csproj]
            C:\src\project.csproj : error NU1100: Unable to resolve 'Pkg' for 'net8.0'. [C:\src\project.csproj]
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
    }

    // --- Codeless project-level error tests ---

    [Test]
    public void Parse_CodelessProjectLevelError_IsParsed()
    {
        var output = "error : Unable to find package 'Some.Package'. No packages exist with this id in source(s): nuget.org";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("BUILD"));
            Assert.That(result[0].Message, Does.Contain("Unable to find package"));
            Assert.That(result[0].FilePath, Is.Empty);
            Assert.That(result[0].Line, Is.EqualTo(0));
            Assert.That(result[0].Severity, Is.EqualTo("error"));
        });
    }

    [Test]
    public void Parse_IndentedCodelessProjectLevelError_IsParsed()
    {
        var output = "  error : Target 'GenerateCode' failed.";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("BUILD"));
            Assert.That(result[0].Message, Does.Contain("Target 'GenerateCode' failed"));
        });
    }

    [Test]
    public void Parse_CodelessProjectLevelWarning_IsParsed()
    {
        var output = "warning : Some build warning without a code";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Code, Is.EqualTo("BUILD"));
            Assert.That(result[0].Severity, Is.EqualTo("warning"));
        });
    }

    // --- Project reference stripping for standard errors ---

    [Test]
    public void Parse_StandardErrorWithProjectRef_MessageIsStripped()
    {
        var output = @"C:\src\File.cs(10,5): error CS0246: The type or namespace name 'Foo' could not be found [C:\src\project.csproj]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Message, Does.Not.Contain("["));
            Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
            Assert.That(result[0].Message, Is.EqualTo("The type or namespace name 'Foo' could not be found"));
        });
    }

    [Test]
    public void Parse_NoColErrorWithProjectRef_MessageIsStripped()
    {
        var output = @"C:\src\File.cs(10): error CS1234: Some message [C:\src\project.csproj::TargetFramework=net8.0]";
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
            Assert.That(result[0].Message, Is.EqualTo("Some message"));
        });
    }

    // --- Mixed format tests ---

    [Test]
    public void Parse_MixedAllFormats_AllParsed()
    {
        var output = """
            C:\src\File.cs(10,5): error CS0246: The type 'Foo' could not be found [C:\src\p.csproj]
            C:\src\project.csproj : error NU1100: Unable to resolve 'Pkg'
            MSBUILD : error MSB1009: Project file does not exist.
            error : Unable to find package 'Bar'
            C:\nuget\ApiCompat.targets(82,5): error : CannotSealType : Type 'Baz' is effectively sealed. [C:\src\p.csproj]
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(5));
        var codes = result.Select(e => e.Code).ToList();
        Assert.Multiple(() =>
        {
            Assert.That(codes, Does.Contain("CS0246"));
            Assert.That(codes, Does.Contain("NU1100"));
            Assert.That(codes, Does.Contain("MSB1009"));
            Assert.That(codes, Does.Contain("BUILD"));
            Assert.That(codes, Does.Contain("CannotSealType"));
        });
    }

    [Test]
    public void Parse_StandardErrorProjectRefDoesNotAffectDedup()
    {
        // Same error from two target frameworks — should dedup to 1
        var output = """
            C:\src\File.cs(10,5): error CS0246: The type 'Foo' could not be found [C:\src\p.csproj::TargetFramework=netstandard2.0]
            C:\src\File.cs(10,5): error CS0246: The type 'Foo' could not be found [C:\src\p.csproj::TargetFramework=net8.0]
            """;
        var result = BuildOutputParser.Parse(output);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Message, Does.Not.Contain(".csproj"));
    }
}
