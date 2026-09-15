// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Extensions.Plugin.Visitors;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.SourceInput;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;

namespace Test.Extensions.Plugin;

public class ExperimentalImplementationTests
{
    private CodeModelGenerator? _previousGenerator;

    [SetUp]
    public void Setup()
    {
        FieldInfo instance = typeof(CodeModelGenerator).GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static)!;
        _previousGenerator = (CodeModelGenerator?)instance.GetValue(null);
        instance.SetValue(null, new TestGenerator());
    }

    [TearDown]
    public void TearDown() =>
        typeof(CodeModelGenerator).GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static)!.SetValue(null, _previousGenerator);

    [Test]
    public void StableConstructorOptsInOnlyWhenAssigningExperimentalProperty()
    {
        TestModel model = new();
        PropertyProvider preview = Property(model, "Preview", experimental: true);
        PropertyProvider stable = Property(model, "Stable", experimental: false);
        ConstructorProvider previewConstructor = Constructor(model, preview);
        ConstructorProvider stableConstructor = Constructor(model, stable);
        stableConstructor.Signature.Update(parameters: [new ParameterProvider("stable", $"A stable value.", typeof(bool))]);
        model.Update(properties: [preview, stable], constructors: [previewConstructor, stableConstructor]);

        new TestVisitor().Apply(model);
        new TestVisitor().Apply(model);

        Assert.That(Codes(previewConstructor.Suppressions), Is.EqualTo(new[] { "AAIP001" }));
        Assert.That(stableConstructor.Suppressions, Is.Empty);
        Assert.That(previewConstructor.Signature.Attributes, Is.Empty);
        Assert.That(model.Attributes, Is.Empty);
        Assert.That(preview.Attributes, Has.Count.EqualTo(1));
    }

    [Test]
    public void SerializationOptsInLocallyAndPreservesExistingSuppressions()
    {
        TestModel model = new();
        PropertyProvider preview = Property(model, "Preview", experimental: true);
        ConstructorProvider constructor = Constructor(model, preview);
        constructor.Signature.Update(attributes: [Experimental()]);
        TestType serializer = new();
        MethodProvider write = Method(serializer, "JsonModelWriteCore");
        MethodProvider read = Method(serializer, "DeserializeTestModel");
        MethodProvider forward = Method(serializer, "JsonModelCreateCore");
        write.Update(suppressions: [new SuppressionStatement(null, Snippet.Literal("TEST001"), "Existing suppression.")]);
        serializer.Update(methods: [write, read, forward]);
        model.Update(properties: [preview], constructors: [constructor], serializations: [serializer]);

        new TestVisitor().Apply(model);
        new TestVisitor().Apply(model);

        Assert.That(Codes(write.Suppressions), Is.EqualTo(new[] { "TEST001", "AAIP001" }));
        Assert.That(Codes(read.Suppressions), Is.EqualTo(new[] { "AAIP001" }));
        Assert.That(forward.Suppressions, Is.Empty);
        Assert.That(write.Signature.Attributes, Is.Empty);
        Assert.That(read.Signature.Attributes, Is.Empty);
        Assert.That(constructor.Suppressions, Is.Empty, "An experimental declaration already opts in its body.");
    }

    [Test]
    public void PropertyOnlyExperimentDoesNotOptInStableDeserializer()
    {
        TestModel model = new();
        PropertyProvider preview = Property(model, "Preview", experimental: true);
        TestType serializer = new();
        MethodProvider read = Method(serializer, "DeserializeTestModel");
        serializer.Update(methods: [read]);
        model.Update(properties: [preview], constructors: [], serializations: [serializer]);

        new TestVisitor().Apply(model);

        Assert.That(read.Suppressions, Is.Empty, "Reading a stable property type and calling a stable constructor need no opt-in.");
    }

    [Test]
    public void ExperimentalTypeNeedsNoImplementationSuppressions()
    {
        TestModel model = new();
        PropertyProvider preview = Property(model, "Preview", experimental: true);
        ConstructorProvider constructor = Constructor(model, preview);
        model.Update(attributes: [Experimental()], properties: [preview], constructors: [constructor]);

        new TestVisitor().Apply(model);

        Assert.That(constructor.Suppressions, Is.Empty);
    }

    [Test]
    public void NonModelContextIsNotInspected()
    {
        new TestVisitor().Apply(new UninspectableType());
    }

    [Test]
    public void OpenAICatalogRetainsIdsForGenericAndNonGenericTypes()
    {
        var compilation = CSharpCompilation.Create("OpenAI", [CSharpSyntaxTree.ParseText("""
            using System.Diagnostics.CodeAnalysis;
            namespace OpenAI.Test
            {
                [Experimental("OPENAI001")]
                public class Preview { }
                [Experimental("OPENAI002")]
                public class Preview<T> { }
            }
            """)], [Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(typeof(object).Assembly.Location)]);
        Type catalogType = typeof(ExperimentalImplementationVisitor).Assembly.GetType("Extensions.Plugin.OpenAIExperimentalCatalog")!;
        var diagnostics = new Dictionary<string, HashSet<string>>();
        MethodInfo collect = catalogType.GetMethod("CollectExperimentalTypes", BindingFlags.NonPublic | BindingFlags.Static,
            [typeof(Microsoft.CodeAnalysis.INamespaceSymbol), diagnostics.GetType()])!;
        collect.Invoke(null, [compilation.Assembly.GlobalNamespace, diagnostics]);

        Assert.That(diagnostics["OpenAI.Test.Preview"], Is.EquivalentTo(new[] { "OPENAI001", "OPENAI002" }));
    }

    private static AttributeStatement Experimental() => new(typeof(ExperimentalAttribute), Snippet.Literal("AAIP001"));

    private static PropertyProvider Property(TypeProvider model, string name, bool experimental) =>
        new(null, MethodSignatureModifiers.Public, typeof(string), name, new AutoPropertyBody(true), model,
            attributes: experimental ? [Experimental()] : []);

    private static ConstructorProvider Constructor(TypeProvider model, PropertyProvider property) =>
        new(new ConstructorSignature(model.Type, null, MethodSignatureModifiers.Public, []),
            new MethodBodyStatements([new AssignmentExpression(new MemberExpression(null, property.Name), Snippet.Literal("test")).Terminate()]), model);

    private static MethodProvider Method(TypeProvider type, string name) =>
        new(new MethodSignature(name, null, MethodSignatureModifiers.Internal, null, null, []),
            new MethodBodyStatements([]), type);

    private static string[] Codes(IReadOnlyList<SuppressionStatement> suppressions) =>
        suppressions.Select(suppression => (string)((LiteralExpression)((ScopedApi)suppression.Code).Original).Literal!).ToArray();

    private sealed class TestVisitor : ExperimentalImplementationVisitor
    {
        public TypeProvider Apply(TypeProvider type) => VisitType(type);
    }

    private sealed class TestGenerator : CodeModelGenerator
    {
        private readonly SourceInputModel _sourceInputModel = new(CSharpCompilation.Create("Customizations"), null);
        public override SourceInputModel SourceInputModel => _sourceInputModel;
    }

    private sealed class TestModel : ModelProvider
    {
        public TestModel() : base(new InputModelType("TestModel", "Tests", "Tests.TestModel", "public", null, null, null,
            InputModelTypeUsage.Input | InputModelTypeUsage.Output, [], null, [], null, null, new Dictionary<string, InputModelType>(), null, false, new InputSerializationOptions(null, null, null, null), false))
        {
            Update(properties: [], constructors: [], methods: [], serializations: [], attributes: []);
        }

        protected override string BuildName() => "TestModel";
        protected override string BuildNamespace() => "Tests";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Public | TypeSignatureModifiers.Class;
        protected override CSharpType BuildBaseType() => null!;
    }

    private class TestType : TypeProvider
    {
        protected override string BuildName() => "TestSerializer";
        protected override string BuildNamespace() => "Tests";
        protected override string BuildRelativeFilePath() => "TestSerializer.cs";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;
    }

    private sealed class UninspectableType : TestType
    {
        protected override IReadOnlyList<MethodBodyStatement> BuildAttributes() =>
            throw new InvalidOperationException("A non-model's attributes must not be inspected.");
    }
}
