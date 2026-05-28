// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    /// <summary>
    /// Repairs hidden model factory compatibility overloads after flattening changes the current model factory shape.
    /// Used from <see cref="ManagementClientGenerator.GetWriter(TypeProvider)"/> because some compatibility overloads are
    /// synthesized from LastContractView after normal visitors have finished.
    /// </summary>
    internal static class ModelFactoryBackwardCompatHelper
    {
        /// <summary>
        /// Updates hidden compatibility overload bodies so old parameters still flow into the current flattened model shape.
        /// Input is the complete model factory method list; output is in-place method body updates for repairable overloads.
        /// Used just before writing a <see cref="ModelFactoryProvider"/> to cover both visitor-created and LastContractView-created overloads.
        /// </summary>
        internal static void FixModelFactoryBackwardCompatOverloads(IReadOnlyList<MethodProvider> methods)
        {
            // First identify the current primary overload for each model factory method name. Hidden compatibility overloads
            // are skipped here because they represent older signatures, not the current argument order/body shape.
            var primaryMethods = new Dictionary<string, MethodProvider>();
            foreach (var method in methods)
            {
                if (!IsBackwardCompatMethod(method))
                {
                    var key = method.Signature.Name;
                    if (!primaryMethods.TryGetValue(key, out var existing) || method.Signature.Parameters.Count > existing.Signature.Parameters.Count)
                    {
                        primaryMethods[key] = method;
                    }
                }
            }

            // Then scan hidden compatibility overload bodies and repair the two shapes we know how to preserve:
            // 1. A call into the primary overload with stale positional arguments.
            // 2. A direct model construction with default arguments where the old overload still has matching inputs.
            foreach (var method in methods)
            {
                if (!IsBackwardCompatMethod(method) || method.BodyStatements is null)
                {
                    continue;
                }

                var updatedBodyStatements = new List<MethodBodyStatement>();
                var bodyUpdated = false;
                foreach (var statement in method.BodyStatements)
                {
                    if (TryUpdatePrimaryMethodInvocation(statement, primaryMethods, out var updatedInvocation))
                    {
                        updatedBodyStatements.Add(updatedInvocation);
                        bodyUpdated = true;
                    }
                    else if (statement is ExpressionStatement { Expression: KeywordExpression { Expression: NewInstanceExpression newInstanceExpression } }
                        && TryUpdateNewInstanceArguments(method, newInstanceExpression, out var updatedArguments, out var matchedParameters))
                    {
                        updatedBodyStatements.RemoveAll(s => IsNullCoalescingAssignmentToMatchedParameter(s, matchedParameters, newInstanceExpression.Parameters));
                        updatedBodyStatements.Add(Return(New.Instance(newInstanceExpression.Type!, updatedArguments)));
                        bodyUpdated = true;
                    }
                    else
                    {
                        updatedBodyStatements.Add(statement);
                    }
                }

                if (bodyUpdated)
                {
                    method.Update(signature: method.Signature, bodyStatements: updatedBodyStatements);
                }
            }
        }

        /// <summary>
        /// Returns true when a method is a hidden backward-compatibility overload.
        /// Input is a method provider; output is whether it has <see cref="System.ComponentModel.EditorBrowsableAttribute"/>.
        /// Used by this helper and tests to separate old compatibility overloads from current primary overloads.
        /// </summary>
        internal static bool IsBackwardCompatMethod(MethodProvider method)
        {
            return method.Signature.Attributes.Any(a =>
                a.Type is { IsFrameworkType: true } && a.Type.FrameworkType == typeof(System.ComponentModel.EditorBrowsableAttribute));
        }

        internal static bool TryCreateBackwardCompatMethod(MethodProvider method, TypeProvider enclosingType, [NotNullWhen(true)] out MethodProvider? updatedMethod)
        {
            updatedMethod = null;
            if (method.Signature.ReturnType is null || !TryGetModelProvider(method.Signature.ReturnType, out var modelProvider))
            {
                return false;
            }

            var constructorParameters = modelProvider.FullConstructor.Signature.Parameters;
            var directParameterNames = constructorParameters
                .Where(parameter => TryGetMethodParameter(method, parameter.Name, parameter.Type, out _))
                .Select(parameter => parameter.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var arguments = new List<ValueExpression>(constructorParameters.Count);
            foreach (var constructorParameter in constructorParameters)
            {
                if (TryBuildCompatibilityArgument(method, constructorParameter, directParameterNames, out var argument))
                {
                    arguments.Add(argument.Argument);
                }
                else
                {
                    arguments.Add(constructorParameter.DefaultValue ?? Default);
                }
            }

            updatedMethod = new MethodProvider(
                CreateBackwardCompatSignature(method.Signature),
                Return(New.Instance(method.Signature.ReturnType, arguments)),
                enclosingType);
            return true;
        }

        private static MethodSignature CreateBackwardCompatSignature(MethodSignature signature)
        {
            var attributes = signature.Attributes.Any(attribute =>
                attribute.Type is { IsFrameworkType: true } && attribute.Type.FrameworkType == typeof(EditorBrowsableAttribute))
                    ? signature.Attributes
                    : [.. signature.Attributes, new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))];

            return new MethodSignature(
                signature.Name,
                signature.Description,
                signature.Modifiers,
                signature.ReturnType,
                signature.ReturnDescription,
                signature.Parameters,
                attributes,
                signature.GenericArguments,
                signature.GenericParameterConstraints,
                signature.ExplicitInterface,
                signature.NonDocumentComment);
        }

        /// <summary>
        /// Rebuilds a hidden overload's primary-method invocation in the current primary method parameter order.
        /// Inputs are one body statement and the primary method lookup; output is a replacement return statement when the call changed.
        /// Used by <see cref="FixModelFactoryBackwardCompatOverloads"/> for overloads whose body delegates to another model factory method.
        /// </summary>
        private static bool TryUpdatePrimaryMethodInvocation(
            MethodBodyStatement statement,
            IReadOnlyDictionary<string, MethodProvider> primaryMethods,
            [NotNullWhen(true)] out MethodBodyStatement? updatedStatement)
        {
            updatedStatement = null;
            if (statement is not ExpressionStatement expressionStatement
                || (expressionStatement.Expression as KeywordExpression)?.Expression is not InvokeMethodExpression invokeExpression
                || (invokeExpression.MethodName ?? invokeExpression.MethodSignature?.Name) is not string calledMethodName
                || !primaryMethods.TryGetValue(calledMethodName, out var primaryMethod))
            {
                return false;
            }

            // The invoke signature describes the old overload's argument names, while primaryParams describes the current
            // overload shape. If either side is unavailable, the safest behavior is to leave the old body unchanged.
            var primaryParams = primaryMethod.Signature.Parameters;
            var invokeArgs = invokeExpression.Arguments;
            var invokeSignatureParams = invokeExpression.MethodSignature?.Parameters;

            if (invokeSignatureParams is null || invokeSignatureParams.Count != invokeArgs.Count)
            {
                return false;
            }

            // Compatibility overloads may call the current primary overload using an older parameter order.
            // Rebuild the call by parameter name so old overload arguments continue to flow to their matching
            // current parameters, and any parameters not present in the old overload keep a named default value.
            var argsByName = new Dictionary<string, ValueExpression>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < invokeSignatureParams.Count; i++)
            {
                argsByName[invokeSignatureParams[i].Name] = invokeArgs[i];
            }

            var newArgs = new List<ValueExpression>(primaryParams.Count);
            var changed = false;
            for (int i = 0; i < primaryParams.Count; i++)
            {
                // Preserve old arguments by matching parameter names instead of trusting old positional order.
                if (argsByName.TryGetValue(primaryParams[i].Name, out var arg))
                {
                    newArgs.Add(arg);
                    if (!changed && (i >= invokeArgs.Count || !ReferenceEquals(arg, invokeArgs[i])))
                    {
                        changed = true;
                    }
                }
                else
                {
                    // Parameters added after the old overload was generated must remain defaulted, but we emit them as
                    // named positional references so the generated call remains stable if later parameters move again.
                    newArgs.Add(Snippet.PositionalReference(primaryParams[i], primaryParams[i].DefaultValue ?? Default));
                    changed = true;
                }
            }

            if (!changed)
            {
                return false;
            }

            updatedStatement = Return(new InvokeMethodExpression(null, primaryMethod.Signature, newArgs));
            return true;
        }

        /// <summary>
        /// Replaces default arguments in a hidden overload's direct model construction with arguments rebuilt from old parameters.
        /// Inputs are the old method and its returned <see cref="NewInstanceExpression"/>; outputs are updated constructor arguments
        /// and the old parameters consumed by the repair. Used for compatibility overloads that construct the model directly.
        /// </summary>
        private static bool TryUpdateNewInstanceArguments(
            MethodProvider method,
            NewInstanceExpression newInstanceExpression,
            [NotNullWhen(true)] out IReadOnlyList<ValueExpression>? updatedArguments,
            [NotNullWhen(true)] out IReadOnlyList<ParameterProvider>? matchedParameters)
        {
            updatedArguments = null;
            matchedParameters = null;
            if (newInstanceExpression.Type is null || !TryGetModelProvider(newInstanceExpression.Type, out var modelProvider))
            {
                return false;
            }

            // The repair maps arguments by the generated full constructor. If the expression contains named arguments that
            // target a customization constructor instead, the full-constructor parameter order is not authoritative.
            var constructorParameters = modelProvider.FullConstructor.Signature.Parameters;
            if (constructorParameters.Count != newInstanceExpression.Parameters.Count)
            {
                return false;
            }

            if (HasNamedArgumentMismatchingFullConstructor(newInstanceExpression.Parameters, constructorParameters))
            {
                return false;
            }

            List<ValueExpression>? arguments = null;
            List<ParameterProvider>? matched = null;
            var unavailableDirectParameterNames = GetUnavailableDirectParameterNames(method, constructorParameters, newInstanceExpression.Parameters);
            for (int i = 0; i < newInstanceExpression.Parameters.Count; i++)
            {
                // Only default slots are candidates for repair. Non-default arguments were intentionally present in the
                // old generated body and should not be overwritten.
                var currentArgument = newInstanceExpression.Parameters[i];
                if (!IsDefaultExpression(currentArgument))
                {
                    continue;
                }

                if (TryBuildCompatibilityArgument(method, constructorParameters[i], unavailableDirectParameterNames, out var replacement))
                {
                    arguments ??= [.. newInstanceExpression.Parameters];
                    matched ??= [];
                    arguments[i] = replacement.Argument;
                    matched.AddRange(replacement.MatchedParameters);
                }
            }

            updatedArguments = arguments;
            matchedParameters = matched;
            return arguments is not null;
        }

        /// <summary>
        /// Detects named constructor arguments that prove a <see cref="NewInstanceExpression"/> is not bound to the generated full constructor.
        /// Inputs are rendered arguments and full-constructor parameters; output is true when a named argument targets a different slot.
        /// Used before direct-constructor repair to avoid corrupting calls to custom constructors.
        /// </summary>
        private static bool HasNamedArgumentMismatchingFullConstructor(IReadOnlyList<ValueExpression> arguments, IReadOnlyList<ParameterProvider> constructorParameters)
        {
            for (int i = 0; i < arguments.Count; i++)
            {
                if (arguments[i] is PositionalParameterReferenceExpression { ParameterName: var argumentName }
                    && !string.Equals(argumentName, constructorParameters[i].Name, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true for a null-coalescing assignment statement that initializes a parameter consumed by a repaired argument.
        /// Inputs are a method body statement and repaired parameters; output is whether the statement should be removed.
        /// Used after rebuilding nested model arguments because the new conditional construction handles null/default behavior.
        /// </summary>
        private static bool IsNullCoalescingAssignmentToMatchedParameter(
            MethodBodyStatement statement,
            IReadOnlyList<ParameterProvider> parameters,
            IReadOnlyList<ValueExpression> originalArguments)
        {
            if (statement is not ExpressionStatement { Expression: AssignmentExpression { UseNullCoalesce: true } assignment })
            {
                return false;
            }

            return parameters.Any(parameter =>
                ReferencesParameter(assignment.Variable, parameter)
                && !IsParameterUsedByOriginalArgument(parameter, originalArguments));
        }

        /// <summary>
        /// Returns true when a matched old parameter is still used by an original non-default constructor argument.
        /// Used to preserve existing null-coalescing assignments needed by unrepaired direct arguments.
        /// </summary>
        private static bool IsParameterUsedByOriginalArgument(ParameterProvider parameter, IReadOnlyList<ValueExpression> originalArguments)
        {
            return originalArguments.Any(argument =>
                !IsDefaultExpression(argument)
                && ReferencesParameter(argument, parameter));
        }

        private static HashSet<string> GetUnavailableDirectParameterNames(MethodProvider method, IReadOnlyList<ParameterProvider> constructorParameters, IReadOnlyList<ValueExpression> originalArguments)
        {
            var result = GetParameterNamesUsedByOriginalArguments(method.Signature.Parameters, originalArguments);
            foreach (var constructorParameter in constructorParameters)
            {
                if (TryGetMethodParameter(method, constructorParameter.Name, constructorParameter.Type, out _))
                {
                    result.Add(constructorParameter.Name);
                }
            }

            return result;
        }

        private static HashSet<string> GetParameterNamesUsedByOriginalArguments(IReadOnlyList<ParameterProvider> parameters, IReadOnlyList<ValueExpression> originalArguments)
            => parameters
                .Where(parameter => IsParameterUsedByOriginalArgument(parameter, originalArguments))
                .Select(parameter => parameter.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        private static bool ReferencesParameter(ValueExpression expression, ParameterProvider parameter)
        {
            if (ReferenceEquals(expression, parameter))
            {
                return true;
            }

            return expression switch
            {
                VariableExpression variable => string.Equals(variable.Declaration.RequestedName, parameter.Name, StringComparison.Ordinal),
                PositionalParameterReferenceExpression positional => string.Equals(positional.ParameterName, parameter.Name, StringComparison.Ordinal)
                    || ReferencesParameter(positional.ParameterValue, parameter),
                InvokeMethodExpression invoke => (invoke.InstanceReference is not null && ReferencesParameter(invoke.InstanceReference, parameter))
                    || invoke.Arguments.Any(argument => ReferencesParameter(argument, parameter)),
                NewInstanceExpression newInstance => newInstance.Parameters.Any(argument => ReferencesParameter(argument, parameter)),
                BinaryOperatorExpression binary => ReferencesParameter(binary.Left, parameter) || ReferencesParameter(binary.Right, parameter),
                _ => false
            };
        }

        private static bool TryBuildCompatibilityArgument(
            MethodProvider method,
            ParameterProvider constructorParameter,
            IReadOnlySet<string> unavailableDirectParameterNames,
            [NotNullWhen(true)] out CompatibilityArgument? argument)
        {
            // Direct matching is only safe for the constructor slot currently being repaired. Recursive nested
            // resolution uses combined/contextual names to avoid stealing outer parameters with the same name.
            if (TryGetMethodParameter(method, constructorParameter.Name, constructorParameter.Type, out var directParameter))
            {
                argument = new CompatibilityArgument(BuildParameterArgument(directParameter, constructorParameter.Type), [directParameter]);
                return true;
            }

            return TryBuildModelCompatibilityArgument(method, constructorParameter, [], unavailableDirectParameterNames, useNullGuard: true, out argument);
        }

        /// <summary>
        /// Reconstructs a model argument from parameters still present on the old overload.
        /// </summary>
        /// <param name="method">The hidden backward-compatible overload being repaired.</param>
        /// <param name="constructorParameter">The model-typed constructor parameter to build an argument for.</param>
        /// <param name="visitedTypes">The current recursion stack used to avoid cycles in nested model graphs.</param>
        /// <param name="unavailableDirectParameterNames">Old parameter names that should not be reused by direct nested-name fallback.</param>
        /// <param name="useNullGuard">
        /// True when creating a top-level nested model argument, so the old overload keeps returning default when all flattened inputs are null.
        /// False for recursive nested models, which are already inside a parent instance that decided whether to be created.
        /// </param>
        /// <param name="argument">The reconstructed model argument and old parameters used by it.</param>
        private static bool TryBuildModelCompatibilityArgument(
            MethodProvider method,
            ParameterProvider constructorParameter,
            List<CSharpType> visitedTypes,
            IReadOnlySet<string> unavailableDirectParameterNames,
            bool useNullGuard,
            [NotNullWhen(true)] out CompatibilityArgument? argument)
        {
            // For flattened models, old overload parameters often correspond to leaves of a nested model. Track visited
            // model types by name to avoid infinite recursion in self-referential model graphs.
            if (visitedTypes.Any(type => type.AreNamesEqual(constructorParameter.Type)))
            {
                argument = null;
                return false;
            }

            visitedTypes.Add(constructorParameter.Type);

            if (!TryGetModelProvider(constructorParameter.Type, out var nestedModel))
            {
                argument = null;
                visitedTypes.Remove(constructorParameter.Type);
                return false;
            }

            // Reconstruct the nested model by independently resolving each constructor parameter from the old overload.
            // Missing nested parameters intentionally stay defaulted to preserve old overload shape.
            var nestedConstructorParameters = nestedModel.FullConstructor.Signature.Parameters;
            var nestedArguments = new List<ValueExpression>(nestedConstructorParameters.Count);
            var matchedParameters = new List<ParameterProvider>();
            foreach (var nestedParameter in nestedConstructorParameters)
            {
                if (TryGetNestedCompatibilityArgument(method, constructorParameter.Property, constructorParameter.Name, nestedParameter, visitedTypes, unavailableDirectParameterNames, out var nestedArgument))
                {
                    nestedArguments.Add(nestedArgument.Argument);
                    matchedParameters.AddRange(nestedArgument.MatchedParameters);
                }
                else
                {
                    nestedArguments.Add(nestedParameter.DefaultValue ?? Default);
                }
            }

            if (matchedParameters.Count == 0)
            {
                argument = null;
                visitedTypes.Remove(constructorParameter.Type);
                return false;
            }

            // For top-level replacement arguments, preserve old all-null behavior by returning default instead of creating
            // an empty nested model. Recursive replacements are embedded inside an already-created parent and skip this guard.
            var newInstance = New.Instance(constructorParameter.Type, nestedArguments);
            var condition = useNullGuard ? BuildAllNullCondition(matchedParameters) : null;
            var expression = condition is null
                ? newInstance
                : new TernaryConditionalExpression(condition, Default, newInstance);
            argument = new CompatibilityArgument(expression, matchedParameters);
            visitedTypes.Remove(constructorParameter.Type);
            return true;
        }

        /// <summary>
        /// Resolves one nested constructor parameter against the old overload signature.
        /// Inputs are the old method, optional parent property, nested parameter, and recursion stack; output is the rebuilt nested argument.
        /// Used by <see cref="TryBuildCompatibilityArgument"/> while reconstructing flattened nested model instances.
        /// </summary>
        private static bool TryGetNestedCompatibilityArgument(
            MethodProvider method,
            PropertyProvider? parentProperty,
            string? parentName,
            ParameterProvider nestedParameter,
            List<CSharpType> visitedTypes,
            IReadOnlySet<string> unavailableDirectParameterNames,
            [NotNullWhen(true)] out CompatibilityArgument? argument)
        {
            // Prefer the flattened combined name (for example, parent + child) when available so it wins over unrelated
            // top-level parameters with the same child name.
            if (parentProperty is not null && nestedParameter.Property is not null)
            {
                var combinedName = PropertyHelpers.GetCombinedPropertyName(nestedParameter.Property, parentProperty).ToVariableName();
                if (TryGetMethodParameter(method, combinedName, nestedParameter.Type, out var combinedParameter))
                {
                    argument = new CompatibilityArgument(BuildParameterArgument(combinedParameter, nestedParameter.Type), [combinedParameter]);
                    return true;
                }
            }

            // Fall back to contextual old names before the nested parameter's own name. Some old overloads preserved
            // collision-avoiding names that are not identical to the current combined name, such as
            // namePropertiesProgressName for a nested progress.name leaf.
            if (parentName is not null
                && nestedParameter.Property is not null
                && TryGetContextualMethodParameter(method, parentName, nestedParameter, out var contextualParameter))
            {
                argument = new CompatibilityArgument(BuildParameterArgument(contextualParameter, nestedParameter.Type), [contextualParameter]);
                return true;
            }

            // Fall back to the nested parameter's own name when it is not already consumed by an original non-default
            // constructor argument or exposed as a current top-level constructor parameter. Reusing such a parameter is
            // ambiguous because it likely belongs to that original slot.
            if (TryGetMethodParameter(method, nestedParameter.Name, nestedParameter.Type, out var directParameter)
                && !unavailableDirectParameterNames.Contains(directParameter.Name))
            {
                argument = new CompatibilityArgument(BuildParameterArgument(directParameter, nestedParameter.Type), [directParameter]);
                return true;
            }

            return TryBuildModelCompatibilityArgument(method, nestedParameter, visitedTypes, unavailableDirectParameterNames, useNullGuard: false, out argument);
        }

        /// <summary>
        /// Finds an old overload parameter by name and compatible type.
        /// Inputs are the old method, expected parameter name, and expected type; output is the matching parameter.
        /// Used whenever direct or nested compatibility repair needs to reuse an existing old overload argument.
        /// </summary>
        private static bool TryGetMethodParameter(MethodProvider method, string name, CSharpType expectedType, [NotNullWhen(true)] out ParameterProvider? parameter)
        {
            parameter = method.Signature.Parameters.SingleOrDefault(p =>
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)
                && AreCompatibleParameterTypes(p.Type, expectedType));
            return parameter is not null;
        }

        private static bool TryGetContextualMethodParameter(MethodProvider method, string parentName, ParameterProvider nestedParameter, [NotNullWhen(true)] out ParameterProvider? parameter)
        {
            var matches = method.Signature.Parameters.Where(p =>
                !string.Equals(p.Name, nestedParameter.Name, StringComparison.OrdinalIgnoreCase)
                && p.Name.Contains(parentName, StringComparison.OrdinalIgnoreCase)
                && p.Name.EndsWith(nestedParameter.Name, StringComparison.OrdinalIgnoreCase)
                && AreCompatibleParameterTypes(p.Type, nestedParameter.Type)).ToArray();
            parameter = matches.Length == 1 ? matches[0] : null;
            return parameter is not null;
        }

        /// <summary>
        /// Determines whether an old parameter can be used for a current constructor parameter.
        /// Inputs are old and expected types; output is whether direct assignment or helper conversion can make them compatible.
        /// Used by <see cref="TryGetMethodParameter"/> to allow nullable/value and list-interface shape differences.
        /// </summary>
        private static bool AreCompatibleParameterTypes(CSharpType parameterType, CSharpType expectedType)
            => parameterType.AreNamesEqual(expectedType)
            || parameterType.InputType.AreNamesEqual(expectedType.InputType)
            || AreCompatibleListTypes(parameterType, expectedType)
            || AreCompatibleDictionaryTypes(parameterType, expectedType);

        /// <summary>
        /// Determines whether two list-like types have compatible element types.
        /// Inputs are old and expected list types; output is whether their element type names match.
        /// Used when old overloads expose <c>IEnumerable&lt;T&gt;</c> but current constructors need another list interface.
        /// </summary>
        private static bool AreCompatibleListTypes(CSharpType parameterType, CSharpType expectedType)
            => parameterType.IsList
            && expectedType.IsList
            && parameterType.Arguments.Count == expectedType.Arguments.Count
            && parameterType.Arguments.Zip(expectedType.Arguments).All(pair => pair.First.AreNamesEqual(pair.Second));

        private static bool AreCompatibleDictionaryTypes(CSharpType parameterType, CSharpType expectedType)
            => parameterType.IsDictionary
            && expectedType.IsDictionary
            && parameterType.Arguments.Count == expectedType.Arguments.Count
            && parameterType.Arguments.Zip(expectedType.Arguments).All(pair => pair.First.AreNamesEqual(pair.Second));

        /// <summary>
        /// Converts an old overload parameter into an expression suitable for a current constructor parameter.
        /// Inputs are the matched old parameter and expected type; output is the expression to pass to generated code.
        /// Used after name/type matching to handle list materialization and nullable value-type unwrapping.
        /// </summary>
        private static ValueExpression BuildParameterArgument(ParameterProvider parameter, CSharpType expectedType)
        {
            if (AreCompatibleListTypes(parameter.Type, expectedType))
            {
                return parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList();
            }

            if (AreCompatibleDictionaryTypes(parameter.Type, expectedType))
            {
                var dictionaryType = ManagementClientGenerator.Instance.TypeFactory.DictionaryInitializationType.MakeGenericType(expectedType.Arguments);
                var nullCoalescedDictionary = parameter.NullCoalesce(New.Instance(dictionaryType));
                return parameter.Type.AreNamesEqual(expectedType)
                    ? nullCoalescedDictionary
                    : New.Instance(dictionaryType, nullCoalescedDictionary);
            }

            if (parameter.Type.IsValueType && parameter.Type.IsNullable && expectedType.IsValueType && !expectedType.IsNullable)
            {
                return parameter.Invoke(nameof(Nullable<int>.GetValueOrDefault));
            }

            return parameter;
        }

        /// <summary>
        /// Builds the guard that preserves old "all flattened inputs are null" behavior.
        /// Input is the set of old parameters consumed by a reconstructed nested model; output is the combined null check.
        /// Used for top-level nested model reconstruction to emit <c>allNull ? default : new Nested(...)</c>.
        /// </summary>
        private static ScopedApi<bool>? BuildAllNullCondition(IEnumerable<ParameterProvider> parameters)
        {
            ScopedApi<bool>? result = null;
            foreach (var parameter in parameters)
            {
                if (parameter.Type.IsValueType && !parameter.Type.IsNullable)
                {
                    continue;
                }

                result = result is null
                    ? parameter.Is(Null)
                    : result.And(parameter.Is(Null));
            }
            return result;
        }

        /// <summary>
        /// Returns true when an expression renders as a C# default literal/expression.
        /// Input is a generated value expression; output is whether it is eligible for replacement.
        /// Used by <see cref="TryUpdateNewInstanceArguments"/> so only previously defaulted constructor slots are repaired.
        /// </summary>
        private static bool IsDefaultExpression(ValueExpression expression)
        {
            return expression is KeywordExpression { Keyword: "default" };
        }

        /// <summary>
        /// Resolves a generated model provider from a C# type.
        /// Input is a constructor parameter type; output is the corresponding model provider when the type is a generated model.
        /// Used by direct-constructor repair to recursively reconstruct nested flattened model arguments.
        /// </summary>
        private static bool TryGetModelProvider(CSharpType type, [NotNullWhen(true)] out ModelProvider? modelProvider)
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(type, out var typeProvider) && typeProvider is ModelProvider model)
            {
                modelProvider = model;
                return true;
            }
            modelProvider = null;
            return false;
        }

        private record CompatibilityArgument(ValueExpression Argument, IReadOnlyList<ParameterProvider> MatchedParameters);
    }
}
