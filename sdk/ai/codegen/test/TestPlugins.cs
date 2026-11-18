// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
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
    private static readonly InputDateTimeType s_utcDateTime =
        new(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);

    private static readonly FieldInfo s_generatorInstance =
        typeof(CodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)!;

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
        Assert.That(property.WireInfo!.SerializedName, Is.EqualTo("wire_name"));
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
        var context = (GeneratorContext)Activator.CreateInstance(typeof(GeneratorContext),
            BindingFlags.Instance | BindingFlags.NonPublic, binder: null,
            args: [new Configuration(AppContext.BaseDirectory, [], "TestLibrary", false, default, null)], culture: null)!;
        var generator = new TestGenerator(context, new SourceInputModel(null, lastContract));
        var previousInstance = s_generatorInstance.GetValue(null);
        s_generatorInstance.SetValue(null, generator);
        try
        {
            var pluginType = typeof(ExperimentalAttributeVisitor).Assembly.GetTypes().Single(t => t.IsSubclassOf(typeof(GeneratorPlugin)));
            ((GeneratorPlugin)Activator.CreateInstance(pluginType)!).Apply(generator);

            var input = new InputModelProperty(name, null, null, type, isRequired: true, isReadOnly: false, access: null,
                isDiscriminator: false, serializedName: "wire_name", isHttpMetadata: false, isApiVersion: false,
                defaultValue: null, serializationOptions: new InputSerializationOptions());
            var model = new InputModelType(modelName, "TestLibrary", $"TestLibrary.{modelName}", access: null,
                deprecation: null, summary: null, doc: null, usage: InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                properties: [input], baseModel: null, derivedModels: [], discriminatorValue: null, discriminatorProperty: null,
                discriminatedSubtypes: new Dictionary<string, InputModelType>(), additionalProperties: null, modelAsStruct: false,
                serializationOptions: new InputSerializationOptions(), isDynamicModel: false);
            return generator.TypeFactory.CreateProperty(input, new ModelProvider(model))!;
        }
        finally
        {
            s_generatorInstance.SetValue(null, previousInstance);
        }
    }

    private sealed class TestGenerator(GeneratorContext context, SourceInputModel sourceInputModel) : CodeModelGenerator(context)
    {
        public override InputLibrary InputLibrary { get; } = new EmptyInputLibrary();
        public override SourceInputModel SourceInputModel => sourceInputModel;
    }

    private sealed class EmptyInputLibrary : InputLibrary
    {
        public override InputNamespace InputNamespace { get; } = new("TestLibrary", [], [], [], [], [], null);
    }
}
