// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // IOperation.Children is obsolete, but ChildOperations returns a struct enumerator

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Analyzes method bodies for ConfigureAwait(true) usage.
    /// Reports: AZC0101 (ConfigureAwait(true)).
    /// </summary>
    internal readonly struct MethodBodyAnalyzer
    {
        private readonly AsyncAnalyzerUtilities _asyncUtilities;
        private readonly List<StackFrame> _frames;
        private readonly Action<Diagnostic> _reportDiagnostic;

        public static void Run(Action<Diagnostic> reportDiagnostic, AsyncAnalyzerUtilities utilities, IMethodSymbol method, IBlockOperation methodBody)
            => new MethodBodyAnalyzer(reportDiagnostic, utilities).Run(method, methodBody);

        private MethodBodyAnalyzer(Action<Diagnostic> reportDiagnostic, AsyncAnalyzerUtilities utilities)
        {
            _reportDiagnostic = reportDiagnostic;
            _asyncUtilities = utilities;
            _frames = new List<StackFrame>();
        }

        private void Run(IMethodSymbol method, IBlockOperation methodBody)
        {
            var asyncParameter = GetAsyncParameter(method);

            PushChildren(methodBody, new MethodAnalysisContext(method, asyncParameter));

            while (_frames.Count > 0)
            {
                var frame = PeekFrame();
                if (frame.Index >= frame.Children.Length)
                {
                    PopFrame();
                    continue;
                }

                var current = frame.Children[frame.Index];
                AdvanceFrame();

                if (current == null)
                {
                    continue;
                }

                var context = frame.Context;
                var analyzeChildren = AnalyzeOperation(current, ref context);
                if (analyzeChildren)
                {
                    PushChildren(current, context);
                }
            }
        }

        private void PushChildren(IOperation parent, MethodAnalysisContext context)
        {
            var children = parent.Children.ToImmutableArray();
            if (children.Length > 0)
            {
                _frames.Add(new StackFrame(children, context));
            }
        }

        private void PushSingleOperation(IOperation operation, MethodAnalysisContext context)
        {
            _frames.Add(new StackFrame(ImmutableArray.Create(operation), context));
        }

        private StackFrame PeekFrame() => _frames[_frames.Count - 1];

        private void AdvanceFrame()
        {
            var frame = _frames[_frames.Count - 1];
            frame.Index++;
            _frames[_frames.Count - 1] = frame;
        }

        private void PopFrame() => _frames.RemoveAt(_frames.Count - 1);

        private bool AnalyzeOperation(IOperation current, ref MethodAnalysisContext context)
        {
            switch (current)
            {
                case IParameterReferenceOperation reference when SymbolEqualityComparer.Default.Equals(reference.Parameter, context.AsyncParameter):
                    AnalyzeAsyncParameterReference(context, reference);
                    return false;
                case IAnonymousFunctionOperation function when function.Symbol != null:
                    context = context.WithNewMethod(function.Symbol, GetAsyncParameter(function.Symbol));
                    return true;
                case ILocalFunctionOperation function when function.Symbol != null:
                    context = context.WithNewMethod(function.Symbol, GetAsyncParameter(function.Symbol));
                    return true;
                case IInvocationOperation invocation:
                    AnalyzeInvocation(invocation, context);
                    return true;
                default:
                    return true;
            }
        }

        // Scope tracking: async parameter references in if/else or ternary determine async/sync scope
        private void AnalyzeAsyncParameterReference(in MethodAnalysisContext context, IOperation reference)
        {
            switch (reference.Parent)
            {
                case IConditionalOperation conditional:
                    PopFrame();
                    TryPushOperationToStack(context, conditional.WhenFalse, Scope.Sync);
                    TryPushOperationToStack(context, conditional.WhenTrue, Scope.Async);
                    return;
                case IUnaryOperation unary when unary.OperatorKind == UnaryOperatorKind.Not && unary.Parent is IConditionalOperation conditional:
                    PopFrame();
                    PopFrame();
                    TryPushOperationToStack(context, conditional.WhenFalse, Scope.Async);
                    TryPushOperationToStack(context, conditional.WhenTrue, Scope.Sync);
                    return;
                case IArgumentOperation argument when _asyncUtilities.IsAsyncParameter(argument.Parameter):
                    return;
                default:
                    return;
            }
        }

        private void AnalyzeInvocation(in IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            // AZC0101 applies in Unknown and Async scopes (not Sync — that would be AZC0104)
            if (context.Scope != Scope.Sync && _asyncUtilities.IsConfigureAwait(invocation.TargetMethod))
            {
                AnalyzeConfigureAwait(invocation);
            }
        }

        // AZC0101: ConfigureAwait(true) should be ConfigureAwait(false)
        private void AnalyzeConfigureAwait(IInvocationOperation invocation)
        {
            if (invocation.Arguments.IsEmpty)
            {
                return;
            }

            IArgumentOperation argument = invocation.Arguments.Last();
            if (argument?.Value != null && IsEqualsToBoolValue(argument.Value, true))
            {
                ReportDiagnosticOnMember(invocation, Descriptors.AZC0101);
            }
        }

        private static bool IsEqualsToBoolValue(IOperation operation, bool value)
            => operation != null && operation.ConstantValue.HasValue && operation.ConstantValue.Value is bool boolValue && value == boolValue;

        private IParameterSymbol GetAsyncParameter(IMethodSymbol method)
            => method.Parameters.FirstOrDefault(_asyncUtilities.IsAsyncParameter);

        private void TryPushOperationToStack(in MethodAnalysisContext context, IOperation operation, Scope scope)
        {
            if (operation == null)
            {
                return;
            }

            PushSingleOperation(operation, context.WithScope(scope));
        }

        private void ReportDiagnosticOnMember(IOperation operation, DiagnosticDescriptor diagnosticDescriptor, params object[] messageArgs)
        {
            var location = Location.Create(operation.Syntax.SyntaxTree, GetMemberTextSpan(operation));
            var diagnostic = Diagnostic.Create(diagnosticDescriptor, location, messageArgs);
            _reportDiagnostic(diagnostic);
        }

        private static TextSpan GetMemberTextSpan(IOperation operation)
        {
            var invocation = (InvocationExpressionSyntax) operation.Syntax;
            var name = invocation.Expression is MemberAccessExpressionSyntax memberAccess ? memberAccess.Name : invocation.Expression;
            var start = name.Span.Start;
            var end = invocation.Span.End;
            return TextSpan.FromBounds(start, end);
        }

        private struct StackFrame
        {
            public readonly ImmutableArray<IOperation> Children;
            public int Index;
            public readonly MethodAnalysisContext Context;

            public StackFrame(ImmutableArray<IOperation> children, MethodAnalysisContext context)
            {
                Children = children;
                Index = 0;
                Context = context;
            }
        }

        private readonly struct MethodAnalysisContext
        {
            public IParameterSymbol AsyncParameter { get; }
            public Scope Scope { get; }

            public MethodAnalysisContext(IMethodSymbol method, IParameterSymbol asyncParameter)
                :this(asyncParameter, GetScope(method, asyncParameter)) { }

            private MethodAnalysisContext(IParameterSymbol asyncParameter, Scope scope)
            {
                AsyncParameter = asyncParameter;
                Scope = scope;
            }

            public MethodAnalysisContext WithNewMethod(IMethodSymbol method, IParameterSymbol asyncParameter)
                => new MethodAnalysisContext(asyncParameter ?? AsyncParameter, GetScope(method, asyncParameter));

            public MethodAnalysisContext WithScope(Scope scope)
                => new MethodAnalysisContext(AsyncParameter, Scope == Scope.Sync ? Scope.Sync : scope);

            private static Scope GetScope(IMethodSymbol method, IParameterSymbol asyncParameter) =>
                method.IsAsync
                    ? asyncParameter != null ? Scope.Unknown : Scope.Async
                    : Scope.Sync;
        }

        private enum Scope
        {
            Unknown,
            Async,
            Sync
        }
    }
}
