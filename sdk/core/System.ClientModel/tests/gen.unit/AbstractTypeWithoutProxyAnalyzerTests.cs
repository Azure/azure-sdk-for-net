// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class AbstractTypeWithoutProxyAnalyzerTests
    {
        [Test]
        public async Task AbstractTypeWithoutProxyShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public abstract class JsonModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task AbstractTypeWithProxyShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    [PersistableModelProxy(typeof(object))]
    public abstract class JsonModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task NonAbstractTypeShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
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

    public abstract class Foo<T> { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task AbstractClosedGenericWithoutProxyShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo<int>))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public abstract class Foo<T> { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task InterfaceTypeShouldNotReport()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(IMyInterface))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public interface IMyInterface { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new AbstractTypeWithoutProxyAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }
    }
}
