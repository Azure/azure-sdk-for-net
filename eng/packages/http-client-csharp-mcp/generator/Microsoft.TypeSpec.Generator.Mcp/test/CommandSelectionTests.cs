// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class CommandSelectionTests
{
    private static CommandSelection Selection => new(
        "Example.Resource.get", "Example", "get", "12b53c92-f2cf-4a1a-880d-c6f44a0d49d6",
        "example resource get", "Get resource", new(), "Resource");

    [Test]
    public void GeneratedNamesAndOptionalCustomizationsDoNotRequireAHandler()
    {
        Assert.That(Selection.CommandType, Is.EqualTo("Example.ResourceGetCommand"));
        Assert.That(Selection.ServiceName, Is.EqualTo("ResourceGetService"));
        Assert.That(Selection.HandlerName, Is.EqualTo("GetResource"));
        Assert.That(CommandModel.FindCustomization(Selection, Compile("")), Is.Null);
        Assert.That(CommandModel.FindCustomization(Selection,
            Compile("public interface IService { void GetResource(); }")), Is.Null,
            "A prewritten handler must not determine the generated contract.");
    }

    [Test]
    public void StandaloneOperationsDeriveTheirOwnNames()
    {
        var selection = Selection with { InterfaceName = null, Name = "getResource", OperationId = "Example.getResource" };
        Assert.That(selection.ServiceName, Is.EqualTo("GetResourceService"));
        Assert.That(selection.HandlerName, Is.EqualTo("GetResource"));
    }

    [TestCase("public static readonly string Description = \"Not a constant\";", "string constant")]
    [TestCase("private const string Description = \"Inaccessible\";", "string constant")]
    [TestCase("public const string? Description = null;", "string constant")]
    [TestCase("public static string GetErrorMessage(string error) => error;", "accepting Exception")]
    [TestCase("private static string GetErrorMessage(Exception error) => error.Message;", "accepting Exception")]
    [TestCase("public static string GetErrorMessage(ref Exception error) => error.Message;", "accepting Exception")]
    public void OptionalCustomizationsMustResolveToTypedAccessibleMembers(string source, string message)
    {
        Assert.That(() => CommandModel.FindCustomization(Selection,
            Compile("public static class ResourceGetCustomization { " + source + " }")),
            Throws.InvalidOperationException.With.Message.Contains(message));
    }

    [Test]
    public void TypedCustomizationsAreDiscoveredWithoutAnExistingService()
    {
        var type = CommandModel.FindCustomization(Selection, Compile("""
            internal static class ResourceGetCustomization
            {
                internal const string Description = "Reviewed description.";
                internal const string DefaultErrorMessage = "Request failed (HTTP {0}): {1}";
                internal static string? GetErrorMessage(Exception exception) => null;
            }
            """));
        Assert.That(type?.ToDisplayString(), Is.EqualTo("Example.ResourceGetCustomization"));
    }

    [Test]
    public void DuplicateAndInvalidCustomizationClassesFailInsteadOfChoosingOne()
    {
        Assert.That(() => CommandModel.FindCustomization(Selection, Compile("public class ResourceGetCustomization {}")),
            Throws.InvalidOperationException.With.Message.Contains("static classes"));
        Assert.That(() => CommandModel.FindCustomization(Selection, Compile(
            "public static class ResourceGetCustomization {} namespace Nested { public static class ResourceGetCustomization {} }")),
            Throws.InvalidOperationException.With.Message.Contains("must be unique"));
    }

    [Test]
    public void InvalidDefaultErrorFormatIsRejected()
    {
        Assert.Throws<FormatException>(() => CommandModel.FindCustomization(Selection,
            Compile("public static class ResourceGetCustomization { public const string DefaultErrorMessage = \"{invalid\"; }")));
    }

    private static CSharpCompilation Compile(string source)
    {
        var references = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator)
            .Select(path => MetadataReference.CreateFromFile(path));
        return CSharpCompilation.Create("CustomizationTests",
            [CSharpSyntaxTree.ParseText("#nullable enable\nusing System;\nnamespace Example {\n" + source + "\n}")],
            references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}
