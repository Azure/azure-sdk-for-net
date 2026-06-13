// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RequestContextCancellationTokenAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0020);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterOperationAction(AnalyzeInvocation, OperationKind.Invocation);
        }

        private void AnalyzeInvocation(OperationAnalysisContext context)
        {
            var invocation = (IInvocationOperation)context.Operation;

            // Only analyze invocations of Azure SDK APIs
            if (!IsAzureSdkApi(invocation.TargetMethod))
            {
                return;
            }

            // Find the containing method
            var containingMethod = GetContainingMethod(context.Operation);
            if (containingMethod == null)
            {
                return;
            }

            // Check if the containing method has a CancellationToken parameter
            var cancellationTokenParam = containingMethod.Parameters
                .FirstOrDefault(p => IsCancellationToken(p.Type));

            if (cancellationTokenParam == null)
            {
                return;
            }

            // Check if any argument is a RequestContext
            foreach (var argument in invocation.Arguments)
            {
                if (IsRequestContext(argument.Value.Type))
                {
                    // Check if the RequestContext has the CancellationToken set
                    if (!IsRequestContextWithCancellationToken(argument.Value, cancellationTokenParam, context))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(
                            Descriptors.AZC0020,
                            argument.Syntax.GetLocation(),
                            containingMethod.Name));
                    }
                }
            }
        }

        private bool IsAzureSdkApi(IMethodSymbol method)
        {
            if (method == null)
            {
                return false;
            }

            // Check if the method is in an Azure or Microsoft.Azure namespace
            var containingNamespace = method.ContainingNamespace;
            while (containingNamespace != null && !containingNamespace.IsGlobalNamespace)
            {
                if (containingNamespace.Name == "Azure")
                {
                    return true;
                }

                // Check for Microsoft.Azure (e.g., bridge packages, extensions)
                if (containingNamespace.Name == "Azure" &&
                    containingNamespace.ContainingNamespace != null &&
                    containingNamespace.ContainingNamespace.Name == "Microsoft")
                {
                    return true;
                }

                containingNamespace = containingNamespace.ContainingNamespace;
            }

            return false;
        }

        private IMethodSymbol GetContainingMethod(IOperation operation)
        {
            var current = operation;
            while (current != null)
            {
                // Check for lambda/anonymous function
                if (current is IAnonymousFunctionOperation anonymousFunction)
                {
                    return anonymousFunction.Symbol;
                }

                // Check for method body
                if (current is IMethodBodyBaseOperation methodBody)
                {
                    return methodBody.SemanticModel.GetDeclaredSymbol(methodBody.Syntax) as IMethodSymbol;
                }

                current = current.Parent;
            }

            return null;
        }

        private bool IsCancellationToken(ITypeSymbol type)
        {
            if (type == null)
            {
                return false;
            }

            return type.Name == "CancellationToken" &&
                   type.ContainingNamespace?.ToDisplayString() == "System.Threading";
        }

        private bool IsRequestContext(ITypeSymbol type)
        {
            if (type == null)
            {
                return false;
            }

            return type.Name == "RequestContext" &&
                   type.ContainingNamespace?.ToDisplayString() == "Azure";
        }

        private bool IsRequestContextWithCancellationToken(
            IOperation requestContextOperation,
            IParameterSymbol cancellationTokenParam,
            OperationAnalysisContext context)
        {
            // Check for object creation with initializer
            if (requestContextOperation is IObjectCreationOperation objectCreation)
            {
                // Check if initializer sets CancellationToken property
                if (objectCreation.Initializer != null)
                {
                    foreach (var initializer in objectCreation.Initializer.Initializers)
                    {
                        if (initializer is ISimpleAssignmentOperation assignment)
                        {
                            if (assignment.Target is IPropertyReferenceOperation propertyRef &&
                                propertyRef.Property.Name == "CancellationToken")
                            {
                                // Check if the value being assigned is the cancellation token parameter
                                if (IsCancellationTokenParameterReference(assignment.Value, cancellationTokenParam))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                // Check constructor arguments
                foreach (var argument in objectCreation.Arguments)
                {
                    // RequestContext doesn't have a constructor that takes CancellationToken,
                    // but we should check just in case
                    if (IsCancellationToken(argument.Parameter?.Type) &&
                        IsCancellationTokenParameterReference(argument.Value, cancellationTokenParam))
                    {
                        return true;
                    }
                }

                return false;
            }

            // Check for any operation that uses the CancellationToken parameter
            // This covers extension methods, helper methods, and other ways to create RequestContext
            if (requestContextOperation is IInvocationOperation invocationOp)
            {
                // Check if any part of the invocation references the cancellation token parameter
                if (ContainsCancellationTokenReference(invocationOp, cancellationTokenParam))
                {
                    return true;
                }
            }

            // Check for parameter reference (passed from another scope)
            // In this case, we can't easily determine if it has the token set, so we assume it's okay
            if (requestContextOperation is IParameterReferenceOperation ||
                requestContextOperation is ILocalReferenceOperation ||
                requestContextOperation is IFieldReferenceOperation ||
                requestContextOperation is IPropertyReferenceOperation)
            {
                // Don't report a diagnostic for pre-existing RequestContext objects
                // as we can't easily determine if they have the token set
                return true;
            }

            return false;
        }

        private bool IsCancellationTokenParameterReference(IOperation operation, IParameterSymbol parameter)
        {
            if (operation is IParameterReferenceOperation paramRef)
            {
                return SymbolEqualityComparer.Default.Equals(paramRef.Parameter, parameter);
            }

            // Also check for CancellationToken.None or default
            if (operation is IPropertyReferenceOperation propertyRef)
            {
                if (propertyRef.Property.Name == "None" &&
                    IsCancellationToken(propertyRef.Property.ContainingType))
                {
                    return false; // CancellationToken.None is not the parameter
                }
            }

            if (operation is IDefaultValueOperation defaultOp)
            {
                if (IsCancellationToken(defaultOp.Type))
                {
                    return false; // default(CancellationToken) is not the parameter
                }
            }

            return false;
        }

        private bool ContainsCancellationTokenReference(IOperation operation, IParameterSymbol cancellationTokenParam)
        {
            if (operation == null)
            {
                return false;
            }

            // Check if this operation directly references the cancellation token parameter
            if (operation is IParameterReferenceOperation paramRef)
            {
                if (SymbolEqualityComparer.Default.Equals(paramRef.Parameter, cancellationTokenParam))
                {
                    return true;
                }
            }

            // Recursively check all child operations
            foreach (var child in operation.ChildOperations)
            {
                if (ContainsCancellationTokenReference(child, cancellationTokenParam))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
