// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers.Perf
{
    /// <summary>
    /// Measures wall-clock time for running analyzers against a compilation.
    /// This is the standard way to benchmark Roslyn analyzers — it captures the
    /// end-to-end cost of registering, walking the tree, and reporting diagnostics.
    /// </summary>
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Throughput, warmupCount: 3, iterationCount: 10)]
    public class AnalyzerBenchmark
    {
        private Compilation _smallCompilation;
        private Compilation _largeCompilation;
        private ImmutableArray<DiagnosticAnalyzer> _asyncAnalyzers;
        private ImmutableArray<DiagnosticAnalyzer> _taskCompletionSourceAnalyzers;
        private ImmutableArray<DiagnosticAnalyzer> _requestContextAnalyzers;
        private CompilationWithAnalyzersOptions _options;

        [GlobalSetup]
        public void Setup()
        {
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Task).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(CancellationToken).Assembly.Location),
            };

            // Try to add System.Runtime for newer TFMs
            var runtimeAssembly = typeof(object).Assembly.GetReferencedAssemblies()
                .FirstOrDefault(a => a.Name == "System.Runtime");
            var refList = references.ToList();
            if (runtimeAssembly != null)
            {
                try
                {
                    refList.Add(MetadataReference.CreateFromFile(
                        System.Reflection.Assembly.Load(runtimeAssembly).Location));
                }
                catch { }
            }

            _smallCompilation = CSharpCompilation.Create("SmallBench",
                new[] { CSharpSyntaxTree.ParseText(SmallSource) },
                refList,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            _largeCompilation = CSharpCompilation.Create("LargeBench",
                new[] { CSharpSyntaxTree.ParseText(LargeSource) },
                refList,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            _asyncAnalyzers = ImmutableArray.Create<DiagnosticAnalyzer>(new AsyncPatternAnalyzer());
            _taskCompletionSourceAnalyzers = ImmutableArray.Create<DiagnosticAnalyzer>(new TaskCompletionSourceAnalyzer());
            _requestContextAnalyzers = ImmutableArray.Create<DiagnosticAnalyzer>(new RequestContextCancellationTokenAnalyzer());

            _options = new CompilationWithAnalyzersOptions(
                options: null,
                onAnalyzerException: null,
                concurrentAnalysis: false,  // Single-threaded for stable measurements
                logAnalyzerExecutionTime: false);
        }

        [Benchmark(Description = "AsyncPatternAnalyzer - small (1 method)")]
        public async Task<ImmutableArray<Diagnostic>> AsyncPattern_Small()
        {
            var cwa = new CompilationWithAnalyzers(_smallCompilation, _asyncAnalyzers, _options);
            return await cwa.GetAnalyzerDiagnosticsAsync();
        }

        [Benchmark(Description = "AsyncPatternAnalyzer - large (20 methods)")]
        public async Task<ImmutableArray<Diagnostic>> AsyncPattern_Large()
        {
            var cwa = new CompilationWithAnalyzers(_largeCompilation, _asyncAnalyzers, _options);
            return await cwa.GetAnalyzerDiagnosticsAsync();
        }

        [Benchmark(Description = "TaskCompletionSourceAnalyzer - large")]
        public async Task<ImmutableArray<Diagnostic>> TaskCompletionSource_Large()
        {
            var cwa = new CompilationWithAnalyzers(_largeCompilation, _taskCompletionSourceAnalyzers, _options);
            return await cwa.GetAnalyzerDiagnosticsAsync();
        }

        [Benchmark(Description = "RequestContextAnalyzer - large")]
        public async Task<ImmutableArray<Diagnostic>> RequestContext_Large()
        {
            var cwa = new CompilationWithAnalyzers(_largeCompilation, _requestContextAnalyzers, _options);
            return await cwa.GetAnalyzerDiagnosticsAsync();
        }

        // A single method with an async pattern — minimal workload
        private const string SmallSource = @"
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample
{
    public static class TaskExtensions
    {
        public static T EnsureCompleted<T>(this Task<T> task) => task.GetAwaiter().GetResult();
        public static void EnsureCompleted(this Task task) => task.GetAwaiter().GetResult();
    }

    public class SmallClient
    {
        internal async Task<int> MethodAsync(bool async)
        {
            if (async)
            {
                return await Task.FromResult(42).ConfigureAwait(false);
            }
            else
            {
                return Task.FromResult(42).EnsureCompleted();
            }
        }
    }
}
";

        // 20 methods with varying async patterns — realistic workload
        private static readonly string LargeSource = BuildLargeSource();

        private static string BuildLargeSource()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample
{
    public static class TaskExtensions
    {
        public static T EnsureCompleted<T>(this Task<T> task) => task.GetAwaiter().GetResult();
        public static void EnsureCompleted(this Task task) => task.GetAwaiter().GetResult();
    }

    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class TaskCompletionSourceUser
    {
        private TaskCompletionSource<int> _tcs1 = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        private TaskCompletionSource<string> _tcs2 = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
    }

    public class LargeClient
    {
        public async Task<int> ProtocolAsync(string content, RequestContext context = null) => 0;");

            for (int i = 0; i < 20; i++)
            {
                sb.AppendLine($@"
        internal async Task<int> Method{i}Async(bool async)
        {{
            if (async)
            {{
                var result = await Task.FromResult({i}).ConfigureAwait(false);
                var result2 = await Task.FromResult(result + 1).ConfigureAwait(false);
                return result2;
            }}
            else
            {{
                var result = Task.FromResult({i}).EnsureCompleted();
                return Task.FromResult(result + 1).EnsureCompleted();
            }}
        }}

        public async Task Caller{i}Async(CancellationToken cancellationToken)
        {{
            await ProtocolAsync(""data"", new RequestContext {{ CancellationToken = cancellationToken }});
        }}");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
