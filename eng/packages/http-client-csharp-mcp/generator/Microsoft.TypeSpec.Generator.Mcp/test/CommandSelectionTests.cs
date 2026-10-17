// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class CommandSelectionTests
{
    private static CommandSelection Selection => new(
        "Example.Resources.get", "12b53c92-f2cf-4a1a-880d-c6f44a0d49d6", "example resource get", "Get resource",
        "Example.Commands.ResourceGetCommand", new StaticMember("Example.IService", "GetAsync"), "Resource",
        new SafetyOverrides(null, null, null, false));

    [Test]
    public void HandlerTypesAndRequirednessAreInferredWithoutClrMappings()
    {
        var compilation = Compile("""
            /// <summary>Service workflow.</summary>
            public interface IService
            {
                /// <param name="name">Resource name.</param>
                /// <param name="limit">Optional limit.</param>
                Task<Model> GetAsync(string name,int? limit=null,CancellationToken cancellationToken=default);
            }
            """);
        var signature = CommandModel.InferHandler(Selection, compilation);
        Assert.That(signature.Result.ToDisplayString(), Is.EqualTo("Example.Model"));
        Assert.That(signature.Options.Select(option => (option.Name, option.Type, option.Required)),
            Is.EqualTo(new[] { ("Name", "string", true), ("Limit", "int", false) }));
        Assert.That(signature.Options.Select(option => option.Description), Is.EqualTo(new[] { "Resource name.", "Optional limit." }));
    }

    [TestCase("public class IService {}", "existing nongeneric interface")]
    [TestCase("public interface IService { Task<Model> GetAsync(string name); }", "CancellationToken")]
    [TestCase("public interface IService { Model GetAsync(string name,CancellationToken token); }", "return Task<T>")]
    [TestCase("public interface IService { Task<Model> GetAsync(string name,CancellationToken first,CancellationToken last); }", "exactly one CancellationToken")]
    [TestCase("public interface IService { Task<Model> GetAsync(CancellationToken token,string name); }", "final parameter")]
    [TestCase("public interface IService { Task<Model> GetAsync(string name,CancellationToken token); Task<Model> GetAsync(int name,CancellationToken token); }", "exactly one public instance method")]
    [TestCase("public interface IService { Task<Model> GetAsync<T>(string name,CancellationToken token); }", "exactly one public instance method")]
    [TestCase("public interface IService { Task<Model[]> GetAsync(string name,CancellationToken token); }", "nongeneric result model")]
    [TestCase("public interface IService { Task<Model?> GetAsync(string name,CancellationToken token); }", "nonnullable")]
    [TestCase("public interface IService { Task<Model> GetAsync(Model model,CancellationToken token); }", "only primitive options")]
    [TestCase("public interface IService { Task<Model> GetAsync(ref string name,CancellationToken token); }", "By-reference")]
    [TestCase("public interface IService { Task<Model> GetAsync(string name=\"default\",CancellationToken token=default); }", "Unsupported default")]
    [TestCase("public interface IService { Task<Model> GetAsync(string name,CancellationToken token); }", "needs documentation")]
    public void UnsupportedHandlerMappingsAreRejected(string source, string message)
    {
        var error = Assert.Throws<InvalidOperationException>(() => CommandModel.InferHandler(Selection, Compile(source)));
        Assert.That(error!.Message, Does.Contain(message));
    }

    [Test]
    public void UnmatchedDescriptionOverrideDoesNotBecomeAnExtraOption()
    {
        var selection = Selection with { Options = [new CommandOption("subscription", Description: "Not in the handler.")] };
        Assert.That(() => CommandModel.InferHandler(selection,
            Compile("public interface IService { Task<Model> GetAsync(CancellationToken token); }")),
            Throws.InvalidOperationException.With.Message.Contains("must name a handler parameter"));
    }

    [TestCase("Description", "public static readonly string Description = \"Not a constant\";", "description constant")]
    [TestCase("Description", "private const string Description = \"Inaccessible\";", "description constant")]
    [TestCase("Description", "public const string? Description = null;", "description constant")]
    [TestCase("ErrorPolicy", "public static string GetErrorMessage(string error) => error;", "error-policy method")]
    [TestCase("ErrorPolicy", "private static string GetErrorMessage(Exception error) => error.Message;", "error-policy method")]
    [TestCase("ErrorPolicy", "public static string GetErrorMessage(ref Exception error) => error.Message;", "error-policy method")]
    public void CustomizationsMustResolveToTypedMembers(string kind, string source, string message)
    {
        var selection = kind == "Description"
            ? Selection with { Description = new StaticMember("Example.Customization", "Description") }
            : Selection with { ErrorPolicy = new StaticMember("Example.Customization", "GetErrorMessage") };
        var compilation = Compile(
            "public interface IService { Task<Model> GetAsync(CancellationToken token); } public static class Customization { " + source + " }");
        Assert.That(() => CommandModel.InferHandler(selection, compilation),
            Throws.InvalidOperationException.With.Message.Contains(message));
    }

    [TestCase("internal const string Description = \"Resource name.\";", true)]
    [TestCase("public static readonly string Description = \"Not a constant\";", false)]
    [TestCase("public const int Description = 1;", false)]
    [TestCase("", false)]
    public void OptionDescriptionMembersMustResolveToAccessibleStringConstants(string source, bool valid)
    {
        var selection = Selection with
        {
            Options = [new CommandOption("name", DescriptionMember: new StaticMember("Example.Customization", "Description"))]
        };
        var compilation = Compile(
            "public interface IService { Task<Model> GetAsync(string name,CancellationToken token); } public static class Customization { " + source + " }");
        if (valid)
        {
            Assert.DoesNotThrow(() => CommandModel.InferHandler(selection, compilation));
        }
        else
        {
            Assert.That(() => CommandModel.InferHandler(selection, compilation),
                Throws.InvalidOperationException.With.Message.Contains("description constant"));
        }
    }

    [TestCase("path")]
    [TestCase("type")]
    [TestCase("result")]
    [TestCase("safety")]
    [TestCase("description")]
    public void CompactConfigurationRejectsInvalidIdentities(string change)
    {
        var selection = change switch
        {
            "path" => Selection with { Path = "../bad" },
            "type" => Selection with { CommandType = "Example.NotACommandType" },
            "result" => Selection with { ResultName = "invalid-name" },
            "safety" => Selection with { Safety = null! },
            "description" => Selection with { Options = [new CommandOption("name")] },
            _ => throw new ArgumentException("Unknown test case.", nameof(change))
        };
        Assert.Throws<InvalidOperationException>(selection.Validate);
    }

    [Test]
    public void GeneratedCommandAndLegacyToolCannotClaimTheSameIdentity()
    {
        var original = ManifestFixtures.Create();
        var command = Selection with { Id = original.Operations[0].Id };
        Assert.Throws<InvalidOperationException>(() => (original with { Commands = [command] }).Validate());
    }

    [Test]
    public void CommandOutputCannotOverwriteAnUnrelatedLegacyOutput()
    {
        var original = ManifestFixtures.Create();
        var command = Selection with { CommandType = "Example.Commands.SecretCommand" };
        var tool = original.Operations[0] with { Types = original.Operations[0].Types with { Result = "SecretCommand" } };
        Assert.Throws<InvalidOperationException>(() => (original with { Operations = [tool], Commands = [command] }).Validate());
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
                namespace Example;
                public sealed class Model {}
                """ + "\n" + source, new CSharpParseOptions(documentationMode: DocumentationMode.Diagnose))],
            references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}
