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
    public void NamesTypesAndRequirednessComeFromServiceAndSourceConventions()
    {
        var signature = CommandModel.InferHandler(Selection, Compile("""
            public interface IService
            {
                /// <param name="name">Resource name.</param>
                /// <param name="limit">Optional limit.</param>
                Task<Model> GetResourceAsync(string name,int? limit=null,CancellationToken cancellationToken=default);
            }
            """));
        Assert.That(Selection.CommandType, Is.EqualTo("Example.ResourceGetCommand"));
        Assert.That(signature.Method.ContainingType.ToDisplayString(), Is.EqualTo("Example.IService"));
        Assert.That(signature.Result.ToDisplayString(), Is.EqualTo("Example.Model"));
        Assert.That(signature.Options.Select(option => (option.Name, option.Type, option.Required)),
            Is.EqualTo(new[] { ("Name", "string", true), ("Limit", "int", false) }));
        Assert.That(signature.Options.Select(option => option.Description), Is.EqualTo(new[] { "Resource name.", "Optional limit." }));
    }

    [Test]
    public void StandaloneOperationsAndAsyncSuffixDoNotRequireTypeNames()
    {
        var selection = Selection with { InterfaceName = null, Name = "getResource", OperationId = "Example.getResource" };
        var signature = CommandModel.InferHandler(selection,
            Compile("public interface IService { Task<Model> GetResource(CancellationToken token); }"));
        Assert.That(selection.CommandType, Is.EqualTo("Example.GetResourceCommand"));
        Assert.That(signature.Method.Name, Is.EqualTo("GetResource"));
    }

    [TestCase("public class IService { }", "exactly one")]
    [TestCase("public interface IService { Task<Model> Other(CancellationToken token); }", "found 0")]
    [TestCase("public interface IService<T> { Task<Model> GetResourceAsync(CancellationToken token); }", "exactly one")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(string name); }", "CancellationToken")]
    [TestCase("public interface IService { Model GetResourceAsync(CancellationToken token); }", "return Task<T>")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(CancellationToken first,CancellationToken last); }", "exactly one CancellationToken")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(CancellationToken token,string name); }", "final parameter")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(string name,CancellationToken token); Task<Model> GetResourceAsync(int name,CancellationToken token); }", "exactly one")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync<T>(CancellationToken token); }", "exactly one")]
    [TestCase("public interface IService { Task<Model[]> GetResourceAsync(CancellationToken token); }", "nongeneric result model")]
    [TestCase("public interface IService { Task<Model?> GetResourceAsync(CancellationToken token); }", "nonnullable")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(Model model,CancellationToken token); }", "only primitive")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(ref string name,CancellationToken token); }", "By-reference")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(string name=\"default\",CancellationToken token=default); }", "Unsupported default")]
    [TestCase("public interface IService { Task<Model> GetResourceAsync(string name,CancellationToken token); }", "needs XML documentation")]
    [TestCase("public interface IFirst { Task<Model> GetResourceAsync(CancellationToken token); } public interface ISecond { Task<Model> GetResourceAsync(CancellationToken token); }", "found 2")]
    [TestCase("public interface IService { Task<Model> GetResource(CancellationToken token); Task<Model> GetResourceAsync(CancellationToken token); }", "found 2")]
    public void UnsupportedOrAmbiguousHandlerMappingsAreRejected(string source, string message)
    {
        Assert.That(() => CommandModel.InferHandler(Selection, Compile(source)),
            Throws.InvalidOperationException.With.Message.Contains(message));
    }

    [TestCase("public static readonly string Description = \"Not a constant\";", "string constant")]
    [TestCase("private const string Description = \"Inaccessible\";", "string constant")]
    [TestCase("public const string? Description = null;", "string constant")]
    [TestCase("public static string GetErrorMessage(string error) => error;", "accepting Exception")]
    [TestCase("private static string GetErrorMessage(Exception error) => error.Message;", "accepting Exception")]
    [TestCase("public static string GetErrorMessage(ref Exception error) => error.Message;", "accepting Exception")]
    public void ConventionalCustomizationsMustResolveToTypedAccessibleMembers(string source, string message)
    {
        var compilation = Compile(
            "public interface IService { Task<Model> GetResourceAsync(CancellationToken token); } " +
            "public static class ResourceGetCustomization { " + source + " }");
        Assert.That(() => CommandModel.InferHandler(Selection, compilation),
            Throws.InvalidOperationException.With.Message.Contains(message));
    }

    [TestCase("internal const string NameDescription = \"Resource name.\";", true)]
    [TestCase("public static readonly string NameDescription = \"Not a constant\";", false)]
    [TestCase("public const int NameDescription = 1;", false)]
    [TestCase("private const string NameDescription = \"Inaccessible\";", false)]
    public void OptionDescriptionMembersAreDiscoveredAndTypeChecked(string source, bool valid)
    {
        var compilation = Compile(
            "public interface IService { Task<Model> GetResourceAsync(string name,CancellationToken token); } " +
            "public static class ResourceGetCustomization { " + source + " }");
        if (valid)
        {
            Assert.That(CommandModel.InferHandler(Selection, compilation).Options.Single().DescriptionMember,
                Is.EqualTo(new StaticMember("Example.ResourceGetCustomization", "NameDescription")));
        }
        else
        {
            Assert.That(() => CommandModel.InferHandler(Selection, compilation),
                Throws.InvalidOperationException.With.Message.Contains("string constant"));
        }
    }

    [Test]
    public void DuplicateAndInvalidCustomizationClassesFailInsteadOfChoosingOne()
    {
        const string handler = "public interface IService { Task<Model> GetResourceAsync(CancellationToken token); } ";
        Assert.That(() => CommandModel.InferHandler(Selection, Compile(handler + "public class ResourceGetCustomization {}")),
            Throws.InvalidOperationException.With.Message.Contains("static classes"));
        Assert.That(() => CommandModel.InferHandler(Selection, Compile(handler +
            "public static class ResourceGetCustomization {} namespace Nested { public static class ResourceGetCustomization {} }")),
            Throws.InvalidOperationException.With.Message.Contains("must be unique"));
    }

    [Test]
    public void InvalidDefaultErrorFormatIsRejected()
    {
        var compilation = Compile(
            "public interface IService { Task<Model> GetResourceAsync(CancellationToken token); } " +
            "public static class ResourceGetCustomization { public const string DefaultErrorMessage = \"{invalid\"; }");
        Assert.Throws<FormatException>(() => CommandModel.InferHandler(Selection, compilation));
    }

    private static CSharpCompilation Compile(string source)
    {
        var references = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator)
            .Select(path => MetadataReference.CreateFromFile(path));
        return CSharpCompilation.Create("HandlerTests",
            [CSharpSyntaxTree.ParseText("""
                #nullable enable
                using System;
                using System.Threading;
                using System.Threading.Tasks;
                namespace Example
                {
                public sealed class Model {}
                """ + "\n" + source + "\n}", new CSharpParseOptions(documentationMode: DocumentationMode.Diagnose))],
            references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}
