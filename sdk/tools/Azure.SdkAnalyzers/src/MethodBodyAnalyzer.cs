// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // IOperation.Children is obsolete, but ChildOperations returns a struct enumerator

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Analyzes method bodies for async/sync pattern correctness.
    /// Reports: AZC0101 (ConfigureAwait(true)), AZC0108 (wrong async param value),
    /// AZC0109 (async param misuse), AZC0111 (EnsureCompleted in async scope).
    /// </summary>
    internal readonly struct MethodBodyAnalyzer
    {
        private readonly AsyncAnalyzerUtilities _asyncUtilities;
        private readonly Stack<(IEnumerator<IOperation>, MethodAnalysisContext)> _symbolIteratorsStack;
        private readonly Action<Diagnostic> _reportDiagnostic;

        public static void Run(Action<Diagnostic> reportDiagnostic, Compilation compilation, AsyncAnalyzerUtilities utilities, IMethodSymbol method, IBlockOperation methodBody)
            => new MethodBodyAnalyzer(reportDiagnostic, compilation, utilities).Run(method, methodBody);

        private MethodBodyAnalyzer(Action<Diagnostic> reportDiagnostic, Compilation compilation, AsyncAnalyzerUtilities utilities)
        {
            _reportDiagnostic = reportDiagnostic;
            _asyncUtilities = utilities;
            _symbolIteratorsStack = new Stack<(IEnumerator<IOperation>, MethodAnalysisContext)>();
        }

        private void Run(IMethodSymbol method, IBlockOperation methodBody)
        {
            var asyncParameter = GetAsyncParameter(method);

            _symbolIteratorsStack.Push((methodBody.Children.GetEnumerator(), new MethodAnalysisContext(method, asyncParameter)));

            while (_symbolIteratorsStack.Count > 0)
            {
                var (enumerator, context) = _symbolIteratorsStack.Peek();
                if (!enumerator.MoveNext())
                {
                    _symbolIteratorsStack.Pop();
                    continue;
                }

                var current = enumerator.Current;
                if (current == null)
                {
                    continue;
                }

                var analyzeChildren = AnalyzeOperation(current, ref context);
                if (analyzeChildren)
                {
                    _symbolIteratorsStack.Push((current.Children.GetEnumerator(), context));
                }
            }
        }

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
                case IAwaitOperation awaitOperation when context.Scope == Scope.Unknown:
                    AnalyzeAwaitableOperationInUnknownScope(awaitOperation, context);
                    return false;
                case IInvocationOperation invocation:
                    AnalyzeInvocation(invocation, context);
                    return true;
                default:
                    return true;
            }
        }

        // AZC0109: async parameter can only be used as exclusive condition in ?: or if/else
        private void AnalyzeAsyncParameterReference(in MethodAnalysisContext context, IOperation reference)
        {
            switch (reference.Parent)
            {
                case IConditionalOperation conditional:
                    _symbolIteratorsStack.Pop();
                    TryPushOperationToStack(context, conditional.WhenFalse, Scope.Sync);
                    TryPushOperationToStack(context, conditional.WhenTrue, Scope.Async);
                    return;
                case IUnaryOperation unary when unary.OperatorKind == UnaryOperatorKind.Not && unary.Parent is IConditionalOperation conditional:
                    _symbolIteratorsStack.Pop();
                    _symbolIteratorsStack.Pop();
                    TryPushOperationToStack(context, conditional.WhenFalse, Scope.Async);
                    TryPushOperationToStack(context, conditional.WhenTrue, Scope.Sync);
                    return;
                case IArgumentOperation argument when _asyncUtilities.IsAsyncParameter(argument.Parameter):
                    return;
                default:
                    ReportDiagnosticOnOperation(reference.Parent, Descriptors.AZC0109);
                    return;
            }
        }

        // AZC0111: EnsureCompleted in unknown scope (possibly async)
        private void AnalyzeAwaitableOperationInUnknownScope(in IAwaitOperation awaitOperation, in MethodAnalysisContext context)
        {
            var operation = GetAwaitableOperation(awaitOperation.Operation);

            if (operation is IInvocationOperation invocation &&
                TryGetAsyncArgument(invocation, out var argument) &&
                IsEqualsToParameter(argument.Value, context.AsyncParameter))
            {
                return;
            }

            // AZC0110 would be reported here for await in unknown scope,
            // but that rule is not migrated in this tier.
        }

        private IOperation GetAwaitableOperation(IOperation operation)
        {
            while (operation is IInvocationOperation invocation)
            {
                if (IsExtensionMethodOnInvocation(invocation, out var argumentInvocation))
                {
                    operation = argumentInvocation;
                }
                else if (invocation.Instance != null && _asyncUtilities.IsTaskType(invocation.Instance.Type))
                {
                    operation = invocation.Instance;
                }
                else
                {
                    return operation;
                }
            }
            return operation;
        }

        private void AnalyzeInvocation(in IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            switch (context.Scope) {
                case Scope.Unknown:
                    AnalyzeInvocationUnknownScope(invocation, context);
                    return;
                case Scope.Async:
                    AnalyzeInvocationAsyncScope(invocation, context);
                    return;
                case Scope.Sync:
                    AnalyzeInvocationSyncScope(invocation, context);
                    return;
            }
        }

        private void AnalyzeInvocationUnknownScope(in IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            var method = invocation.TargetMethod;
            if (_asyncUtilities.IsConfigureAwait(method))
            {
                AnalyzeConfigureAwait(invocation);
            }
            else if (IsGetAwaiterGetResult(invocation))
            {
                // AZC0102 not migrated in this tier
            }
            else if (IsEnsureCompleted(invocation, out var firstArgument))
            {
                var operation = GetAwaitableOperation(firstArgument);
                ReportDiagnosticOnOperation(operation, Descriptors.AZC0111);
            }
        }

        private void AnalyzeInvocationAsyncScope(IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            var method = invocation.TargetMethod;
            if (_asyncUtilities.IsConfigureAwait(method))
            {
                AnalyzeConfigureAwait(invocation);
            }
            else if (IsGetAwaiterGetResult(invocation))
            {
                // AZC0103 not migrated in this tier
            }
            else if (IsEnsureCompleted(invocation, out _))
            {
                // AZC0103 not migrated in this tier
            }
            else if (method.IsAsync && !IsPublicMethod(method) && TryGetAsyncArgument(invocation, out var asyncArgument))
            {
                AnalyzeAsyncParameterValue(invocation, context.AsyncParameter, asyncArgument, true);
            }
        }

        private void AnalyzeInvocationSyncScope(IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            if (_asyncUtilities.IsConfigureAwait(invocation.TargetMethod))
            {
                // AZC0104 not migrated in this tier
            }
            else if (IsGetAwaiterGetResult(invocation))
            {
                // AZC0102 not migrated in this tier
            }
            else if (IsEnsureCompleted(invocation, out var firstArgument))
            {
                AnalyzeEnsureCompleted(firstArgument, context);
            }
        }

        // AZC0101: ConfigureAwait(true) is always wrong
        private void AnalyzeConfigureAwait(IInvocationOperation invocation)
        {
            if (IsEqualsToBoolValue(invocation.Arguments.Last().Value, true))
            {
                ReportDiagnosticOnMember(invocation, Descriptors.AZC0101);
            }
        }

        private void AnalyzeEnsureCompleted(in IOperation firstArgument, in MethodAnalysisContext context)
        {
            switch (firstArgument)
            {
                case IFieldReferenceOperation _:
                case ILocalReferenceOperation _:
                case IParameterReferenceOperation _:
                case IPropertyReferenceOperation _:
                    // AZC0104 not migrated in this tier
                    return;
                case IInvocationOperation invocation:
                    AnalyzeEnsureCompletedOnInvocation(invocation, context);
                    return;
            }
        }

        private void AnalyzeEnsureCompletedOnInvocation(IInvocationOperation invocation, in MethodAnalysisContext context)
        {
            while (true)
            {
                var method = invocation.TargetMethod;
                if (TryGetAsyncArgument(invocation, out var asyncArgument))
                {
                    AnalyzeAsyncParameterValue(invocation, context.AsyncParameter, asyncArgument, false);
                    return;
                }

                if (IsExtensionMethodOnInvocation(invocation, out var argumentInvocation))
                {
                    invocation = argumentInvocation;
                    continue;
                }

                // AZC0106/AZC0107 not migrated in this tier
                return;
            }
        }

        private bool IsExtensionMethodOnInvocation(IInvocationOperation invocation, out IInvocationOperation invocationOperation)
        {
            var method = invocation.TargetMethod;
            if (method.IsExtensionMethod && invocation.Arguments[0].Value is IInvocationOperation argument && _asyncUtilities.IsTaskType(argument.Type))
            {
                invocationOperation = argument;
                return true;
            }

            invocationOperation = default;
            return false;
        }

        // AZC0108: async parameter has incorrect value
        private void AnalyzeAsyncParameterValue(IInvocationOperation invocation, IParameterSymbol asyncParameter, IArgumentOperation asyncArgument, bool asyncValue)
        {
            if (IsEqualsToParameter(asyncArgument.Value, asyncParameter) || IsEqualsToBoolValue(asyncArgument.Value, asyncValue))
            {
                return;
            }

            var messageArgs = asyncValue
                ? new object[] {"asynchronous", invocation.TargetMethod.Name, "be 'true'"}
                : new object[] {"synchronous", invocation.TargetMethod.Name, "be 'false'"};

            ReportDiagnosticOnOperation(asyncArgument, Descriptors.AZC0108, messageArgs);
        }

        private static bool IsEqualsToBoolValue(IOperation operation, bool value)
            => operation != null && operation.ConstantValue.HasValue && operation.ConstantValue.Value is bool boolValue && value == boolValue;

        private static bool IsEqualsToParameter(IOperation operation, IParameterSymbol parameter)
            => operation != null && operation is IParameterReferenceOperation reference && SymbolEqualityComparer.Default.Equals(reference.Parameter, parameter);

        private IParameterSymbol GetAsyncParameter(IMethodSymbol method)
            => method.Parameters.FirstOrDefault(_asyncUtilities.IsAsyncParameter);

        private bool TryGetAsyncArgument(IInvocationOperation invocation, out IArgumentOperation asyncArgument)
        {
            asyncArgument = invocation.Arguments.FirstOrDefault(IsAsyncArgument);
            return asyncArgument != default;
        }

        private bool IsAsyncArgument(IArgumentOperation argument)
            => _asyncUtilities.IsAsyncParameter(argument.Parameter);

        public bool IsGetAwaiterGetResult(IInvocationOperation invocation)
            => _asyncUtilities.IsGetAwaiter(invocation.TargetMethod) && invocation.Parent is IInvocationOperation parentInvocation && _asyncUtilities.IsAwaiterGetResultMethod(parentInvocation.TargetMethod);

        private bool IsEnsureCompleted(IInvocationOperation invocation, out IOperation firstArgument)
        {
            if (_asyncUtilities.IsEnsureCompleted(invocation.TargetMethod))
            {
                firstArgument = invocation.Arguments[0].Value;
                return true;
            }

            firstArgument = default;
            return false;
        }

        private void TryPushOperationToStack(in MethodAnalysisContext context, IOperation operation, Scope scope)
        {
            if (operation == null)
            {
                return;
            }

            IEnumerable<IOperation> enumerable = new[] {operation};
            _symbolIteratorsStack.Push((enumerable.GetEnumerator(), context.WithScope(scope)));
        }

        private void ReportDiagnosticOnOperation(IOperation operation, DiagnosticDescriptor diagnosticDescriptor, params object[] messageArgs)
        {
            var location = operation.Syntax.GetLocation();
            var diagnostic = Diagnostic.Create(diagnosticDescriptor, location, messageArgs);
            _reportDiagnostic(diagnostic);
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

        private static bool IsPublicMethod(IMethodSymbol method)
        {
            if (method.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            if (method.AssociatedSymbol != null && method.AssociatedSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            var type = method.ContainingType;
            while (type != null)
            {
                if (type.DeclaredAccessibility != Accessibility.Public)
                {
                    return false;
                }

                type = type.ContainingType;
            }

            return true;
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
