// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class TaskCompletionSourceAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Descriptors.AZC0013);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterCompilationStartAction(CompilationStart);
        }

        private void CompilationStart(CompilationStartAnalysisContext context)
        {
            var oca = new ObjectCreationAnalyzer(context.Compilation);
            context.RegisterOperationAction(oca.Analyze, OperationKind.ObjectCreation);
        }

        private class ObjectCreationAnalyzer
        {
            private readonly INamedTypeSymbol _taskCompletionSourceOfTTypeSymbol;
            private readonly INamedTypeSymbol _taskCreationOptionsTypeSymbol;

            public ObjectCreationAnalyzer(Compilation compilation)
            {
                _taskCompletionSourceOfTTypeSymbol = compilation.GetTypeByMetadataName(typeof(TaskCompletionSource<>).FullName);
                _taskCreationOptionsTypeSymbol = compilation.GetTypeByMetadataName(typeof(TaskCreationOptions).FullName);
            }

            public void Analyze(OperationAnalysisContext context)
            {
                var objectCreation = (IObjectCreationOperation) context.Operation;
                if (!SymbolEqualityComparer.Default.Equals(_taskCompletionSourceOfTTypeSymbol, objectCreation.Type.OriginalDefinition))
                {
                    return;
                }

                if (objectCreation.Arguments.Length == 0)
                {
                    ReportDiagnostics(context, objectCreation.Syntax.Span);
                    return;
                }

                var arguments = objectCreation.Arguments;
                var argument = arguments.FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.Parameter.Type, _taskCreationOptionsTypeSymbol));
                if (argument == null)
                {
                    var textSpan = TextSpan.FromBounds(arguments.First().Syntax.Span.Start, arguments.Last().Syntax.Span.End);
                    ReportDiagnostics(context, textSpan);
                    return;
                }

                if (argument.Value is IFieldReferenceOperation fieldReference)
                {
                    if (!IsRunContinuationsAsynchronously(fieldReference))
                    {
                        ReportDiagnostics(context, argument.Syntax.Span);
                    }
                    return;
                }

                if (!HasRunContinuationsAsynchronously(argument.Value))
                {
                    ReportDiagnostics(context, argument.Syntax.Span);
                }
            }
        }

        private static bool HasRunContinuationsAsynchronously(IOperation operation)
            => operation.Descendants().OfType<IFieldReferenceOperation>().Any(IsRunContinuationsAsynchronously);

        private static bool IsRunContinuationsAsynchronously(IFieldReferenceOperation fieldReference)
            => fieldReference.Member.Name == "RunContinuationsAsynchronously";

        private static void ReportDiagnostics(OperationAnalysisContext context, TextSpan textSpan)
        {
            var location = context.Operation.Syntax.SyntaxTree.GetLocation(textSpan);
            var diagnostic = Diagnostic.Create(Descriptors.AZC0013, location);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
