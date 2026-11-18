// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.Composition.Hosting;
using System.Runtime.CompilerServices;
using Extensions.Plugin.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using NUnit.Framework;

namespace Test.Extensions.Plugin;

[NonParallelizable]
public class TestPlugins
{
    private const string TestNamespace = "TestLibrary";
    private const string WireName = "wire_name";

    private static readonly InputDateTimeType s_utcDateTime =
        new(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);

    private static IEnumerable<TestCaseData> DatePropertyCases()
    {
        yield return new TestCaseData("createdAt", s_utcDateTime, "Widget", "CreatedAt", "createdAt");
        yield return new TestCaseData("ip_start_at", new InputNullableType(s_utcDateTime), "Widget", "IPStartAt", "ipStartAt");
        yield return new TestCaseData("expiresAt", InputPrimitiveType.PlainDate, "Widget", "ExpiresAt", "expiresAt");
        yield return new TestCaseData("createdAt", s_utcDateTime, "CreatedAt", "CreatedOn", "createdOn");
        yield return new TestCaseData("createdAt", s_utcDateTime, "CreatedOn", "CreatedOnProperty", "createdOnProperty");
        yield return new TestCaseData("updatedOn", s_utcDateTime, "Widget", "UpdatedOn", "updatedOn");
        yield return new TestCaseData("startTime", s_utcDateTime, "Widget", "StartsOn", "startsOn");
        yield return new TestCaseData("lastAt", s_utcDateTime, "Widget", "LastAt", "lastAt");
        yield return new TestCaseData("createdAt", InputPrimitiveType.String, "Widget", "CreatedAt", "createdAt");
    }

    [TestCaseSource(nameof(DatePropertyCases))]
    public void PreservesAtForDateProperties(string inputName, InputType inputType, string modelName, string propertyName, string parameterName)
    {
        var property = CreateProperty(inputName, inputType, modelName);

        Assert.That(property.Name, Is.EqualTo(propertyName));
        Assert.That(property.AsParameter.Name, Is.EqualTo(parameterName));
        Assert.That(property.WireInfo!.SerializedName, Is.EqualTo(WireName));
    }

    [Test]
    public void PreservesPublishedOnProperty()
    {
        var lastContract = CSharpCompilation.Create("PreviousContract",
            [CSharpSyntaxTree.ParseText("namespace TestLibrary; public class Widget { public System.DateTimeOffset CreatedOn { get; set; } }")],
            [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)]);

        var property = CreateProperty("createdAt", s_utcDateTime, "Widget", lastContract);

        Assert.That(property.Name, Is.EqualTo("CreatedOn"));
    }

    private static PropertyProvider CreateProperty(string name, InputType type, string modelName, Compilation? lastContract = null)
    {
        var input = InputFactory.Property(name, type, isRequired: true, wireName: WireName);
        var model = InputFactory.Model(modelName, clientNamespace: TestNamespace, properties: [input]);
        var generator = new TestGenerator(new SourceInputModel(null, lastContract));

        using var catalog = new AssemblyCatalog(typeof(ExperimentalAttributeVisitor).Assembly);
        using var container = new CompositionContainer(catalog);

        ref var instance = ref GetGeneratorInstance(null);
        var previousInstance = instance;
        instance = generator;
        try
        {
            container.GetExportedValue<GeneratorPlugin>()!.Apply(generator);
            return generator.TypeFactory.CreateProperty(input, new ModelProvider(model))!;
        }
        finally
        {
            instance = previousInstance;
        }
    }

    // The generator host normally initializes this singleton when it loads the plugin.
    [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_instance")]
    private static extern ref CodeModelGenerator? GetGeneratorInstance(CodeModelGenerator? _);

    private sealed class TestGenerator(SourceInputModel sourceInputModel) : CodeModelGenerator
    {
        public override InputLibrary InputLibrary { get; } = new EmptyInputLibrary();
        public override TypeFactory TypeFactory { get; } = new TestTypeFactory();
        public override SourceInputModel SourceInputModel => sourceInputModel;
    }

    private sealed class TestTypeFactory : TypeFactory;

    private sealed class EmptyInputLibrary : InputLibrary
    {
        public override InputNamespace InputNamespace { get; } = new(TestNamespace, [], [], [], [], [], null);
    }
}
