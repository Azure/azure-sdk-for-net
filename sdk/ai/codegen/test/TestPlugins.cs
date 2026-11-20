// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.CompilerServices;
using Extensions.Plugin.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using NUnit.Framework;

namespace Test.Extensions.Plugin;

[NonParallelizable]
public class TestPlugins
{
    private const string TestNamespace = "TestLibrary";
    private const string OperationName = "GetWidgets";
    private const string WireName = "wire_name";

    private static readonly InputDateTimeType s_utcDateTime =
        new(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);

    private static IEnumerable<TestCaseData> DatePropertyCases()
    {
        yield return new TestCaseData("createdAt", s_utcDateTime, "Widget", "CreatedAt", "createdAt");
        yield return new TestCaseData("ip_start_at", new InputNullableType(s_utcDateTime), "Widget", "IPStartsAt", "ipStartsAt");
        yield return new TestCaseData("expiresAt", InputPrimitiveType.PlainDate, "Widget", "ExpiresAt", "expiresAt");
        yield return new TestCaseData("createdAt", s_utcDateTime, "CreatedAt", "CreatedOn", "createdOn");
        yield return new TestCaseData("createdAt", s_utcDateTime, "CreatedOn", "CreatedOnProperty", "createdOnProperty");
        yield return new TestCaseData("updatedOn", s_utcDateTime, "Widget", "UpdatedAt", "updatedAt");
        yield return new TestCaseData("startTime", s_utcDateTime, "Widget", "StartsAt", "startsAt");
        yield return new TestCaseData("startAt", s_utcDateTime, "Widget", "StartsAt", "startsAt");
        yield return new TestCaseData("updatedOn", s_utcDateTime, "UpdatedAt", "UpdatedOn", "updatedOn");
        yield return new TestCaseData("lastAt", s_utcDateTime, "Widget", "LastAt", "lastAt");
        yield return new TestCaseData("updatedOn", InputPrimitiveType.String, "Widget", "UpdatedOn", "updatedOn");
    }

    [TestCaseSource(nameof(DatePropertyCases))]
    public void PreservesAtForDateProperties(string inputName, InputType inputType, string modelName, string propertyName, string parameterName)
    {
        var property = CreateProperty(inputName, inputType, modelName);

        Assert.That(property.Name, Is.EqualTo(propertyName));
        Assert.That(property.AsParameter.Name, Is.EqualTo(parameterName));
        Assert.That(property.WireInfo!.SerializedName, Is.EqualTo(WireName));
    }

    [TestCase("createdAt")]
    [TestCase("createdOn")]
    public void PreservesPublishedOnProperty(string inputName)
    {
        var lastContract = CSharpCompilation.Create("PreviousContract",
            [CSharpSyntaxTree.ParseText("namespace TestLibrary; public class Widget { public System.DateTimeOffset CreatedOn { get; set; } }")],
            [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)]);

        var property = CreateProperty(inputName, s_utcDateTime, "Widget", lastContract);

