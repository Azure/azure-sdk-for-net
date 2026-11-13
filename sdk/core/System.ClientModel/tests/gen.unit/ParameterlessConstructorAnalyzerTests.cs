// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ParameterlessConstructorAnalyzerTests
    {
        [TestCase("private", true)]
        [TestCase("protected", true)]
        [TestCase("public", false)]
        [TestCase("internal", false)]
        [TestCase("private protected", true)]
        [TestCase("protected internal", false)]
        public async Task PersistableModelCtorAccessibility(string modifier, bool expectDiagnostic)
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(PersistableModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class PersistableModel
    {
        {{modifier}} PersistableModel() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            if (expectDiagnostic)
            {
                Assert.AreEqual(1, diagnostics.Length);
                Assert.AreEqual(
                    ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor.Id,
                    diagnostics[0].Id);
            }
            else
            {
                Assert.AreEqual(0, diagnostics.Length);
            }
        }

        [Test]
        public async Task AbstractTypeShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(PersistableModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public abstract class PersistableModel
    {
        protected PersistableModel() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task DoesNotReportForBadDependencyType()
        {
            string depSource =
$$"""
namespace DepNamespace
{
    public class DepModel
    {
        public DepModel(int x) { }
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

            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task DoesNotReportForGoodDependencyType()
        {
            string depSource =
$$"""
using System.ClientModel.Primitives;

namespace DepNamespace
{
    [ModelReaderWriterBuildable(typeof(DepModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class DepModel
    {
        internal DepModel() { }
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

            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ProxyTypeWithoutParameterlessCtorShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    [PersistableModelProxy(typeof(MyProxy))]
    public class MyModel { }

    public class MyProxy
    {
        public MyProxy(int x) { }
    }
}
""";
            var compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor.Id,
                diagnostics[0].Id);
            Assert.IsTrue(diagnostics[0].GetMessage().Contains("MyProxy"));
        }

        [Test]
        public async Task ProxyTypeWithParameterlessCtorShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    [PersistableModelProxy(typeof(MyProxy))]
    public class MyModel { }

    public class MyProxy
    {
        public MyProxy() { }
    }
}
""";
            var compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
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

    public class Foo<T>
    {
        private Foo() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ClosedGenericWithCtorShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<int>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo<T>
    {
        public Foo() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task ClosedGenericWithoutCtorShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<int>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo<T>
    {
        private Foo() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task StructTypeShouldNotReport()
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
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task SealedClassWithoutCtorShouldReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(SealedModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public sealed class SealedModel
    {
        private SealedModel() { }
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task ImplicitDefaultCtorShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(MyModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new ParameterlessConstructorAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }
    }
}
