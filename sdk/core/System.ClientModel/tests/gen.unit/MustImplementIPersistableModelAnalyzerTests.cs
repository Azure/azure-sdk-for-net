// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class MustImplementIPersistableModelAnalyzerTests
    {
        [Test]
        public async Task TypeWithoutIPersistableModelShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel.Id,
                diagnostics[0].Id);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("Foo"));
        }

        [Test]
        public async Task TypeWithIPersistableModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo : IPersistableModel<Foo>
    {
        public Foo Create(BinaryData data, ModelReaderWriterOptions options) => new Foo();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task TypeWithIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ListOfFooWhereFooDoesNotImplementShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<Foo>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel.Id,
                diagnostics[0].Id);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("Foo"));
        }

        [Test]
        public async Task ListOfFooWhereFooImplementsShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<Foo>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo : IPersistableModel<Foo>
    {
        public Foo Create(BinaryData data, ModelReaderWriterOptions options) => new Foo();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task DictionaryOfStringToFooWhereFooDoesNotImplementShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Dictionary<string, Foo>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("Foo"));
        }

        [Test]
        public async Task DictionaryOfStringToFooWhereFooImplementsShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Dictionary<string, Foo>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo : IPersistableModel<Foo>
    {
        public Foo Create(BinaryData data, ModelReaderWriterOptions options) => new Foo();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task NestedCollectionsShouldReportIfInnermostDoesNotImplement()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<Dictionary<string, Foo[]>>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("Foo"));
        }

        [Test]
        public async Task NestedCollectionsShouldNotReportIfInnermostImplements()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<Dictionary<string, Foo[]>>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo : IPersistableModel<Foo>
    {
        public Foo Create(BinaryData data, ModelReaderWriterOptions options) => new Foo();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ArrayOfFooWhereFooDoesNotImplementShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo[]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("Foo"));
        }

        [Test]
        public async Task ArrayOfFooWhereFooImplementsShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo[]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo : IPersistableModel<Foo>
    {
        public Foo Create(BinaryData data, ModelReaderWriterOptions options) => new Foo();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ListOfIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<MyModel>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task DictionaryOfStringToIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Dictionary<string, MyModel>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ArrayOfIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel[]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task NestedCollectionsWithIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(List<Dictionary<string, MyModel[]>>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task JaggedArrayOfIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel[][]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task JaggedArrayOfNonPersistableShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel[][]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("MyModel"));
        }

        [Test]
        public async Task MultidimensionalArrayOfIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel[,]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task MultidimensionalArrayOfNonPersistableShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel[,]))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("MyModel"));
        }

        [Test]
        public async Task ReadOnlyMemoryOfIJsonModelShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(ReadOnlyMemory<MyModel>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel : IJsonModel<MyModel>
    {
        public MyModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyModel();
        public MyModel Create(BinaryData data, ModelReaderWriterOptions options) => new MyModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ReadOnlyMemoryOfNonPersistableShouldReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(ReadOnlyMemory<MyModel>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("MyModel"));
        }

        [Test]
        public async Task NonPersistableModelFromDependencyShouldReport()
        {
            string depSource =
$$"""
namespace DepNamespace
{
    public class DepModel { }
}
""";
            var depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "DepAssembly");

            string source =
$$"""
using System.ClientModel.Primitives;
using DepNamespace;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(DepModel))]
    public partial class LocalContext : ModelReaderWriterContext { }
}
""";
            var compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [depCompilation.ToMetadataReference()]);

            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task PersistableModelFromDependencyShouldNotReport()
        {
            string depSource =
$$"""
using System;
using System.ClientModel.Primitives;
namespace DepNamespace
{
    public class DepModel : IPersistableModel<DepModel>
    {
        public DepModel Create(BinaryData data, ModelReaderWriterOptions options) => new DepModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            var depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "DepAssembly");

            string source =
$$"""
using System.ClientModel.Primitives;
using DepNamespace;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(DepModel))]
    public partial class LocalContext : ModelReaderWriterContext { }
}
""";
            var compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [depCompilation.ToMetadataReference()]);

            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task UnboundGenericTypeShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo<T> { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ClosedGenericNonPersistableShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<int>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo<T> { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task ClosedGenericPersistableShouldNotReport()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<int>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo<T> : IPersistableModel<Foo<T>>
    {
        public Foo<T> Create(BinaryData data, ModelReaderWriterOptions options) => default!;
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task StructWithoutIPersistableModelShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyStruct))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public struct MyStruct { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task MultipleAttributesMixedShouldReportOnlyBadOnes()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(GoodModel))]
    [ModelReaderWriterBuildable(typeof(BadModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class GoodModel : IPersistableModel<GoodModel>
    {
        public GoodModel Create(BinaryData data, ModelReaderWriterOptions options) => new GoodModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    public class BadModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MustImplementIPersistableModelAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("BadModel"));
        }
    }
}