        Assert.That(property.Name, Is.EqualTo("CreatedOn"));
    }

    [Test]
    public void AvoidsDatePropertyNameCollisionWithASeparateProperty()
    {
        var date = InputFactory.Property("updatedOn", s_utcDateTime, isRequired: true, wireName: WireName);
        var sibling = InputFactory.Property("updated_at", InputPrimitiveType.String, isRequired: true, wireName: "label");
        var model = InputFactory.Model("Widget", TestNamespace, [date, sibling]);
        var generator = new TestGenerator(new SourceInputModel(null, null));

        var names = WithGenerator(generator, () => new ModelProvider(model).Properties.Select(p => p.Name).ToArray());

        Assert.That(names, Is.EqualTo(new[] { "UpdatedOn", "UpdatedAt" }));
    }

    private static IEnumerable<TestCaseData> DateParameterCases()
    {
        yield return new TestCaseData("createdAt", s_utcDateTime, false, "createdAt");
        yield return new TestCaseData("startAt", s_utcDateTime, false, "startsAt");
        yield return new TestCaseData("ipStartAt", new InputNullableType(s_utcDateTime), false, "ipStartsAt");
        yield return new TestCaseData("expiresAt", InputPrimitiveType.PlainDate, false, "expiresAt");
        yield return new TestCaseData("updatedOn", s_utcDateTime, false, "updatedAt");
        yield return new TestCaseData("startTime", s_utcDateTime, false, "startsAt");
        yield return new TestCaseData("fromTime", s_utcDateTime, false, "fromTime");
        yield return new TestCaseData("updatedOn", InputPrimitiveType.String, false, "updatedOn");
        yield return new TestCaseData("Updated_On", s_utcDateTime, true, "Updated_On");
    }

    [TestCaseSource(nameof(DateParameterCases))]
    public void PreservesAtForOperationParameters(string inputName, InputType inputType, bool isExactName, string expectedName)
    {
        WithQueryClient([InputFactory.QueryParameter(inputName, inputType, WireName, isExactName)], client =>
        {
            var methods = client.Methods.OfType<ScmMethodProvider>().ToArray();
            Assert.That(methods, Has.Length.EqualTo(4));
            foreach (var method in methods)
            {
                var parameter = method.Signature.Parameters.Single(p => p.InputParameter != null);
                Assert.That(parameter.Name, Is.EqualTo(expectedName), method.Signature.Name);
                Assert.That(parameter.WireInfo.SerializedName, Is.EqualTo(WireName));
            }
        });
    }

    [Test]
    public void PreservesDateParameterReferencesInRenderedMethods()
    {
        WithQueryClient([
            InputFactory.QueryParameter("filter", InputPrimitiveType.String, "filter"),
            InputFactory.QueryParameter("startTime", s_utcDateTime, WireName)
        ], client =>
        {
            var source = CodeModelGenerator.Instance.GetWriter(client).Write().Content;
            var restSource = CodeModelGenerator.Instance.GetWriter(client.RestClient).Write().Content;

            Assert.That(source, Does.Contain("<param name=\"startsAt\">"));
            Assert.That(source, Does.Contain("GetWidgets(filter: null, startsAt: startsAt,"));
            Assert.That(source, Does.Contain("GetWidgetsAsync(filter: null, startsAt: startsAt,"));
            Assert.That(source, Does.Contain("CreateGetWidgetsRequest(filter, startsAt, options)"));
            Assert.That(restSource, Does.Contain($"\"{WireName}\""));
        }, omitFirstFromConvenience: true, applyTwice: true);
    }

    [TestCase("createdAt")]
    [TestCase("createdOn")]
    public void KeepsPublishedDateParameterName(string inputName)
    {
        var lastContract = CSharpCompilation.Create("PreviousContract",
            [CSharpSyntaxTree.ParseText("""
                namespace TestLibrary;
                public class WidgetClient
                {
                    public System.ClientModel.ClientResult GetWidgets(
                        System.DateTimeOffset? createdOn = default, System.Threading.CancellationToken cancellationToken = default) => null;
                }
                """)],
            [MetadataReference.CreateFromFile(typeof(object).Assembly.Location), MetadataReference.CreateFromFile(typeof(ClientResult).Assembly.Location)]);

        WithQueryClient([InputFactory.QueryParameter(inputName, s_utcDateTime, WireName)], client =>
        {
            var convenience = client.Methods.OfType<ScmMethodProvider>().Single(m =>
                m.Kind == ScmMethodKind.Convenience && m.Signature.Name == OperationName);
            Assert.That(convenience.Signature.Parameters[0].Name, Is.EqualTo("createdOn"));
        }, lastContract);
    }

    [Test]
    public void AvoidsDateParameterNameCollisionWithAnotherDeclaration()
    {
        WithQueryClient([
            InputFactory.QueryParameter("createdOn", s_utcDateTime, WireName),
            InputFactory.QueryParameter("created_at", InputPrimitiveType.String, "marker")
        ], client =>
        {
            var source = CodeModelGenerator.Instance.GetWriter(client).Write().Content;

            Assert.That(source, Does.Contain("CreateGetWidgetsRequest(createdOn, createdAt, options)"));
            Assert.That(source, Does.Contain("<param name=\"createdOn\">"));
            Assert.That(source, Does.Contain("<param name=\"createdAt\">"));
        });
    }

    private static void WithQueryClient(
        InputQueryParameter[] inputs, Action<ClientProvider> assertClient, Compilation? lastContract = null,
        bool omitFirstFromConvenience = false, bool applyTwice = false)
    {
        var sourceInputModel = new SourceInputModel(null, lastContract);
        ref var scmInstance = ref GetScmGeneratorInstance(null);
        var previousScmInstance = scmInstance;
        try
        {
            var generator = new TestScmGenerator(sourceInputModel);
            WithGenerator(generator, () =>
            {
                var method = InputFactory.QueryMethod(OperationName, inputs, omitFirstFromConvenience);
                var client = new InputClient("WidgetClient", TestNamespace, "WidgetClient", null, null, false, [method], [], null, null, null);
                assertClient(generator.TypeFactory.CreateClient(client)!);
                return true;
            }, applyTwice);
        }
        finally
        {
            scmInstance = previousScmInstance;
        }
    }

    private static PropertyProvider CreateProperty(string name, InputType type, string modelName, Compilation? lastContract = null)
    {
        var input = InputFactory.Property(name, type, isRequired: true, wireName: WireName);
        var model = InputFactory.Model(modelName, clientNamespace: TestNamespace, properties: [input]);
        var generator = new TestGenerator(new SourceInputModel(null, lastContract));

        return WithGenerator(generator, () => generator.TypeFactory.CreateProperty(input, new ModelProvider(model))!);
    }

    private static T WithGenerator<T>(CodeModelGenerator generator, Func<T> test, bool applyTwice = false)
    {
        using var catalog = new AssemblyCatalog(typeof(ExperimentalAttributeVisitor).Assembly);
        using var container = new CompositionContainer(catalog);

        ref var instance = ref GetGeneratorInstance(null);
        var previousInstance = instance;
        instance = generator;
        try
        {
            var plugin = container.GetExportedValue<GeneratorPlugin>()!;
            plugin.Apply(generator);
            if (applyTwice)
            {
                plugin.Apply(generator);
            }

            return test();
        }
        finally
        {
            instance = previousInstance;
        }
    }

    // The generator host normally initializes this singleton when it loads the plugin.
    [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_instance")]
    private static extern ref CodeModelGenerator? GetGeneratorInstance(CodeModelGenerator? _);

    [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_instance")]
    private static extern ref ScmCodeModelGenerator? GetScmGeneratorInstance(ScmCodeModelGenerator? _);

    [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
    private static extern GeneratorContext CreateContext(Configuration configuration);

    private sealed class TestScmGenerator(SourceInputModel sourceInputModel)
        : ScmCodeModelGenerator(CreateContext(new Configuration(
            Path.GetTempPath(), [], TestNamespace, disableXmlDocs: false,
            Configuration.UnreferencedTypesHandlingOption.KeepAll, licenseInfo: null)))
    {
        public override InputLibrary InputLibrary { get; } = new EmptyInputLibrary();
        public override SourceInputModel SourceInputModel => sourceInputModel;
    }

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
